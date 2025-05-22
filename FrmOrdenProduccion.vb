Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web
Imports DevComponents.DotNetBar.Controls

Public Class FrmOrdenProduccion
    Private BDComando As New SqlCommand
    Private BDReader As SqlDataReader
    Private NuevosAcuses As Boolean = False

    Private Sub FrmOrdenProduccion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando.Connection = ConectaBD.BDConexion
        If TxtOP.Text = "" Then
            MessageBox.Show("Error al cargar la información de la OP, contactar a sistemas.", "Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Me.Close()
        Else
            ConsultarOP()
        End If
    End Sub

    Private Sub ConsultarOP()
        DGMateriales.Rows.Clear()

        BDComando.Parameters.Clear()

        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT OPA.No_OP,PI.No_Pedido,OPA.Cve_Maquilador,OPA.Nom_Maquilador,PI.Cve_Cliente,PI.Nom_Cliente,PIT.Cve_Prenda,PIT.DescripcionPrenda,CONVERT(NVARCHAR(MAX),P.Descripcion) as Descripcion FROM OP_ASIGNACION OPA,PEDIDO_INTERNO_TALLAS PIT,PEDIDO_INTERNO PI,Prenda P WHERE OPA.Empresa = " + ConectaBD.Cve_Empresa.ToString + " AND OPA.No_OP = " + TxtOP.Text + " AND PIT.Empresa = OPA.Empresa AND PIT.No_OP = OPA.No_OP AND PI.Empresa = PIT.Empresa AND PI.No_Pedido = PIT.No_Pedido AND P.CVE_PRENDA = PIT.CVE_PRENDA GROUP BY OPA.No_OP,PI.No_Pedido,OPA.Cve_Maquilador,OPA.Nom_Maquilador,PI.Cve_Cliente,PI.Nom_Cliente,PIT.Cve_Prenda,PIT.DescripcionPrenda,CONVERT(NVARCHAR(MAX),P.Descripcion)"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                TxtNoPedido.Text = BDReader("No_Pedido")
                TxtMaquilador.Text = BDReader("Nom_Maquilador") + " (" + BDReader("Cve_Maquilador").ToString + ")"
                TxtCliente.Text = BDReader("Nom_Cliente") + " " + BDReader("Cve_Cliente").ToString
                TxtDescripcionPrenda.Text = BDReader("Cve_Prenda").ToString + " " + BDReader("DescripcionPrenda")
                TxtDescripcionPrendaDetalle.Text = BDReader("Descripcion")
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar los datos generales de la Orden de Producción, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
        BDComando.CommandText = "SP_OP_CONSULTA_ACUSES_RECIBO_MATERIAL"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = Val(TxtOP.Text)

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Dim DiccionarioMateriales As New Dictionary(Of String, Int32)
                Dim Fila As Integer = 1
                While BDReader.Read
                    Dim LlaveDiccionario As String = BDReader("Cve_Material").ToString & "|" & BDReader("DescripcionMaterial").ToString
                    If DiccionarioMateriales.ContainsKey(LlaveDiccionario) Then
                        DGMateriales.Rows.Add(BDReader("No_OP"), BDReader("TipoMaterial"), "", "", BDReader("No_OrdenCompra"), BDReader("Partida"), BDReader("No_Parcialidad"), BDReader("CantidadRemision"))
                        If IsDBNull(BDReader("RutaAcuse")) = False Then
                            If BDReader("RutaAcuse") <> "" Then
                                DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("Acuse") = New DataGridViewTextBoxCell()
                                DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("Acuse").Value = "Si"
                                DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("RutaTemporal").Value = BDReader("RutaAcuse")
                            Else
                                DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("Acuse").Value = "..."
                            End If
                        Else
                            DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("Acuse").Value = "..."
                        End If
                    Else
                        DGMateriales.Rows.Add(BDReader("No_OP"), BDReader("TipoMaterial"), BDReader("Cve_Material"), BDReader("DescripcionMaterial"), "", "", "", BDReader("Consumo"), BDReader("CantidadRemisionada"), BDReader("CantidadEnviada"), BDReader("Saldo"))
                        DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("Acuse") = New DataGridViewTextBoxCell()
                        DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("Acuse").Value = ""
                        DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("FechaFirmaAcuse") = New DataGridViewTextBoxCell()
                        DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("FechaFirmaAcuse").Value = ""
                        DGMateriales.Rows.Add(BDReader("No_OP"), BDReader("TipoMaterial"), "", "", BDReader("No_OrdenCompra"), BDReader("Partida"), BDReader("No_Parcialidad"), BDReader("CantidadRemision"))
                        If IsDBNull(BDReader("No_Remision")) = False Then
                            DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("No_RemisionSistema").Value = BDReader("No_Remision")
                        End If
                        If IsDBNull(BDReader("RutaAcuse")) = False Then
                            If BDReader("RutaAcuse") <> "" Then
                                DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("Acuse") = New DataGridViewTextBoxCell()
                                DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("Acuse").Value = "Si"
                                DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("RutaTemporal").Value = BDReader("RutaAcuse")
                            Else
                                DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("Acuse").Value = "..."
                            End If
                        Else
                            DGMateriales.Rows(DGMateriales.Rows.Count - 1).Cells("Acuse").Value = "..."
                        End If
                        DiccionarioMateriales.Add(LlaveDiccionario, Fila)
                    End If
                End While
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

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_RECUPERA_OP_LOGOS"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        BDComando.Parameters("@NO_OP").Value = Val(TxtOP.Text)
        'BDComando.CommandText = "SELECT PL.CVE_PRENDA,PL.CVE_LOGOTIPO FROM PRENDA_LOGOTIPO PL,PEDIDO_INTERNO_TALLAS PIT WHERE PIT.EMPRESA = " & ConectaBD.Cve_Empresa & " AND PIT.NO_OP = " & DGVProgramaProduccion.CurrentRow.Cells("OP").Value & " AND PIT.CVE_PRENDA = PL.CVE_PRENDA GROUP BY PL.CVE_PRENDA,PL.CVE_LOGOTIPO"
        BDComando.Connection.Open()

        Try
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    If BDReader.HasRows = True Then
                        While BDReader.Read
                            If Logotipo1.ImageLocation = Nothing Then
                                Logotipo1.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                    Logotipo1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                    Logotipo1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                    Logotipo1.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                End If
                                Logotipo1.Visible = True
                            ElseIf Logotipo2.ImageLocation = Nothing Then
                                Logotipo2.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                    Logotipo2.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                    Logotipo2.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                    Logotipo2.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                End If
                                Logotipo2.Visible = True
                            ElseIf Logotipo3.ImageLocation = Nothing Then
                                Logotipo3.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                    Logotipo3.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                    Logotipo3.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                    Logotipo3.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                End If
                                Logotipo3.Visible = True
                            ElseIf Logotipo4.ImageLocation = Nothing Then
                                Logotipo4.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                    Logotipo4.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                    Logotipo4.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                    Logotipo4.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                End If
                                Logotipo4.Visible = True
                            ElseIf Logotipo5.ImageLocation = Nothing Then
                                Logotipo5.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                    Logotipo5.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                    Logotipo5.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                    Logotipo5.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                End If
                                Logotipo5.Visible = True
                            ElseIf Logotipo6.ImageLocation = Nothing Then
                                Logotipo6.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                    Logotipo6.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                    Logotipo6.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                    Logotipo6.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                End If
                                Logotipo6.Visible = True
                            ElseIf Logotipo7.ImageLocation = Nothing Then
                                Logotipo7.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                    Logotipo7.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                    Logotipo7.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                    Logotipo7.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                End If
                                Logotipo7.Visible = True
                            ElseIf Logotipo8.ImageLocation = Nothing Then
                                Logotipo8.AccessibleDescription = BDReader("CVE_LOGOTIPO")
                                If My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg") = True Then
                                    Logotipo8.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg") = True Then
                                    Logotipo8.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".jpeg"
                                ElseIf My.Computer.FileSystem.FileExists(ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp") = True Then
                                    Logotipo8.ImageLocation = ConectaBD.DACOrcelec & "\Logotipos\" & Val(BDReader("CVE_LOGOTIPO")) & ".bmp"
                                End If
                                Logotipo8.Visible = True
                            End If
                        End While
                    End If
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar los Logos de la Descripción de Prenda, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de Orden de Producción", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
    End Sub

    Private Sub DGMateriales_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGMateriales.CellContentClick
        If TypeOf DGMateriales.Rows(e.RowIndex).Cells(e.ColumnIndex) Is DataGridViewButtonCell Then
            If DGMateriales.Rows(e.RowIndex).Cells("RutaTemporal").Value = "" Then
                ' La celda es un botón
                ' Crea una nueva instancia de OpenFileDialog
                Dim ArchivoAcuse As New OpenFileDialog()
                ' Establece el filtro para limitar los tipos de archivos que se pueden seleccionar
                ArchivoAcuse.Filter = "PDF Files|*.pdf"
                ' Muestra la ventana de diálogo y verifica si el usuario hizo clic en el botón Abrir
                If ArchivoAcuse.ShowDialog() = DialogResult.OK Then
                    ' Obtiene la ruta del archivo seleccionado
                    Dim RutaDeArchivo As String = ArchivoAcuse.FileName
                    ' Crea una instancia de FileInfo para obtener la información del archivo
                    Dim Archivo As New FileInfo(RutaDeArchivo)

                    ' Obtén el tamaño en MB.
                    Dim TamanoArchivoMB As Double = Archivo.Length / 1024 / 1024

                    ' Comprueba si el tamaño del archivo supera el límite.
                    If TamanoArchivoMB > 1 Then
                        MessageBox.Show("El archivo excede el tamaño máximo permitido de 1 MB.", "Acuse de recibo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    Else
                        DGMateriales.Rows(e.RowIndex).Cells("Acuse") = New DataGridViewTextBoxCell()
                        DGMateriales.Rows(e.RowIndex).Cells("Acuse").Value = ArchivoAcuse.SafeFileName
                        DGMateriales.Rows(e.RowIndex).Cells("RutaTemporal").Value = RutaDeArchivo
                        NuevosAcuses = True
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub BtnGuardarAcuses_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardarAcuses.Click
        If NuevosAcuses = True Then
            Dim Consecutivo As Integer
            Dim No_RemisionSistemaAnterior As Long
            Dim Cve_Material As String = ""
            Dim DescripcionMaterial As String = ""
            For Fila As Integer = 0 To DGMateriales.Rows.Count - 1
                If DGMateriales.Rows(Fila).Cells("Cve_Material").Value <> "" And DGMateriales.Rows(Fila).Cells("DescripcionMaterial").Value <> "" Then
                    Cve_Material = DGMateriales.Rows(Fila).Cells("Cve_Material").Value
                    DescripcionMaterial = DGMateriales.Rows(Fila).Cells("DescripcionMaterial").Value
                End If
                If DGMateriales.Rows(Fila).Cells("DescripcionMaterial").Value = "" And DGMateriales.Rows(Fila).Cells("Acuse").Value <> "Si" And DGMateriales.Rows(Fila).Cells("Acuse").Value <> "..." Then
                    If File.Exists(DGMateriales.Rows(Fila).Cells("RutaTemporal").Value.ToString()) = False Then
                        ' El archivo de origen no existe, maneja este caso aquí
                        MessageBox.Show("El archivo de origen " + DGMateriales.Rows(Fila).Cells("Acuse").Value + ", no existe o se movio, verificar.", "Acuse de entrega de material", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        DGMateriales.Rows(Fila).Cells("Acuse") = New DataGridViewButtonCell()
                        DGMateriales.Rows(Fila).Cells("Acuse").Value = "..."
                        DGMateriales.Rows(Fila).Cells("No_RemisionFisica").Value = ""
                        DGMateriales.Rows(Fila).Cells("CantidadRemision").Value = ""
                    Else
                        Dim MensajesDeValidacion As String = ""
                        If DGMateriales.Rows(Fila).Cells("No_RemisionFisica").Value Is Nothing AndAlso IsDBNull(DGMateriales.Rows(Fila).Cells("No_RemisionFisica").Value) Then
                            MensajesDeValidacion += "-Falta escribir el número de remisión física." & vbCrLf
                        End If
                        If DGMateriales.Rows(Fila).Cells("CantidadRemision").Value Is Nothing AndAlso IsDBNull(DGMateriales.Rows(Fila).Cells("CantidadRemision").Value) Then
                            MensajesDeValidacion += "-Falta escribir la cantidad de la remisión física." & vbCrLf
                        Else
                            If IsNumeric(DGMateriales.Rows(Fila).Cells("CantidadRemision").Value) = False Then
                                MensajesDeValidacion += "-La cantidad de la remisión física debe ser un número." & vbCrLf
                            End If
                        End If
                        If DGMateriales.Rows(Fila).Cells("FechaFirmaAcuse").Value Is Nothing AndAlso IsDBNull(DGMateriales.Rows(Fila).Cells("FechaFirmaAcuse").Value) Then
                            MensajesDeValidacion += "-Falta escribir la Fecha de firma de Acuse de la remisión física." & vbCrLf
                        Else
                            If IsDate(DGMateriales.Rows(Fila).Cells("FechaFirmaAcuse").Value) = False Then
                                MensajesDeValidacion += "-La fecha de firma de acuse de la remisión física debe ser una fecha con el formato dd/mm/yyyy." & vbCrLf
                            End If
                        End If
                        If MensajesDeValidacion <> "" Then
                            MessageBox.Show("Favor de validar algunos datos del acuse del material " & DescripcionMaterial & ", Orden de compra " & DGMateriales.Rows(Fila).Cells("No_OrdenCompra").Value & " y No. de Parcialidad " & DGMateriales.Rows(Fila).Cells("OC_No_parcialidad").Value & "." & vbCrLf & MensajesDeValidacion, "Acuses de recibo de material", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                            Exit Sub
                        End If
                        'GUARDA EL REGISTRO DE ACUSE DE RECIBO.
                        BDComando.Parameters.Clear()

                        BDComando.CommandType = CommandType.StoredProcedure
                        BDComando.CommandText = "ALTA_OP_ACUSES_RECIBOMATERIAL"
                        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_ORDENCOMPRA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@PARTIDA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_PARCIALIDAD", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@CONSECUTIVO", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@REMISIONSISTEMAANTERIOR", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@TIPOMATERIAL", SqlDbType.NVarChar)
                        BDComando.Parameters.Add("@CVE_MATERIAL", SqlDbType.NVarChar)
                        BDComando.Parameters.Add("@DESCRIPCIONMATERIAL", SqlDbType.NVarChar)
                        BDComando.Parameters.Add("@NO_REMISIONSISTEMA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@NO_REMISIONFISICA", SqlDbType.NVarChar)
                        BDComando.Parameters.Add("@CANTIDADREMISIONFISICA", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@FECHAFIRMAACUSE", SqlDbType.Date)
                        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)


                        BDComando.Parameters("@EMPRESA").Value = Val(ConectaBD.Cve_Empresa)
                        BDComando.Parameters("@NO_OP").Value = DGMateriales.Rows(Fila).Cells("No_OP").Value
                        BDComando.Parameters("@NO_ORDENCOMPRA").Value = DGMateriales.Rows(Fila).Cells("No_OrdenCompra").Value
                        BDComando.Parameters("@PARTIDA").Value = DGMateriales.Rows(Fila).Cells("OC_Partida").Value
                        BDComando.Parameters("@NO_PARCIALIDAD").Value = DGMateriales.Rows(Fila).Cells("OC_No_Parcialidad").Value
                        BDComando.Parameters("@CONSECUTIVO").Direction = ParameterDirection.Output
                        BDComando.Parameters("@REMISIONSISTEMAANTERIOR").Direction = ParameterDirection.Output
                        BDComando.Parameters("@TIPOMATERIAL").Value = DGMateriales.Rows(Fila).Cells("TipoMaterial").Value
                        BDComando.Parameters("@CVE_MATERIAL").Value = Cve_Material
                        BDComando.Parameters("@DESCRIPCIONMATERIAL").Value = DescripcionMaterial
                        If DGMateriales.Rows(Fila).Cells("No_RemisionSistema").Value IsNot Nothing AndAlso Not IsDBNull(DGMateriales.Rows(Fila).Cells("No_RemisionSistema").Value) Then
                            BDComando.Parameters("@NO_REMISIONSISTEMA").Value = DGMateriales.Rows(Fila).Cells("No_RemisionSistema").Value
                        Else
                            BDComando.Parameters("@NO_REMISIONSISTEMA").Value = DBNull.Value
                        End If
                        BDComando.Parameters("@NO_REMISIONFISICA").Value = DGMateriales.Rows(Fila).Cells("No_RemisionFisica").Value
                        BDComando.Parameters("@CANTIDADREMISIONFISICA").Value = Val(DGMateriales.Rows(Fila).Cells("CantidadRemision").Value)
                        BDComando.Parameters("@FECHAFIRMAACUSE").Value = Date.Parse(DGMateriales.Rows(Fila).Cells("FechaFirmaAcuse").Value)
                        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name


                        Try
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            BDReader.Close()
                            No_RemisionSistemaAnterior = BDComando.Parameters("@REMISIONSISTEMAANTERIOR").Value
                            Consecutivo = BDComando.Parameters("@CONSECUTIVO").Value
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

                        ' Crea un nombre de archivo único basado en No_OP
                        Dim NuevoNombreArchivo As String = DGMateriales.Rows(Fila).Cells("No_OP").Value.ToString() & "-" & DGMateriales.Rows(Fila).Cells("No_OrdenCompra").Value.ToString() & "-" & DGMateriales.Rows(Fila).Cells("OC_Partida").Value.ToString() & "-" & DGMateriales.Rows(Fila).Cells("OC_No_Parcialidad").Value.ToString() & "-" & Consecutivo & ".pdf"
                        ' Crea una ruta completa al archivo en el directorio de almacenamiento de acuses
                        Dim RutaDestino As String = Path.Combine(ConectaBD.DACOrcelec + "AcusesRemisiones\", NuevoNombreArchivo)

                        ' Comprueba si el archivo de destino ya existe
                        ' Guarda el archivo en el servidor
                        File.Copy(DGMateriales.Rows(Fila).Cells("RutaTemporal").Value.ToString(), RutaDestino, True)
                        DGMateriales.Rows(Fila).Cells("Acuse") = New DataGridViewTextBoxCell()
                        DGMateriales.Rows(Fila).Cells("Acuse").Value = "Si"
                        DGMateriales.Rows(Fila).Cells("No_RemisionFisica").Value = ""
                        DGMateriales.Rows(Fila).Cells("CantidadRemision").Value = ""
                        DGMateriales.Rows(Fila).Cells("RutaTemporal").Value = RutaDestino
                        DGMateriales.Rows(Fila).Cells("FechaFirmaAcuse").Value = ""

                        If No_RemisionSistemaAnterior <> 0 Then
                            NuevoNombreArchivo = No_RemisionSistemaAnterior.ToString.PadLeft(8, "0"c) + ".pdf"
                            RutaDestino = Path.Combine("\\192.168.1.9\COMANDO\PRODUCC\SCANDOC\REMISIONES\", NuevoNombreArchivo)
                            File.Copy(DGMateriales.Rows(Fila).Cells("RutaTemporal").Value.ToString(), RutaDestino, True)
                        End If
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub DGMateriales_EditingControlShowing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGMateriales.EditingControlShowing
        AddHandler e.Control.KeyPress, AddressOf DGMaterialesTextBox_KeyPress
    End Sub

    Private Sub DGMaterialesTextBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Dim dataGridViewTextBox As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
        Dim rowIndex As Integer = DGMateriales.CurrentCell.RowIndex
        Dim currentCellValue As Object = DGMateriales.Rows(rowIndex).Cells(DGMateriales.CurrentCell.ColumnIndex).Value

        If DGMateriales.Rows(rowIndex).Cells("DescripcionMaterial").Value Is Nothing OrElse DGMateriales.Rows(rowIndex).Cells("DescripcionMaterial").Value.ToString() = "" And DGMateriales.Rows(rowIndex).Cells("Acuse").Value <> "Si" And DGMateriales.Rows(rowIndex).Cells("Acuse").Value <> "..." Then
            If (DGMateriales.CurrentCell.ColumnIndex >= 0 And DGMateriales.CurrentCell.ColumnIndex <= 11) Then
                e.Handled = True
                dataGridViewTextBox.Text = If(currentCellValue IsNot Nothing, currentCellValue.ToString(), String.Empty)
            End If
        Else
            e.Handled = True
            dataGridViewTextBox.Text = If(currentCellValue IsNot Nothing, currentCellValue.ToString(), String.Empty)
        End If
        ''Dim rowIndex As Integer = DGMateriales.CurrentCell.RowIndex
        ''Dim currentCellValue As Object = DGMateriales.Rows(rowIndex).Cells(DGMateriales.CurrentCell.ColumnIndex).Value

        ''If (DGMateriales.Rows(rowIndex).Cells("DescripcionMaterial").Value Is Nothing OrElse DGMateriales.Rows(rowIndex).Cells("DescripcionMaterial").Value.ToString() = "") And DGMateriales.Rows(rowIndex).Cells("Acuse").Value <> "Si" And DGMateriales.Rows(rowIndex).Cells("Acuse").Value <> "..." Then
        ''    If (DGMateriales.CurrentCell.ColumnIndex >= 0 And DGMateriales.CurrentCell.ColumnIndex <= 11) Then
        ''        ' Verifica el tipo de columna
        ''        If TypeOf DGMateriales.CurrentCell Is DataGridViewTextBoxCell Then
        ''            Dim dataGridViewTextBox As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
        ''            e.Handled = True
        ''            dataGridViewTextBox.Text = If(currentCellValue IsNot Nothing, currentCellValue.ToString(), String.Empty)
        ''        ElseIf TypeOf DGMateriales.Columns(DGMateriales.CurrentCell.ColumnIndex) Is DataGridViewMaskedTextBoxAdvColumn Then
        ''            ' Trata la columna DataGridViewMaskedTextBoxAdvColumn aquí
        ''            Dim dataGridViewMaskedBox As MaskedTextBoxAdv = DirectCast(sender, MaskedTextBoxAdv)
        ''            e.Handled = True
        ''            If currentCellValue IsNot Nothing Then
        ''                ' Convertir la fecha a un formato válido para la máscara
        ''                dataGridViewMaskedBox.Text = DirectCast(currentCellValue, Date).ToString("MM/dd/yyyy")
        ''            Else
        ''                dataGridViewMaskedBox.Text = String.Empty
        ''            End If
        ''        End If
        ''    End If
        ''Else
        ''    ' Verifica el tipo de la columna actual
        ''    If DGMateriales.CurrentCell.ColumnIndex = 15 Then
        ''        If (DGMateriales.Rows(rowIndex).Cells("DescripcionMaterial").Value Is Nothing Or DGMateriales.Rows(rowIndex).Cells("DescripcionMaterial").Value.ToString() = "") Then
        ''            'Entra aqui cuando esta posicionado en una celda donde puede ser posible que se pueda escribir una fecha.
        ''            If DGMateriales.Rows(rowIndex).Cells("Acuse").Value = "Si" Or DGMateriales.Rows(rowIndex).Cells("Acuse").Value = "..." Then
        ''                'Entra aquí cuando no se ha seleccionado un acuse para subir o cuando ya se tiene un acuse asociado, entonces no se permite la edición.
        ''                Dim dataGridViewMaskedBox As DataGridViewMaskedTextBoxAdvEditingControl = DirectCast(DGMateriales.EditingControl, DataGridViewMaskedTextBoxAdvEditingControl)
        ''                e.Handled = True
        ''                If currentCellValue IsNot Nothing Then
        ''                    ' Convertir la fecha a un formato válido para la máscara
        ''                    If IsDate(currentCellValue) Then
        ''                        dataGridViewMaskedBox.Text = DirectCast(currentCellValue, Date).ToString("MM/dd/yyyy")
        ''                    Else
        ''                        dataGridViewMaskedBox.Text = Nothing
        ''                        DGMateriales.EndEdit()
        ''                    End If
        ''                Else
        ''                    dataGridViewMaskedBox.Text = Nothing
        ''                    DGMateriales.EndEdit()
        ''                End If
        ''            End If
        ''        ElseIf DGMateriales.Rows(rowIndex).Cells("Acuse").Value <> "Si" And DGMateriales.Rows(rowIndex).Cells("Acuse").Value <> "..." Then
        ''            Dim dataGridViewTextBox As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
        ''            e.Handled = True
        ''            dataGridViewTextBox.Text = If(currentCellValue IsNot Nothing, currentCellValue.ToString(), String.Empty)
        ''        End If
        ''    Else
        ''        Dim dataGridViewTextBox As DataGridViewTextBoxEditingControl = DirectCast(sender, DataGridViewTextBoxEditingControl)
        ''        e.Handled = True
        ''        dataGridViewTextBox.Text = If(currentCellValue IsNot Nothing, currentCellValue.ToString(), String.Empty)
        ''    End If
        ''End If
        
    End Sub

    Private Sub DGMateriales_CellContentDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGMateriales.CellContentDoubleClick
        If DGMateriales.Rows(e.RowIndex).Cells("Acuse").Value = "Si" Then
            ' Obtiene la ruta del archivo desde la columna "RutaTemporal"
            Dim rutaArchivo As String = DGMateriales.Rows(e.RowIndex).Cells("RutaTemporal").Value.ToString()

            ' Abre el archivo PDF con el programa predeterminado del sistema operativo
            Try
                Process.Start(rutaArchivo)
            Catch ex As Exception
                ' Maneja cualquier excepción que pueda ocurrir
                MessageBox.Show("No se pudo abrir el archivo. Mensaje de error: " & ex.Message)
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
End Class
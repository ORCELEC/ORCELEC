Imports System.Data
Imports System.Data.SqlClient
Imports MailKit.Net.Smtp
Imports MimeKit

Public Class Validaciones
    Dim AbrirBD As New ConectaBD
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private BDInspectores As New DataTable
    Private BDAdapter As SqlDataAdapter

    Private Sub Validaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AbrirBD.ObtenerDirectorioPassword()
        AbrirBD.ConectarBD()
        BDAdapter = New SqlDataAdapter("", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        EjecutarValidacionesPorEmpresa(1, "UNIFORMES EL TREN SA DE CV")
        Application.ExitThread()
    End Sub

    Private Sub EjecutarValidacionesPorEmpresa(ByVal Empresa As Int32, ByVal NombreEmpresa As String)
        Dim ErroresGenerales As String = ""
        Dim MensajeMaterialesCompletos As String = ""
        Dim MensajeOPMas3DiasSinActualizacion As String = ""
        Dim MensajeOCIncompletasFechasPromesa As String = ""
        Dim FaltaOCConfirmacionFechasPromesa As Boolean = False
        Dim FaltaPedidosSinOC As Boolean = False
        Dim MensajeOCConfirmacionFechasPromesa As String = ""
        Dim MensajePedidosSinCompra As String = ""
        Dim MensajeOCConfirmacionFechasPromesaMas7Dias As String = ""
        Dim MensajeOPConfirmacionMoldeListo As String = ""
        Dim MensajeOPConfirmacionMaterialesListos As String = ""
        Dim MensajeOpConfirmacionMaquiladorListo As String = ""
        Dim MensajeOpConSinTablaMedidas As String = ""
        Dim MensajeAvanceOP As String = ""
        Dim MensajeAvanceOPInspector As String = ""
        Dim SMTP As String = "smtp.ionos.mx"
        Dim Usuario As String = "orcelec@uet.mx"
        Dim Contraseña As String = "M0r15qu3t@$pru3b@$897@"
        Dim CorreoOrigen As String = "orcelec@uet.mx"
        Dim Puerto As Integer = 465

        'VALIDAR QUE LOS MATERIALES SE HAYAN RECIBIDO POR COMPLETO PARA PODER INICIAR LA OP
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure

        BDComando.CommandText = "VALIDACIONES_OP_MATERIALESENTREGADOSCOMPLETOS"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = Empresa

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                MensajeMaterialesCompletos += "<table border=1>" 'ABRE TABLA
                MensajeMaterialesCompletos += "<tr>" 'ABRE FILA
                MensajeMaterialesCompletos += "<th width=50px>No. OP</th>" 'ENCABEZADO DE COLUMNA
                MensajeMaterialesCompletos += "<th width=200px>Cve. de Tela o Habilitación</th>" 'ENCABEZADO DE COLUMNA
                MensajeMaterialesCompletos += "<th width=500px>Descripción de Tela o Habilitación</th>" 'ENCABEZADO DE COLUMNA
                MensajeMaterialesCompletos += "<th width=500px>Cantidad pendiente de acuse</th>" 'ENCABEZADO DE COLUMNA
                MensajeMaterialesCompletos += "<th width=200px>Maquilador</th>" 'ENCABEZADO DE COLUMNA
                MensajeMaterialesCompletos += "<th width=200px>Cliente</th>" 'ENCABEZADO DE COLUMNA
                MensajeMaterialesCompletos += "<th width=200px>Prenda</th>" 'ENCABEZADO DE COLUMNA
                MensajeMaterialesCompletos += "<th width=50px>Cantidad de Prendas de la OP</th>" 'ENCABEZADO DE COLUMNA
                MensajeMaterialesCompletos += "<th width=100px>Fecha para iniciar</th>" 'ENCABEZADO DE COLUMNA
                MensajeMaterialesCompletos += "</tr>" 'CIERRA FILA
                While BDReader.Read
                    'If BDReader("SIN_ENTREGAR") > 0 Then
                    MensajeMaterialesCompletos += "<tr>" 'ABRE FILA
                    If (IsDBNull(BDReader("No_OPSistemaAnterior")) = True) Then
                        MensajeMaterialesCompletos += "<td>" & BDReader("NO_OP") & "</td>" 'DATO COLUMNA
                    Else
                        MensajeMaterialesCompletos += "<td>" & BDReader("No_OPSistemaAnterior") & "-" & BDReader("No_OP") & "</td>" 'DATO COLUMNA
                    End If
                    MensajeMaterialesCompletos += "<td>" & BDReader("CVE_MATERIAL") & "</td>" 'DATO COLUMNA
                    MensajeMaterialesCompletos += "<td>" & BDReader("DESCRIPCIONMATERIAL") & "</td>" 'DATO COLUMNA
                    MensajeMaterialesCompletos += "<td>" & BDReader("DIFERENCIASINACUSE") & "</td>" 'DATO COLUMNA
                    MensajeMaterialesCompletos += "<td>" & BDReader("NOM_MAQUILADOR") & "</td>" 'DATO COLUMNA
                    MensajeMaterialesCompletos += "<td>" & BDReader("CLIENTE") & "</td>" 'DATO COLUMNA
                    MensajeMaterialesCompletos += "<td>" & BDReader("DESCRIPCIONPRENDA") & "</td>" 'DATO COLUMNA
                    MensajeMaterialesCompletos += "<td>" & BDReader("CANTIDADPRENDASOP") & "</td>" 'DATO COLUMNA
                    MensajeMaterialesCompletos += "<td>" & Format(BDReader("FECHAPARAASIGNAR"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                    MensajeMaterialesCompletos += "</tr>" 'CIERRA FILA
                    'MensajeMaterialesCompletos += "-No. OP: " & BDReader("NO_OP") & ", Fecha de inicio: " & Format(BDReader("FECHAPARAASIGNAR"), "dd/MM/yyyy") & "." & vbCrLf
                    'End If
                End While
                MensajeMaterialesCompletos += "</table>" 'CIERRA TABLA
            End If
        Catch ex As Exception
            ErroresGenerales += "<br>Error al ejecutar la Validación de Materiales Recibidos Completos por el Maquilador, Referencia:<br> " & ex.Message & ".<br>"
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        '-----------------------------------------------------------------------------------------------------------------------------------


        'VALIDAR QUE LAS OP EN PROCESO, TENGAN MÁS DE TRES DÍAS SIN ACTUALIZACIÓN
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure

        BDComando.CommandText = "VALIDACIONES_ACTUALIZACIONES_AVANCEDEOP"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = Empresa

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                MensajeOPMas3DiasSinActualizacion += "<table border=1>" 'ABRE TABLA
                MensajeOPMas3DiasSinActualizacion += "<tr>" 'ABRE FILA
                MensajeOPMas3DiasSinActualizacion += "<th width=50px>No. OP</th>" 'ENCABEZADO DE COLUMNA
                MensajeOPMas3DiasSinActualizacion += "<th width=200px>Maquilador</th>" 'ENCABEZADO DE COLUMNA
                MensajeOPMas3DiasSinActualizacion += "<th width=200px>Cliente</th>" 'ENCABEZADO DE COLUMNA
                MensajeOPMas3DiasSinActualizacion += "<th width=200px>Prenda</th>" 'ENCABEZADO DE COLUMNA
                MensajeOPMas3DiasSinActualizacion += "<th width=50px>Cantidad</th>" 'ENCABEZADO DE COLUMNA
                MensajeOPMas3DiasSinActualizacion += "<th width=100px>Fecha de última actualización</th>" 'ENCABEZADO DE COLUMNA
                MensajeOPMas3DiasSinActualizacion += "</tr>" 'CIERRA FILA
                While BDReader.Read
                    MensajeOPMas3DiasSinActualizacion += "<tr>" 'ABRE FILA
                    If (IsDBNull(BDReader("No_OPSistemaAnterior")) = True) Then
                        MensajeOPMas3DiasSinActualizacion += "<td>" & BDReader("NO_OP") & "</td>" 'DATO COLUMNA
                    Else
                        MensajeOPMas3DiasSinActualizacion += "<td>" & BDReader("No_OPSistemaAnterior") & "-" & BDReader("No_OP") & "</td>" 'DATO COLUMNA
                    End If
                    MensajeOPMas3DiasSinActualizacion += "<td>" & BDReader("NOM_MAQUILADOR") & "</td>" 'DATO COLUMNA
                    MensajeOPMas3DiasSinActualizacion += "<td>" & BDReader("CLIENTE") & "</td>" 'DATO COLUMNA
                    MensajeOPMas3DiasSinActualizacion += "<td>" & BDReader("PRENDA") & "</td>" 'DATO COLUMNA
                    MensajeOPMas3DiasSinActualizacion += "<td>" & BDReader("CANTIDAD") & "</td>" 'DATO COLUMNA
                    MensajeOPMas3DiasSinActualizacion += "<td>" & Format(BDReader("FECHAULTIMAACTUALIZACION"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                    MensajeOPMas3DiasSinActualizacion += "</tr>" 'CIERRA FILA
                    'MensajeOPMas3DiasSinActualizacion += "-No. OP: " & BDReader("NO_OP") & ", Fecha de ultima actualización: " & Format(BDReader("FECHAULTIMAACTUALIZACION"), "dd/MM/yyyy") & "." & vbCrLf
                End While
                MensajeOPMas3DiasSinActualizacion += "</table>" 'CIERRA TABLA
            End If
        Catch ex As Exception
            ErroresGenerales += "Error al ejecutar la Validación de OP con 3 o más días sin Actualización. Referencia: " & ex.Message & "." & vbCrLf
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        '-----------------------------------------------------------------------------------------------------------------------------------


        'VALIDAR QUE LAS OC AUTORIZADAS TENGAN CAPTURADO LAS FECHAS PROMESA DEL MATERIAL COMPLETO COMPRADO
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure

        BDComando.CommandText = "VALIDACIONES_FECHAS_PROMESA_ENTREGA"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = Empresa

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                MensajeOCIncompletasFechasPromesa += "<table border=1>" 'ABRE TABLA
                MensajeOCIncompletasFechasPromesa += "<tr>" 'ABRE FILA
                MensajeOCIncompletasFechasPromesa += "<th width=50px>No. OC</th>" 'ENCABEZADO DE COLUMNA
                MensajeOCIncompletasFechasPromesa += "<th width=100px>Fecha OC</th>" 'ENCABEZADO DE COLUMNA
                MensajeOCIncompletasFechasPromesa += "<th width=30px>Partida</th>" 'ENCABEZADO DE COLUMNA
                MensajeOCIncompletasFechasPromesa += "<th width=50px>Cve. Material</th>" 'ENCABEZADO DE COLUMNA
                MensajeOCIncompletasFechasPromesa += "<th width=200px>Descripción</th>" 'ENCABEZADO DE COLUMNA
                MensajeOCIncompletasFechasPromesa += "<th width=100px>Cantidad</th>" 'ENCABEZADO DE COLUMNA
                MensajeOCIncompletasFechasPromesa += "<th width=50px>Unidad</th>" 'ENCABEZADO DE COLUMNA
                MensajeOCIncompletasFechasPromesa += "</tr>" 'CIERRA FILA
                While BDReader.Read
                    MensajeOCIncompletasFechasPromesa += "<tr>" 'ABRE FILA
                    MensajeOCIncompletasFechasPromesa += "<td>" & BDReader("NO_OrdenCompra") & "</td>" 'DATO COLUMNA
                    MensajeOCIncompletasFechasPromesa += "<td>" & Format(BDReader("FechaOC"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                    MensajeOCIncompletasFechasPromesa += "<td>" & BDReader("Partida") & "</td>" 'DATO COLUMNA
                    MensajeOCIncompletasFechasPromesa += "<td>" & BDReader("CVE_MATERIAL") & "</td>" 'DATO COLUMNA
                    MensajeOCIncompletasFechasPromesa += "<td>" & BDReader("DescripcionMaterial") & "</td>" 'DATO COLUMNA
                    MensajeOCIncompletasFechasPromesa += "<td>" & BDReader("CantidadComprada") & "</td>" 'DATO COLUMNA
                    MensajeOCIncompletasFechasPromesa += "<td>" & BDReader("Unidad") & "</td>" 'DATO COLUMNA
                    MensajeOCIncompletasFechasPromesa += "</tr>" 'CIERRA FILA
                    'MensajeOCIncompletasFechasPromesa += "-No. Orden de Compra: " & BDReader("No_OrdenCompra") & ", Partida: " & BDReader("Partida") & ", Descripción: " & BDReader("DescripcionMaterial") & "." & vbCrLf
                End While
                MensajeOCIncompletasFechasPromesa += "</table>" 'CIERRA TABLA
            End If
        Catch ex As Exception
            ErroresGenerales += "Error al ejecutar la Validación de Ordenes de Compra que estas incompletas en Fechas Promesa de Entrega. Referencia: " & ex.Message & "." & vbCrLf
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        '-----------------------------------------------------------------------------------------------------------------------------------


        'VALIDAR QUE LAS OC AUTORIZADAS Y NO RECIBIDAS, QUE LAS FECHAS PROMESA DE ENTREGA ESTEN CONFIRMADAS
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure

        BDComando.CommandText = "VALIDACIONES_CONFIRMACION_FECHAS_PROMESA"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = Empresa

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            MensajeOCConfirmacionFechasPromesa += "<table border=1>" 'ABRE TABLA
            MensajeOCConfirmacionFechasPromesa += "<tr>" 'ABRE FILA
            MensajeOCConfirmacionFechasPromesa += "<th width=50px>No. OC</th>" 'ENCABEZADO DE COLUMNA
            MensajeOCConfirmacionFechasPromesa += "<th width=100px>Fecha OC</th>" 'ENCABEZADO DE COLUMNA
            MensajeOCConfirmacionFechasPromesa += "<th width=30px>Partida</th>" 'ENCABEZADO DE COLUMNA
            MensajeOCConfirmacionFechasPromesa += "<th width=50px>Cve. Material</th>" 'ENCABEZADO DE COLUMNA
            MensajeOCConfirmacionFechasPromesa += "<th width=200px>Descripción</th>" 'ENCABEZADO DE COLUMNA
            MensajeOCConfirmacionFechasPromesa += "<th width=50px>No. Parcialidad</th>" 'ENCABEZADO DE COLUMNA
            MensajeOCConfirmacionFechasPromesa += "<th width=100px>Fecha Promesa</th>" 'ENCABEZADO DE COLUMNA
            MensajeOCConfirmacionFechasPromesa += "<th width=100px>Cantidad Promesa</th>" 'ENCABEZADO DE COLUMNA
            MensajeOCConfirmacionFechasPromesa += "<th width=50px>Unidad</th>" 'ENCABEZADO DE COLUMNA
            MensajeOCConfirmacionFechasPromesa += "</tr>" 'CIERRA FILA

            If BDReader.HasRows = True Then
                While BDReader.Read
                    If BDReader("DiferenciaDias") >= 7 Then
                        FaltaOCConfirmacionFechasPromesa = True
                        MensajeOCConfirmacionFechasPromesa += "<tr>" 'ABRE FILA
                        MensajeOCConfirmacionFechasPromesa += "<td>" & BDReader("NO_OrdenCompra") & "</td>" 'DATO COLUMNA
                        MensajeOCConfirmacionFechasPromesa += "<td>" & Format(BDReader("FechaOC"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                        MensajeOCConfirmacionFechasPromesa += "<td>" & BDReader("Partida") & "</td>" 'DATO COLUMNA
                        MensajeOCConfirmacionFechasPromesa += "<td>" & BDReader("CVE_MATERIAL") & "</td>" 'DATO COLUMNA
                        MensajeOCConfirmacionFechasPromesa += "<td>" & BDReader("DescripcionMaterial") & "</td>" 'DATO COLUMNA
                        MensajeOCConfirmacionFechasPromesa += "<td>" & BDReader("No_Parcialidad") & "</td>" 'DATO COLUMNA
                        MensajeOCConfirmacionFechasPromesa += "<td>" & Format(BDReader("FechaPromesa"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                        MensajeOCConfirmacionFechasPromesa += "<td>" & BDReader("CantidadPromesa") & "</td>" 'DATO COLUMNA
                        MensajeOCConfirmacionFechasPromesa += "<td>" & BDReader("Unidad") & "</td>" 'DATO COLUMNA
                        MensajeOCConfirmacionFechasPromesa += "</tr>" 'CIERRA FILA
                        'MensajeOCConfirmacionFechasPromesa += "-No. Orden de Compra: " & BDReader("No_OrdenCompra") & ", Partida: " & BDReader("Partida") & ", Descripción: " & BDReader("DescripcionMaterial") & ", No. Parcialidad: " & BDReader("No_Parcialidad") & ", Fecha Promesa de Entrega: " & Format(BDReader("FechaPromesa"), "dd/MM/yyyy") & "." & vbCrLf
                        'Else
                        '    MensajeOCConfirmacionFechasPromesaMas7Dias += "-No. Orden de Compra: " & BDReader("No_OrdenCompra") & ", Partida: " & BDReader("Partida") & ", Descripción: " & BDReader("DescripcionMaterial") & ", No. Parcialidad: " & BDReader("No_Parcialidad") & ", Fecha Promesa de Entrega: " & Format(BDReader("FechaPromesa"), "dd/MM/yyyy") & "." & vbCrLf
                    End If
                End While
                MensajeOCConfirmacionFechasPromesa += "</table>" 'CIERRA TABLA
            End If
        Catch ex As Exception
            ErroresGenerales += "Error al ejecutar la Validación de Confirmación de Fechas Promesa de Entrega de Ordenes de Compra . Referencia: " & ex.Message & "." & vbCrLf
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        '-----------------------------------------------------------------------------------------------------------------------------------


        'VALIDAR PEDIDOS AUTORIZADOS SIN OC
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure

        BDComando.CommandText = "VALIDACIONES_PEDIDO_SIN_ORDEN_COMPRA"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = Empresa

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            MensajePedidosSinCompra += "<table border=1>" 'ABRE TABLA
            MensajePedidosSinCompra += "<tr>" 'ABRE FILA
            MensajePedidosSinCompra += "<th width=80px>No. Pedido</th>" 'ENCABEZADO DE COLUMNA
            MensajePedidosSinCompra += "<th width=150px>Cliente</th>" 'ENCABEZADO DE COLUMNA
            MensajePedidosSinCompra += "<th width=50px>Cve. de Tela O Habilitacíón</th>" 'ENCABEZADO DE COLUMNA
            MensajePedidosSinCompra += "<th width=250px>Descripcón de Tela o Habilitación</th>" 'ENCABEZADO DE COLUMNA
            MensajePedidosSinCompra += "<th width=80px>Existencia</th>" 'ENCABEZADO DE COLUMNA
            MensajePedidosSinCompra += "<th width=80px>Cantidad Pendiente de Compra</th>" 'ENCABEZADO DE COLUMNA
            MensajePedidosSinCompra += "<th width=50px>Unidad</th>" 'ENCABEZADO DE COLUMNA
            MensajePedidosSinCompra += "<th width=100px>Observaciones</th>" 'ENCABEZADO DE COLUMNA
            MensajePedidosSinCompra += "<th width=80px>Días desde Solicitud</th>" 'ENCABEZADO DE COLUMNA
            MensajePedidosSinCompra += "</tr>" 'CIERRA FILA

            If BDReader.HasRows = True Then
                While BDReader.Read
                    FaltaPedidosSinOC = True
                    MensajePedidosSinCompra += "<tr>" 'ABRE FILA
                    MensajePedidosSinCompra += "<td>" & BDReader("No_Pedido") & "</td>" 'DATO COLUMNA
                    MensajePedidosSinCompra += "<td>" & BDReader("Nom_Cliente") & "</td>" 'DATO COLUMNA
                    MensajePedidosSinCompra += "<td>" & BDReader("Cve_Material") & "</td>" 'DATO COLUMNA
                    MensajePedidosSinCompra += "<td>" & BDReader("DescripcionMaterial") & "</td>" 'DATO COLUMNA
                    MensajePedidosSinCompra += "<td>" & BDReader("Stock") & "</td>" 'DATO COLUMNA
                    MensajePedidosSinCompra += "<td>" & BDReader("Cantidad") & "</td>" 'DATO COLUMNA
                    MensajePedidosSinCompra += "<td>" & BDReader("Unidad") & "</td>" 'DATO COLUMNA
                    MensajePedidosSinCompra += "<td>" & BDReader("ObservacionOP") & "</td>" 'DATO COLUMNA
                    MensajePedidosSinCompra += "<td>" & BDReader("DiasDesdeSolicitud") & "</td>" 'DATO COLUMNA
                    MensajePedidosSinCompra += "</tr>" 'CIERRA FILA
                    'MensajeOCConfirmacionFechasPromesa += "-No. Orden de Compra: " & BDReader("No_OrdenCompra") & ", Partida: " & BDReader("Partida") & ", Descripción: " & BDReader("DescripcionMaterial") & ", No. Parcialidad: " & BDReader("No_Parcialidad") & ", Fecha Promesa de Entrega: " & Format(BDReader("FechaPromesa"), "dd/MM/yyyy") & "." & vbCrLf
                    'Else
                    '    MensajeOCConfirmacionFechasPromesaMas7Dias += "-No. Orden de Compra: " & BDReader("No_OrdenCompra") & ", Partida: " & BDReader("Partida") & ", Descripción: " & BDReader("DescripcionMaterial") & ", No. Parcialidad: " & BDReader("No_Parcialidad") & ", Fecha Promesa de Entrega: " & Format(BDReader("FechaPromesa"), "dd/MM/yyyy") & "." & vbCrLf
                End While
                MensajePedidosSinCompra += "</table>" 'CIERRA TABLA
            End If
        Catch ex As Exception
            ErroresGenerales += "Error al ejecutar la Validación de Pedidos Autorizados sin Orden de Compra . Referencia: " & ex.Message & "." & vbCrLf
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        '-----------------------------------------------------------------------------------------------------------------------------------



        ''VALIDAR QUE SE HAYAN CONFIRMADOS LOS ELEMENTOS BÁSICOS (MOLDES, MATERIALES, MAQUILADOR), PARA PODER INICIAR 3 DÍAS ANTES DE
        ''LA FECHA DE INICIO
        'BDComando.Parameters.Clear()
        'BDComando.CommandType = CommandType.StoredProcedure

        'BDComando.CommandText = "VALIDACIONES_OP_ASIGNACION_CONFIRMACION_BASICOS"
        'BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

        'BDComando.Parameters("@EMPRESA").Value = Empresa

        'Try
        '    BDComando.Connection.Open()
        '    BDReader = BDComando.ExecuteReader
        '    If BDReader.HasRows = True Then
        '        MensajeOPConfirmacionMoldeListo += "<table>" 'ABRE TABLA
        '        MensajeOPConfirmacionMoldeListo += "<tr>" 'ABRE FILA
        '        MensajeOPConfirmacionMoldeListo += "<th width=50px>No. OP</th>" 'ENCABEZADO DE COLUMNA
        '        MensajeOPConfirmacionMoldeListo += "<th width=200px>Maquilador</th>" 'ENCABEZADO DE COLUMNA
        '        MensajeOPConfirmacionMoldeListo += "<th width=200px>Cliente</th>" 'ENCABEZADO DE COLUMNA
        '        MensajeOPConfirmacionMoldeListo += "<th width=200px>Prenda</th>" 'ENCABEZADO DE COLUMNA
        '        MensajeOPConfirmacionMoldeListo += "<th width=50px>Molde</th>" 'ENCABEZADO DE COLUMNA
        '        MensajeOPConfirmacionMoldeListo += "<th width=50px>Materiales</th>" 'ENCABEZADO DE COLUMNA
        '        MensajeOPConfirmacionMoldeListo += "<th width=50px>Maquilador</th>" 'ENCABEZADO DE COLUMNA
        '        MensajeOPConfirmacionMoldeListo += "<th width=100px>Cantidad Promesa</th>" 'ENCABEZADO DE COLUMNA
        '        MensajeOPConfirmacionMoldeListo += "<th width=50px>Unidad</th>" 'ENCABEZADO DE COLUMNA
        '        MensajeOPConfirmacionMoldeListo += "</tr>" 'CIERRA FILA
        '        While BDReader.Read
        '            If BDReader("MoldeListo") = False Then
        '                MensajeOPConfirmacionMoldeListo += "-No. OP: " & BDReader("No_OP") & ", Maquilador: " & BDReader("NOM_MAQUILADOR") & ", Fecha de Inicio Programada: " & BDReader("FECHAINICIO") & IIf(BDReader("DIFERENCIADIASATRASO") > 0, ", Días de Atraso: " & BDReader("DIFERENCIADIASATRASO"), "") & "." & vbCrLf
        '            ElseIf BDReader("MaterialesListos") = False Then
        '                MensajeOPConfirmacionMaterialesListos += "-No. OP: " & BDReader("No_OP") & ", Maquilador: " & BDReader("NOM_MAQUILADOR") & ", Fecha de Inicio Programada: " & BDReader("FECHAINICIO") & IIf(BDReader("DIFERENCIADIASATRASO") > 0, ", Días de Atraso: " & BDReader("DIFERENCIADIASATRASO"), "") & "." & vbCrLf
        '            ElseIf BDReader("MaquiladorListo") = False Then
        '                MensajeOPConfirmacionMaterialesListos += "-No. OP: " & BDReader("No_OP") & ", Maquilador: " & BDReader("NOM_MAQUILADOR") & ", Fecha de Inicio Programada: " & BDReader("FECHAINICIO") & IIf(BDReader("DIFERENCIADIASATRASO") > 0, ", Días de Atraso: " & BDReader("DIFERENCIADIASATRASO"), "") & "." & vbCrLf
        '            End If
        '        End While
        '    End If
        '    BDReader.Close()
        '    BDComando.Connection.Close()
        'Catch ex As Exception
        '    BDReader.Close()
        '    BDComando.Connection.Close()
        '    ErroresGenerales += "Error al ejecutar la Validación de Confirmación de Moldes, Materiales y Maquilador Listos para iniciar la OP. Referencia: " & ex.Message & "." & vbCrLf
        'End Try

        '-----------------------------------------------------------------------------------------------------------------------------------

        'AVANCE DE ORDEN DE PRODUCCIÓN
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure

        BDComando.CommandText = "SP_OP_VISTAAVANCE"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@FINALIZADAS", SqlDbType.Bit)
        BDComando.Parameters.Add("@CVE_USUCALIDADINICIAL", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_USUCALIDADFINAL", SqlDbType.BigInt)

        BDComando.Parameters("@EMPRESA").Value = Empresa
        BDComando.Parameters("@FINALIZADAS").Value = False
        BDComando.Parameters("@CVE_USUCALIDADINICIAL").Value = 1
        BDComando.Parameters("@CVE_USUCALIDADFINAL").Value = 9999


        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                MensajeAvanceOP += "<table border=1>" 'ABRE TABLA
                MensajeAvanceOP += "<tr>" 'ABRE FILA
                MensajeAvanceOP += "<th width=200px>Maquilador</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=50px>OP</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=200px>Prenda</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=100px>Fecha de OP</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=100px>Fecha Vencimiento OP</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=200px>Cliente</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=100px>Materiales Recibidos Completos</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=100px>Cantidad OP</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=100px>% de Avance de hace una semana</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=100px>% de Avance de Ayer</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=100px>% de Avance Actual</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=100px>Fecha Entrega Programada</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "<th width=200px>Observaciones</th>" 'ENCABEZADO DE COLUMNA
                MensajeAvanceOP += "</tr>" 'CIERRA FILA
                While BDReader.Read
                    MensajeAvanceOP += "<tr>" 'ABRE FILA
                    MensajeAvanceOP += "<td>" & BDReader("ENCARGADO") & "</td>" 'DATO COLUMNA
                    If (IsDBNull(BDReader("No_OPSistemaAnterior")) = True) Then
                        MensajeAvanceOP += "<td>" & BDReader("NO_OP") & "</td>" 'DATO COLUMNA
                    Else
                        MensajeAvanceOP += "<td>" & BDReader("No_OPSistemaAnterior") & "-" & BDReader("No_OP") & "</td>" 'DATO COLUMNA
                    End If
                    MensajeAvanceOP += "<td>" & BDReader("DESCRIPCIONPRENDA") & "</td>" 'DATO COLUMNA
                    MensajeAvanceOP += "<td>" & Format(BDReader("FECHACREACION"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                    MensajeAvanceOP += "<td>" & Format(BDReader("FECHAVENCIMIENTO"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA 
                    MensajeAvanceOP += "<td>" & BDReader("NOM_CLIENTE") & "</td>" 'DATO COLUMNA
                    If (BDReader("FaltaRecibir") > 0) Then
                        MensajeAvanceOP += "<td>" & "NO" & "</td>" 'DATO COLUMNA
                    Else
                        If (IsDBNull(BDReader("FECHACONFIRMACIONMATERIALES")) = True) Then
                            MensajeAvanceOP += "<td>" & "SI" & "</td>" 'DATO COLUMNA
                        Else
                            MensajeAvanceOP += "<td>" & Format(BDReader("FECHACONFIRMACIONMATERIALES"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA 
                        End If
                    End If

                    MensajeAvanceOP += "<td>" & BDReader("CANT_OP") & "</td>" 'DATO COLUMNA
                    MensajeAvanceOP += "<td>" & BDReader("PORCENTAJEAVANCEOPMENOSUNASEMANA") & "</td>" 'DATO COLUMNA
                    MensajeAvanceOP += "<td>" & BDReader("PORCENTAJEAVANCEOPMENOSUNDIA") & "</td>" 'DATO COLUMNA
                    MensajeAvanceOP += "<td>" & BDReader("PORCENTAJEAVANCEOP") & "</td>" 'DATO COLUMNA
                    MensajeAvanceOP += "<td>" & Format(BDReader("FECHAVENCIMIENTO"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA 
                    MensajeAvanceOP += "<td>" & BDReader("OBSERVACIONES") & "</td>" 'DATO COLUMNA
                    MensajeAvanceOP += "</tr>" 'CIERRA FILA
                    'MensajeMaterialesCompletos += "-No. OP: " & BDReader("NO_OP") & ", Fecha de inicio: " & Format(BDReader("FECHAPARAASIGNAR"), "dd/MM/yyyy") & "." & vbCrLf
                End While
                MensajeAvanceOP += "</table>" 'CIERRA TABLA
            End If
        Catch ex As Exception
            ErroresGenerales += "<br>Error al ejecutar la consulta de Avance de OP, Referencia:<br> " & ex.Message & ".<br>"
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        ''-----------------------------------------------------------------------------------------------------------------------------------

        Dim TextoCorreoVeronica As String = ""
        Dim TextoCorreoArturo As String = ""
        Dim TextoCorreoAdolfo As String = ""
        Dim TextoCorreoDaniel As String = ""
        Dim TextoCorreoLicenciado As String = ""
        Dim TextoCorreoToño As String = ""
        Dim TextoCorreoInspector As String = ""

        ''PREPARAR TEXTO DEL CORREO PARA MANDAR ALERTA DE PEDIDOS SIN OC
        'ESTE CORREO VA DIRIGIDO A DANIEL PRADO
        If MensajePedidosSinCompra <> "" And FaltaPedidosSinOC = True Then
            TextoCorreoDaniel += "<h1>Pedidos Autorizados Sin Orden de Compra</h1><br>" & MensajePedidosSinCompra & "<br><br>"
        End If

        ''PREPARAR TEXTO DEL CORREO PARA MANDAR ALERTA DE OC AUTORIZADAS Y NO RECIBIDAS, QUE LAS FECHAS PROMESA DE ENTREGA ESTEN SIN CONFIRMADAS
        'ESTE CORREO VA DIRIGIDO A DANIEL PRADO
        If MensajeOCConfirmacionFechasPromesa <> "" And FaltaOCConfirmacionFechasPromesa = True Then
            TextoCorreoDaniel += "<h1>Ordenes de Compra, sin confirmación de Fechas Promesa de Entrega.</h1><br>" & MensajeOCConfirmacionFechasPromesa & "<br><br>"
        End If

        ''PREPARAR TEXTO DEL CORREO PARA MANDAR ALERTA DE OP CON MATERIALES SIN CONFIRMAR QUE ESTAN RECIBIDOS COMPLETOS EN EL TALLER DE MAQUILA
        'ESTE CORREO VA DIRIGIDO A ARTURO BUSQUEÑO Y TOÑO MURAD
        If MensajeMaterialesCompletos <> "" Then
            TextoCorreoVeronica += "<h1>Ordenes de Producción Sin Acuse de Entrega al Maquilador.</h1><br>" & MensajeMaterialesCompletos & "<br><br>"
            TextoCorreoToño += "<h1>Ordenes de Producción Sin Acuse de Entrega al Maquilador.</h1><br>" & MensajeMaterialesCompletos & "<br><br>"
            TextoCorreoLicenciado += "<h1>Ordenes de Producción Sin Acuse de Entrega al Maquilador.</h1><br>" & MensajeMaterialesCompletos & "<br><br>"
            TextoCorreoDaniel += "<h1>Ordenes de Producción Sin Acuse de Entrega al Maquilador.</h1><br>" & MensajeMaterialesCompletos & "<br><br>"
        End If

        ''PREPARAR TEXTO DEL CORREO PARA MANDAR ALERTA DE OP EN PROCESO, TENGAN MÁS DE DOS DÍAS SIN ACTUALIZACIÓN
        'ESTE CORREO VA DIRIGIDO A VERÓNICA CASTILLO, ARTURO, ADOLFO Y TOÑO MURAD
        If MensajeOPMas3DiasSinActualizacion <> "" Then
            TextoCorreoVeronica += "<h1>Ordenes de Producción con 3 días o más sin actualización.</h1><br>" & MensajeOPMas3DiasSinActualizacion & "<br><br>"
            'TextoCorreoArturo += "<h1>Las siguientes Ordenes de Producción, tienen 3 días o más sin actualización.</h1><br>" & MensajeOPMas3DiasSinActualizacion & "<br><br>"
            'TextoCorreoAdolfo += "<h1>Las siguientes Ordenes de Producción, tienen 3 días o más sin actualización.</h1><br>" & MensajeOPMas3DiasSinActualizacion & "<br><br>"
            TextoCorreoToño += "<h1>Ordenes de Producción con 3 días o más sin actualización.</h1><br>" & MensajeOPMas3DiasSinActualizacion & "<br><br>"
            TextoCorreoLicenciado += "<h1>Ordenes de Producción con 3 días o más sin actualización.</h1><br>" & MensajeOPMas3DiasSinActualizacion & "<br><br>"
        End If

        ''PREPARAR TEXTO DEL CORREO PARA MANDAR ALERTA DE OC AUTORIZADAS QUE FALTEN DE CAPTURAR LAS FECHAS PROMESA DEL MATERIAL COMPLETO COMPRADO
        'ESTE CORREO VA DIRIGIDO A TOÑO MURAD Y AL LICENCIADO
        If MensajeOCIncompletasFechasPromesa <> "" Then
            TextoCorreoToño += "<h1>Ordenes de Compra sin Fechas Promesa de Entrega.</h1><br>" & MensajeOCIncompletasFechasPromesa & "<br><br>"
            'TextoCorreoLicenciado += "<h1>Las siguientes Ordenes de Compra, tienen pendiente capturar Fechas Promesa de Entrega.</h1><br>" & MensajeOCIncompletasFechasPromesa & "<br><br>"
        End If


        If MensajeAvanceOP <> "" Then
            TextoCorreoLicenciado += "<h1>Avance de Ordenes de Producción</h1><br>" & MensajeAvanceOP & "<br><br>"
        End If

        ''PREPARAR TEXTO DEL CORREO PARA MANDAR ALERTA DE OP QUE ESTEN PENDIENTES DE CONFIRMAR LOS ELEMENTOS BÁSICOS
        '(MOLDES, MATERIALES, MAQUILADOR), 3 DÍAS ANTES DE INICIAR LA OP
        'MOLDES: ESTE CORREO VA DIRIGIDO A ARTURO
        If MensajeOPConfirmacionMoldeListo <> "" Then
            TextoCorreoArturo += "Ordenes de Producción sin confirmación de Moldes Listo." & vbCrLf & vbCrLf & MensajeOPConfirmacionMoldeListo & vbCrLf & vbCrLf
        End If
        'MATERIALES: ESTE CORREO VA DIRIGIDO A DANIEL PRADO
        If MensajeOPConfirmacionMaterialesListos <> "" Then
            TextoCorreoDaniel += "Las siguientes Ordenes de Producción, tienen pendiente confirmación de Materiales Listos." & vbCrLf & vbCrLf & MensajeOPConfirmacionMaterialesListos & vbCrLf & vbCrLf
        End If
        'MAQUILADOR: ESTE CORREO VA DIRIGIDO A VERÓNICA
        If MensajeOpConfirmacionMaquiladorListo <> "" Then
            TextoCorreoVeronica += "Las siguientes Ordenes de Producción, tienen pendiente confirmación de Maquilador Listo." & vbCrLf & vbCrLf & MensajeOpConfirmacionMaquiladorListo & vbCrLf & vbCrLf
        End If

        '-----------------------------------------------------------------------------------------------------------------------------------

        ''-------SE MANDAN CORREOS PREVIAMENTE ARMADOS
        'If TextoCorreoVeronica <> "" Then
        '    'Declaro la variable para enviar el correo
        '    Dim correo As New System.Net.Mail.MailMessage()
        '    correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
        '    correo.IsBodyHtml = True
        '    correo.Subject = "Alertas del Sistema ORCELEC de la Razón Social " & NombreEmpresa
        '    'correo.Headers.Add("X-SES-CONFIGURATION-SET", "ConfigSet")
        '    correo.To.Add("ch@uet.mx") ''ESTE CORREO SE DEBE MANDAR A VERÓNICA CASTILLO, CAMBIAR
        '    'correo.To.Add("vcp@uet.mx") ''ESTE CORREO SE DEBE MANDAR A VERÓNICA CASTILLO, CAMBIAR
        '    'correo.To.Add("amm@uet.mx") ''ESTE CORREO SE DEBE MANDAR A VERÓNICA CASTILLO, CAMBIAR
        '    correo.Body = "<body>" & TextoCorreoVeronica & "</body>"

        '    'Configuracion del servidor
        '    Dim Servidor As New System.Net.Mail.SmtpClient
        '    Servidor.Host = SMTP
        '    Servidor.Port = Puerto
        '    Servidor.EnableSsl = False
        '    Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
        '    Servidor.Send(correo)
        'End If


        'If TextoCorreoArturo <> "" Then
        '    'Declaro la variable para enviar el correo
        '    Dim correo As New System.Net.Mail.MailMessage()
        '    correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
        '    correo.IsBodyHtml = True
        '    correo.Subject = "Alertas del Sistema ORCELEC de la Razón Social " & NombreEmpresa
        '    correo.To.Add("ch@uet.mx") ''ESTE CORREO SE DEBE MANDAR A ARTURO BUSQUEÑO, CAMBIAR
        '    'correo.To.Add("abg@uet.mx") ''ESTE CORREO SE DEBE MANDAR A VERÓNICA CASTILLO, CAMBIAR
        '    'correo.To.Add("amm@uet.mx") ''ESTE CORREO SE DEBE MANDAR A VERÓNICA CASTILLO, CAMBIAR
        '    correo.Body = "<body>" & TextoCorreoArturo & "</body>"

        '    'Configuracion del servidor
        '    Dim Servidor As New System.Net.Mail.SmtpClient
        '    Servidor.Host = SMTP
        '    Servidor.Port = Puerto
        '    Servidor.EnableSsl = False
        '    Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
        '    Servidor.Send(correo)
        'End If


        'If TextoCorreoAdolfo <> "" Then
        '    'Declaro la variable para enviar el correo
        '    Dim correo As New System.Net.Mail.MailMessage()
        '    correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
        '    correo.IsBodyHtml = True
        '    correo.Subject = "Alertas del Sistema ORCELEC de la Razón Social " & NombreEmpresa
        '    correo.To.Add("ch@uet.mx") ''ESTE CORREO SE DEBE MANDAR A ADOLFO HERNÁNDEZ, CAMBIAR
        '    'correo.To.Add("ahv@uet.mx") ''ESTE CORREO SE DEBE MANDAR A ADOLFO HERNÁNDEZ, CAMBIAR
        '    'correo.To.Add("amm@uet.mx") ''ESTE CORREO SE DEBE MANDAR A ADOLFO HERNÁNDEZ, CAMBIAR
        '    correo.Body = "<body>" & TextoCorreoAdolfo & "</body>"

        '    'Configuracion del servidor
        '    Dim Servidor As New System.Net.Mail.SmtpClient
        '    Servidor.Host = SMTP
        '    Servidor.Port = Puerto
        '    Servidor.EnableSsl = False
        '    Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
        '    Servidor.Send(correo)
        'End If


        If TextoCorreoDaniel <> "" Then
            'Declaro la variable para enviar el correo

            'Dim correo As New System.Net.Mail.MailMessage()
            'correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
            'correo.IsBodyHtml = True
            'correo.Subject = "Alertas del Sistema ORCELEC de la Razón Social " & NombreEmpresa
            'correo.To.Add("ch@uet.mx") ''ESTE CORREO SE DEBE MANDAR A DANIEL PRADO, CAMBIAR
            'correo.To.Add("am@uet.mx") ''ESTE CORREO SE DEBE MANDAR A DANIEL PRADO, CAMBIAR
            'correo.To.Add("amm@uet.mx") ''ESTE CORREO SE DEBE MANDAR A DANIEL PRADO, CAMBIAR
            'correo.To.Add("dpa@uet.mx") ''ESTE CORREO SE DEBE MANDAR A DANIEL PRADO, CAMBIAR
            'correo.To.Add("lmc@uet.mx") ''ESTE CORREO SE DEBE MANDAR A DANIEL PRADO, CAMBIAR
            'correo.Body = "<body>" & TextoCorreoDaniel & "</body>"

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
            message.To.Add(New MailboxAddress("", "am@uet.mx"))
            message.To.Add(New MailboxAddress("", "amm@uet.mx"))
            message.To.Add(New MailboxAddress("", "dpa@uet.mx"))
            message.To.Add(New MailboxAddress("", "lmc@uet.mx"))
            message.Subject = "Resumen de Pendientes de Compras del sistema ORCELEC de la Razón Social " & NombreEmpresa

            Dim builder As New BodyBuilder()
            builder.HtmlBody = "<body>" & TextoCorreoDaniel & "</body>"
            message.Body = builder.ToMessageBody()

            Using client As New SmtpClient()
                client.Connect(SMTP, Puerto, MailKit.Security.SecureSocketOptions.SslOnConnect)
                client.Authenticate(Usuario, Contraseña)
                client.Send(message)
                client.Disconnect(True)
            End Using
        End If


        If TextoCorreoLicenciado <> "" Then
            ''Declaro la variable para enviar el correo
            'Dim correo As New System.Net.Mail.MailMessage()
            'correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
            'correo.IsBodyHtml = True
            'correo.Subject = "Alertas del Sistema ORCELEC de la Razón Social " & NombreEmpresa
            'correo.To.Add("ch@uet.mx") ''ESTE CORREO SE DEBE MANDAR AL LIC. ANTONIO MURAD, CAMBIAR
            'correo.To.Add("am@uet.mx") ''ESTE CORREO SE DEBE MANDAR AL LIC. ANTONIO MURAD, CAMBIAR
            'correo.To.Add("amm@uet.mx") ''ESTE CORREO SE DEBE MANDAR A VERÓNICA CASTILLO, CAMBIAR
            'correo.To.Add("vcp@uet.mx") ''ESTE CORREO SE DEBE MANDAR A VERÓNICA CASTILLO, CAMBIAR
            'correo.To.Add("apm@uet.mx") ''ESTE CORREO SE DEBE MANDAR A VERÓNICA CASTILLO, CAMBIAR
            'correo.To.Add("mlg@uet.mx") ''ESTE CORREO SE DEBE MANDAR A VERÓNICA CASTILLO, CAMBIAR
            'correo.Body = "<body>" & TextoCorreoLicenciado & "</body>"

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
            message.To.Add(New MailboxAddress("", "am@uet.mx"))
            message.To.Add(New MailboxAddress("", "amm@uet.mx"))
            message.To.Add(New MailboxAddress("", "vcp@uet.mx"))
            message.To.Add(New MailboxAddress("", "apm@uet.mx"))
            message.To.Add(New MailboxAddress("", "mlg@uet.mx"))
            message.Subject = "Alertas del Sistema ORCELEC de la Razón Social " & NombreEmpresa

            Dim builder As New BodyBuilder()
            builder.HtmlBody = "<body>" & TextoCorreoLicenciado & "</body>"
            message.Body = builder.ToMessageBody()

            Using client As New SmtpClient()
                client.Connect(SMTP, Puerto, MailKit.Security.SecureSocketOptions.SslOnConnect)
                client.Authenticate(Usuario, Contraseña)
                client.Send(message)
                client.Disconnect(True)
            End Using

        End If



        'If TextoCorreoToño <> "" Then
        '    'Declaro la variable para enviar el correo
        '    Dim correo As New System.Net.Mail.MailMessage()
        '    correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
        '    correo.IsBodyHtml = True
        '    correo.Subject = "Alertas del Sistema ORCELEC de la Razón Social " & NombreEmpresa
        '    correo.To.Add("ch@uet.mx") ''ESTE CORREO SE DEBE MANDAR A TOÑO MURAD, CAMBIAR
        '    'correo.To.Add("amm@uet.mx") ''ESTE CORREO SE DEBE MANDAR A TOÑO MURAD, CAMBIAR
        '    correo.Body = "<body>" & TextoCorreoToño & "</body>"

        '    'Configuracion del servidor
        '    Dim Servidor As New System.Net.Mail.SmtpClient
        '    Servidor.Host = SMTP
        '    Servidor.Port = Puerto
        '    Servidor.EnableSsl = False
        '    Servidor.Credentials = New System.Net.NetworkCredential(Usuario, Contraseña)
        '    Servidor.Send(correo)
        'End If

        ''-----------------------------------------------------------------------------------------------------------------------------


        'AVANCE DE ORDEN DE PRODUCCIÓN POR INSPECTOR
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM USUARIOS WHERE PUESTO = 'CALIDAD' AND STATUS = 1"

        Try
            BDAdapter = New SqlDataAdapter(BDComando)
            BDAdapter.Fill(BDInspectores)
            If BDInspectores.Rows.Count > 0 Then
                For Each Fila As DataRow In BDInspectores.Rows
                    TextoCorreoInspector = ""
                    MensajeAvanceOPInspector = ""
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure

                    BDComando.CommandText = "SP_OP_VISTAAVANCE"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@FINALIZADAS", SqlDbType.Bit)
                    BDComando.Parameters.Add("@CVE_USUCALIDADINICIAL", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@CVE_USUCALIDADFINAL", SqlDbType.BigInt)

                    BDComando.Parameters("@EMPRESA").Value = Empresa
                    BDComando.Parameters("@FINALIZADAS").Value = False
                    BDComando.Parameters("@CVE_USUCALIDADINICIAL").Value = Fila.Item("CVE_USU").ToString()
                    BDComando.Parameters("@CVE_USUCALIDADFINAL").Value = Fila.Item("CVE_USU").ToString()

                    BDComando.Connection.Open()
                    BDReader = BDComando.ExecuteReader
                    If BDReader.HasRows = True Then
                        MensajeAvanceOPInspector += "<table border=1>" 'ABRE TABLA
                        MensajeAvanceOPInspector += "<tr>" 'ABRE FILA
                        MensajeAvanceOPInspector += "<th width=200px>Maquilador</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=50px>OP</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=200px>Prenda</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=100px>Fecha de OP</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=100px>Fecha Vencimiento OP</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=200px>Cliente</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=100px>Materiales Recibidos Completos</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=100px>Cantidad OP</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=100px>% de Avance de hace una semana</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=100px>% de Avance de Ayer</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=100px>% de Avance Actual</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=100px>Fecha Entrega Programada</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "<th width=200px>Observaciones</th>" 'ENCABEZADO DE COLUMNA
                        MensajeAvanceOPInspector += "</tr>" 'CIERRA FILA
                        While BDReader.Read
                            MensajeAvanceOPInspector += "<tr>" 'ABRE FILA
                            MensajeAvanceOPInspector += "<td>" & BDReader("ENCARGADO") & "</td>" 'DATO COLUMNA
                            If (IsDBNull(BDReader("No_OPSistemaAnterior")) = True) Then
                                MensajeAvanceOPInspector += "<td>" & BDReader("NO_OP") & "</td>" 'DATO COLUMNA
                            Else
                                MensajeAvanceOPInspector += "<td>" & BDReader("No_OPSistemaAnterior") & "-" & BDReader("No_OP") & "</td>" 'DATO COLUMNA
                            End If
                            MensajeAvanceOPInspector += "<td>" & BDReader("DESCRIPCIONPRENDA") & "</td>" 'DATO COLUMNA
                            MensajeAvanceOPInspector += "<td>" & Format(BDReader("FECHACREACION"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                            MensajeAvanceOPInspector += "<td>" & Format(BDReader("FECHAVENCIMIENTO"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA 
                            MensajeAvanceOPInspector += "<td>" & BDReader("NOM_CLIENTE") & "</td>" 'DATO COLUMNA
                            If (BDReader("FaltaRecibir") > 0) Then
                                MensajeAvanceOPInspector += "<td>" & "NO" & "</td>" 'DATO COLUMNA
                            Else
                                If (IsDBNull(BDReader("FECHACONFIRMACIONMATERIALES")) = True) Then
                                    MensajeAvanceOPInspector += "<td>" & "SI" & "</td>" 'DATO COLUMNA
                                Else
                                    MensajeAvanceOPInspector += "<td>" & Format(BDReader("FECHACONFIRMACIONMATERIALES"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA 
                                End If
                            End If

                            MensajeAvanceOPInspector += "<td>" & BDReader("CANT_OP") & "</td>" 'DATO COLUMNA
                            MensajeAvanceOPInspector += "<td>" & BDReader("PORCENTAJEAVANCEOPMENOSUNASEMANA") & "</td>" 'DATO COLUMNA
                            MensajeAvanceOPInspector += "<td>" & BDReader("PORCENTAJEAVANCEOPMENOSUNDIA") & "</td>" 'DATO COLUMNA
                            MensajeAvanceOPInspector += "<td>" & BDReader("PORCENTAJEAVANCEOP") & "</td>" 'DATO COLUMNA
                            MensajeAvanceOPInspector += "<td>" & Format(BDReader("FECHAVENCIMIENTO"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA 
                            MensajeAvanceOPInspector += "<td>" & BDReader("OBSERVACIONES") & "</td>" 'DATO COLUMNA
                            MensajeAvanceOPInspector += "</tr>" 'CIERRA FILA
                            'MensajeMaterialesCompletos += "-No. OP: " & BDReader("NO_OP") & ", Fecha de inicio: " & Format(BDReader("FECHAPARAASIGNAR"), "dd/MM/yyyy") & "." & vbCrLf
                        End While
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If

                        MensajeAvanceOPInspector += "</table>" 'CIERRA TABLA
                        TextoCorreoInspector += "<h1>Avance de Ordenes de Producción del inspector " & Fila.Item("NOM_USUARIO").ToString() & "</h1><br>" & MensajeAvanceOPInspector & "<br><br>"

                        ''Declaro la variable para enviar el correo
                        'Dim correo As New System.Net.Mail.MailMessage()
                        'correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
                        'correo.IsBodyHtml = True
                        'correo.Subject = "Alertas del Sistema ORCELEC de la Razón Social " & NombreEmpresa
                        'correo.To.Add("ch@uet.mx")
                        ''correo.To.Add("am@uet.mx") 
                        'correo.To.Add("amm@uet.mx")
                        'correo.To.Add("vcp@uet.mx")
                        'correo.To.Add(Fila.Item("EMAIL").ToString()) ''ESTE CORREO SE DEBE MANDAR A CADA INSPECTOR QUE SE ESTA GENERANDO
                        'correo.Body = "<body>" & TextoCorreoInspector & "</body>"

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
                        message.To.Add(New MailboxAddress("", "am@uet.mx"))
                        message.To.Add(New MailboxAddress("", "amm@uet.mx"))
                        message.To.Add(New MailboxAddress("", "vcp@uet.mx"))
                        message.To.Add(New MailboxAddress("", Fila.Item("EMAIL").ToString()))
                        message.Subject = "Avance de Ordenes de Producción del inspector " & Fila.Item("NOM_USUARIO").ToString() & " del Sistema ORCELEC de la Razón Social " & NombreEmpresa

                        Dim builder As New BodyBuilder()
                        builder.HtmlBody = "<body>" & TextoCorreoInspector & "</body>"
                        message.Body = builder.ToMessageBody()

                        Using client As New SmtpClient()
                            client.Connect(SMTP, Puerto, MailKit.Security.SecureSocketOptions.SslOnConnect)
                            client.Authenticate(Usuario, Contraseña)
                            client.Send(message)
                            client.Disconnect(True)
                        End Using
                    Else
                        ' Asegurarse de que el DataReader y la conexión se cierren.
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            ErroresGenerales += "<br>Error al ejecutar la consulta de Avance de OP por inspector, Referencia:<br> " & ex.Message & ".<br>"
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        '-----------------------------------------------------------------------------------------------------------------------------------

        'OP CON O SIN TABLA DE MEDIDAS
        Dim today As DayOfWeek = DateTime.Now.DayOfWeek

        If today = DayOfWeek.Monday Then
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "OBTIENE_OP_CONSIN_TABLAMEDIDA"

            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)

            BDComando.Parameters("@EMPRESA").Value = Empresa

            Try
                TextoCorreoToño = ""
                MensajeOpConSinTablaMedidas = ""
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    MensajeOpConSinTablaMedidas += "<table border=1>" 'ABRE TABLA
                    MensajeOpConSinTablaMedidas += "<tr>" 'ABRE FILA
                    MensajeOpConSinTablaMedidas += "<th width=60px>No. OP sistema anterior</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "<th width=50px>No. OP</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "<th width=50px>Cve. cliente</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "<th width=200px>Cliente</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "<th width=50px>Cve. Prenda</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "<th width=200px>Descripción de prenda</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "<th width=100px>Cant. de prendas</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "<th width=50px>Cve. maquilador</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "<th width=200px>Maquilador</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "<th width=80px>Fecha de inicio</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "<th width=50px>Tiene tabla de medida</th>" 'ENCABEZADO DE COLUMNA
                    MensajeOpConSinTablaMedidas += "</tr>" 'CIERRA FILA
                    While BDReader.Read
                        MensajeOpConSinTablaMedidas += "<tr>" 'ABRE FILA
                        If (IsDBNull(BDReader("NO_OPSISTEMAANTERIOR")) = True) Then
                            MensajeOpConSinTablaMedidas += "<td></td>" 'DATO COLUMNA
                        Else
                            MensajeOpConSinTablaMedidas += "<td>" & BDReader("NO_OPSISTEMAANTERIOR") & "</td>" 'DATO COLUMNA
                        End If
                        MensajeOpConSinTablaMedidas += "<td>" & BDReader("NO_OP") & "</td>" 'DATO COLUMNA
                        MensajeOpConSinTablaMedidas += "<td>" & BDReader("Cve_Cliente") & "</td>" 'DATO COLUMNA
                        MensajeOpConSinTablaMedidas += "<td>" & BDReader("Nom_Cliente") & "</td>" 'DATO COLUMNA
                        MensajeOpConSinTablaMedidas += "<td>" & BDReader("Cve_Prenda") & "</td>" 'DATO COLUMNA
                        MensajeOpConSinTablaMedidas += "<td>" & BDReader("DescripcionPrenda") & "</td>" 'DATO COLUMNA
                        MensajeOpConSinTablaMedidas += "<td>" & BDReader("CANT_PRENDAS") & "</td>" 'DATO COLUMNA
                        MensajeOpConSinTablaMedidas += "<td>" & BDReader("CVE_MAQUILADOR") & "</td>" 'DATO COLUMNA
                        MensajeOpConSinTablaMedidas += "<td>" & BDReader("NOM_MAQUILADOR") & "</td>" 'DATO COLUMNA
                        MensajeOpConSinTablaMedidas += "<td>" & Format(BDReader("FECHAINICIO"), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                        MensajeOpConSinTablaMedidas += "<td>" & BDReader("TIENE_TABLA_MEDIDA") & "</td>" 'DATO COLUMNA
                        MensajeOpConSinTablaMedidas += "</tr>" 'CIERRA FILA
                    End While
                End If
                ' Asegurarse de que el DataReader y la conexión se cierren.
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If

                MensajeOpConSinTablaMedidas += "</table>" 'CIERRA TABLA
                TextoCorreoToño += "<h1>OP con tablas de medida</h1><br>" & MensajeOpConSinTablaMedidas & "<br><br>"

                ''Declaro la variable para enviar el correo
                'Dim correo As New System.Net.Mail.MailMessage()
                'correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
                'correo.IsBodyHtml = True
                'correo.Subject = "OP con tablas de medida de la Razón Social " & NombreEmpresa
                'correo.To.Add("ch@uet.mx")
                'correo.To.Add("amm@uet.mx")
                'correo.Body = "<body>" & TextoCorreoToño & "</body>"

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
                message.To.Add(New MailboxAddress("", "amm@uet.mx"))
                message.Subject = "OP con tablas de medida de la Razón Social " & NombreEmpresa

                Dim builder As New BodyBuilder()
                builder.HtmlBody = "<body>" & TextoCorreoToño & "</body>"
                message.Body = builder.ToMessageBody()

                Using client As New SmtpClient()
                    client.Connect(SMTP, Puerto, MailKit.Security.SecureSocketOptions.SslOnConnect)
                    client.Authenticate(Usuario, Contraseña)
                    client.Send(message)
                    client.Disconnect(True)
                End Using
            Catch ex As Exception
                ErroresGenerales += "<br>Error al ejecutar la consulta de Avance de OP por inspector, Referencia:<br> " & ex.Message & ".<br>"
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

        '-----------------------------------------------------------------------------------------------------------------------------------


        If ErroresGenerales <> "" Then
            'Declaro la variable para enviar el correo
            'Dim correo As New System.Net.Mail.MailMessage()
            'correo.From = New System.Net.Mail.MailAddress(CorreoOrigen, "ORCELEC")
            'correo.IsBodyHtml = False
            'correo.Subject = "Errores de Ejecución Programa de Validaciones ORCELEC"
            'correo.To.Add("ch@uet.mx") ''ESTE CORREO SE DEBE MANDAR A SISTEMAS, CAMBIAR
            ''correo.To.Add("amm@uet.mx") ''ESTE CORREO SE DEBE MANDAR A VERÓNICA CASTILLO, CAMBIAR
            'correo.Body = ErroresGenerales

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
            message.Subject = "Errores de Ejecución del Programa de Validaciones del Sistema ORCELEC de la Razón Social " & NombreEmpresa

            Dim builder As New BodyBuilder()
            builder.HtmlBody = ErroresGenerales
            message.Body = builder.ToMessageBody()

            Using client As New SmtpClient()
                client.Connect(SMTP, Puerto, MailKit.Security.SecureSocketOptions.SslOnConnect)
                client.Authenticate(Usuario, Contraseña)
                client.Send(message)
                client.Disconnect(True)
            End Using
        End If

    End Sub
End Class
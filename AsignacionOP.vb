Imports System.Data
Imports System.Data.SqlClient
Imports System.Net
Imports MimeKit
Imports MailKit.Net.Smtp
Imports MailKit.Security

Public Class AsignacionOP
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader
    Private Coordenadas As Point
    Private CoordenadasDestino As Point
    Private FechaReferencia As Date
    Private Colores(200) As Color
    Private No_OP(200) As Int32
    Private FechaInicio(200) As Date
    Private FechaFinalizacion(200) As Date
    Private Maquilador(200) As Int32
    Private MaquiladorNombre(200) As String
    Private CvePrendaCorreo(200) As String
    Private DescripcionPrendaCorreo(200) As String
    Private CveClienteCorreo(200) As String
    Private NombreClienteCorreo(200) As String
    Private Dias(200) As Int32
    Private CantidadCorreo(200) As Int64
    Dim ConsecColor As Int32 = 0
    Dim ColoresAsignados As Int32 = 0
    Dim FilaOrigen As Int32
    Dim IndexTabSeleccionadoAnterior As Int32 = 0

    Private Sub AsignacionOP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Colores(0) = Color.Aqua
        Colores(1) = Color.Aquamarine
        Colores(2) = Color.Salmon
        Colores(3) = Color.Sienna
        Colores(4) = Color.Beige
        Colores(5) = Color.Silver
        Colores(6) = Color.Turquoise
        Colores(7) = Color.Blue
        Colores(8) = Color.BlueViolet
        Colores(9) = Color.Brown
        Colores(10) = Color.BurlyWood
        Colores(11) = Color.CadetBlue
        Colores(12) = Color.Chartreuse
        Colores(13) = Color.Coral
        Colores(14) = Color.CornflowerBlue
        Colores(15) = Color.Cornsilk
        Colores(16) = Color.Crimson
        Colores(17) = Color.Cyan
        Colores(18) = Color.LemonChiffon
        Colores(19) = Color.LightBlue
        Colores(20) = Color.LightCoral
        Colores(21) = Color.LightCyan
        Colores(22) = Color.LightGoldenrodYellow
        Colores(23) = Color.LightGray
        Colores(24) = Color.LightGreen
        Colores(25) = Color.LightPink
        Colores(26) = Color.LightSalmon
        Colores(27) = Color.LightSeaGreen
        Colores(28) = Color.LightSkyBlue
        Colores(29) = Color.LightSlateGray
        Colores(30) = Color.LightSteelBlue
        Colores(31) = Color.LightYellow
        Colores(32) = Color.Lime
        Colores(33) = Color.LimeGreen
        Colores(34) = Color.Linen
        Colores(35) = Color.OldLace
        Colores(36) = Color.Olive
        Colores(37) = Color.OliveDrab
        Colores(38) = Color.Orange
        Colores(39) = Color.Orchid
        Colores(40) = Color.PaleGoldenrod
        Colores(41) = Color.PaleGreen
        Colores(42) = Color.PaleTurquoise
        Colores(43) = Color.PapayaWhip
        Colores(44) = Color.PeachPuff
        Colores(45) = Color.Peru
        Colores(46) = Color.Pink
        Colores(47) = Color.Plum
        Colores(48) = Color.PowderBlue
        Colores(49) = Color.RosyBrown
        Colores(50) = Color.Aqua
        Colores(51) = Color.Aquamarine
        Colores(52) = Color.Salmon
        Colores(53) = Color.Sienna
        Colores(54) = Color.Beige
        Colores(55) = Color.Silver
        Colores(56) = Color.Turquoise
        Colores(57) = Color.Blue
        Colores(58) = Color.BlueViolet
        Colores(59) = Color.Brown
        Colores(60) = Color.BurlyWood
        Colores(61) = Color.CadetBlue
        Colores(62) = Color.Chartreuse
        Colores(63) = Color.Coral
        Colores(64) = Color.CornflowerBlue
        Colores(65) = Color.Cornsilk
        Colores(66) = Color.Crimson
        Colores(67) = Color.Cyan
        Colores(68) = Color.LemonChiffon
        Colores(69) = Color.LightBlue
        Colores(70) = Color.LightCoral
        Colores(71) = Color.LightCyan
        Colores(72) = Color.LightGoldenrodYellow
        Colores(73) = Color.LightGray
        Colores(74) = Color.LightGreen
        Colores(75) = Color.LightPink
        Colores(76) = Color.LightSalmon
        Colores(77) = Color.LightSeaGreen
        Colores(78) = Color.LightSkyBlue
        Colores(79) = Color.LightSlateGray
        Colores(80) = Color.LightSteelBlue
        Colores(81) = Color.LightYellow
        Colores(82) = Color.Lime
        Colores(83) = Color.LimeGreen
        Colores(84) = Color.Linen
        Colores(85) = Color.OldLace
        Colores(86) = Color.Olive
        Colores(87) = Color.OliveDrab
        Colores(88) = Color.Orange
        Colores(89) = Color.Orchid
        Colores(90) = Color.PaleGoldenrod
        Colores(91) = Color.PaleGreen
        Colores(92) = Color.PaleTurquoise
        Colores(93) = Color.PapayaWhip
        Colores(94) = Color.PeachPuff
        Colores(95) = Color.Peru
        Colores(96) = Color.Pink
        Colores(97) = Color.Plum
        Colores(98) = Color.PowderBlue
        Colores(99) = Color.RosyBrown
        Colores(100) = Color.Aqua
        Colores(101) = Color.Aquamarine
        Colores(102) = Color.Salmon
        Colores(103) = Color.Sienna
        Colores(104) = Color.Beige
        Colores(105) = Color.Silver
        Colores(106) = Color.Turquoise
        Colores(107) = Color.Blue
        Colores(108) = Color.BlueViolet
        Colores(109) = Color.Brown
        Colores(110) = Color.BurlyWood
        Colores(111) = Color.CadetBlue
        Colores(112) = Color.Chartreuse
        Colores(113) = Color.Coral
        Colores(114) = Color.CornflowerBlue
        Colores(115) = Color.Cornsilk
        Colores(116) = Color.Crimson
        Colores(117) = Color.Cyan
        Colores(118) = Color.LemonChiffon
        Colores(119) = Color.LightBlue
        Colores(120) = Color.LightCoral
        Colores(121) = Color.LightCyan
        Colores(122) = Color.LightGoldenrodYellow
        Colores(123) = Color.LightGray
        Colores(124) = Color.LightGreen
        Colores(125) = Color.LightPink
        Colores(126) = Color.LightSalmon
        Colores(127) = Color.LightSeaGreen
        Colores(128) = Color.LightSkyBlue
        Colores(129) = Color.LightSlateGray
        Colores(130) = Color.LightSteelBlue
        Colores(131) = Color.LightYellow
        Colores(132) = Color.Lime
        Colores(133) = Color.LimeGreen
        Colores(134) = Color.Linen
        Colores(135) = Color.OldLace
        Colores(136) = Color.Olive
        Colores(137) = Color.OliveDrab
        Colores(138) = Color.Orange
        Colores(139) = Color.Orchid
        Colores(140) = Color.PaleGoldenrod
        Colores(141) = Color.PaleGreen
        Colores(142) = Color.PaleTurquoise
        Colores(143) = Color.PapayaWhip
        Colores(144) = Color.PeachPuff
        Colores(145) = Color.Peru
        Colores(146) = Color.Pink
        Colores(147) = Color.Plum
        Colores(148) = Color.PowderBlue
        Colores(149) = Color.RosyBrown
        Colores(150) = Color.Aqua
        Colores(151) = Color.Aquamarine
        Colores(152) = Color.Salmon
        Colores(153) = Color.Sienna
        Colores(154) = Color.Beige
        Colores(155) = Color.Silver
        Colores(156) = Color.Turquoise
        Colores(157) = Color.Blue
        Colores(158) = Color.BlueViolet
        Colores(159) = Color.Brown
        Colores(160) = Color.BurlyWood
        Colores(161) = Color.CadetBlue
        Colores(162) = Color.Chartreuse
        Colores(163) = Color.Coral
        Colores(164) = Color.CornflowerBlue
        Colores(165) = Color.Cornsilk
        Colores(166) = Color.Crimson
        Colores(167) = Color.Cyan
        Colores(168) = Color.LemonChiffon
        Colores(169) = Color.LightBlue
        Colores(170) = Color.LightCoral
        Colores(171) = Color.LightCyan
        Colores(172) = Color.LightGoldenrodYellow
        Colores(173) = Color.LightGray
        Colores(174) = Color.LightGreen
        Colores(175) = Color.LightPink
        Colores(176) = Color.LightSalmon
        Colores(177) = Color.LightSeaGreen
        Colores(178) = Color.LightSkyBlue
        Colores(179) = Color.LightSlateGray
        Colores(180) = Color.LightSteelBlue
        Colores(181) = Color.LightYellow
        Colores(182) = Color.Lime
        Colores(183) = Color.LimeGreen
        Colores(184) = Color.Linen
        Colores(185) = Color.OldLace
        Colores(186) = Color.Olive
        Colores(187) = Color.OliveDrab
        Colores(188) = Color.Orange
        Colores(189) = Color.Orchid
        Colores(190) = Color.PaleGoldenrod
        Colores(191) = Color.PaleGreen
        Colores(192) = Color.PaleTurquoise
        Colores(193) = Color.PapayaWhip
        Colores(194) = Color.PeachPuff
        Colores(195) = Color.Peru
        Colores(196) = Color.Pink
        Colores(197) = Color.Plum
        Colores(198) = Color.PowderBlue
        Colores(199) = Color.RosyBrown
        LimpiaPanelAsignacion()
        LlenaProgramaProduccion()
    End Sub

    Private Sub LlenaProgramaProduccion()
        Dim Contador As Int32 = 0

        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion

        BDComando.CommandType = CommandType.Text
        'BDComando.CommandText = "SELECT M.CVE_MAQUILADOR,M.ENCARGADO,ISNULL((SELECT MIN(OPA.FECHAINICIO) FROM OP_ASIGNACION OPA WHERE OPA.Empresa = 1 AND OPA.Cve_Maquilador = M.Cve_Maquilador AND OPA.Finalizada = 0 AND OPA.Cancelada = 0 AND OPA.Estatus = 'AUTORIZADA'),GETDATE()) AS FECHAMININICIO FROM Maquilador M WHERE M.STATUS = 1 AND M.TIPOTALLER IN ('MAQUILA','AMBOS') ORDER BY M.ENCARGADO"
        BDComando.CommandText = "SELECT M.CVE_MAQUILADOR,M.ENCARGADO,ISNULL((SELECT MIN(OPA.FECHAINICIO) FROM OP_ASIGNACION OPA WHERE OPA.Empresa = 1 AND OPA.Cve_Maquilador = M.Cve_Maquilador AND OPA.Finalizada = 0 AND OPA.Cancelada = 0 AND OPA.Estatus = 'AUTORIZADA'),'01/01/2025') AS FECHAMININICIO FROM Maquilador M WHERE M.STATUS = 1 AND M.TIPOTALLER IN ('MAQUILA','AMBOS') ORDER BY M.ENCARGADO"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Contador = 0
                While BDReader.Read
                    If TCMaquilador.TabPages(Contador).Text = "TabPage1" Then
                        'DGVProgramaAsignaciones.Columns.Add(BDReader("CVE_MAQUILADOR"), BDReader("ENCARGADO"))
                        TCMaquilador.TabPages(Contador).Text = BDReader("ENCARGADO")
                        TCMaquilador.TabPages(Contador).AccessibleName = BDReader("CVE_MAQUILADOR")
                        Dim FechaInicial As Date
                        FechaInicial = BDReader("FECHAMININICIO")
                        DGVProgramaAsignaciones.Rows.Add(Format(FechaInicial, "dd/MM/yyyy"))
                        DGVProgramaAsignaciones.Columns(0).Frozen = True
                        For Fila As Int32 = 1 To 365
                            If DateAdd("d", CDbl(Fila), FechaInicial).DayOfWeek.GetHashCode() <> 0 And DateAdd("d", CDbl(Fila), FechaInicial).DayOfWeek.GetHashCode() <> 6 Then
                                DGVProgramaAsignaciones.Rows.Add(Format(DateAdd("d", CDbl(Fila), FechaInicial), "dd/MM/yyyy"))
                            End If
                        Next
                    Else
                        TCMaquilador.TabPages.Add("TabPages" & Contador + 1)
                        Contador += 1
                        TCMaquilador.TabPages(Contador).Text = BDReader("ENCARGADO")
                        TCMaquilador.TabPages(Contador).AccessibleName = BDReader("CVE_MAQUILADOR")
                        Dim DGVProgramaAsignaciones1 As New DevComponents.DotNetBar.Controls.DataGridViewX
                        Dim TipoFuente As New DataGridViewCellStyle

                        DGVProgramaAsignaciones1.Top = 6
                        DGVProgramaAsignaciones1.Left = 6
                        DGVProgramaAsignaciones1.Height = 573
                        DGVProgramaAsignaciones1.Width = 806
                        DGVProgramaAsignaciones1.Columns.Add("FECHACALENDARIO" & Contador, "Fecha")
                        DGVProgramaAsignaciones1.Columns(0).Width = 70
                        DGVProgramaAsignaciones1.Columns(0).Frozen = True
                        'TipoFuente.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                        TipoFuente = DGVProgramaAsignaciones.DefaultCellStyle.Clone
                        DGVProgramaAsignaciones1.Columns(0).DefaultCellStyle = TipoFuente
                        DGVProgramaAsignaciones1.ColumnHeadersDefaultCellStyle = TipoFuente
                        DGVProgramaAsignaciones1.ColumnHeadersHeight = 18
                        Dim FechaInicial As Date
                        FechaInicial = BDReader("FECHAMININICIO")
                        DGVProgramaAsignaciones1.Rows.Add(Format(FechaInicial, "dd/MM/yyyy"))
                        For Fila As Int32 = 1 To 365
                            If DateAdd("d", CDbl(Fila), FechaInicial).DayOfWeek.GetHashCode() <> 0 And DateAdd("d", CDbl(Fila), FechaInicial).DayOfWeek.GetHashCode() <> 6 Then
                                DGVProgramaAsignaciones1.Rows.Add(Format(DateAdd("d", CDbl(Fila), FechaInicial), "dd/MM/yyyy"))
                            End If
                        Next
                        TCMaquilador.TabPages(Contador).Controls.Add(DGVProgramaAsignaciones1)
                    End If
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar el catálogo de Maquiladores, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & ex.Message, "Maquilador", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

        DGVOPAAsignar.Rows.Clear()

        BDComando.CommandType = CommandType.Text
        BDComando.Parameters.Clear()
        BDComando.CommandText = "SELECT OPA.No_OP,OPA.FechaParaAsignar,PIT.Cve_Prenda,PIT.DescripcionPrenda,SUM(PIT.CANTIDAD-ISNULL(RIPT.CANTIDAD,0)) AS CANTIDAD,PI.CVE_CLIENTE,PI.NOM_CLIENTE,PI.NO_PEDIDO FROM OP_ASIGNACION OPA,PEDIDO_INTERNO PI,PEDIDO_INTERNO_TALLAS PIT LEFT JOIN RESERVADO_INVENTARIO_PRODUCTO_TERMINADO RIPT ON RIPT.Empresa = PIT.Empresa AND RIPT.No_Pedido = PIT.No_Pedido AND RIPT.Partida = PIT.Partida AND RIPT.Cve_Prenda = PIT.Cve_Prenda AND RIPT.LugarDeEntrega = PIT.LugarDeEntrega AND RIPT.Prioridad = PIT.Prioridad AND RIPT.Talla = PIT.Talla WHERE OPA.EMPRESA = " & ConectaBD.Cve_Empresa & " AND OPA.Estatus = 'PENDIENTE' AND OPA.ASIGNADA = 0 AND OPA.FECHAPARAASIGNAR IS NOT NULL AND OPA.CANCELADA = 0 AND OPA.Empresa = PIT.Empresa AND OPA.No_OP = PIT.No_OP AND PI.EMPRESA = PIT.EMPRESA AND PI.NO_PEDIDO = PIT.NO_PEDIDO GROUP BY OPA.No_OP,OPA.FechaParaAsignar,PIT.Cve_Prenda,PIT.DescripcionPrenda,PI.CVE_CLIENTE,PI.NOM_CLIENTE,PI.NO_PEDIDO"

        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                While BDReader.Read
                    DGVOPAAsignar.Rows.Add(BDReader("NO_OP"), Format(BDReader("FECHAPARAASIGNAR"), "dd/MM/yyyy"), BDReader("CVE_PRENDA"), BDReader("DESCRIPCIONPRENDA"), BDReader("CANTIDAD"), BDReader("CVE_CLIENTE"), BDReader("NOM_CLIENTE"), BDReader("No_Pedido"))
                End While
            End If
        Catch ex As Exception
            MessageBox.Show("Error al consultar las OP a Asignar, contactar a Sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Ordenes de Producción a Asignar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            ' Asegurarse de que el DataReader y la conexión se cierren.
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try

        For NumTab As Int32 = 0 To TCMaquilador.TabCount - 1

            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.Parameters.Clear()
            BDComando.CommandText = "SP_RECUPERA_FECHAS_OP_ASIGNADAS"
            BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@CVE_MAQUILADOR", SqlDbType.BigInt)

            BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
            BDComando.Parameters("@CVE_MAQUILADOR").Value = TCMaquilador.TabPages(NumTab).AccessibleName

            Try
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    ColoresAsignados = 0
                    Dim DGVAux As New DevComponents.DotNetBar.Controls.DataGridViewX
                    DGVAux = TCMaquilador.TabPages(NumTab).Controls(0)
                    While BDReader.Read
                        DGVAux.Columns.Add(BDReader("NO_OP"), BDReader("NO_OP"))
                        DGVAux.Columns(DGVAux.Columns.Count - 1).Width = 40
                        For Fila As Int32 = 0 To DGVAux.Rows.Count - 1
                            If DGVAux.Rows(Fila).Cells("FECHACALENDARIO" & NumTab).Value >= BDReader("FECHAINICIO") And DGVAux.Rows(Fila).Cells("FECHACALENDARIO" & NumTab).Value <= BDReader("FECHAFINALIZACION") Then
                                'Celda = DGVProgramaAsignaciones.Rows(Fila).Cells(Columna)
                                'DGVProgramaAsignaciones1.Rows(Fila).Cells(DGVProgramaAsignaciones1.Columns.Count - 1).Value = "OP. " & BDReader("NO_OP")
                                DGVAux.Rows(Fila).Cells(DGVAux.Columns.Count - 1).Style.BackColor = Colores(ColoresAsignados)
                                'Celda.Value = "OP. " & BDReader("NO_OP")
                                'Celda.Style.BackColor = Colores(ColoresAsignados)
                            ElseIf DGVAux.Rows(Fila).Cells("FECHACALENDARIO" & NumTab).Value > BDReader("FECHAFINALIZACION") Then
                                Exit For
                            End If
                        Next
                        ColoresAsignados += 1
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show("Error al consultar las OP a Asignar, contactar a Sistemas y dar como referencia el siguiente mensaje" & vbCrLf & ex.Message, "Ordenes de Producción a Asignar", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
    End Sub

    Private Sub LimpiaPanelAsignacion()
        'SOLO SE ELILMINAN TODOS LOS TAB DEL SEGUNDO EN ADELANTE
        For Contador As Int32 = TCMaquilador.TabPages.Count - 1 To 1 Step -1
            TCMaquilador.TabPages.Remove(TCMaquilador.TabPages(Contador))
        Next
        ConsecColor = 0
        TCMaquilador.TabPages(0).Text = "TabPage1"
        DGVProgramaAsignaciones.Rows.Clear()
        DGVProgramaAsignaciones.Columns.Clear()
        DGVProgramaAsignaciones.Columns.Add("FechaCalendario0", "Fecha")
        DGVProgramaAsignaciones.Columns(0).Width = 70

    End Sub

    Private Sub DGVOPAAsignar_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGVOPAAsignar.MouseDown
        If DGVOPAAsignar.Rows.Count > 0 Then
            If DGVOPAAsignar.CurrentRow IsNot Nothing Then
                FilaOrigen = DGVOPAAsignar.CurrentRow.Index
                LblAux.Top = DGVOPAAsignar.Top + DGVOPAAsignar.GetCellDisplayRectangle(DGVOPAAsignar.CurrentCell.ColumnIndex, DGVOPAAsignar.CurrentRow.Index, False).Top
                LblAux.Left = DGVOPAAsignar.Left + DGVOPAAsignar.GetCellDisplayRectangle(DGVOPAAsignar.CurrentCell.ColumnIndex, DGVOPAAsignar.CurrentRow.Index, False).Left
                Coordenadas.X = MousePosition.X - LblAux.Left
                Coordenadas.Y = MousePosition.Y - LblAux.Top
                LblAux.Text = "OP. " & DGVOPAAsignar.CurrentRow.Cells("OPAAsignar").Value '& vbCrLf & DGVOPAAsignar.CurrentRow.Cells("FechaIniciar").Value
                FechaReferencia = DGVOPAAsignar.CurrentRow.Cells("FechaIniciar").Value
                'LblAux.Height = 22 CAMBIADO EL 03 DE OCTUBRE DE 2023
                LblAux.Height = DGVOPAAsignar.CurrentRow.Height
                LblAux.Visible = True
            End If
        End If
    End Sub

    Private Sub DGVOPAAsignar_MouseMove(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGVOPAAsignar.MouseMove
        If e.Button = MouseButtons.Left Then
            LblAux.Top = MousePosition.Y - Coordenadas.Y
            LblAux.Left = MousePosition.X - Coordenadas.X
        End If
    End Sub

    Private Sub DGVOPAAsignar_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles DGVOPAAsignar.MouseUp
        'MessageBox.Show("LblAux.X: " & LblAux.Location.X & ", LblAux.Y: " & LblAux.Location.Y & ", LblAux.Top: " & LblAux.Top & ", LblAux.Left: " & LblAux.Left & ", DGV.Top: " & DGVProgramaAsignaciones.Top)
        Dim Fila As Int32
        Dim Columna As Int32
        Dim FechaFinal As String
        Dim input As String
        Dim CantDiasFinalizarOP As Long
        Dim DGVAux As New DevComponents.DotNetBar.Controls.DataGridViewX
        Dim Celda As DataGridViewCell
        Dim PrimeraFilaTop As Int32

        DGVAux = TCMaquilador.TabPages(TCMaquilador.SelectedIndex).Controls(0)
        If DGVAux.Rows.Count > 0 Then
            If LblAux.Location.X >= 63 And LblAux.Location.Y >= 73 And LblAux.Location.Y <= 623 And LblAux.Location.X + LblAux.Width <= 808 Then
                PrimeraFilaTop = DGVAux.FirstDisplayedScrollingRowIndex
                'Fila = Math.Truncate(CInt((LblAux.Location.Y - 73) / 22)) modificado el 03 de octubre de 2023
                'Fila = Math.Round(CInt((LblAux.Location.Y + LblAux.Height / 2 - 73) / 22))
                Fila = Math.Floor(CInt((LblAux.Location.Y - 73) / 22))
                'MessageBox.Show(DGVAux.GetCellDisplayRectangle(0, 0, False).Top)
                Fila = Fila + PrimeraFilaTop
                'Columna = CInt((LblAux.Location.X - DGVAux.GetCellDisplayRectangle(0, 0, False).Left - DGVAux.Left) / 100)
                If Fila <= DGVAux.Rows.Count - 1 Then
                    'If IsNothing(DGVAux.Rows(Fila).Cells(Columna).Value) = False Then
                    '    MessageBox.Show("Ya hay una OP Asignada a este Maquilador en esta fecha, seleccione otra fecha", "Asigmnación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    'Else
                    If DGVAux.Rows(Fila).Cells(0).Value >= FechaReferencia Then
                        FechaReferencia = DGVAux.Rows(Fila).Cells(0).Value
                        input = InputBox("¿Cúantos días para Finalizar OP? ", "Días de Proceso", "")
                        If Long.TryParse(input, CantDiasFinalizarOP) Then
                            ' En este bloque, la conversión fue exitosa y puedes utilizar CantDiasFinalizarOP como un Long.
                        Else
                            LblAux.Visible = False
                            Exit Sub
                        End If
                        DGVAux.Columns.Add(LblAux.Text.Substring(3, Len(LblAux.Text) - 3), LblAux.Text.Substring(3, Len(LblAux.Text) - 3))
                        DGVAux.ColumnHeadersDefaultCellStyle.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
                        Columna = DGVAux.Columns.Count - 1
                        DGVAux.Columns(Columna).Width = 40
                        Dias(ConsecColor) = CantDiasFinalizarOP
                        If IsNumeric(CantDiasFinalizarOP) = True Then
                            For FilaAux As Int32 = Fila To Fila + CantDiasFinalizarOP - 1
                                Celda = DGVAux.Rows(FilaAux).Cells(Columna)
                                Celda.Style.BackColor = Colores(ColoresAsignados)
                            Next
                            FechaFinal = DGVAux.Rows(Fila + CantDiasFinalizarOP - 1).Cells(0).Value
                            CvePrendaCorreo(ConsecColor) = DGVOPAAsignar.Rows(FilaOrigen).Cells("CvePrenda").Value
                            DescripcionPrendaCorreo(ConsecColor) = DGVOPAAsignar.Rows(FilaOrigen).Cells("DescripcionPrenda").Value
                            CveClienteCorreo(ConsecColor) = DGVOPAAsignar.Rows(FilaOrigen).Cells("CveCliente").Value
                            NombreClienteCorreo(ConsecColor) = DGVOPAAsignar.Rows(FilaOrigen).Cells("NomCliente").Value
                            CantidadCorreo(ConsecColor) = DGVOPAAsignar.Rows(FilaOrigen).Cells("Cantidad").Value
                            DGVOPAAsignar.Rows.Remove(DGVOPAAsignar.Rows(FilaOrigen))
                            No_OP(ConsecColor) = LblAux.Text.Substring(3, Len(LblAux.Text) - 3)
                            Maquilador(ConsecColor) = TCMaquilador.TabPages(TCMaquilador.SelectedIndex).AccessibleName
                            MaquiladorNombre(ConsecColor) = TCMaquilador.TabPages(TCMaquilador.SelectedIndex).Text
                            FechaInicio(ConsecColor) = FechaReferencia
                            FechaFinalizacion(ConsecColor) = FechaFinal
                            ToolStrip1.Visible = True
                            ConsecColor += 1
                            ColoresAsignados += 1
                        End If
                    End If
                    'End If
                End If
            End If
        End If
        DGVOPAAsignar.ClearSelection()
        LblAux.Visible = False
    End Sub

    'Private Sub DGVProgramaAsignaciones_CellMouseEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVProgramaAsignaciones.CellMouseEnter
    '    If e.RowIndex > 0 Then
    '        MessageBox.Show(DGVProgramaAsignaciones.Rows(e.RowIndex).Cells("FECHACALENDARIO").Value)
    '        If DGVProgramaAsignaciones.Rows(e.RowIndex).Cells("FECHACALENDARIO").Value = FechaReferencia Then
    '            LblAux.Height = 220
    '        Else
    '            LblAux.Height = 44
    '        End If
    '    End If
    'End Sub

    Private Sub AsignacionOP_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If ToolStrip1.Visible = True Then
            MessageBox.Show("Se detectaron asignaciones sin guardar", "Asignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
    End Sub

    Private Sub TSBGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TSBGuardar.Click
        If ToolStrip1.Visible = True Then
            If MessageBox.Show("¿Confirma guardar la Asignación de OP?", "Asignación de OP", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Dim MensajeCorreoAsignacion As String = ""
                Dim SeEnviaCorreo As Boolean = False
                Dim ContinuoDeUnError As Boolean = False
                'ESTRUCTURA DE LA TABLA DEL CORREO DE ASIGNACIÓN
                MensajeCorreoAsignacion += "<table border=1>" 'ABRE TABLA
                MensajeCorreoAsignacion += "<tr>" 'ABRE FILA
                MensajeCorreoAsignacion += "<th width=50px>No. OP</th>" 'ENCABEZADO DE COLUMNA
                MensajeCorreoAsignacion += "<th width=200px>Maquilador</th>" 'ENCABEZADO DE COLUMNA
                MensajeCorreoAsignacion += "<th width=80px>Fecha de Inicio</th>" 'ENCABEZADO DE COLUMNA
                MensajeCorreoAsignacion += "<th width=80px>Fecha de Vencimiento</th>" 'ENCABEZADO DE COLUMNA
                MensajeCorreoAsignacion += "<th width=80px>Fecha de Finalización</th>" 'ENCABEZADO DE COLUMNA
                MensajeCorreoAsignacion += "<th width=100px>Cliente</th>" 'ENCABEZADO DE COLUMNA
                MensajeCorreoAsignacion += "<th width=100px>Prenda</th>" 'ENCABEZADO DE COLUMNA
                MensajeCorreoAsignacion += "<th width=50px>Cantidad</th>" 'ENCABEZADO DE COLUMNA
                MensajeCorreoAsignacion += "</tr>" 'CIERRA FILA

                For Consec As Int32 = 0 To ConsecColor - 1
                    BDComando.Parameters.Clear()
                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_ACTUALIZA_OP_ASIGNACION"
                    BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NO_OP", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@CVE_MAQUILADOR", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@NOM_MAQUILADOR", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@FECHAINICIO", SqlDbType.Date)
                    BDComando.Parameters.Add("@FECHAFINALIZACION", SqlDbType.Date)
                    BDComando.Parameters.Add("@DIASPROCESO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
                    BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@FECHAVENCIMIENTOPEDIDO", SqlDbType.Date)


                    BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                    BDComando.Parameters("@NO_OP").Value = No_OP(Consec)
                    BDComando.Parameters("@CVE_MAQUILADOR").Value = Maquilador(Consec)
                    BDComando.Parameters("@NOM_MAQUILADOR").Value = MaquiladorNombre(Consec)
                    BDComando.Parameters("@FECHAINICIO").Value = FechaInicio(Consec)
                    BDComando.Parameters("@FECHAFINALIZACION").Value = FechaFinalizacion(Consec)
                    BDComando.Parameters("@DIASPROCESO").Value = Dias(Consec)
                    BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
                    BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
                    BDComando.Parameters("@FECHAVENCIMIENTOPEDIDO").Direction = ParameterDirection.Output
                    'BDComando.CommandText = "UPDATE OP_ASIGNACION SET ASIGNADA = 1,CVE_MAQUILADOR = " & Maquilador(Consec) & ",FECHAINICIO = '" & FechaInicio(Consec) & "',FECHAFINALIZACION = '" & FechaFinalizacion(Consec) & "',DIASPROCESO = " & Dias(Consec) & " WHERE EMPRESA = " & ConectaBD.Cve_Empresa & " AND NO_OP = " & No_OP(Consec)

                    Try
                        BDComando.Connection.Open()
                        BDComando.ExecuteNonQuery()
                        MensajeCorreoAsignacion += "<tr>" 'ABRE FILA
                        MensajeCorreoAsignacion += "<td>" & No_OP(Consec) & "</td>" 'DATO COLUMNA
                        MensajeCorreoAsignacion += "<td>" & MaquiladorNombre(Consec) & "</td>" 'DATO COLUMNA
                        MensajeCorreoAsignacion += "<td>" & Format(FechaInicio(Consec), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                        MensajeCorreoAsignacion += "<td>" & Format(BDComando.Parameters("@FECHAVENCIMIENTOPEDIDO").Value, "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                        If BDComando.Parameters("@FECHAVENCIMIENTOPEDIDO").Value <= FechaFinalizacion(Consec) Then
                            MensajeCorreoAsignacion += "<td>" & Format(FechaFinalizacion(Consec), "dd/MM/yyyy") & ", se terminará fuera de tiempo.</td>" 'DATO COLUMNA
                            'MensajeCorreoFueraTiempo += "-No. OP: " & No_OP(Consec) & ", Maquilador: " & MaquiladorNombre(Consec) & ", Fecha de Inicio: " & Format(FechaInicio(Consec), "dd/MM/yyyy") & ", Fecha de Finalización: " & Format(FechaFinalizacion(Consec), "dd/MM/yyyy") & ", Fecha de Vencimiento del Pedido: " & Format(BDComando.Parameters("@FECHAVENCIMIENTOPEDIDO").Value, "dd/MM/yyyy") & "." & vbCrLf
                        Else
                            MensajeCorreoAsignacion += "<td>" & Format(FechaFinalizacion(Consec), "dd/MM/yyyy") & "</td>" 'DATO COLUMNA
                        End If
                        MensajeCorreoAsignacion += "<td>" & NombreClienteCorreo(Consec) & "</td>" 'DATO COLUMNA
                        MensajeCorreoAsignacion += "<td>" & DescripcionPrendaCorreo(Consec) & "</td>" 'DATO COLUMNA
                        MensajeCorreoAsignacion += "<td>" & CantidadCorreo(Consec) & "</td>" 'DATO COLUMNA
                        MensajeCorreoAsignacion += "</tr>" 'CIERRA FILA
                        'MensajeCorreoAsignacion += "-No. OP: " & No_OP(Consec) & ", Maquilador: " & MaquiladorNombre(Consec) & ", Fecha de Inicio: " & Format(FechaInicio(Consec), "dd/MM/yyyy") & ", Fecha de Finalización: " & Format(FechaFinalizacion(Consec), "dd/MM/yyyy") & "." & vbCrLf
                        'MensajeCorreoAsignacion += "-No. OP: " & No_OP(Consec) & ", Maquilador: " & MaquiladorNombre(Consec) & ", Fecha de Inicio: " & Format(FechaInicio(Consec), "dd/MM/yyyy") & ", Fecha de Finalización: " & Format(FechaFinalizacion(Consec), "dd/MM/yyyy") & "." & vbCrLf
                        SeEnviaCorreo = True
                    Catch ex As Exception
                        MessageBox.Show("Error al guardar las Asignaciones, contactar a Sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Asignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        If SeEnviaCorreo = True Then
                            ContinuoDeUnError = True
                            GoTo ContinuaEnviarCorreo
                        End If
                        LimpiaPanelAsignacion()
                        LlenaProgramaProduccion()
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
                Next
ContinuaEnviarCorreo:
                MensajeCorreoAsignacion += "</table>" 'CIERRA TABLA
                If SeEnviaCorreo = True Then

                    ' Crear el mensaje
                    Dim mensaje As New MimeMessage()
                    mensaje.From.Add(New MailboxAddress("ORCELEC", ConectaBD.MailUsuario))

                    ' Puedes agregar múltiples destinatarios separados por coma
                    Dim destinatarios As String() = {"ch@uet.mx", "amm@uet.mx"}
                    For Each destinatario As String In destinatarios
                        mensaje.To.Add(MailboxAddress.Parse(destinatario))
                    Next

                    mensaje.Subject = "Asignación de Ordenes de Producción"

                    ' Crear el cuerpo en HTML
                    Dim builder As New BodyBuilder()
                    builder.HtmlBody = "<body><h1>Se Asignaron las siguientes Ordenes de Producción.</h1><br>" & MensajeCorreoAsignacion & "<br><br></body>"
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

                    ''Declaro la variable para enviar el correo
                    'Dim correo As New System.Net.Mail.MailMessage()
                    'correo.From = New System.Net.Mail.MailAddress(ConectaBD.MailUsuario, "ORCELEC")
                    'correo.IsBodyHtml = True
                    'correo.Subject = "Asignación de Ordenes de Producción"
                    'correo.To.Add("ch@uet.mx,amm@uet.mx")
                    ''correo.Body = "Se Asignaron las siguientes Ordenes de Producción." & vbCrLf & vbCrLf & vbCrLf & MensajeCorreoAsignacion
                    'correo.Body = "<body><h1>Se Asignaron las siguientes Ordenes de Producción.</h1><br>" & MensajeCorreoAsignacion & "<br><br></body>"

                    '' Forzar el uso de TLS 1.2
                    'ServicePointManager.SecurityProtocol = DirectCast(3072, SecurityProtocolType)

                    ''Configuracion del servidor
                    'Dim Servidor As New System.Net.Mail.SmtpClient
                    'Servidor.Host = ConectaBD.MailSMTP
                    'Servidor.Port = ConectaBD.MailPuerto
                    'Servidor.EnableSsl = ConectaBD.MailSSL
                    'Servidor.Credentials = New System.Net.NetworkCredential(ConectaBD.MailUsuario, ConectaBD.PasswordCorreo)
                    'AddHandler Servidor.SendCompleted, AddressOf SendCompletedCallback
                    'Servidor.SendAsync(correo, "AsignacionOP")

                    If ContinuoDeUnError = True Then
                        Exit Sub
                    End If
                End If


                ToolStrip1.Visible = False
                MessageBox.Show("Se guardaron correctamente las asignaciones de OP", "Asignación de OP", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)

                LimpiaPanelAsignacion()
                LlenaProgramaProduccion()
            End If
        End If
    End Sub

    Private Sub TCMaquilador_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TCMaquilador.SelectedIndexChanged
        'If TCMaquilador.TabPages.Count > 0 Then
        '    If TCMaquilador.SelectedTab IsNot Nothing Then
        '        TCMaquilador.TabPages(IndexTabSeleccionadoAnterior)
        '        TCMaquilador.TabPages(IndexTabSeleccionadoAnterior).BackColor = Color.White
        '        TCMaquilador.TabPages(IndexTabSeleccionadoAnterior).ForeColor = Color.Black
        '        TCMaquilador.TabPages(TCMaquilador.SelectedIndex).BackColor = Color.Black
        '        TCMaquilador.TabPages(TCMaquilador.SelectedIndex).ForeColor = Color.White
        '        IndexTabSeleccionadoAnterior = TCMaquilador.SelectedIndex
        '    End If
        'End If
    End Sub
End Class
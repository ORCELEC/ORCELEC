Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports DevComponents.DotNetBar

Public Class FrmDiseñoPrenda
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As New DataTable
    Private BDReader As SqlDataReader
    Private Bandera As String
    Private Nivel As Integer
    Private NivelAnt As Integer
    Private AnchoGrupo As Integer
    Private PosicionY() As Long
    Private AnchoBordeGrupo() As Integer = {13, 11, 9, 7, 5, 3, 1}
    Private GroupBox() As GroupBox
    Private ContadorGroupBox As Integer
    Private PosicionGroupBox As Integer
    Public Clave As String
    Public DescripcionClave As String = ""
    Public TabIndice As Long
    Public Mensaje As String = ""
    Public ControlAnterior As Boolean = False
    Public ContadorRadioButtonSi As Integer
    Public Dato As String
    Public OtroDato As String
    Public NivelLetra As String
    Public DescripcionSeccionGuardado As String = ""
    Public SeccionGuardado As Integer = 0
    Public CvePrenda As Long
    Public NumeroErrores As Integer
    Public TipoMovimiento As String
    Public EntraProcesos As Boolean = False

    Private Sub FrmDiseñoPrenda_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        'PARA STANDARIZAR LA PROPIEDAD TAG DE LOS OBJETOS, QUEDARA COMO DESCRIPCION,NIVELNUMERICO,TIPODEOBJETO,CVEHABILITACION
        BDAdapter = New SqlDataAdapter("SELECT * FROM DISEÑO_GENERICO WHERE CVE_TIPOPRENDA = 0", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        PanDetallePrenda.AutoScroll = True
        ActivaBotonesConsulta()
    End Sub

    Private Sub LlenaDiseñoGenerico(ByVal CveTipoPrenda As Integer)
        Dim NivelMax As Integer
        Dim ContNivel As Boolean
        Dim ValorSi As Boolean = False
        Dim ValorNo As Boolean = False
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT MAX(LEN(NIVEL)) AS LONGITUD FROM DISEÑO_GENERICO WHERE CVE_TIPOPRENDA = " & CveTipoPrenda
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            BDReader.Read()
            NivelMax = BDReader("LONGITUD")
        End If
        NivelMax = NivelMax / 2
        ReDim PosicionY(NivelMax)
        BDReader.Close()
        BDComando.Connection.Close()

        BDTabla.Clear()
        BDAdapter.SelectCommand.Parameters.Clear()
        BDAdapter.SelectCommand.CommandType = CommandType.Text
        BDAdapter.SelectCommand.CommandText = "SELECT * FROM DISEÑO_GENERICO WHERE CVE_TIPOPRENDA = " & CveTipoPrenda
        BDAdapter.Fill(BDTabla)
        Nivel = 0
        NivelAnt = -1
        PosicionY(Nivel) = 20
        ContadorGroupBox = 0
        AnchoGrupo = 750
        Bandera = 1
        ContNivel = False
        TabIndice = 1
        If BDTabla.Rows.Count > 0 Then
            For i As Integer = 0 To BDTabla.Rows.Count - 1
                'If i = 419 Then
                '    MsgBox("DETENER")
                'End If
                Nivel = (Len(BDTabla.Rows.Item(i).Item("NIVEL")) / 2) - 0.5
                If NivelAnt > Nivel Then
                    If Nivel > 0 Then
                        For Contador As Integer = 1 To ContadorGroupBox
                            If GroupBox(Contador).Name = "CTRL" & Strings.Left(BDTabla.Rows.Item(i).Item("NIVEL"), Len(BDTabla.Rows.Item(i).Item("NIVEL")) - 2) Then
                                PosicionGroupBox = Contador
                                Exit For
                            End If
                        Next
                    ElseIf Nivel = 0 Then
                        If ContadorGroupBox > 1 Then
                            For Contador As Integer = ContadorGroupBox To 1 Step -1
                                If Len(GroupBox(Contador).Name) = 5 Then
                                    PosicionY(Nivel) = GroupBox(Contador).Top + GroupBox(Contador).Height + 20
                                    Exit For
                                End If
                            Next
                        End If
                    End If
                ElseIf NivelAnt < Nivel And Bandera = 1 Then
                    PosicionY(Nivel) = 20
                End If
                NivelAnt = Nivel
                If Nivel = 0 Then
                    If BDTabla.Rows.Item(i).Item("TIPODATO") = "B" Then
                        Dim LabelNivel As New Label
                        Dim GroupBit As New GroupBox
                        Dim OpcBitSi As New RadioButton
                        Dim OpcBitNo As New RadioButton

                        LabelNivel.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                        LabelNivel.Location = New Point(11, PosicionY(Nivel) + 15)
                        LabelNivel.AutoSize = True
                        LabelNivel.TabIndex = TabIndice
                        LabelNivel.Text = BDTabla.Rows.Item(i).Item("DESCRIPCION")

                        TabIndice += 1

                        GroupBit.Height = 35
                        GroupBit.Width = 100
                        GroupBit.TabIndex = TabIndice
                        GroupBit.Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & "," & "SINO" & ","
                        GroupBit.Name = "SINO" & BDTabla.Rows.Item(i).Item("NIVEL")
                        'PanDetallePrenda.Controls.Add(GroupBit)

                        TabIndice += 1

                        OpcBitSi.Height = 17
                        OpcBitSi.Width = 45
                        OpcBitSi.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                        OpcBitSi.Location = New Point(6, 12)
                        OpcBitSi.Name = "OPCSI" & BDTabla.Rows.Item(i).Item("NIVEL")
                        OpcBitSi.Text = "SI"
                        OpcBitSi.TabIndex = TabIndice
                        OpcBitSi.TabStop = True

                        'SE AGREGA EL CODIGO PARA LLENAR LOS CONTROLES CUANDO SE CONSULTA UN DISEÑO
                        If CvePrenda > 0 Then
                            BDComando.CommandType = CommandType.Text
                            BDComando.CommandText = "SELECT * FROM PRENDA_DETALLE WHERE CVE_PRENDA = " & CvePrenda & " AND NIVEL = '" & BDTabla.Rows.Item(i).Item("NIVEL") & "'"
                            BDComando.Connection.Open()
                            BDReader = BDComando.ExecuteReader
                            If BDReader.HasRows = True Then
                                OpcBitSi.Checked = True
                            Else
                                OpcBitNo.Checked = True
                            End If
                            BDReader.Close()
                            BDComando.Connection.Close()
                        End If

                        AddHandler OpcBitSi.CheckedChanged, AddressOf RBSiNo_CheckedChanged
                        GroupBit.Controls.Add(OpcBitSi)

                        TabIndice += 1

                        OpcBitNo.Height = 17
                        OpcBitNo.Width = 45
                        OpcBitNo.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                        OpcBitNo.Location = New Point(54, 12)
                        OpcBitNo.Name = "OPCNO" & BDTabla.Rows.Item(i).Item("NIVEL")
                        OpcBitNo.Text = "NO"
                        OpcBitNo.TabIndex = TabIndice
                        OpcBitNo.TabStop = True
                        AddHandler OpcBitNo.CheckedChanged, AddressOf RBSiNo_CheckedChanged
                        GroupBit.Controls.Add(OpcBitNo)

                        TabIndice += 1

                        PanDetallePrenda.Controls.Add(LabelNivel)
                        PanDetallePrenda.Controls.Add(GroupBit)
                        GroupBit.Location = New Point(LabelNivel.Location.X.ToString + LabelNivel.Width + 20, PosicionY(Nivel))
                        PosicionY(Nivel) += GroupBit.Height + 8
                    End If

                    ContadorGroupBox += 1
                    PosicionGroupBox = ContadorGroupBox
                    ReDim Preserve GroupBox(ContadorGroupBox)
                    GroupBox(ContadorGroupBox) = New GroupBox
                    GroupBox(ContadorGroupBox).Width = AnchoGrupo
                    GroupBox(ContadorGroupBox).Height = 35
                    GroupBox(ContadorGroupBox).AutoSize = True
                    GroupBox(ContadorGroupBox).Location = New Point(11, PosicionY(Nivel))
                    GroupBox(ContadorGroupBox).Name = "CTRL" & BDTabla.Rows.Item(i).Item("NIVEL")
                    GroupBox(ContadorGroupBox).Text = "SECCIÓN " & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & ": " & BDTabla.Rows.Item(i).Item("DESCRIPCION")
                    GroupBox(ContadorGroupBox).Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & ",,"
                    GroupBox(ContadorGroupBox).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                    GroupBox(ContadorGroupBox).TabIndex = TabIndice
                    PanDetallePrenda.Controls.Add(GroupBox(ContadorGroupBox))
                    If BDTabla.Rows.Item(i).Item("TIPODATO") = "B" Then
                        GroupBox(ContadorGroupBox).Enabled = False
                    End If
                    PosicionY(Nivel) += GroupBox(ContadorGroupBox).Height + 8

                    TabIndice += 1

                    If IsDBNull(BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO")) = False Then
                        If BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO") = "H" Or BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO") = "TE" Then
                            'SE AGREGA EL CODIGO PARA LLENAR LOS CONTROLES CUANDO SE CONSULTA UN DISEÑO
                            If CvePrenda > 0 Then
                                BDComando.CommandType = CommandType.Text
                                BDComando.CommandText = "SELECT * FROM PRENDA_DETALLE WHERE CVE_PRENDA = " & CvePrenda & " AND NIVEL = '" & BDTabla.Rows.Item(i).Item("NIVEL") & "'"
                                BDComando.Connection.Open()
                                BDReader = BDComando.ExecuteReader
                                If BDReader.HasRows = True Then
                                    BDReader.Read()
                                    Dato = BDReader("DATO")
                                End If
                                BDReader.Close()
                                BDComando.Connection.Close()
                            End If
                            '*****************************************************************************
                            Dim LabelCveHabilitacion As New Label
                            Dim TxtCveHabilitacion As New Controls.TextBoxX
                            Dim LabelDescripcionHabilitacion As New Label

                            LabelCveHabilitacion.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                            LabelCveHabilitacion.Location = New Point(11, 15)
                            LabelCveHabilitacion.AutoSize = True
                            LabelCveHabilitacion.TabIndex = TabIndice
                            LabelCveHabilitacion.Text = IIf(BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO") = "H", "CVE. HABILITACION", "CVE. TELA")

                            TabIndice += 1

                            GroupBox(ContadorGroupBox).Controls.Add(LabelCveHabilitacion)
                            TxtCveHabilitacion.Height = 20
                            TxtCveHabilitacion.Width = 200
                            TxtCveHabilitacion.FocusHighlightEnabled = True
                            TxtCveHabilitacion.CharacterCasing = CharacterCasing.Upper
                            TxtCveHabilitacion.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                            TxtCveHabilitacion.BorderStyle = BorderStyle.FixedSingle
                            TxtCveHabilitacion.Location = New Point(LabelCveHabilitacion.Location.X.ToString + LabelCveHabilitacion.Width + 20, 15)
                            TxtCveHabilitacion.Name = "TXTHT" & BDTabla.Rows.Item(i).Item("NIVEL")
                            TxtCveHabilitacion.Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & "," & IIf(BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO") = "H", "CVEHABILITACION", "CVETELA") & "," & IIf(IsDBNull(BDTabla.Rows.Item(i).Item("GRUPOHABILITACION")), "", BDTabla.Rows.Item(i).Item("GRUPOHABILITACION"))
                            TxtCveHabilitacion.TabIndex = TabIndice
                            TxtCveHabilitacion.TabStop = True
                            If CvePrenda > 0 Then
                                TxtCveHabilitacion.Text = Dato
                                Dato = ""
                            Else
                                TxtCveHabilitacion.Text = ""
                            End If
                            If BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO") = "H" Then
                                AddHandler TxtCveHabilitacion.KeyUp, AddressOf TxtHabilitacion_KeyUp
                                AddHandler TxtCveHabilitacion.Leave, AddressOf TxtHabilitacion_Leave
                            ElseIf BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO") = "TE" Then
                                AddHandler TxtCveHabilitacion.KeyUp, AddressOf TxtTela_KeyUp
                                AddHandler TxtCveHabilitacion.Leave, AddressOf TxtTela_Leave
                            End If
                            GroupBox(ContadorGroupBox).Controls.Add(TxtCveHabilitacion)

                            TabIndice += 1

                            LabelDescripcionHabilitacion.Height = 50
                            LabelDescripcionHabilitacion.Width = 300
                            LabelDescripcionHabilitacion.AutoSize = False
                            LabelDescripcionHabilitacion.Text = ""
                            LabelDescripcionHabilitacion.Location = New Point(TxtCveHabilitacion.Location.X.ToString + TxtCveHabilitacion.Width + 20, 15)
                            LabelDescripcionHabilitacion.Name = "CTRLLBL" & BDTabla.Rows.Item(i).Item("NIVEL")
                            LabelDescripcionHabilitacion.TabIndex = TabIndice

                            GroupBox(ContadorGroupBox).Controls.Add(LabelDescripcionHabilitacion)
                            PosicionY(Nivel) += GroupBox(ContadorGroupBox).Height + 8
                            PosicionY(Nivel + 1) = TxtCveHabilitacion.Top + TxtCveHabilitacion.Height + 8
                            Bandera = 0

                            TabIndice += 1
                        End If
                    End If
                ElseIf BDTabla.Rows.Item(i).Item("TIPODATO") = "S" Then
                    ContadorGroupBox += 1
                    ReDim Preserve GroupBox(ContadorGroupBox)
                    GroupBox(ContadorGroupBox) = New GroupBox
                    GroupBox(ContadorGroupBox).AutoSize = True
                    GroupBox(ContadorGroupBox).Width = AnchoGrupo - (Nivel * 20)
                    GroupBox(ContadorGroupBox).Height = 35
                    GroupBox(ContadorGroupBox).Location = New Point(11, PosicionY(Nivel))
                    GroupBox(ContadorGroupBox).Name = "CTRL" & BDTabla.Rows.Item(i).Item("NIVEL")
                    GroupBox(ContadorGroupBox).Text = BDTabla.Rows.Item(i).Item("DESCRIPCION")
                    GroupBox(ContadorGroupBox).Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & ",,"
                    GroupBox(ContadorGroupBox).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                    GroupBox(ContadorGroupBox).TabIndex = TabIndice
                    GroupBox(PosicionGroupBox).Controls.Add(GroupBox(ContadorGroupBox))
                    PosicionY(Nivel) += GroupBox(ContadorGroupBox).Height + 8
                    PosicionGroupBox = ContadorGroupBox
                    Bandera = 1

                    TabIndice += 1
                ElseIf BDTabla.Rows.Item(i).Item("TIPODATO") = "B" Then
                    'SE AGREGA EL CODIGO PARA LLENAR LOS CONTROLES CUANDO SE CONSULTA UN DISEÑO
                    If CvePrenda > 0 Then
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM PRENDA_DETALLE WHERE CVE_PRENDA = " & CvePrenda & " AND NIVEL = '" & BDTabla.Rows.Item(i).Item("NIVEL") & "'"
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            ValorSi = True
                            ValorNo = False
                        Else
                            ValorNo = True
                            ValorSi = False
                        End If
                        BDReader.Close()
                        BDComando.Connection.Close()
                    End If
                    '*****************************************************************************
                    AgregarControlBit(PosicionY(Nivel), ValorSi, ValorNo, i, BDTabla.Rows.Item(i).Item("NIVEL"))
                    ValorSi = False
                    ValorNo = False
                    If i + 1 <= BDTabla.Rows.Count - 1 And IsDBNull(BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO")) = True Then
                        If (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5 > Nivel Then
                            ContadorGroupBox += 1
                            ReDim Preserve GroupBox(ContadorGroupBox)
                            GroupBox(ContadorGroupBox) = New GroupBox
                            GroupBox(ContadorGroupBox).AutoSize = True
                            GroupBox(ContadorGroupBox).Width = AnchoGrupo - (Nivel * 20)
                            GroupBox(ContadorGroupBox).Height = 35
                            GroupBox(ContadorGroupBox).Location = New Point(11, PosicionY(Nivel))
                            GroupBox(ContadorGroupBox).Name = "CTRL" & BDTabla.Rows.Item(i).Item("NIVEL")
                            GroupBox(ContadorGroupBox).Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & ",,"
                            GroupBox(ContadorGroupBox).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                            GroupBox(ContadorGroupBox).Enabled = False
                            GroupBox(ContadorGroupBox).TabIndex = TabIndice
                            GroupBox(PosicionGroupBox).Controls.Add(GroupBox(ContadorGroupBox))
                            PosicionGroupBox = ContadorGroupBox
                            PosicionY(Nivel) += GroupBox(ContadorGroupBox).Height + 8

                            TabIndice += 1
                        End If
                    ElseIf IsDBNull(BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO")) = False Then
                        If BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO") = "H" Or BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO") = "TE" Then
                            'SE AGREGA EL CODIGO PARA LLENAR LOS CONTROLES CUANDO SE CONSULTA UN DISEÑO
                            If CvePrenda > 0 Then
                                BDComando.CommandType = CommandType.Text
                                BDComando.CommandText = "SELECT * FROM PRENDA_DETALLE WHERE CVE_PRENDA = " & CvePrenda & " AND NIVEL = '" & BDTabla.Rows.Item(i).Item("NIVEL") & "'"
                                BDComando.Connection.Open()
                                BDReader = BDComando.ExecuteReader
                                If BDReader.HasRows = True Then
                                    BDReader.Read()
                                    Dato = BDReader("DATO")
                                End If
                                BDReader.Close()
                                BDComando.Connection.Close()
                            End If
                            '*****************************************************************************
                            AgregarCveHabilitacion(PosicionY(Nivel), False, False, i, IIf(BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO") = "H", "CVE. HABILITACION", IIf(BDTabla.Rows.Item(i).Item("TIPODATOSECUNDARIO") = "TE", "CVE. TELA", "")), IIf(IsDBNull(BDTabla.Rows.Item(i).Item("GRUPOHABILITACION")), "", BDTabla.Rows.Item(i).Item("GRUPOHABILITACION")))
                            Dato = ""
                            GroupBox(ContadorGroupBox).Enabled = False
                            If i + 1 <= BDTabla.Rows.Count - 1 Then
                                If (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5 > Nivel Then
                                    NivelAnt = (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5
                                    PosicionGroupBox = ContadorGroupBox
                                End If
                            End If
                        End If
                    End If
                    If i + 1 <= BDTabla.Rows.Count - 1 Then
                        If (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5 < Nivel Then
                            PosicionY(Nivel - 1) = GroupBox(PosicionGroupBox).Top + GroupBox(PosicionGroupBox).Height + 8
                        End If
                    End If
                    Bandera = 1
                ElseIf BDTabla.Rows.Item(i).Item("TIPODATO") = "O" Then
                    Dim Opcion As New RadioButton
                    'SE AGREGA EL CODIGO PARA LLENAR LOS CONTROLES CUANDO SE CONSULTA UN DISEÑO
                    If CvePrenda > 0 Then
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM PRENDA_DETALLE WHERE CVE_PRENDA = " & CvePrenda & " AND DATO = '" & BDTabla.Rows.Item(i).Item("NIVEL") & "'"
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            BDReader.Read()
                            ValorSi = True
                            OtroDato = BDReader("OTRODATO")
                        End If
                        BDReader.Close()
                        BDComando.Connection.Close()
                    End If
                    '*****************************************************************************
                    Opcion.AutoSize = True
                    Opcion.Height = 17
                    Opcion.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                    Opcion.Location = New Point(11, PosicionY(Nivel))
                    Opcion.Name = "OPCOTRO" & BDTabla.Rows.Item(i).Item("NIVEL")
                    Opcion.Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & ",OPCOTRO,"
                    Opcion.Text = BDTabla.Rows.Item(i).Item("DESCRIPCION")
                    Opcion.TabIndex = TabIndice
                    Opcion.TabStop = True
                    If ValorSi = True Then
                        Opcion.Checked = True
                    End If
                    GroupBox(PosicionGroupBox).Controls.Add(Opcion)

                    TabIndice += 1
                    If BDTabla.Rows.Item(i).Item("DESCRIPCION") = "OTRO" Then
                        AddHandler Opcion.CheckedChanged, AddressOf RBOtro_CheckedChanged
                        Dim TxtOtro As New Controls.TextBoxX
                        TxtOtro.Height = 20
                        TxtOtro.Width = 200
                        TxtOtro.CharacterCasing = CharacterCasing.Upper
                        TxtOtro.FocusHighlightEnabled = True
                        TxtOtro.BorderStyle = BorderStyle.FixedSingle
                        TxtOtro.Name = "TXTOTRO" & BDTabla.Rows.Item(i).Item("NIVEL")
                        TxtOtro.Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & ",TXTOTRO,"
                        If CvePrenda > 0 Then
                            TxtOtro.Text = OtroDato
                            ValorSi = False
                            ValorNo = False
                            OtroDato = ""
                        End If
                        TxtOtro.Enabled = False
                        TxtOtro.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                        TxtOtro.Location = New Point(Opcion.Location.X.ToString + Opcion.Width + 20, PosicionY(Nivel))
                        TxtOtro.TabIndex = TabIndice
                        TxtOtro.TabStop = True
                        GroupBox(PosicionGroupBox).Controls.Add(TxtOtro)
                        PosicionY(Nivel) += TxtOtro.Height + 8

                        TabIndice += 1
                    Else
                        PosicionY(Nivel) += Opcion.Height + 8
                    End If
                    ValorSi = False
                    ValorNo = False
                    OtroDato = ""
                    If i + 1 <= BDTabla.Rows.Count - 1 Then
                        If (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5 < Nivel Then
                            If ContNivel = True Then
                                PosicionY(Nivel) = GroupBox(PosicionGroupBox).Top + GroupBox(PosicionGroupBox).Height + 8
                                PosicionY(Nivel - 1) = GroupBox(PosicionGroupBox - 1).Top + GroupBox(PosicionGroupBox - 1).Height + 8
                                ContNivel = False
                            Else
                                If NivelAnt - ((Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5) > 1 Then
                                    For Contador As Integer = 1 To ContadorGroupBox
                                        If GroupBox(Contador).Name = "CTRL" & Strings.Left(BDTabla.Rows.Item(i).Item("NIVEL"), Len(BDTabla.Rows.Item(i).Item("NIVEL")) - ((NivelAnt - (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2 - 0.5)) * 2)) Then
                                            PosicionY(Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2 - 0.5) = GroupBox(Contador).Top + GroupBox(Contador).Height + 8
                                            Exit For
                                        End If
                                    Next
                                Else
                                    PosicionY(Nivel - 1) = GroupBox(PosicionGroupBox).Top + GroupBox(PosicionGroupBox).Height + 8
                                End If
                            End If
                        End If
                    End If
                    Bandera = 1
                ElseIf BDTabla.Rows.Item(i).Item("TIPODATO") = "C" Then
                    Dim Check As New CheckBox
                    'SE AGREGA EL CODIGO PARA LLENAR LOS CONTROLES CUANDO SE CONSULTA UN DISEÑO
                    If CvePrenda > 0 Then
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM PRENDA_DETALLE WHERE CVE_PRENDA = " & CvePrenda & " AND DATO LIKE '%" & BDTabla.Rows.Item(i).Item("NIVEL") & "%'"
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            BDReader.Read()
                            ValorSi = True
                            OtroDato = BDReader("OTRODATO")
                        Else
                            ValorNo = True
                        End If
                        BDReader.Close()
                        BDComando.Connection.Close()
                    End If
                    '*****************************************************************************
                    Check.AutoSize = True
                    Check.Height = 17
                    Check.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                    Check.Location = New Point(11, PosicionY(Nivel))
                    Check.Text = BDTabla.Rows.Item(i).Item("DESCRIPCION")
                    Check.Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & ",OPCOTRO,"
                    Check.Name = "CHK" & BDTabla.Rows.Item(i).Item("NIVEL")
                    If ValorSi = True Then
                        Check.Checked = True
                    End If
                    Check.TabIndex = TabIndice
                    Check.TabStop = True
                    GroupBox(PosicionGroupBox).Controls.Add(Check)

                    TabIndice += 1
                    If BDTabla.Rows.Item(i).Item("DESCRIPCION") = "OTRO" Then
                        Dim TxtOtro As New Controls.TextBoxX
                        TxtOtro.Height = 20
                        TxtOtro.Width = 200
                        TxtOtro.CharacterCasing = CharacterCasing.Upper
                        TxtOtro.FocusHighlightEnabled = True
                        TxtOtro.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                        TxtOtro.BorderStyle = BorderStyle.FixedSingle
                        TxtOtro.Location = New Point(Check.Location.X.ToString + Check.Width + 20, PosicionY(Nivel))
                        TxtOtro.Name = "TXTOTRO" & BDTabla.Rows.Item(i).Item("NIVEL")
                        If CvePrenda > 0 Then
                            TxtOtro.Text = OtroDato
                        End If
                        TxtOtro.Text = OtroDato
                        TxtOtro.Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & ",TXTOTRO,"
                        TxtOtro.TabIndex = TabIndice
                        TxtOtro.TabStop = True
                        GroupBox(PosicionGroupBox).Controls.Add(TxtOtro)
                        PosicionY(Nivel) += TxtOtro.Height + 8

                        TabIndice += 1
                    Else
                        PosicionY(Nivel) += Check.Height + 8
                    End If
                    ValorSi = False
                    ValorNo = False
                    OtroDato = ""
                    If i + 1 <= BDTabla.Rows.Count - 1 Then
                        If (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5 < Nivel Then
                            If ContNivel = True Then
                                PosicionY(Nivel) = GroupBox(PosicionGroupBox).Top + GroupBox(PosicionGroupBox).Height + 8
                                PosicionY(Nivel - 1) = GroupBox(PosicionGroupBox - 1).Top + GroupBox(PosicionGroupBox - 1).Height + 8
                                ContNivel = False
                            Else
                                PosicionY(Nivel - 1) = GroupBox(PosicionGroupBox).Top + GroupBox(PosicionGroupBox).Height + 8
                            End If
                        End If
                    End If
                    Bandera = 1
                ElseIf BDTabla.Rows.Item(i).Item("TIPODATO") = "T" Then
                    Dim LblDato As New Label
                    LblDato.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                    LblDato.Location = New Point(11, PosicionY(Nivel))
                    LblDato.AutoSize = True
                    LblDato.TabIndex = TabIndice
                    LblDato.Text = BDTabla.Rows.Item(i).Item("DESCRIPCION")

                    TabIndice += 1

                    'SE AGREGA EL CODIGO PARA LLENAR LOS CONTROLES CUANDO SE CONSULTA UN DISEÑO
                    If CvePrenda > 0 Then
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM PRENDA_DETALLE WHERE CVE_PRENDA = " & CvePrenda & " AND NIVEL = '" & BDTabla.Rows.Item(i).Item("NIVEL") & "'"
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            BDReader.Read()
                            Dato = BDReader("DATO")
                        End If
                        BDReader.Close()
                        BDComando.Connection.Close()
                    End If
                    '*****************************************************************************

                    Dim TxtDato As New Controls.TextBoxX
                    TxtDato.Height = 20
                    TxtDato.Width = 200
                    TxtDato.CharacterCasing = CharacterCasing.Upper
                    TxtDato.FocusHighlightEnabled = True
                    TxtDato.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                    TxtDato.Name = "TXT" & BDTabla.Rows.Item(i).Item("NIVEL")
                    TxtDato.BorderStyle = BorderStyle.FixedSingle
                    TxtDato.Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & ",TXT,"
                    TxtDato.TabIndex = TabIndice
                    TxtDato.TabStop = True
                    If CvePrenda > 0 Then
                        TxtDato.Text = Dato
                        Dato = ""
                    End If
                    GroupBox(PosicionGroupBox).Controls.Add(LblDato)
                    GroupBox(PosicionGroupBox).Controls.Add(TxtDato)
                    TxtDato.Location = New Point(LblDato.Location.X.ToString + LblDato.Width + 20, PosicionY(Nivel))
                    PosicionY(Nivel) += TxtDato.Height + 8
                    PosicionY(Nivel - 1) = GroupBox(PosicionGroupBox).Top + GroupBox(PosicionGroupBox).Height + 8

                    TabIndice += 1

                    If i + 1 <= BDTabla.Rows.Count - 1 Then
                        If (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5 = Nivel And (BDTabla.Rows.Item(i + 1).Item("TIPODATO") = "O" Or BDTabla.Rows.Item(i + 1).Item("TIPODATO") = "C") Then
                            ContadorGroupBox += 1
                            ReDim Preserve GroupBox(ContadorGroupBox)
                            GroupBox(ContadorGroupBox) = New GroupBox
                            GroupBox(ContadorGroupBox).AutoSize = True
                            GroupBox(ContadorGroupBox).Width = AnchoGrupo - (Nivel * 20)
                            GroupBox(ContadorGroupBox).Height = 35
                            GroupBox(ContadorGroupBox).Location = New Point(11, PosicionY(Nivel))
                            GroupBox(ContadorGroupBox).Name = "CTRL" & BDTabla.Rows.Item(i).Item("NIVEL")
                            GroupBox(ContadorGroupBox).Tag = BDTabla.Rows.Item(i).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(i).Item("NIVELNUMERICO") & ",,"
                            GroupBox(ContadorGroupBox).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                            GroupBox(ContadorGroupBox).TabIndex = TabIndice
                            GroupBox(PosicionGroupBox).Controls.Add(GroupBox(ContadorGroupBox))
                            PosicionGroupBox = ContadorGroupBox
                            PosicionY(Nivel) = 20
                            ContNivel = True

                            TabIndice += 1
                        ElseIf (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5 < Nivel Then
                            If NivelAnt - ((Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5) > 1 Then
                                For Contador As Integer = 1 To ContadorGroupBox
                                    If GroupBox(Contador).Name = "CTRL" & Strings.Left(BDTabla.Rows.Item(i).Item("NIVEL"), Len(BDTabla.Rows.Item(i).Item("NIVEL")) - ((NivelAnt - (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2 - 0.5)) * 2)) Then
                                        PosicionY(Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2 - 0.5) = GroupBox(Contador).Top + GroupBox(Contador).Height + 8
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    End If
                    Bandera = 1
                ElseIf BDTabla.Rows.Item(i).Item("TIPODATO") = "H" Or BDTabla.Rows.Item(i).Item("TIPODATO") = "TE" Then
                    'SE AGREGA EL CODIGO PARA LLENAR LOS CONTROLES CUANDO SE CONSULTA UN DISEÑO
                    If CvePrenda > 0 Then
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM PRENDA_DETALLE WHERE CVE_PRENDA = " & CvePrenda & " AND NIVEL = '" & BDTabla.Rows.Item(i).Item("NIVEL") & "'"
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            BDReader.Read()
                            Dato = BDReader("DATO")
                        End If
                        BDReader.Close()
                        BDComando.Connection.Close()
                    End If
                    '*****************************************************************************
                    AgregarCveHabilitacion(PosicionY(Nivel), False, False, i, IIf(BDTabla.Rows.Item(i).Item("TIPODATO") = "H", "CVE. HABILITACION", IIf(BDTabla.Rows.Item(i).Item("TIPODATO") = "TE", "CVE. TELA", "")), IIf(IsDBNull(BDTabla.Rows.Item(i).Item("GRUPOHABILITACION")), "", BDTabla.Rows.Item(i).Item("GRUPOHABILITACION")))
                    Dato = ""
                    If i + 1 <= BDTabla.Rows.Count - 1 Then
                        If (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5 > Nivel Then
                            NivelAnt = (Len(BDTabla.Rows.Item(i + 1).Item("NIVEL")) / 2) - 0.5
                            PosicionGroupBox = ContadorGroupBox
                        End If
                    End If
                    Bandera = 1
                End If
            Next
        End If
    End Sub

    Private Sub AgregarControlBit(ByVal Y As Long, ByVal ValorSi As Boolean, ByVal ValorNo As Boolean, ByVal RegActual As Integer, ByVal NivelSiNo As String)
        Dim LabelBit As New Label
        Dim GroupBit As New GroupBox
        Dim OpcBitSi As New RadioButton
        Dim OpcBitNo As New RadioButton

        LabelBit.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        LabelBit.Location = New Point(11, Y + 15)
        LabelBit.AutoSize = True
        LabelBit.TabIndex = TabIndice
        LabelBit.Text = BDTabla.Rows.Item(RegActual).Item("DESCRIPCION")

        TabIndice += 1

        GroupBit.Height = 35
        GroupBit.Width = 100
        GroupBit.TabIndex = TabIndice
        GroupBit.Tag = BDTabla.Rows.Item(RegActual).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(RegActual).Item("NIVELNUMERICO") & ",SINO,"
        GroupBit.Name = "SINO" & BDTabla.Rows.Item(RegActual).Item("NIVEL")
        'PanDetallePrenda.Controls.Add(GroupBit)

        TabIndice += 1

        OpcBitSi.Height = 17
        OpcBitSi.Width = 45
        OpcBitSi.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        OpcBitSi.Location = New Point(6, 12)
        OpcBitSi.Name = "OPCSI" & NivelSiNo
        OpcBitSi.Text = "SI"
        OpcBitSi.TabIndex = TabIndice
        OpcBitSi.TabStop = True
        If ValorSi = True Then
            OpcBitSi.Checked = True
        End If
        AddHandler OpcBitSi.CheckedChanged, AddressOf RBSiNo_CheckedChanged
        GroupBit.Controls.Add(OpcBitSi)

        TabIndice += 1

        OpcBitNo.Height = 17
        OpcBitNo.Width = 45
        OpcBitNo.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        OpcBitNo.Location = New Point(54, 12)
        OpcBitNo.Name = "OPCNO" & NivelSiNo
        OpcBitNo.Text = "NO"
        OpcBitNo.TabIndex = TabIndice
        OpcBitNo.TabStop = True
        If ValorNo = True Then
            OpcBitNo.Checked = True
        End If
        AddHandler OpcBitNo.CheckedChanged, AddressOf RBSiNo_CheckedChanged
        GroupBit.Controls.Add(OpcBitNo)

        TabIndice += 1

        GroupBox(PosicionGroupBox).Controls.Add(LabelBit)
        GroupBox(PosicionGroupBox).Controls.Add(GroupBit)
        GroupBit.Location = New Point(LabelBit.Location.X.ToString + LabelBit.Width + 20, Y)
        PosicionY(Nivel) += GroupBit.Height + 8
    End Sub

    Private Sub AgregarCveHabilitacion(ByVal Y As Long, ByVal ValorSi As Boolean, ByVal ValorNo As Boolean, ByVal RegActual As Integer, ByVal Texto As String, ByVal GrupoHabilitacion As String)
        Dim LabelCveHabilitacion As New Label
        Dim TxtCveHabilitacion As New Controls.TextBoxX
        Dim LabelDescripcionHabilitacion As New Label

        LabelCveHabilitacion.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        LabelCveHabilitacion.Location = New Point(11, 15)
        LabelCveHabilitacion.AutoSize = True
        LabelCveHabilitacion.Text = Texto
        LabelCveHabilitacion.TabIndex = TabIndice

        TabIndice += 1

        ContadorGroupBox += 1
        ReDim Preserve GroupBox(ContadorGroupBox)
        GroupBox(ContadorGroupBox) = New GroupBox
        GroupBox(ContadorGroupBox).AutoSize = True
        GroupBox(ContadorGroupBox).Width = AnchoGrupo - (Nivel * 20)
        GroupBox(ContadorGroupBox).Height = 35
        GroupBox(ContadorGroupBox).Height = 35
        GroupBox(ContadorGroupBox).Location = New Point(11, PosicionY(Nivel))
        GroupBox(ContadorGroupBox).Tag = BDTabla.Rows.Item(RegActual).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(RegActual).Item("NIVELNUMERICO") & "," & Texto & ","
        GroupBox(ContadorGroupBox).Name = "CTRL" & BDTabla.Rows.Item(RegActual).Item("NIVEL")
        GroupBox(ContadorGroupBox).Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        GroupBox(ContadorGroupBox).TabIndex = TabIndice
        GroupBox(PosicionGroupBox).Controls.Add(GroupBox(ContadorGroupBox))
        GroupBox(ContadorGroupBox).Height = 35
        If RegActual + 1 <= BDTabla.Rows.Count - 1 Then
            If (Len(BDTabla.Rows.Item(RegActual + 1).Item("NIVEL")) / 2) - 0.5 > Nivel Then
                PosicionGroupBox = ContadorGroupBox
            End If
        End If

        TabIndice += 1

        GroupBox(ContadorGroupBox).Controls.Add(LabelCveHabilitacion)
        TxtCveHabilitacion.Height = 20
        TxtCveHabilitacion.Width = 200
        TxtCveHabilitacion.FocusHighlightEnabled = True
        TxtCveHabilitacion.CharacterCasing = CharacterCasing.Upper
        TxtCveHabilitacion.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
        TxtCveHabilitacion.Location = New Point(LabelCveHabilitacion.Location.X.ToString + LabelCveHabilitacion.Width + 20, 15)
        TxtCveHabilitacion.Name = "TXTHT" & BDTabla.Rows.Item(RegActual).Item("NIVEL")
        TxtCveHabilitacion.Tag = BDTabla.Rows.Item(RegActual).Item("DESCRIPCION") & "," & BDTabla.Rows.Item(RegActual).Item("NIVELNUMERICO") & "," & IIf(Texto = "CVE. HABILITACION", "CVEHABILITACION", "CVETELA") & "," & GrupoHabilitacion
        If CvePrenda > 0 Then
            TxtCveHabilitacion.Text = Dato
        Else
            TxtCveHabilitacion.Text = ""
        End If
        TxtCveHabilitacion.TabIndex = TabIndice
        TxtCveHabilitacion.TabStop = True
        If Texto = "CVE. HABILITACION" Then
            AddHandler TxtCveHabilitacion.KeyUp, AddressOf TxtHabilitacion_KeyUp
            AddHandler TxtCveHabilitacion.Leave, AddressOf TxtHabilitacion_Leave
        ElseIf Texto = "CVE. TELA" Then
            AddHandler TxtCveHabilitacion.KeyUp, AddressOf TxtTela_KeyUp
            AddHandler TxtCveHabilitacion.Leave, AddressOf TxtTela_Leave
        End If
        GroupBox(ContadorGroupBox).Controls.Add(TxtCveHabilitacion)

        TabIndice += 1

        LabelDescripcionHabilitacion.Height = 50
        LabelDescripcionHabilitacion.Width = 300
        LabelDescripcionHabilitacion.AutoSize = False
        LabelDescripcionHabilitacion.Text = ""
        LabelDescripcionHabilitacion.Location = New Point(TxtCveHabilitacion.Location.X.ToString + TxtCveHabilitacion.Width + 20, 15)
        LabelDescripcionHabilitacion.Name = "CTRLLBL" & BDTabla.Rows.Item(RegActual).Item("NIVEL")
        LabelDescripcionHabilitacion.TabIndex = TabIndice
        GroupBox(ContadorGroupBox).Controls.Add(LabelDescripcionHabilitacion)

        TabIndice += 1

        PosicionY(Nivel) += GroupBox(ContadorGroupBox).Height + 8
        PosicionY(Nivel + 1) = TxtCveHabilitacion.Top + TxtCveHabilitacion.Height + 8
    End Sub

    Private Sub TxtHabilitacion_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        Dim Descripcion As String = ""
        Dim Aux As Integer = 0
        If e.KeyCode = Keys.Enter Then
            Aux = Strings.InStr(sender.tag, ",")
            Aux = Strings.InStr(Aux + 1, sender.tag, ",")
            Aux = Strings.InStr(Aux + 1, sender.tag, ",")
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "SELECT * FROM HABILITACION_GRUPO WHERE CVE_GRUPO = '" & Mid(sender.TAG, Aux + 1, Len(sender.tag) - Aux) & "'"
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                BDReader.Read()
                Descripcion = BDReader("DESCRIPCION")
            End If
            BDReader.Close()
            BDComando.Connection.Close()
            sender.TEXT = ""
            Dim FrmBuscarHabilitacion As New FrmHabilitaciones
            FrmBuscarHabilitacion.TipoEntrada = "DISEÑOPRENDA"
            FrmBuscarHabilitacion.Busqueda = Descripcion & " " & Mid(sender.TAG, Aux + 1, Len(sender.tag) - Aux)
            FrmBuscarHabilitacion.ShowDialog(Me)
            'Dim FrmBuscarHabilitacion As New FrmSeleccionarHabilitacion
            'FrmBuscarHabilitacion.Busqueda = Mid(sender.TAG, Aux + 1, Len(sender.tag) - Aux)
            'FrmBuscarHabilitacion.ShowDialog(Me)
            sender.text = Clave
            For Contador As Integer = 1 To GroupBox.Count - 1
                If GroupBox(Contador).Name = "CTRL" & Strings.Right(sender.name, Len(sender.name) - 5) Then
                    PosicionGroupBox = Contador
                    Exit For
                End If
            Next
            GroupBox(PosicionGroupBox).Controls.Item("CTRLLBL" & Strings.Right(sender.name, Len(sender.name) - 5)).Text = DescripcionClave
            Clave = ""
            DescripcionClave = ""
        End If
    End Sub

    Private Sub TxtTela_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        Dim Descripcion As String = ""
        If e.KeyCode = Keys.Enter Then
            sender.TEXT = ""
            Dim FrmBuscarTela As New FrmSufijosTela
            FrmBuscarTela.TipoEntrada = "DISEÑOPRENDA"
            FrmBuscarTela.ShowDialog(Me)
            sender.text = Clave
            For Contador As Integer = 1 To GroupBox.Count - 1
                If GroupBox(Contador).Name = "CTRL" & Strings.Right(sender.name, Len(sender.name) - 5) Then
                    PosicionGroupBox = Contador
                    Exit For
                End If
            Next
            GroupBox(PosicionGroupBox).Controls.Item("CTRLLBL" & Strings.Right(sender.name, Len(sender.name) - 5)).Text = DescripcionClave
            Clave = ""
            DescripcionClave = ""
        End If
    End Sub

    Private Sub RBOtro_CheckedChanged(sender As System.Object, e As System.EventArgs)
        PosicionGroupBox = 0
        For Contador As Integer = 1 To GroupBox.Count - 1
            If GroupBox(Contador).Name = "CTRL" & Strings.Left(Strings.Right(sender.name, Len(sender.name) - 7), Len(Strings.Right(sender.name, Len(sender.name) - 7)) - 2) Then
                PosicionGroupBox = Contador
                Exit For
            End If
        Next
        If sender.CHECKED = True Then
            GroupBox(PosicionGroupBox).Controls.Item("TXTOTRO" & Strings.Right(sender.name, Len(sender.name) - 7)).Enabled = True
        Else
            GroupBox(PosicionGroupBox).Controls.Item("TXTOTRO" & Strings.Right(sender.name, Len(sender.name) - 7)).Text = ""
            GroupBox(PosicionGroupBox).Controls.Item("TXTOTRO" & Strings.Right(sender.name, Len(sender.name) - 7)).Enabled = False
        End If
    End Sub

    Private Sub RBSiNo_CheckedChanged(sender As System.Object, e As System.EventArgs)
        PosicionGroupBox = 0
        For Contador As Integer = 1 To GroupBox.Count - 1
            If GroupBox(Contador).Name = "CTRL" & Strings.Right(sender.name, Len(sender.name) - 5) Then
                PosicionGroupBox = Contador
                Exit For
            End If
        Next
        If PosicionGroupBox > 0 Then
            If Strings.Left(sender.NAME, 5) = "OPCSI" Then
                GroupBox(PosicionGroupBox).Enabled = True
            ElseIf Strings.Left(sender.NAME, 5) = "OPCNO" Then
                GroupBox(PosicionGroupBox).Enabled = False
            End If
        End If
    End Sub

    Private Sub VerificaDatosLlenado()
        Dim Objeto As System.Object
        Dim ContadorSiNo As Integer = 0
        Dim Seccion As Integer = 0
        Dim DescripcionSeccion As String = ""
        Dim Aux As Integer = 0
        Mensaje = ""
        For Contador As Integer = 0 To PanDetallePrenda.Controls.Count - 1
            If PanDetallePrenda.Controls(Contador).GetType.ToString() = "System.Windows.Forms.GroupBox" And PanDetallePrenda.Controls(Contador).Enabled = True And Strings.Left(PanDetallePrenda.Controls(Contador).Name, 4) = "SINO" Then
                ContadorSiNo = 0
                DescripcionSeccion = Strings.Left(PanDetallePrenda.Controls(Contador).Tag, InStr(PanDetallePrenda.Controls(Contador).Tag, ",") - 1)
                Seccion = Strings.Mid(PanDetallePrenda.Controls(Contador).Tag, InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1, (InStr(InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1, PanDetallePrenda.Controls(Contador).Tag, ",")) - (InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1))
                For Contador1 = 0 To PanDetallePrenda.Controls(Contador).Controls.Count - 1
                    If PanDetallePrenda.Controls(Contador).Controls(Contador1).GetType.ToString = "System.Windows.Forms.RadioButton" Then
                        Objeto = PanDetallePrenda.Controls(Contador).Controls(Contador1)
                        If Objeto.checked = True Then
                            ContadorSiNo += 1
                        End If
                    End If
                Next
                If ContadorSiNo = 0 Then
                    Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta Seleccionar una opción" & vbCrLf
                End If
            ElseIf PanDetallePrenda.Controls(Contador).GetType.ToString() = "System.Windows.Forms.GroupBox" And PanDetallePrenda.Controls(Contador).Enabled = True Then
                Objeto = PanDetallePrenda.Controls(Contador)
                LeeControles(Objeto)
            ElseIf PanDetallePrenda.Controls(Contador).GetType.ToString() = "DevComponents.DotNetBar.Controls.TextBoxX" Then
                Aux = InStr(PanDetallePrenda.Controls(Contador).Tag, ",")
                Aux = InStr(Aux, PanDetallePrenda.Controls(Contador).Tag, ",")
                Aux += 1
                If Mid(PanDetallePrenda.Controls(Contador).Tag, Aux, InStr(Aux, PanDetallePrenda.Controls(Contador).Tag, ",") - Aux) = "CVETELA" Or Mid(PanDetallePrenda.Controls(Contador).Tag, Aux, InStr(Aux, PanDetallePrenda.Controls(Contador).Tag, ",") - Aux) = "CVEHABILITACION" Then
                    If Mid(PanDetallePrenda.Controls(Contador).Tag, Aux, InStr(Aux, PanDetallePrenda.Controls(Contador).Tag, ",") - Aux) = "CVETELA" Then
                        If PanDetallePrenda.Controls(Contador).Text = "" Then
                            Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta seleccionar una clave de Tela o escribir la palabra GENERICO" & vbCrLf
                        ElseIf IsNumeric(PanDetallePrenda.Controls(Contador).Text) = False Then
                            If PanDetallePrenda.Controls(Contador).Text <> "GENERICO" Then
                                Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Debe escribir una clave de Tela Valida o la palabra GENERICO" & vbCrLf
                            End If
                        End If
                    ElseIf Mid(PanDetallePrenda.Controls(Contador).Tag, Aux, InStr(Aux, PanDetallePrenda.Controls(Contador).Tag, ",") - Aux) = "CVEHABILITACION" Then
                        If PanDetallePrenda.Controls(Contador).Text = "" Then
                            Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta seleccionar una clave de Habilitación o escribir GENERICO" & vbCrLf
                        End If
                    End If
                End If
            ElseIf PanDetallePrenda.Controls(Contador).GetType.ToString() = "System.Windows.Forms.RadioButton" Then
                Objeto = PanDetallePrenda.Controls(Contador)
                If ControlAnterior = False Then
                    ContadorRadioButtonSi = 0
                    ControlAnterior = True
                    DescripcionSeccion = Strings.Left(PanDetallePrenda.Tag, InStr(PanDetallePrenda.Tag, ",") - 1)
                    Seccion = Strings.Mid(PanDetallePrenda.Controls(Contador).Tag, InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1, (InStr(InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1, PanDetallePrenda.Controls(Contador).Tag, ",")) - (InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1))
                    If Objeto.CHECKED = True Then
                        ContadorRadioButtonSi += 1
                    End If
                ElseIf PanDetallePrenda.Controls.Count = Contador + 1 Or Objeto.TEXT = "OTRO" Then
                    If Objeto.checked = True Then
                        ContadorRadioButtonSi += 1
                        Contador += 1
                        Objeto = PanDetallePrenda.Controls(Contador)
                        If Trim(Objeto.TEXT) = "" Then
                            Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta escribir una descripción de la opción otro" & vbCrLf
                        End If
                    End If
                    If ContadorRadioButtonSi = 0 Then
                        Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta seleccionar una opción" & vbCrLf
                    End If
                    ControlAnterior = False
                ElseIf Objeto.checked = True Then
                    ContadorRadioButtonSi += 1
                End If
            End If
        Next
        If DGVProcesosSeleccionados.Rows.Count = 0 Then
            Mensaje += "-Agregar por lo menos un Proceso." & vbCrLf
        Else
            For Contador As Integer = 0 To DGVProcesosSeleccionados.Rows.Count - 1
                If IsNumeric(DGVProcesosSeleccionados.Item(4, Contador).Value) = False Then
                    Mensaje += "-El proceso " & DGVProcesosSeleccionados.Item(3, Contador).Value & ", falta definir el orden." & vbCrLf
                End If
            Next
        End If

    End Sub

    Private Sub LeeControles(ByVal ObjetoHeredado As System.Object)
        Dim ContadorSiNo As Integer = 0
        Dim DescripcionSeccion As String = ""
        Dim Seccion As Integer = 0
        Dim Objeto As System.Object
        Dim Aux As Integer = 0
        For Contador As Integer = 0 To ObjetoHeredado.controls.count - 1
            If ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.GroupBox" And ObjetoHeredado.Controls(Contador).Enabled = True And Strings.Left(ObjetoHeredado.Controls(Contador).Name, 4) = "SINO" Then
                ContadorSiNo = 0
                DescripcionSeccion = Strings.Left(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") - 1)
                Seccion = Strings.Mid(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, (InStr(InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, ObjetoHeredado.Controls(Contador).Tag, ",")) - (InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1))
                For Contador1 = 0 To ObjetoHeredado.Controls(Contador).Controls.Count - 1
                    If ObjetoHeredado.Controls(Contador).Controls(Contador1).GetType.ToString() = "System.Windows.Forms.RadioButton" Then
                        Objeto = ObjetoHeredado.Controls(Contador).Controls(Contador1)
                        If Objeto.checked = True Then
                            ContadorSiNo += 1
                        End If
                    End If
                Next
                If ContadorSiNo = 0 Then
                    Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta Seleccionar una opción" & vbCrLf
                End If
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.GroupBox" And ObjetoHeredado.Controls(Contador).Enabled = True Then
                Objeto = ObjetoHeredado.Controls(Contador)
                LeeControles(Objeto)
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "DevComponents.DotNetBar.Controls.TextBoxX" And ObjetoHeredado.Controls(Contador).Enabled = True Then
                Objeto = ObjetoHeredado.Controls(Contador)
                Seccion = Strings.Mid(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, (InStr(InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, ObjetoHeredado.Controls(Contador).Tag, ",")) - (InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1))
                Aux = InStr(ObjetoHeredado.Controls(Contador).Tag, ",")
                Aux = InStr(Aux + 1, ObjetoHeredado.Controls(Contador).Tag, ",")
                Aux += 1
                If Mid(ObjetoHeredado.Controls(Contador).Tag, Aux, InStr(Aux, ObjetoHeredado.Controls(Contador).Tag, ",") - Aux) = "CVETELA" Or Mid(ObjetoHeredado.Controls(Contador).Tag, Aux, InStr(Aux, ObjetoHeredado.Controls(Contador).Tag, ",") - Aux) = "CVEHABILITACION" Then
                    If Mid(ObjetoHeredado.Controls(Contador).Tag, Aux, InStr(Aux, ObjetoHeredado.Controls(Contador).Tag, ",") - Aux) = "CVETELA" Then
                        If ObjetoHeredado.Controls(Contador).text = "" Then
                            Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta seleccionar una clave de Tela o escribir la palabra GENERICO" & vbCrLf
                        ElseIf IsNumeric(ObjetoHeredado.Controls(Contador).text) = False Then
                            If ObjetoHeredado.Controls(Contador).text <> "GENERICO" Then
                                Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Debe escribir una clave de Tela Valida o la palabra GENERICO" & vbCrLf
                            End If
                        End If
                    ElseIf Mid(ObjetoHeredado.Controls(Contador).Tag, Aux, InStr(Aux, ObjetoHeredado.Controls(Contador).Tag, ",") - Aux) = "CVEHABILITACION" Then
                        'MessageBox.Show(ObjetoHeredado.Controls(Contador).Tag)
                        'MessageBox.Show(ObjetoHeredado.Controls(Contador).text)
                        If ObjetoHeredado.Controls(Contador).text = "" Then
                            Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta seleccionar una clave de Habilitación o escribir GENERICO" & vbCrLf
                        End If
                    End If
                Else
                    DescripcionSeccion = Strings.Left(Objeto.Tag, InStr(Objeto.Tag, ",") - 1)
                    If Trim(Objeto.text) = "" Then
                        Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta una descripción" & vbCrLf
                    End If
                End If
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.RadioButton" Then
                Objeto = ObjetoHeredado.Controls(Contador)
                If ControlAnterior = False Then
                    ContadorRadioButtonSi = 0
                    ControlAnterior = True
                    DescripcionSeccion = Strings.Left(ObjetoHeredado.Tag, InStr(ObjetoHeredado.Tag, ",") - 1)
                    Seccion = Strings.Mid(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, (InStr(InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, ObjetoHeredado.Controls(Contador).Tag, ",")) - (InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1))
                    If Objeto.CHECKED = True Then
                        ContadorRadioButtonSi += 1
                    End If
                ElseIf ObjetoHeredado.CONTROLS.COUNT = Contador + 1 Or Objeto.TEXT = "OTRO" Then
                    If Objeto.checked = True Then
                        ContadorRadioButtonSi += 1
                        If Objeto.text = "OTRO" Then
                            Contador += 1
                            Objeto = ObjetoHeredado.Controls(Contador)
                            If Trim(Objeto.TEXT) = "" Then
                                Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta escribir una descripción de la opción otro" & vbCrLf
                            End If
                        End If
                    End If
                    If ContadorRadioButtonSi = 0 Then
                        Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta seleccionar una opción" & vbCrLf
                    End If
                    ControlAnterior = False
                ElseIf Objeto.checked = True Then
                    ContadorRadioButtonSi += 1
                End If
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.CheckBox" Then
                Objeto = ObjetoHeredado.Controls(Contador)
                If ControlAnterior = False Then
                    ContadorRadioButtonSi = 0
                    ControlAnterior = True
                    DescripcionSeccion = Strings.Left(ObjetoHeredado.Tag, InStr(ObjetoHeredado.Tag, ",") - 1)
                    Seccion = Strings.Mid(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, (InStr(InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, ObjetoHeredado.Controls(Contador).Tag, ",")) - (InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1))
                    If Objeto.CHECKED = True Then
                        ContadorRadioButtonSi += 1
                    End If
                ElseIf ObjetoHeredado.CONTROLS.COUNT = Contador + 1 Or Objeto.TEXT = "OTRO" Then
                    If Objeto.checked = True Then
                        ContadorRadioButtonSi += 1
                        If Objeto.text = "OTRO" Then
                            Contador += 1
                            Objeto = ObjetoHeredado.Controls(Contador)
                            If Trim(Objeto.TEXT) = "" Then
                                Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta escribir una descripción de la opción otro" & vbCrLf
                            End If
                        End If
                    End If
                    If ContadorRadioButtonSi = 0 Then
                        Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Falta seleccionar máximo dos opciones" & vbCrLf
                    ElseIf ContadorRadioButtonSi > 2 Then
                        Mensaje += "-Sección " & Seccion & ": " & DescripcionSeccion & ": Debe seleccionar máximo dos opciones" & vbCrLf
                    End If
                    ControlAnterior = False
                ElseIf Objeto.checked = True Then
                    ContadorRadioButtonSi += 1
                End If
            End If
        Next
    End Sub

    Private Sub PreparaMatrizGuardado()
        Dim Objeto As System.Object
        Dim Aux As Integer = 0
        Dato = ""
        OtroDato = ""
        For Contador As Integer = 0 To PanDetallePrenda.Controls.Count - 1
            If PanDetallePrenda.Controls(Contador).GetType.ToString() = "System.Windows.Forms.GroupBox" And PanDetallePrenda.Controls(Contador).Enabled = True And Strings.Left(PanDetallePrenda.Controls(Contador).Name, 4) = "SINO" Then
                SeccionGuardado = Strings.Mid(PanDetallePrenda.Controls(Contador).Tag, InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1, (InStr(InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1, PanDetallePrenda.Controls(Contador).Tag, ",")) - (InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1))
                DescripcionSeccionGuardado = Strings.Left(PanDetallePrenda.Controls(Contador).Tag, InStr(PanDetallePrenda.Controls(Contador).Tag, ",") - 1)
                NivelLetra = Strings.Right(PanDetallePrenda.Controls(Contador).Name, Len(PanDetallePrenda.Controls(Contador).Name) - 4)
                For Contador1 = 0 To PanDetallePrenda.Controls(Contador).Controls.Count - 1
                    If PanDetallePrenda.Controls(Contador).Controls(Contador1).GetType.ToString = "System.Windows.Forms.RadioButton" Then
                        Objeto = PanDetallePrenda.Controls(Contador).Controls(Contador1)
                        If Objeto.checked = True Then
                            If Objeto.TEXT = "SI" Then
                                For Registros = 0 To BDTabla.Rows.Count - 1
                                    If BDTabla.Rows.Item(Registros).Item("NIVEL") = NivelLetra Then
                                        Aux = Registros
                                        Exit For
                                    End If
                                Next
                                If BDTabla.Rows.Item(Aux + 1).Item("TIPODATO") = "O" Or BDTabla.Rows.Item(Aux + 1).Item("TIPODATO") = "C" Then
                                Else
                                    GuardarPrendaDetalleBD()
                                    'MsgBox(SeccionGuardado & " - " & NivelLetra)
                                End If
                            End If
                        End If
                    End If
                Next
            ElseIf PanDetallePrenda.Controls(Contador).GetType.ToString() = "System.Windows.Forms.GroupBox" And PanDetallePrenda.Controls(Contador).Enabled = True Then
                For Registros = 0 To BDTabla.Rows.Count - 1
                    If BDTabla.Rows.Item(Registros).Item("NIVEL") = Strings.Right(PanDetallePrenda.Controls(Contador).Name, Len(PanDetallePrenda.Controls(Contador).Name) - 4) Then
                        Aux = Registros
                        Exit For
                    End If
                Next

                SeccionGuardado = Strings.Mid(PanDetallePrenda.Controls(Contador).Tag, InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1, (InStr(InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1, PanDetallePrenda.Controls(Contador).Tag, ",")) - (InStr(PanDetallePrenda.Controls(Contador).Tag, ",") + 1))
                DescripcionSeccionGuardado = Strings.Left(PanDetallePrenda.Controls(Contador).Tag, InStr(PanDetallePrenda.Controls(Contador).Tag, ",") - 1)
                NivelLetra = Strings.Right(PanDetallePrenda.Controls(Contador).Name, Len(PanDetallePrenda.Controls(Contador).Name) - 4)

                If BDTabla.Rows.Count - 1 > Aux Then
                    If BDTabla.Rows.Item(Aux).Item("TIPODATO") = "S" And BDTabla.Rows.Item(Aux + 1).Item("TIPODATO") <> "O" And BDTabla.Rows.Item(Aux + 1).Item("TIPODATO") <> "C" Then
                        GuardarPrendaDetalleBD()
                        'MsgBox(SeccionGuardado & " - " & NivelLetra)
                    End If
                ElseIf BDTabla.Rows.Item(Aux).Item("TIPODATO") = "S" Then
                    GuardarPrendaDetalleBD()
                    'MsgBox(SeccionGuardado & " - " & NivelLetra)
                End If
                Objeto = PanDetallePrenda.Controls(Contador)
                MatrizGuardadoControles(Objeto)
            ElseIf PanDetallePrenda.Controls(Contador).GetType.ToString() = "DevComponents.DotNetBar.Controls.TextBoxX" Then
                Aux = InStr(PanDetallePrenda.Controls(Contador).Tag, ",")
                Aux = InStr(Aux, PanDetallePrenda.Controls(Contador).Tag, ",")
                Aux += 1
                If Mid(PanDetallePrenda.Controls(Contador).Tag, Aux, InStr(Aux, PanDetallePrenda.Controls(Contador).Tag, ",") - Aux) = "CVETELA" Or Mid(PanDetallePrenda.Controls(Contador).Tag, Aux, InStr(Aux, PanDetallePrenda.Controls(Contador).Tag, ",") - Aux) = "CVEHABILITACION" Then
                    Dato = PanDetallePrenda.Controls(Contador).Text
                    GuardarPrendaDetalleBD()
                    'MessageBox.Show(SeccionGuardado & " - " & NivelLetra & " " & Dato)
                    Dato = ""
                    OtroDato = ""
                End If
            End If
        Next
    End Sub

    Private Sub MatrizGuardadoControles(ByVal ObjetoHeredado As System.Object)
        Dim ContadorSiNo As Integer = 0
        Dim Objeto As System.Object
        Dim Aux As Integer = 0
        For Contador As Integer = 0 To ObjetoHeredado.controls.count - 1
            If ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.GroupBox" And ObjetoHeredado.Controls(Contador).Enabled = True And Strings.Left(ObjetoHeredado.Controls(Contador).Name, 4) = "SINO" Then
                SeccionGuardado = Strings.Mid(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, (InStr(InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, ObjetoHeredado.Controls(Contador).Tag, ",")) - (InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1))
                DescripcionSeccionGuardado = Strings.Left(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") - 1)
                NivelLetra = Strings.Right(ObjetoHeredado.Controls(Contador).Name, Len(ObjetoHeredado.Controls(Contador).Name) - 4)
                For Contador1 = 0 To ObjetoHeredado.Controls(Contador).Controls.Count - 1
                    If ObjetoHeredado.Controls(Contador).Controls(Contador1).GetType.ToString() = "System.Windows.Forms.RadioButton" Then
                        Objeto = ObjetoHeredado.Controls(Contador).Controls(Contador1)
                        If Objeto.checked = True Then
                            If Objeto.TEXT = "SI" Then
                                For Registros = 0 To BDTabla.Rows.Count - 1
                                    If BDTabla.Rows.Item(Registros).Item("NIVEL") = NivelLetra Then
                                        Aux = Registros
                                        Exit For
                                    End If
                                Next
                                If BDTabla.Rows.Count - 1 > Aux + 1 Then
                                    If BDTabla.Rows.Item(Aux + 1).Item("TIPODATO") <> "O" And BDTabla.Rows.Item(Aux + 1).Item("TIPODATO") <> "C" And IsDBNull(BDTabla.Rows.Item(Aux).Item("TIPODATOSECUNDARIO")) = True Then
                                        GuardarPrendaDetalleBD()
                                        'MsgBox(SeccionGuardado & " - " & NivelLetra)
                                    End If
                                ElseIf IsDBNull(BDTabla.Rows.Item(Aux).Item("TIPODATOSECUNDARIO")) = True Then
                                    GuardarPrendaDetalleBD()
                                    'MsgBox(SeccionGuardado & " - " & NivelLetra)
                                End If
                            End If
                        End If
                    End If
                Next
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.GroupBox" And ObjetoHeredado.Controls(Contador).Enabled = True Then
                For Registros = 0 To BDTabla.Rows.Count - 1
                    If BDTabla.Rows.Item(Registros).Item("NIVEL") = Strings.Right(ObjetoHeredado.Controls(Contador).Name, Len(ObjetoHeredado.Controls(Contador).Name) - 4) Then
                        Aux = Registros
                        Exit For
                    End If
                Next

                SeccionGuardado = Strings.Mid(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, (InStr(InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, ObjetoHeredado.Controls(Contador).Tag, ",")) - (InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1))
                DescripcionSeccionGuardado = Strings.Left(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") - 1)
                NivelLetra = Strings.Right(ObjetoHeredado.Controls(Contador).Name, Len(ObjetoHeredado.Controls(Contador).Name) - 4)
                If BDTabla.Rows.Count - 1 > Aux Then
                    If BDTabla.Rows.Item(Aux).Item("TIPODATO") = "S" And BDTabla.Rows.Item(Aux + 1).Item("TIPODATO") <> "O" And BDTabla.Rows.Item(Aux + 1).Item("TIPODATO") <> "C" Then
                        GuardarPrendaDetalleBD()
                        'MsgBox(SeccionGuardado & " - " & NivelLetra)
                    End If
                ElseIf BDTabla.Rows.Item(Aux).Item("TIPODATO") = "S" Then
                    GuardarPrendaDetalleBD()
                    'MsgBox(SeccionGuardado & " - " & NivelLetra)
                End If
                Objeto = ObjetoHeredado.Controls(Contador)
                MatrizGuardadoControles(Objeto)
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "DevComponents.DotNetBar.Controls.TextBoxX" Then
                Objeto = ObjetoHeredado.Controls(Contador)
                Aux = InStr(ObjetoHeredado.Controls(Contador).Tag, ",")
                Aux = InStr(Aux + 1, ObjetoHeredado.Controls(Contador).Tag, ",")
                Aux += 1
                If Mid(ObjetoHeredado.Controls(Contador).Tag, Aux, InStr(Aux, ObjetoHeredado.Controls(Contador).Tag, ",") - Aux) = "CVETELA" Or Mid(ObjetoHeredado.Controls(Contador).Tag, Aux, InStr(Aux, ObjetoHeredado.Controls(Contador).Tag, ",") - Aux) = "CVEHABILITACION" Then
                    Dato = Objeto.Text
                    GuardarPrendaDetalleBD()
                    'MessageBox.Show(SeccionGuardado & " - " & NivelLetra & " " & Dato)
                    Dato = ""
                    OtroDato = ""
                ElseIf Objeto.enabled = True Then
                    SeccionGuardado = Strings.Mid(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, (InStr(InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1, ObjetoHeredado.Controls(Contador).Tag, ",")) - (InStr(ObjetoHeredado.Controls(Contador).Tag, ",") + 1))
                    DescripcionSeccionGuardado = Strings.Left(ObjetoHeredado.Controls(Contador).Tag, InStr(ObjetoHeredado.Controls(Contador).Tag, ",") - 1)
                    NivelLetra = Strings.Right(ObjetoHeredado.Controls(Contador).Name, Len(ObjetoHeredado.Controls(Contador).Name) - 3)
                    Dato = Objeto.text
                    GuardarPrendaDetalleBD()
                    'MessageBox.Show(SeccionGuardado & " - " & NivelLetra & " - " & Dato)
                    Dato = ""
                    OtroDato = ""
                End If
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.RadioButton" Then
                Objeto = ObjetoHeredado.Controls(Contador)
                If Objeto.checked = True Then
                    Dato = Strings.Right(Objeto.name, Len(Objeto.name) - 7)
                    If Objeto.text = "OTRO" Then
                        Contador += 1
                        Objeto = ObjetoHeredado.Controls(Contador)
                        OtroDato = Objeto.text
                    End If
                    GuardarPrendaDetalleBD()
                    'MsgBox(SeccionGuardado & " - " & NivelLetra & " - " & Dato & " - " & OtroDato)
                    Dato = ""
                    OtroDato = ""
                End If
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.CheckBox" Then
                Objeto = ObjetoHeredado.Controls(Contador)
                If Objeto.checked = True Then
                    Dato += Strings.Right(Objeto.name, Len(Objeto.name) - 3) & ","
                    If Objeto.text = "OTRO" Then
                        Contador += 1
                        Objeto = ObjetoHeredado.Controls(Contador)
                        OtroDato = Objeto.text
                        GuardarPrendaDetalleBD()
                        'MsgBox(SeccionGuardado & " - " & NivelLetra & " - " & Dato & " - " & OtroDato)
                        Dato = ""
                        OtroDato = ""
                    End If
                End If
                If Contador >= ObjetoHeredado.controls.count - 1 Then
                    GuardarPrendaDetalleBD()
                    'MsgBox(SeccionGuardado & " - " & NivelLetra & " - " & Dato & " - " & OtroDato)
                    Dato = ""
                    OtroDato = ""
                End If
            End If
        Next
    End Sub

    Private Sub ActivaBotonesConsulta()
        BtnNuevo.Enabled = True
        BtnEditar.Enabled = True
        BtnGuardar.Enabled = False
        BtnCancelar.Enabled = False
        BtnBaja.Enabled = False
    End Sub

    Private Sub ActivaBotonesModificar()
        BtnNuevo.Enabled = False
        BtnEditar.Enabled = False
        BtnGuardar.Enabled = True
        BtnCancelar.Enabled = True
        BtnBaja.Enabled = True
    End Sub

    Private Sub BtnNuevo_Click(sender As System.Object, e As System.EventArgs) Handles BtnNuevo.Click
        PanDiseñoPrenda.Enabled = False
        ListTipoPrenda.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT TP.CVE_TIPOPRENDA,TP.DESCRIPCION FROM TIPO_PRENDA TP,DISEÑO_GENERICO DG WHERE TP.STATUS = 1 AND TP.CVE_TIPOPRENDA = DG.CVE_TIPOPRENDA GROUP BY TP.CVE_TIPOPRENDA,TP.DESCRIPCION"
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read()
                ListTipoPrenda.Items.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_TIPOPRENDA"), "0000"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
        PanTipoPrenda.Location = New Point(300, 200)
        PanTipoPrenda.BringToFront()
        PanTipoPrenda.Visible = True
        EntraProcesos = False
    End Sub

    Private Sub ListTipoPrenda_DoubleClick(sender As System.Object, e As System.EventArgs) Handles ListTipoPrenda.DoubleClick
        If ListTipoPrenda.Items.Count > 0 Then
            PanTipoPrenda.Location = New Point(835, 232)
            PanTipoPrenda.Visible = False
            CvePrenda = 0
            Cursor.Current = Cursors.WaitCursor
            LlenaDiseñoGenerico(Val(Strings.Right(ListTipoPrenda.Items(ListTipoPrenda.SelectedIndices.Item(0)).SubItems(0).Text, 4)))
            TxtTipoPrenda.Text = ListTipoPrenda.Items(ListTipoPrenda.SelectedIndices.Item(0)).SubItems(0).Text
            PanDiseñoPrenda.Enabled = True
            ActivaBotonesModificar()
            BtnBaja.Enabled = False
            BtnNotasDiseño.Enabled = True
            BtnProcesos.Enabled = True
            LLenaTipoTallas()
            TipoMovimiento = "ALTA"
            Cursor.Current = Cursors.Default
        End If
    End Sub

    Private Sub TxtTela_Leave(sender As System.Object, e As System.EventArgs)
        Dim Posicion As Integer
        If sender.TEXT <> "" Then
            If sender.TEXT = "GENERICO" Then
                If Strings.Left(sender.tag, 9) = "TELA BASE" Then
                    TxtColor.Text = "GENERICO"
                    TxtTela.Text = "GENERICO"
                End If
            Else
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT * FROM CATALOGO_TELA WHERE STATUS = 1 AND CVE_TELA = " & Val(sender.TEXT)
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader
                If BDReader.HasRows = True Then
                    BDReader.Read()
                    For Contador As Integer = 1 To ContadorGroupBox
                        If GroupBox(Contador).Name = "CTRL" & Strings.Right(sender.NAME, Len(sender.NAME) - 5) Then
                            Posicion = Contador
                            Exit For
                        End If
                    Next
                    GroupBox(Posicion).Controls("CTRLLBL" & Strings.Right(sender.NAME, Len(sender.NAME) - 5)).Text = BDReader("COMPOSICION") & " " & BDReader("TELA") & " " & BDReader("TEJIDO") & " " & BDReader("COLOR") & " V-" & BDReader("VARIANTE") & " PESO " & BDReader("PESO") & " ANCHO " & BDReader("ANCHO") & " MTS"
                    If Strings.Left(sender.tag, 9) = "TELA BASE" Then
                        TxtTela.Text = BDReader("TELA")
                        TxtColor.Text = BDReader("COLOR")
                    End If
                    sender.Text = Format(BDReader("CVE_TELA"), "0000")
                Else
                    MessageBox.Show("Debe escribir una clave de tela existente y activa, favor de verificar.", "Error clave de Tela", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    sender.Focus()
                End If
                BDReader.Close()
                BDComando.Connection.Close()
            End If
        End If
    End Sub

    Private Sub TxtHabilitacion_Leave(sender As System.Object, e As System.EventArgs)
        Dim Posicion As Integer
        Dim Aux As Integer = 0
        If sender.TEXT <> "" Then
            If sender.TEXT <> "GENERICO" Then
                If Len(sender.TEXT) > 3 Then
                    Aux = Strings.InStr(sender.tag, ",")
                    Aux = Strings.InStr(Aux + 1, sender.tag, ",")
                    Aux = Strings.InStr(Aux + 1, sender.tag, ",")
                    If Strings.Left(sender.TEXT, 3) <> Mid(sender.TAG, Aux + 1, Len(sender.tag) - Aux) Then
                        MessageBox.Show("Debe escribir una clave de Habilitación valida, favor de verificar...", "Error de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        sender.focus()
                        Exit Sub
                    End If

                    BDComando.CommandType = CommandType.StoredProcedure
                    BDComando.CommandText = "SP_CONSULTA_HABILITACION_POR_GRUPO_CLAVE"
                    BDComando.Parameters.Add("@CVE_GRUPO", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@CVE_HABILITACION", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@NOMBRE_GRUPO", SqlDbType.NVarChar)
                    BDComando.Parameters.Add("@DESCRIPCION_HABILITACION", SqlDbType.NVarChar)

                    BDComando.Parameters("@CVE_GRUPO").Value = Strings.Left(sender.TEXT, 3)
                    BDComando.Parameters("@CVE_HABILITACION").Value = Strings.Right(sender.TEXT, Len(sender.TEXT) - 3)
                    BDComando.Parameters("@NOMBRE_GRUPO").Value = 0
                    BDComando.Parameters("@DESCRIPCION_HABILITACION").Value = 0

                    Try
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader()
                    Catch ex As Exception
                        MsgBox("Error al consultar la Habilitación, favor de contactar con sistemas dando como referencia el siguiente mensaje" & vbCrLf & ex.Message & vbCrLf & ex.Source, MsgBoxStyle.Information, "Error de consulta a la base de datos")
                        BDComando.Parameters.Clear()
                        BDComando.Connection.Close()
                        sender.focus()
                        Exit Sub
                    End Try
                    BDComando.Parameters.Clear()
                    If BDReader.HasRows = True Then
                        BDReader.Read()
                        For Contador As Integer = 1 To ContadorGroupBox
                            If GroupBox(Contador).Name = "CTRL" & Strings.Right(sender.NAME, Len(sender.NAME) - 5) Then
                                Posicion = Contador
                                Exit For
                            End If
                        Next
                        GroupBox(Posicion).Controls("CTRLLBL" & Strings.Right(sender.NAME, Len(sender.NAME) - 5)).Text = BDReader("NOMBRE_GRUPO") & " " & BDReader("DESCRIPCION_HABILITACION")
                        sender.Text = BDReader("CVE_GRUPO") & Format(BDReader("CVE_HABILITACION"), "000000")
                    Else
                        MessageBox.Show("Debe escribir una clave de Habilitacion existente y activa, favor de verificar.", "Error clave de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                        sender.Focus()
                    End If
                    BDReader.Close()
                    BDComando.Connection.Close()
                Else
                    MessageBox.Show("Debe escribir una clave de Habilitación valida, favor de verificar...", "Error de Habilitación", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                    sender.focus()
                End If
            End If
        End If
    End Sub

    Private Sub BtnNotasDiseño_Click(sender As System.Object, e As System.EventArgs) Handles BtnNotasDiseño.Click
        PanDiseñoPrenda.Enabled = False
        PanNotas.Location = New Point(3, 113)
        PanNotas.Height = 472
        PanNotas.Width = 816
        PanNotas.Visible = True
        TxtNotas.Focus()
        'MessageBox.Show(TxtCvePrenda.Controls.Owner.ToString())
    End Sub

    Private Sub TxtNotas_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtNotas.KeyDown
        If e.KeyCode = Keys.Escape Then
            PanNotas.Visible = False
            PanDiseñoPrenda.Enabled = True
        End If
    End Sub

    Private Sub BtnGuardar_Click(sender As System.Object, e As System.EventArgs) Handles BtnGuardar.Click
        Mensaje = ""
        NumeroErrores = 0
        If Trim(TxtTela.Text) = "" And Trim(TxtColor.Text) = "" Then
            Mensaje += "- No ha seleccionado la tela Base." + vbCrLf
        End If
        If CmbSexo.SelectedIndex < 0 Then
            Mensaje += "- No ha selecionado el Sexo de la Prenda." + vbCrLf
        End If
        If CmbTipoTalla.SelectedIndex < 0 Then
            Mensaje += "- No ha selecionado el Tipo de Talla de la Prenda." + vbCrLf
        End If
        If Mensaje <> "" Then
            MessageBox.Show("Faltan algunos datos: " + vbCrLf + Mensaje, "Datos de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        VerificaDatosLlenado()

        If Mensaje <> "" Then
            MessageBox.Show("Faltan algunos datos: " + vbCrLf + Mensaje, "Datos de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If

        'GUARDAR LA CABECERA DE LA PRENDA
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA"

        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@CVE_TIPOPRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TIPO_PRENDA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TELA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@COLOR", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@SEXO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@MANGA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@ADICIONAL", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@CVE_TIPOTALLA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
        BDComando.Parameters.Add("@CVE_PRENDA_MODIFICACION", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NOTAS", SqlDbType.Text)

        BDComando.Parameters("@CVE_PRENDA").Direction = ParameterDirection.Output
        BDComando.Parameters("@TIPO_PRENDA").Value = Trim(Strings.Left(TxtTipoPrenda.Text, Len(TxtTipoPrenda.Text) - 4))
        BDComando.Parameters("@TELA").Value = TxtTela.Text
        BDComando.Parameters("@COLOR").Value = TxtColor.Text
        BDComando.Parameters("@SEXO").Value = CmbSexo.SelectedItem.ToString
        BDComando.Parameters("@MANGA").Value = CmbManga.Text
        BDComando.Parameters("@ADICIONAL").Value = TxtAdicional.Text
        BDComando.Parameters("@CVE_TIPOTALLA").Value = Val(Strings.Right(CmbTipoTalla.SelectedItem.ToString, 4))
        BDComando.Parameters("@TIPO_MOVIMIENTO").Value = TipoMovimiento
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@STATUS").Value = 1
        BDComando.Parameters("@CVE_TIPOPRENDA").Value = Val(Strings.Right(TxtTipoPrenda.Text, 4))
        BDComando.Parameters("@NOTAS").Value = TxtNotas.Text

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
            CvePrenda = BDComando.Parameters("@CVE_PRENDA").Value
            BDComando.Parameters.Clear()
            BDComando.Connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error al guardar la Prenda, favor de llamar a sistemas y dar como referencia el siguiente error: " & ex.Message, "Error al guardar datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BDComando.Parameters.Clear()
            BDComando.Connection.Close()
            Exit Sub
        End Try

        If TipoMovimiento = "MODIFICACION" Then
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_GUARDAR_ULTIMA_MODIFICACION_PRENDA"

            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)

            BDComando.Parameters("@CVE_PRENDA").Value = Val(TxtCvePrenda.Text)
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name

            Try
                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()
                BDComando.Parameters.Clear()
                BDComando.Connection.Close()
            Catch ex As Exception
                MessageBox.Show("Error al guardar la modificación de la prenda, favor de notificarle a sistemas dando como referencia el siguiente error: " & vbCrLf & ex.Message, "Error al guardar datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                BDComando.Parameters.Clear()
                BDComando.Connection.Close()
                Exit Sub
            End Try
        End If

        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA_DETALLE"

        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@NIVEL", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@NIVELNUMERICO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@DATO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@OTRODATO", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        If Mensaje = "" Then
            PreparaMatrizGuardado()
        End If

        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.StoredProcedure
        BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA_PROCESOS"

        BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
        BDComando.Parameters.Add("@ORDEN", SqlDbType.Int)
        BDComando.Parameters.Add("@NIVEL1", SqlDbType.Int)
        BDComando.Parameters.Add("@NIVEL2", SqlDbType.Int)
        BDComando.Parameters.Add("@NIVEL3", SqlDbType.Int)
        BDComando.Parameters.Add("@DESCRIPCION", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
        BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
        BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)

        For i As Integer = 0 To DGVProcesosSeleccionados.Rows.Count - 1
            BDComando.Parameters("@CVE_PRENDA").Value = Val(CvePrenda)
            BDComando.Parameters("@ORDEN").Value = DGVProcesosSeleccionados.Rows(i).Cells("OrdenBis").Value
            BDComando.Parameters("@NIVEL1").Value = DGVProcesosSeleccionados.Rows(i).Cells("Nivel1Bis").Value
            BDComando.Parameters("@NIVEL2").Value = DGVProcesosSeleccionados.Rows(i).Cells("Nivel2Bis").Value
            BDComando.Parameters("@NIVEL3").Value = DGVProcesosSeleccionados.Rows(i).Cells("Nivel3Bis").Value
            BDComando.Parameters("@DESCRIPCION").Value = DGVProcesosSeleccionados.Rows(i).Cells("DescripcionBis").Value
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"

            Try
                BDComando.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error al guardar la Prenda, favor de llamar a sistemas y dar como referencia el siguiente error: " & ex.Message, "Error al guardar datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                BDComando.Parameters.Clear()
                Exit Sub
            End Try
        Next

        If NumeroErrores = 0 Then
            MessageBox.Show("La prenda se guardo correctamente con la clave " & CvePrenda, "Alta de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BDComando.Parameters.Clear()
            ActivaBotonesConsulta()
            BtnEditar.Enabled = True
            LimpiaCampos()
        Else
            BDComando.Parameters.Clear()
            BDComando.CommandType = CommandType.Text
            BDComando.CommandText = "DELETE PRENDA WHERE CVE_PRENDA = " & CvePrenda
            BDComando.ExecuteNonQuery()
            BDComando.CommandText = "DELETE PRENDA_DETALLE WHERE CVE_PRENDA = " & CvePrenda
            BDComando.ExecuteNonQuery()
            MessageBox.Show("Error al guardar la prenda.", "Error de Alta de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        End If
        TipoMovimiento = ""
    End Sub

    Private Sub GuardarPrendaDetalleBD()
        BDComando.Parameters("@CVE_PRENDA").Value = Val(CvePrenda)
        BDComando.Parameters("@NIVEL").Value = NivelLetra
        BDComando.Parameters("@NIVELNUMERICO").Value = SeccionGuardado
        BDComando.Parameters("@DATO").Value = Dato
        BDComando.Parameters("@OTRODATO").Value = OtroDato
        BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
        BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
        BDComando.Parameters("@TIPO_MOVIMIENTO").Value = "ALTA"

        Try
            BDComando.Connection.Open()
            BDComando.ExecuteNonQuery()
            BDComando.Connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error al guardar el detalle de la prenda, favor de contactar a sistemas dando como referencia el siguiente error. " & vbCrLf & ex.Message, "Error al guardar la prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            NumeroErrores += 1
        End Try
    End Sub

    Private Sub BtnCancelar_Click(sender As System.Object, e As System.EventArgs) Handles BtnCancelar.Click
        ActivaBotonesConsulta()
        LimpiaCampos()
    End Sub

    Private Sub LimpiaCampos()
        TxtCvePrenda.Clear()
        TxtTipoPrenda.Clear()
        TxtTela.Clear()
        TxtColor.Clear()
        CmbSexo.SelectedIndex = -1
        CmbManga.SelectedIndex = -1
        CmbTipoTalla.SelectedIndex = -1
        TxtAdicional.Clear()
        TxtNotas.Clear()
        PanDetallePrenda.Controls.Clear()
        BtnNotasDiseño.Enabled = False
        ReDim GroupBox(0)
        PanProcesos.Visible = False
        DGVProcesosSeleccionables.Rows.Clear()
        DGVProcesosSeleccionados.Rows.Clear()
        BtnProcesos.Enabled = False
    End Sub

    Private Sub BtnEditar_Click(sender As System.Object, e As System.EventArgs) Handles BtnEditar.Click
        Dim Cve_TipoPrenda As Integer
        Dim Clave As String
        Clave = InputBox("Clave de Prenda", "Modifación de Diseño de Prenda")
        If Clave = "" Then
            Exit Sub
        ElseIf IsNumeric(Clave) = False Then
            MessageBox.Show("La clave de prenda debe ser un número.", "Error de Clave de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        CvePrenda = Clave
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT * FROM PRENDA WHERE CVE_PRENDA = " & CvePrenda
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader

        If BDReader.HasRows = True Then
            BDReader.Read()
            If BDReader("TIPOPRENDA") = "E" Then
                MessageBox.Show("Clave de Prenda Especial, favor de modificar en pantalla, PRENDAS ESPECIALES.", "Modificación de Diseño de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                BDReader.Close()
            ElseIf BDReader("STATUS") = True Then
                TipoMovimiento = "MODIFICACION"
                Cve_TipoPrenda = BDReader("CVE_TIPOPRENDA")
                BDReader.Close()
                Cursor.Current = Cursors.WaitCursor
                LlenaDiseñoGenerico(Cve_TipoPrenda)
                ProvocaMovimiento(PanDetallePrenda)
                LLenaTipoTallas()
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.Text
                BDComando.CommandText = "SELECT P.*,TT.DESCRIPCION FROM PRENDA P LEFT JOIN TIPO_TALLA TT ON P.CVE_TIPOTALLA = TT.CVE_TIPOTALLA WHERE P.CVE_PRENDA = " & CvePrenda
                BDReader = BDComando.ExecuteReader
                BDReader.Read()
                TxtCvePrenda.Text = BDReader("CVE_PRENDA")
                TxtTipoPrenda.Text = BDReader("TIPO_PRENDA") & " " & Format(BDReader("CVE_TIPOPRENDA"), "0000")
                TxtTela.Text = BDReader("TELA")
                TxtColor.Text = BDReader("COLOR")
                CmbSexo.SelectedIndex = CmbSexo.FindString(BDReader("SEXO"))
                If IsDBNull(BDReader("MANGA")) = False Then
                    CmbManga.SelectedIndex = CmbManga.FindString(BDReader("MANGA"))
                End If
                If IsDBNull(BDReader("ADICIONAL")) = False Then
                    TxtAdicional.Text = BDReader("ADICIONAL")
                End If
                If IsDBNull(BDReader("CVE_TIPOTALLA")) = False Then
                    CmbTipoTalla.SelectedIndex = CmbTipoTalla.FindString(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_TIPOTALLA"), "0000"))
                End If
                TxtNotas.Text = BDReader("NOTAS")
                BDReader.Close()
                ActivaBotonesModificar()
                BtnNotasDiseño.Enabled = True
                BtnProcesos.Enabled = True
                Cursor.Current = Cursors.Default
                EntraProcesos = False
            Else
                MessageBox.Show("Clave de Prenda dada de Baja.", "Modificación de Diseño de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                BDReader.Close()
                BDComando.Connection.Close()
            End If
        Else
            MessageBox.Show("Clave de Prenda inexistente, favor de verificar.", "Modificación de Diseño de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            BDReader.Close()
            BDComando.Connection.Close()
        End If
    End Sub

    Private Sub ProvocaMovimiento(ByVal ObjetoHeredado As System.Object)
        Dim Objeto As System.Object
        Dim Aux As New Integer
        For Contador As Integer = 0 To ObjetoHeredado.controls.count - 1
            If ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.GroupBox" Then
                Objeto = ObjetoHeredado.Controls(Contador)
                ProvocaMovimiento(Objeto)
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "DevComponents.DotNetBar.Controls.TextBoxX" Then
                Objeto = ObjetoHeredado.Controls(Contador)
                If Strings.Left(Objeto.NAME, 5) = "TXTHT" Then
                    Aux = InStr(Objeto.TAG, ",")
                    Aux = InStr(Aux + 1, Objeto.TAG, ",")
                    If Mid(Objeto.TAG, Aux + 1, 15) = "CVEHABILITACION" Then
                        TxtHabilitacion_Leave(Objeto, Nothing)
                    ElseIf Mid(Objeto.TAG, Aux + 1, 7) = "CVETELA" Then
                        TxtTela_Leave(Objeto, Nothing)
                    End If
                End If
                'TxtTela_Leave(Objeto,Nothing)
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.RadioButton" Then
                Objeto = ObjetoHeredado.Controls(Contador)
                If Objeto.checked = True Then
                    'Objeto.PerformClick()
                    If Strings.Left(Objeto.name, 5) = "OPCSI" Or Strings.Left(Objeto.name, 5) = "OPCNO" Then
                        RBSiNo_CheckedChanged(Objeto, Nothing)
                    ElseIf Strings.Left(Objeto.name, 7) = "OPCOTRO" And Objeto.TEXT = "OTRO" Then
                        RBOtro_CheckedChanged(Objeto, Nothing)
                    End If
                End If
            ElseIf ObjetoHeredado.Controls(Contador).GetType.ToString() = "System.Windows.Forms.CheckBox" Then
                Objeto = ObjetoHeredado.Controls(Contador)
                If Objeto.checked = True Then
                    'Objeto.PerformClick()
                End If
            End If
        Next
    End Sub

    Private Sub BtnBaja_Click(sender As System.Object, e As System.EventArgs) Handles BtnBaja.Click
        If MessageBox.Show("Esta seguro de querer dar de baja la prenda " & TxtCvePrenda.Text, "Baja de Prenda", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            'GUARDAR LA CABECERA DE LA PRENDA PARA BAJA DE PRENDA
            BDComando.CommandType = CommandType.StoredProcedure
            BDComando.CommandText = "SP_ALTA_MODIFICACION_PRENDA"

            BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@CVE_TIPOPRENDA", SqlDbType.BigInt)
            BDComando.Parameters.Add("@TIPO_PRENDA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@TELA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@COLOR", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@SEXO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@MANGA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@ADICIONAL", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@TIPO_MOVIMIENTO", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@USUARIO", SqlDbType.BigInt)
            BDComando.Parameters.Add("@COMPUTADORA", SqlDbType.NVarChar)
            BDComando.Parameters.Add("@STATUS", SqlDbType.Bit)
            BDComando.Parameters.Add("@CVE_PRENDA_MODIFICACION", SqlDbType.BigInt)
            BDComando.Parameters.Add("@NOTAS", SqlDbType.Text)

            BDComando.Parameters("@CVE_PRENDA").Direction = ParameterDirection.Output
            BDComando.Parameters("@CVE_TIPOPRENDA").Value = Val(Strings.Right(TxtTipoPrenda.Text, 4))
            BDComando.Parameters("@TIPO_PRENDA").Value = Trim(Strings.Left(TxtTipoPrenda.Text, Len(TxtTipoPrenda.Text) - 4))
            BDComando.Parameters("@TELA").Value = TxtTela.Text
            BDComando.Parameters("@COLOR").Value = TxtColor.Text
            BDComando.Parameters("@SEXO").Value = CmbSexo.SelectedItem.ToString
            BDComando.Parameters("@MANGA").Value = CmbManga.Text
            BDComando.Parameters("@ADICIONAL").Value = TxtAdicional.Text
            BDComando.Parameters("@TIPO_MOVIMIENTO").Value = TipoMovimiento
            BDComando.Parameters("@USUARIO").Value = ConectaBD.Cve_Usuario
            BDComando.Parameters("@COMPUTADORA").Value = My.Computer.Name
            BDComando.Parameters("@STATUS").Value = 0
            BDComando.Parameters("@CVE_PRENDA_MODIFICACION").Value = Val(TxtCvePrenda.Text)
            BDComando.Parameters("@NOTAS").Value = TxtNotas.Text

            Try
                BDComando.ExecuteNonQuery()
                BDComando.Parameters.Clear()

            Catch ex As Exception
                MessageBox.Show("Error al dar de baja la Prenda, favor de llamar a sistemas y dar como referencia el siguiente error: " & vbCrLf & ex.Message, "Error al guardar datos", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                BDComando.Parameters.Clear()
                Exit Sub
            End Try
            MessageBox.Show("Se dio de baja correctamente la prenda " & Val(TxtCvePrenda.Text), "Baja de Prenda", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            ActivaBotonesConsulta()
            LimpiaCampos()
        End If
    End Sub

    Private Sub LLenaTipoTallas()
        CmbTipoTalla.Items.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT CVE_TIPOTALLA,DESCRIPCION FROM TIPO_TALLA WHERE STATUS = 1 GROUP BY CVE_TIPOTALLA,DESCRIPCION ORDER BY DESCRIPCION"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    CmbTipoTalla.Items.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_TIPOTALLA"), "0000"))
                Loop
            End If
            BDReader.Close()
            BDComando.Connection.Close()
        Catch ex As Exception
            MessageBox.Show("Error al consultar los tipos de tallas, favor de comunicarse a sistemas y dar como referencia el siguiente error" & vbCrLf & ex.Message, "Error de consulta", MessageBoxButtons.OK, MessageBoxIcon.Error)
            BDReader.Close()
            BDComando.Connection.Close()
            Exit Sub
        End Try
    End Sub

    Private Sub BtnProcesos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesos.Click
        If TipoMovimiento = "ALTA" Then
            If EntraProcesos = False Then
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_OBTIENE_CATALOGO_PROCESOS"
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader()
                DGVProcesosSeleccionables.Rows.Clear()
                DGVProcesosSeleccionados.Rows.Clear()
                If BDReader.HasRows = True Then
                    While BDReader.Read()
                        Dim Fila As String() = {BDReader("Nivel1"), BDReader("Nivel2"), BDReader("Nivel3"), BDReader("Descripcion")}
                        DGVProcesosSeleccionables.Rows.Add(Fila)
                    End While
                End If
                BDReader.Close()
                BDComando.Connection.Close()
            End If
            PanProcesos.Visible = True
            EntraProcesos = True
        ElseIf TipoMovimiento = "MODIFICACION" Then
            If EntraProcesos = False Then
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_OBTIENE_PRENDA_PROCESOS"
                BDComando.Parameters.Add("@CVE_PRENDA", SqlDbType.BigInt)

                BDComando.Parameters("@CVE_PRENDA").Value = Val(TxtCvePrenda.Text)
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader()
                If BDReader.HasRows = True Then
                    While BDReader.Read()
                        Dim Fila As String() = {BDReader("Nivel1"), BDReader("Nivel2"), BDReader("Nivel3"), BDReader("Descripcion"), BDReader("Orden")}
                        DGVProcesosSeleccionados.Rows.Add(Fila)
                    End While
                End If
                BDReader.Close()
                BDComando.Connection.Close()

                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_OBTIENE_CATALOGO_PROCESOS"
                BDComando.Connection.Open()
                BDReader = BDComando.ExecuteReader()
                If BDReader.HasRows = True Then
                    While BDReader.Read()
                        Dim Existe As Boolean = False
                        For i As Integer = 0 To DGVProcesosSeleccionados.Rows.Count - 1
                            If BDReader("Nivel1") = DGVProcesosSeleccionados.Rows(i).Cells("Nivel1Bis").Value And BDReader("Nivel2") = DGVProcesosSeleccionados.Rows(i).Cells("Nivel2Bis").Value And BDReader("Nivel3") = DGVProcesosSeleccionados.Rows(i).Cells("Nivel3Bis").Value Then
                                Existe = True
                            End If
                        Next
                        If Existe = False Then
                            Dim Fila As String() = {BDReader("Nivel1"), BDReader("Nivel2"), BDReader("Nivel3"), BDReader("Descripcion")}
                            DGVProcesosSeleccionables.Rows.Add(Fila)
                        End If
                    End While
                End If
            End If
            BDReader.Close()
            BDComando.Connection.Close()
            PanProcesos.Visible = True
            EntraProcesos = True
        End If
    End Sub

    Private Sub BtnProcesosAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesosAgregar.Click
        If DGVProcesosSeleccionables.Rows.Count > 0 And DGVProcesosSeleccionables.CurrentRow.Index >= 0 And DGVProcesosSeleccionables.SelectedRows.Count > 0 Then
            Dim Fila As String() = {DGVProcesosSeleccionables.CurrentRow.Cells("Nivel1").Value, DGVProcesosSeleccionables.CurrentRow.Cells("Nivel2").Value, DGVProcesosSeleccionables.CurrentRow.Cells("Nivel3").Value, DGVProcesosSeleccionables.CurrentRow.Cells("Descripcion").Value}
            DGVProcesosSeleccionados.Rows.Add(Fila)
            DGVProcesosSeleccionables.Rows.Remove(DGVProcesosSeleccionables.CurrentRow)
        End If
    End Sub

    Private Sub BtnProcesosEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnProcesosEliminar.Click
        Dim Fila As String() = {DGVProcesosSeleccionados.CurrentRow.Cells("Nivel1Bis").Value, DGVProcesosSeleccionados.CurrentRow.Cells("Nivel2Bis").Value, DGVProcesosSeleccionados.CurrentRow.Cells("Nivel3Bis").Value, DGVProcesosSeleccionados.CurrentRow.Cells("DescripcionBis").Value}
        DGVProcesosSeleccionables.Rows.Add(Fila)
        'DGVProcesosSeleccionables.Sort(DGVProcesosSeleccionables.Columns.Item("Nivel1"), System.ComponentModel.ListSortDirection.Ascending)
        DGVProcesosSeleccionados.Rows.Remove(DGVProcesosSeleccionados.CurrentRow)
    End Sub

    Private Sub DGVProcesosSeleccionados_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVProcesosSeleccionados.CellEndEdit
        If IsNumeric(DGVProcesosSeleccionados.CurrentCell.Value) = True Then
            If (DGVProcesosSeleccionados.CurrentCell.Value Mod 1) = 0 Then
                Dim Fila As Integer
                Dim CuentaErrores As Integer
                Fila = DGVProcesosSeleccionados.CurrentRow.Index
                CuentaErrores = 0
                For i = 1 To DGVProcesosSeleccionados.Rows.Count - 1 Step 1
                    If Fila <> i Then
                        If DGVProcesosSeleccionados.Rows(i).Cells("OrdenBis").Value = DGVProcesosSeleccionados.CurrentCell.Value Then
                            CuentaErrores += 1
                            MsgBox("El número del orden ya se ha escrito, favor de verificar", vbExclamation, "Orden de Procesos")
                            DGVProcesosSeleccionados.CurrentCell.Value = ""
                        End If
                    End If
                Next
                If CuentaErrores = 0 Then
                    DGVProcesosSeleccionados.Sort(DGVProcesosSeleccionados.Columns("OrdenBis"), System.ComponentModel.ListSortDirection.Ascending)
                End If
            Else
                MsgBox("El valor debe ser un número entero", vbExclamation, "Orden de Procesos")
                DGVProcesosSeleccionados.CurrentCell.Value = ""
            End If
        Else
            MsgBox("El valor debe ser un número", vbExclamation, "Orden de Procesos")
            DGVProcesosSeleccionados.CurrentCell.Value = ""
        End If
    End Sub

    Private Sub BtnCerrarPanProcesos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnCerrarPanProcesos.Click
        PanProcesos.Visible = False
    End Sub

    Private Sub DGVProcesosSeleccionables_RowEnter(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGVProcesosSeleccionables.RowEnter
        'Dim CuentaInserciones As Integer = 0
        'If DGVProcesosSeleccionados.Rows.Count > 0 And IsNothing(DGVProcesosSeleccionables.CurrentRow) = False Then
        '    For i As Integer = 0 To DGVProcesosSeleccionados.Rows.Count - 1
        '        If DGVProcesosSeleccionados.Rows(i).Cells("Nivel1Bis").Value = DGVProcesosSeleccionables.CurrentRow.Cells("Nivel1").Value And DGVProcesosSeleccionados.Rows(i).Cells("Nivel2Bis").Value = DGVProcesosSeleccionables.CurrentRow.Cells("Nivel2").Value Then
        '            CuentaInserciones += 1
        '        End If
        '    Next
        '    If CuentaInserciones > 0 Then
        '        DGVProcesosSeleccionables.Rows(e.RowIndex).Selected = False
        '    End If
        'End If
        'MsgBox("RowEnter")
    End Sub

    Private Sub DGVProcesosSeleccionables_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DGVProcesosSeleccionables.SelectionChanged
        Dim CuentaInserciones As Integer = 0
        If DGVProcesosSeleccionados.Rows.Count > 0 And IsNothing(DGVProcesosSeleccionables.CurrentRow) = False Then
            For i As Integer = 0 To DGVProcesosSeleccionados.Rows.Count - 1
                If DGVProcesosSeleccionados.Rows(i).Cells("Nivel1Bis").Value = DGVProcesosSeleccionables.CurrentRow.Cells("Nivel1").Value And DGVProcesosSeleccionados.Rows(i).Cells("Nivel2Bis").Value = DGVProcesosSeleccionables.CurrentRow.Cells("Nivel2").Value Then
                    CuentaInserciones += 1
                End If
            Next
            If CuentaInserciones > 0 Then
                DGVProcesosSeleccionables.Rows(DGVProcesosSeleccionables.CurrentRow.Index).Selected = False
            End If
        End If
    End Sub
End Class

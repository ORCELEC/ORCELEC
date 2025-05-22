Imports System.Data
Imports System.Data.SqlClient
Imports DevComponents.DotNetBar

Public Class FrmSeleccionarHabilitacion
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDComando1 As SqlCommand
    Private BDTabla As New DataTable
    Private BDDataSet As New DataSet
    Private BDReader As SqlDataReader
    Private BDReader1 As SqlDataReader
    Public Busqueda As String

    Private Sub FrmSeleccionarHabilitacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text

        BDComando.Parameters.Clear()
        BDComando.CommandText = "SELECT * FROM HABILITACION_GRUPO WHERE CVE_GRUPO = '" & Busqueda & "' AND STATUS = 1"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            If BDReader.HasRows = True Then
                BDReader.Read()
                LabelGrupo.Text = BDReader("CVE_GRUPO") & " " & BDReader("DESCRIPCION")
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la habilitación seleccionada, contactar a sistemas y dar como referencia el siguiente error:" & vbCrLf & "-" & ex.Message, "Consulta de habilitación seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
        BDComando.CommandText = "SELECT * FROM HABILITACION_GRUPO_CARACTERISTICAS WHERE CVE_GRUPO = '" & Busqueda & "' AND STATUS = 1"
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader

            BDComando1 = New SqlCommand
            BDComando1.Parameters.Clear()
            BDComando1.Connection = ConectaBD.BDConexion
            BDComando1.CommandType = CommandType.Text

            Dim XLbl, YLbl, XCmb, YCmb As Long
            Dim Contador As Long
            XLbl = 11
            YLbl = 62
            XCmb = 197
            YCmb = 59
            Contador = 1
            If BDReader.HasRows = True Then
                Do While BDReader.Read
                    Dim Label As New LabelX
                    Label.Width = 180
                    Label.Height = 20
                    Label.Location = New Point(XLbl, YLbl)
                    Label.Name = "Lbl" & BDReader("DESCRIPCION") & "." & BDReader("CVE_CARACTERISTICA")
                    Label.Tag = BDReader("CVE_CARACTERISTICA")
                    Label.Text = BDReader("DESCRIPCION") & ":"
                    Label.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                    PanPrincipal.Controls.Add(Label)

                    Dim Combo As New Controls.ComboBoxEx
                    Combo.Width = 247
                    Combo.Height = 23
                    Combo.Location = New Point(XCmb, YCmb)
                    Combo.Name = "Cmb" & BDReader("DESCRIPCION") & "." & BDReader("CVE_CARACTERISTICA")
                    Combo.Tag = BDReader("CVE_CARACTERISTICA")
                    Combo.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Bold)
                    Combo.DropDownStyle = ComboBoxStyle.DropDownList
                    Combo.FocusHighlightEnabled = True
                    Combo.DrawMode = DrawMode.OwnerDrawFixed
                    PanPrincipal.Controls.Add(Combo)

                    Contador += 1
                    'AUMENTAMOS EL ESPACIO DEL SIGUIENTE LABELX Y COMBOBOXX
                    If Contador <= 12 Then
                        YLbl += 26
                        YCmb += 26
                    ElseIf Contador = 13 Then
                        XLbl += 448
                        XCmb += 448
                    ElseIf Contador > 13 Then
                        YLbl += 26
                        YCmb += 26
                    End If
                Loop
                'VAMOS A LLENAR LOS COMBOBOX
                For Each Control In PanPrincipal.Controls
                    If Strings.Left(Control.NAME, 3) = "Cmb" Then
                        BDComando.Parameters.Clear()
                        BDComando.CommandType = CommandType.Text
                        BDComando.CommandText = "SELECT * FROM HABILITACION_GRUPO_CARACTERISTICAS_DEFINICION WHERE CVE_GRUPO = '" & Strings.Left(LabelGrupo.Text, 3) & "' AND CVE_CARACTERISTICA = " & Control.tag & " AND STATUS = 1 ORDER BY DESCRIPCION"
                        If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                            BDReader.Close()
                        End If
                        If BDComando.Connection.State = ConnectionState.Open Then
                            BDComando.Connection.Close()
                        End If
                        BDComando.Connection.Open()
                        BDReader = BDComando.ExecuteReader
                        If BDReader.HasRows = True Then
                            Do While BDReader.Read
                                Control.Items.Add(BDReader("DESCRIPCION") & " " & Format(BDReader("CVE_DEFINICION"), "000"))
                            Loop
                        End If
                        BDReader.Close()
                        BDComando.Connection.Close()
                    End If
                Next
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al consultar la habilitación seleccionada, contactar a sistemas y dar como referencia el siguiente error:" & vbCrLf & "-" & ex.Message, "Consulta de habilitación seleccionada", MessageBoxButtons.OK, MessageBoxIcon.Error)
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

    Private Sub BtnGuardar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnGuardar.Click
        Dim Clave As String
        Dim Descripcion As String
        Clave = Strings.Left(LabelGrupo.Text, 3)
        Descripcion = Trim(Strings.Right(LabelGrupo.Text, Len(LabelGrupo.Text) - 3))

        'FORMAR LA CLAVE Y LA DESCRIPCION DE LA HABILITACIÓN
        For Each Control In PanPrincipal.Controls
            If Strings.Left(Control.name, 3) = "Lbl" Then
                Descripcion += " " & Trim(Strings.Left(Control.text, Len(Control.text) - 1))
            End If
            If Strings.Left(Control.name, 3) = "Cmb" Then
                Clave += "." & Val(Strings.Right(Control.text, 3))
                Descripcion += " " & Trim(Strings.Left(Control.text, Len(Control.text) - 3))
            End If
        Next

        'FrmDiseñoPrenda.Clave = Clave
        'FrmDiseñoPrenda.DescripcionClave = Descripcion
        Me.Close()
    End Sub

    Private Sub BtnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnSalir.Click
        Me.Close()
    End Sub
End Class
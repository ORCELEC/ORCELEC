Imports System.Data
Imports System.Data.SqlClient

Public Class FrmBitSegMue
    Private BDAdapter As SqlDataAdapter
    Private BDTabla As New DataTable
    Private Bandera As String
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader

    Private Sub FrmBitSegMue_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDAdapter = New SqlDataAdapter("SP_CONSULTA_BITACORA_SEGUIMIENTO_MUESTRAS", ConectaBD.BDConexion)
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        'BDAdapter.SelectCommand.Connection = ConectaBD.BDConexion
    End Sub

    Private Sub TxtFolio_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtFolio.KeyUp
        If e.KeyCode = Keys.Enter Then
            TxtArgolla.Text = ""
            LlenaGrid("FOLIO")
        End If
    End Sub

    Private Sub LlenaGrid(Origen As String)
        BDTabla.Clear()
        DGBitacoraSeguimientoMuestras.DataSource = Nothing
        BDAdapter.SelectCommand.Parameters.Clear()
        BDAdapter.SelectCommand.CommandType = CommandType.StoredProcedure
        BDAdapter.SelectCommand.CommandText = "SP_CONSULTA_BITACORA_SEGUIMIENTO_MUESTRAS"
        BDAdapter.SelectCommand.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
        BDAdapter.SelectCommand.Parameters.Add("@FOLIO", SqlDbType.BigInt)
        BDAdapter.SelectCommand.Parameters.Add("@ARGOLLA", SqlDbType.BigInt)
        BDAdapter.SelectCommand.Parameters.Add("@LISTACOMPLETA", SqlDbType.Bit)

        BDAdapter.SelectCommand.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
        If Origen = "FOLIO" Then
            BDAdapter.SelectCommand.Parameters("@FOLIO").Value = Val(TxtFolio.Text)
        Else
            BDAdapter.SelectCommand.Parameters("@FOLIO").Value = 0
        End If
        If Origen = "ARGOLLA" Then
            BDAdapter.SelectCommand.Parameters("@ARGOLLA").Value = Val(TxtArgolla.Text)
        Else
            BDAdapter.SelectCommand.Parameters("@ARGOLLA").Value = 0
        End If
        If Origen = "LISTACOMPLETA" Then
            BDAdapter.SelectCommand.Parameters("@LISTACOMPLETA").Value = True
        Else
            BDAdapter.SelectCommand.Parameters("@LISTACOMPLETA").Value = False
        End If
        BDComando.Connection.Open()
        BDAdapter.Fill(BDTabla)
        DGBitacoraSeguimientoMuestras.DataSource = BDTabla

        DGBitacoraSeguimientoMuestras.Columns.Item("ARGOLLA").Frozen = True
        DGBitacoraSeguimientoMuestras.Columns.Item("ARGOLLA").Width = 60
        DGBitacoraSeguimientoMuestras.Columns.Item("ARGOLLA").ReadOnly = True

        DGBitacoraSeguimientoMuestras.Columns.Item("NUM_FOLIO").HeaderText = "FOLIO"
        DGBitacoraSeguimientoMuestras.Columns.Item("NUM_FOLIO").Frozen = True
        DGBitacoraSeguimientoMuestras.Columns.Item("NUM_FOLIO").Width = 60
        DGBitacoraSeguimientoMuestras.Columns.Item("NUM_FOLIO").ReadOnly = True

        DGBitacoraSeguimientoMuestras.Columns.Item("DESCRIPCION").Width = 200
        DGBitacoraSeguimientoMuestras.Columns.Item("DESCRIPCION").ReadOnly = True

        DGBitacoraSeguimientoMuestras.Columns.Item("ESTADOACTUAL").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("ESTADOACTUAL").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("ESTADOACTUAL").HeaderText = "UBICACION ACTUAL"

        DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAPRODUCCION").Width = 10
        DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAPRODUCCION").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAPRODUCCION").HeaderText = ""
        DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAPRODUCCION").DefaultCellStyle.BackColor = Color.GreenYellow

        DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAPRODUCCION").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAPRODUCCION").HeaderText = "USUARIO ENTREGA A PRODUCCION"

        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEPRODUCCION").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEPRODUCCION").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEPRODUCCION").HeaderText = "USUARIO RECIBE EN PRODUCCION"

        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAENTREGAPRODUCCION").Width = 60
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAENTREGAPRODUCCION").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAENTREGAPRODUCCION").HeaderText = "FECHA"

        If ConectaBD.Departamento = "PRODUCCION" Or ConectaBD.Departamento = "SISTEMAS" Then
            DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAPRODUCCION").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAPRODUCCION").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEPRODUCCION").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("FECHAENTREGAPRODUCCION").Visible = True
        Else
            DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAPRODUCCION").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAPRODUCCION").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEPRODUCCION").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("FECHAENTREGAPRODUCCION").Visible = False
        End If

        DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAMAQUILADOR").Width = 10
        DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAMAQUILADOR").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAMAQUILADOR").HeaderText = ""
        DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAMAQUILADOR").DefaultCellStyle.BackColor = Color.GreenYellow

        DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAMAQUILADOR").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAMAQUILADOR").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAMAQUILADOR").HeaderText = "USUARIO MANDA A MAQUILADOR"

        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAENTREGAMAQUILADOR").Width = 60
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAENTREGAMAQUILADOR").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAENTREGAMAQUILADOR").HeaderText = "FECHA"

        DGBitacoraSeguimientoMuestras.Columns.Item("CVE_ORDEN").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("CVE_ORDEN").HeaderText = "ORDEN PROD."

        DGBitacoraSeguimientoMuestras.Columns.Item("REASIGNACION").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("REASIGNACION").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("REASIGNACION").HeaderText = "REASIGNACION"

        If ConectaBD.Departamento = "PRODUCCION" Or ConectaBD.Departamento = "SISTEMAS" Then
            DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAMAQUILADOR").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAMAQUILADOR").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("FECHAENTREGAMAQUILADOR").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("CVE_ORDEN").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("REASIGNACION").Visible = True
        Else
            DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAMAQUILADOR").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAMAQUILADOR").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("FECHAENTREGAMAQUILADOR").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("CVE_ORDEN").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("REASIGNACION").Visible = False
        End If

        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAALMACENPRODTERMINADO").Width = 10
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAALMACENPRODTERMINADO").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAALMACENPRODTERMINADO").HeaderText = ""
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAALMACENPRODTERMINADO").DefaultCellStyle.BackColor = Color.GreenYellow
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAALMACENPRODTERMINADO").Visible = False

        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEALMACENPRODTERMINADO").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEALMACENPRODTERMINADO").HeaderText = "USUARIO RECIBE REGRESA ALMACEN"
        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEALMACENPRODTERMINADO").Visible = False

        DGBitacoraSeguimientoMuestras.Columns.Item("FECHARECIBEALMACENPRODTERMINADO").Width = 60
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHARECIBEALMACENPRODTERMINADO").HeaderText = "FECHA"
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHARECIBEALMACENPRODTERMINADO").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHARECIBEALMACENPRODTERMINADO").Visible = False

        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAPRODUCCION").Width = 10
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAPRODUCCION").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAPRODUCCION").HeaderText = ""
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAPRODUCCION").DefaultCellStyle.BackColor = Color.GreenYellow

        DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAAPRODUCCION").Visible = False

        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAPRODUCCION").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAPRODUCCION").HeaderText = "USUARIO RECIBE REGRESO A PRODUCCION"

        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAPRODUCCION").Width = 60
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAPRODUCCION").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAPRODUCCION").HeaderText = "FECHA"

        If ConectaBD.Departamento = "ALMACEN" Or ConectaBD.Departamento = "SISTEMAS" Then
            DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAPRODUCCION").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAPRODUCCION").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAPRODUCCION").Visible = True
        Else
            DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAPRODUCCION").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAPRODUCCION").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAPRODUCCION").Visible = False
        End If

        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAADMONVENTAS").Width = 10
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAADMONVENTAS").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAADMONVENTAS").HeaderText = ""
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAADMONVENTAS").DefaultCellStyle.BackColor = Color.GreenYellow

        DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAADMONVENTAS").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAADMONVENTAS").HeaderText = "USUARIO REGRESA A ADMON VENTAS"

        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAADMONVENTAS").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAADMONVENTAS").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAADMONVENTAS").HeaderText = "USUARIO RECIBE REGRESO A ADMON. VENTAS"

        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAADMONVENTAS").Width = 60
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAADMONVENTAS").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAADMONVENTAS").HeaderText = "FECHA"

        If ConectaBD.Departamento = "ADMON. VENTAS" Or ConectaBD.Departamento = "SISTEMAS" Then
            DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAADMONVENTAS").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAADMONVENTAS").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAADMONVENTAS").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAADMONVENTAS").Visible = True
        Else
            DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAADMONVENTAS").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAADMONVENTAS").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAADMONVENTAS").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAADMONVENTAS").Visible = False
        End If

        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAVENTAS").Width = 10
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAVENTAS").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAVENTAS").HeaderText = ""
        DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAVENTAS").DefaultCellStyle.BackColor = Color.GreenYellow

        DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAAVENTAS").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAAVENTAS").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAAVENTAS").HeaderText = "USUARIO REGRESA A VENTAS"

        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAVENTAS").Width = 100
        DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAVENTAS").HeaderText = "USUARIO RECIBE REGRESO A VENTAS"

        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAVENTAS").Width = 60
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAVENTAS").ReadOnly = True
        DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAVENTAS").HeaderText = "FECHA"

        If ConectaBD.Departamento = "ADMON. VENTAS" Or ConectaBD.Departamento = "SISTEMAS" Then
            DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAVENTAS").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAAVENTAS").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAVENTAS").Visible = True
            DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAVENTAS").Visible = True
        Else
            DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAVENTAS").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAAVENTAS").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAVENTAS").Visible = False
            DGBitacoraSeguimientoMuestras.Columns.Item("FECHAREGRESAAVENTAS").Visible = False
        End If
        'DGBitacoraSeguimientoMuestras.Rows(1).Cells(5).ReadOnly = True
        'DGBitacoraSeguimientoMuestras.Columns.Item(0).DefaultCellStyle.BackColor = Color.Green
    End Sub

    Private Sub TxtArgolla_KeyUp(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtArgolla.KeyUp
        If e.KeyCode = Keys.Enter Then
            TxtFolio.Text = ""
            LlenaGrid("ARGOLLA")
        End If
    End Sub

    Private Sub BtnVerLista_Click(sender As System.Object, e As System.EventArgs) Handles BtnVerLista.Click
        TxtFolio.Text = ""
        TxtArgolla.Text = ""
        LlenaGrid("LISTACOMPLETA")
    End Sub

    Private Sub DGBitacoraSeguimientoMuestras_CellFormatting(sender As System.Object, e As System.Windows.Forms.DataGridViewCellFormattingEventArgs) Handles DGBitacoraSeguimientoMuestras.CellFormatting
        If DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAPRODUCCION").Index = e.ColumnIndex Then
            If IsDBNull(DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).Value) = True Then
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).ReadOnly = False
            Else
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).ReadOnly = True
            End If
        End If
        If DGBitacoraSeguimientoMuestras.Columns.Item("ENTREGAMAQUILADOR").Index = e.ColumnIndex Then
            If DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex - 4).Value = False Then
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).ReadOnly = True
            ElseIf (ConectaBD.Departamento = "PRODUCCION" Or ConectaBD.Departamento = "SISTEMAS") And IsDBNull(DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).Value) = True Then
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).ReadOnly = False
                'ElseIf IsDBNull(DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).Value) = True Then
                '   DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).ReadOnly = False
            Else
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).ReadOnly = True
            End If
        End If
        If DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAPRODUCCION").Index = e.ColumnIndex Then
            If DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex - 3).Value = False Then
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 2).ReadOnly = True
            ElseIf IsDBNull(DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).Value) = True Then
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 2).ReadOnly = False
            Else
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 2).ReadOnly = True
            End If
        End If
        If DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAADMONVENTAS").Index = e.ColumnIndex Then
            If DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex - 4).Value = False Then
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).ReadOnly = True
            ElseIf IsDBNull(DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).Value) = True Then
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).ReadOnly = False
            Else
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).ReadOnly = True
            End If
        End If
        If DGBitacoraSeguimientoMuestras.Columns.Item("REGRESAAVENTAS").Index = e.ColumnIndex Then
            If DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex - 4).Value = False Then
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 2).ReadOnly = True
            ElseIf IsDBNull(DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 3).Value) = True Then
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 2).ReadOnly = False
            Else
                DGBitacoraSeguimientoMuestras.Rows(e.RowIndex).Cells(e.ColumnIndex + 2).ReadOnly = True
            End If
        End If
    End Sub

    Private Sub DGBitacoraSeguimientoMuestras_EditingControlShowing(sender As System.Object, e As System.Windows.Forms.DataGridViewEditingControlShowingEventArgs) Handles DGBitacoraSeguimientoMuestras.EditingControlShowing
        If (CType(sender, DataGridView).CurrentCell.ColumnIndex = DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAPRODUCCION").Index) Then
            CType(e.Control, TextBox).PasswordChar = CChar("*")
        ElseIf (CType(sender, DataGridView).CurrentCell.ColumnIndex = DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAPRODUCCION").Index) Then
            CType(e.Control, TextBox).PasswordChar = CChar("*")
        ElseIf (CType(sender, DataGridView).CurrentCell.ColumnIndex = DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAADMONVENTAS").Index) Then
            CType(e.Control, TextBox).PasswordChar = CChar("*")
        ElseIf (CType(sender, DataGridView).CurrentCell.ColumnIndex = DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAVENTAS").Index) Then
            CType(e.Control, TextBox).PasswordChar = CChar("*")
        Else
            CType(e.Control, TextBox).PasswordChar = Char.MinValue
        End If
    End Sub

    Private Sub DGBitacoraSeguimientoMuestras_CellEndEdit(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DGBitacoraSeguimientoMuestras.CellEndEdit
        Dim Cve_Usu As String
        Dim Password As String
        Dim Nom_Usu As String
        Password = IIf(IsDBNull(DGBitacoraSeguimientoMuestras.CurrentCell.Value) = False, DGBitacoraSeguimientoMuestras.CurrentCell.Value, "")
        If Password = "" Then
            Exit Sub
        End If
        If DGBitacoraSeguimientoMuestras.Columns.Item("CVE_ORDEN").Index = e.ColumnIndex Then
            Password = DGBitacoraSeguimientoMuestras.CurrentCell.Value
        Else
            Password = ConectaBD.Encriptar(UCase(Password))
        End If
        DGBitacoraSeguimientoMuestras.CurrentCell.Value = ""
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        If DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAPRODUCCION").Index = e.ColumnIndex Then
            BDComando.CommandText = "SELECT * FROM USUARIOS WHERE CONTRASEÑA = '" & Password & "' AND DEPARTAMENTO IN('ADMON. VENTAS','SISTEMAS')"
        ElseIf DGBitacoraSeguimientoMuestras.Columns.Item("CVE_ORDEN").Index = e.ColumnIndex Then
            BDComando.CommandText = "SELECT * FROM USUARIOS WHERE CVE_USU = '" & ConectaBD.Cve_Usuario & "'"
        ElseIf DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAPRODUCCION").Index = e.ColumnIndex Or DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAADMONVENTAS").Index = e.ColumnIndex Then
            BDComando.CommandText = "SELECT * FROM USUARIOS WHERE CONTRASEÑA = '" & Password & "' AND DEPARTAMENTO IN('PRODUCCION','SISTEMAS')"
        ElseIf DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAVENTAS").Index = e.ColumnIndex Then
            BDComando.CommandText = "SELECT * FROM USUARIOS WHERE CONTRASEÑA = '" & Password & "' AND DEPARTAMENTO IN('VENTAS','SISTEMAS')"
        End If
        Try
            BDComando.Connection.Open()
            BDReader = BDComando.ExecuteReader
            If BDReader.HasRows = False Then
                MessageBox.Show("Usuario no valido ó contraseña incorrecta.", "Bitacora de seguimiento a muestras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Else
                BDReader.Read()
                Cve_Usu = BDReader("CVE_USU")
                Nom_Usu = BDReader("NOM_USUARIO")
                If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                    BDReader.Close()
                End If
                If BDComando.Connection.State = ConnectionState.Open Then
                    BDComando.Connection.Close()
                End If
                BDComando.Parameters.Clear()
                BDComando.CommandType = CommandType.StoredProcedure
                BDComando.CommandText = "SP_MODIFICACION_BITACORA_SEGUIMIENTO_MUESTRAS"
                BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@NUM_FOLIO", SqlDbType.BigInt)
                BDComando.Parameters.Add("@ARGOLLA", SqlDbType.BigInt)
                BDComando.Parameters.Add("@CVE_USUENT", SqlDbType.BigInt)
                BDComando.Parameters.Add("@CVE_USUREC", SqlDbType.BigInt)
                BDComando.Parameters.Add("@OP", SqlDbType.BigInt)
                BDComando.Parameters.Add("@PROCESO", SqlDbType.NVarChar)

                BDComando.Parameters("@EMPRESA").Value = ConectaBD.Cve_Empresa
                BDComando.Parameters("@NUM_FOLIO").Value = Val(DGBitacoraSeguimientoMuestras.Rows.Item(DGBitacoraSeguimientoMuestras.CurrentCell.RowIndex).Cells("NUM_FOLIO").Value)
                BDComando.Parameters("@ARGOLLA").Value = Val(DGBitacoraSeguimientoMuestras.Rows.Item(DGBitacoraSeguimientoMuestras.CurrentCell.RowIndex).Cells("ARGOLLA").Value)
                BDComando.Parameters("@CVE_USUENT").Value = Cve_Usu
                BDComando.Parameters("@CVE_USUREC").Value = ConectaBD.Cve_Usuario
                If DGBitacoraSeguimientoMuestras.Columns.Item("CVE_ORDEN").Index = e.ColumnIndex Then
                    BDComando.Parameters("@OP").Value = Val(Password)
                Else
                    BDComando.Parameters("@OP").Value = 0
                End If
                If DGBitacoraSeguimientoMuestras.Columns.Item("USUENTREGAPRODUCCION").Index = e.ColumnIndex Then
                    BDComando.Parameters("@PROCESO").Value = "ENTREGAPRODUCCIONADMONVENTAS"
                ElseIf DGBitacoraSeguimientoMuestras.Columns.Item("CVE_ORDEN").Index = e.ColumnIndex Then
                    BDComando.Parameters("@PROCESO").Value = "MANDAPRODUCCIONAMAQUILADOR"
                ElseIf DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAPRODUCCION").Index = e.ColumnIndex Then
                    BDComando.Parameters("@PROCESO").Value = "RECIBEPRODUCCIONREGRESOMAQUILADOR"
                ElseIf DGBitacoraSeguimientoMuestras.Columns.Item("USUREGRESAADMONVENTAS").Index = e.ColumnIndex Then
                    BDComando.Parameters("@PROCESO").Value = "REGRESAPRODUCCIONADMONVENTAS"
                ElseIf DGBitacoraSeguimientoMuestras.Columns.Item("USURECIBEREGRESOAVENTAS").Index = e.ColumnIndex Then
                    BDComando.Parameters("@PROCESO").Value = "REGRESAADMONVENTASAVENTAS"
                End If

                BDComando.Connection.Open()
                BDComando.ExecuteNonQuery()

                If Val(TxtFolio.Text) <> 0 Then
                    LlenaGrid("FOLIO")
                ElseIf Val(TxtArgolla.Text) <> 0 Then
                    LlenaGrid("ARGOLLA")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Se genero un error al guardar el movimiento de la bitacora de seguimiento de muestras, contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Bitacora de seguimiento de muestras", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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
End Class
Imports System.Data
Imports System.Data.SqlClient

Public Class MovimientoProductoTerminadoEntreAlmacenes
    Private BDComando As SqlCommand
    Private BDReader As SqlDataReader

    Private Sub MovimientoProductoTerminadoEntreAlmacenes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand()
        BDComando.Connection = ConectaBD.BDConexion
        CargarAlmacenes()
    End Sub

    Private Sub CargarAlmacenes()
        If ListAlmacenes Is Nothing Then
            Return
        End If

        ListAlmacenes.Items.Clear()
        BDComando.Parameters.Clear()
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT DISTINCT Almacen FROM PRENDA_INVENTARIO_ALMACEN WHERE Empresa = @EMPRESA AND Almacen NOT IN ('LIBERADO','RECOLECTADO','TEMPORAL CON OP','TEMPORAL SIN OP') ORDER BY Almacen"
        BDComando.Parameters.Add("@EMPRESA", SqlDbType.BigInt).Value = ConectaBD.Cve_Empresa

        Try
            If BDComando.Connection.State = ConnectionState.Closed Then
                BDComando.Connection.Open()
            End If

            BDReader = BDComando.ExecuteReader()

            While BDReader.Read()
                If IsDBNull(BDReader("Almacen")) = False Then
                    ListAlmacenes.Items.Add(BDReader("Almacen").ToString())
                End If
            End While

        Catch ex As Exception
            MessageBox.Show("Se genero un error al cargar los almacenes disponibles, favor de contactar a sistemas y dar como referencia el siguiente mensaje." & vbCrLf & "-" & ex.Message, "Consulta de almacenes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Finally
            If Not BDReader Is Nothing AndAlso Not BDReader.IsClosed Then
                BDReader.Close()
            End If
            If BDComando.Connection.State = ConnectionState.Open Then
                BDComando.Connection.Close()
            End If
        End Try
    End Sub
End Class
Imports System.Data
Imports System.Data.SqlClient

Public Class FichaTecnicaProceso
    Private BDAdapter As SqlDataAdapter
    Private BDComando As SqlCommand
    Private BDTabla As DataTable
    Private BDReader As SqlDataReader

    Private Sub FichaTecnicaProceso_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        BDComando = New SqlCommand
        BDComando.Connection = ConectaBD.BDConexion
        BDComando.CommandType = CommandType.Text
        BDComando.CommandText = "SELECT P.NIVEL1,P.NIVEL2,P.NIVEL3,P.DESCRIPCION,M.CVE_MAQUILADOR,M.ENCARGADO,FTP.PROVEEDORCAPACIDAD, FTP.PROVEEDORCOSTO FROM MAQUILADOR M,CATALOGO_PROCESOS P,FichaTecnicaProceso FTP WHERE P.NIVEL1 = FTP.ProcesoNivel1 and P.NIVEL2 = FTP.ProcesoNivel2 AND P.NIVEL3 = FTP.ProcesoNivel3 AND M.Cve_Maquilador = FTP.CveProveedor"
        BDComando.Connection.Open()
        BDReader = BDComando.ExecuteReader
        If BDReader.HasRows = True Then
            Do While BDReader.Read = True
                GrdCapacidad.Rows.Add(BDReader("DESCRIPCION"), BDReader("ENCARGADO"), BDReader("PROVEEDORCAPACIDAD"), BDReader("PROVEEDORCOSTO"))
            Loop
        End If
        BDReader.Close()
        BDComando.Connection.Close()
    End Sub
End Class
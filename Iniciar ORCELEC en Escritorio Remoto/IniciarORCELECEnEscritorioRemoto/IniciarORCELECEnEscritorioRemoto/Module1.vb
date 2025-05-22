Imports System.Diagnostics
Imports System.IO
Imports System.Threading

Module Module1

    Sub Main()
        Try
            ' Obtener la ruta dinámica del acceso directo .appref-ms
            Dim accesoDirecto As String = System.IO.Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.StartMenu),
                "Programs\UET\ORCELEC\ORCELEC (Nuevo).appref-ms"
            )

            ' Iniciar el programa ClickOnce
            Process.Start(accesoDirecto)

            ' Esperar unos segundos para que se alcance a lanzar la app (opcional)
            Thread.Sleep(5000)

        Catch ex As Exception
            MsgBox("Error al iniciar ORCELEC: " & ex.Message)
        End Try
    End Sub

End Module

Public Class FrmSepararArchivosPDF

    Private Sub BtnSepararPaginas_Click(sender As System.Object, e As System.EventArgs) Handles BtnSepararPaginas.Click
        SplitPdfByParts("U:\PRODUCC\SCANDOC\REMISIONES\TRASPASO")
    End Sub
    Public Shared Sub SplitPdfByParts(ByVal sourcePdf As String)
        Dim reader As iTextSharp.text.pdf.PdfReader = Nothing
        Dim doc As iTextSharp.text.Document = Nothing
        Dim pdfCpy As iTextSharp.text.pdf.PdfCopy = Nothing
        Dim page As iTextSharp.text.pdf.PdfImportedPage = Nothing
        Dim pageCount As Integer = 0
        Dim ListaArchivos() As String
        Dim ContadorLista As Long
        Dim Inicio As Integer
        Dim fileReader As System.IO.StreamReader
        Dim NumRemisiones As String
        Dim outfile As String
        Dim PosicionInicial As Long
        Dim PosicionFinal As Long

        'SE VA A HACER UNA LISTA DE LOS ARCHIVOS QUE SE VAN A DIVIDIR
        ContadorLista = 1
        Dim NumArchivos = My.Computer.FileSystem.GetFiles(sourcePdf)
        If NumArchivos.Count > 0 Then
            For Contador = 0 To NumArchivos.Count - 1
                If UCase(Strings.Right(NumArchivos.Item(Contador), 3)) = "PDF" Then
                    ReDim Preserve ListaArchivos(ContadorLista)
                    Inicio = InStrRev(NumArchivos.Item(Contador), "\")

                    'MsgBox(NumArchivos.Item(Contador).Substring(Inicio, Len(NumArchivos.Item(Contador)) - Inicio - 4))
                    ListaArchivos(ContadorLista) = NumArchivos.Item(Contador).Substring(Inicio, Len(NumArchivos.Item(Contador)) - Inicio - 4)  'Strings.Left(NumArchivos.Item(Contador), Len(NumArchivos.Item(Contador)) - 4)
                    ContadorLista += 1
                End If
            Next
            If UBound(ListaArchivos) > 0 Then
                For Contador As Long = 1 To UBound(ListaArchivos)
                    Try
                        fileReader = My.Computer.FileSystem.OpenTextFileReader(sourcePdf & "\" & ListaArchivos(Contador) & ".TXT")
                        NumRemisiones = fileReader.ReadLine()
                        If Trim(NumRemisiones) = "" Then
                            Throw New ArgumentException("El archivo de texto no contiene datos para poder hacer la separación")
                        Else
                            PosicionInicial = 1
                        End If
                        Try
                            reader = New iTextSharp.text.pdf.PdfReader(sourcePdf & "\" & ListaArchivos(Contador) & ".PDF")
                            pageCount = reader.NumberOfPages
                            If pageCount <= 0 Then
                                Throw New ArgumentException("El PDF no contiene paginas para poder hacer la separación")
                            Else
                                For PaginaActual As Long = 1 To pageCount
                                    'Obtener el nombre de la salida de archivo
                                    outfile = String.Empty
                                    PosicionFinal = InStr(NumRemisiones, ",")
                                    If PosicionFinal = 0 Then
                                        PosicionFinal = Len(NumRemisiones)
                                        outfile = Trim(Mid(NumRemisiones, PosicionInicial, PosicionFinal))
                                    Else
                                        outfile = Trim(Mid(NumRemisiones, PosicionInicial, PosicionFinal - PosicionInicial))
                                    End If
                                    PosicionInicial = PosicionFinal + 1
                                    NumRemisiones = Mid(NumRemisiones, PosicionInicial, Len(NumRemisiones) - PosicionInicial + 1)
                                    PosicionInicial = 1
                                    doc = New iTextSharp.text.Document(reader.GetPageSizeWithRotation(PaginaActual))
                                    pdfCpy = New iTextSharp.text.pdf.PdfCopy(doc, New IO.FileStream("U:\PRODUCC\SCANDOC\REMISIONES\" & Format(CLng(outfile), "00000000") & ".pdf", IO.FileMode.Create))
                                    doc.Open()
                                    page = pdfCpy.GetImportedPage(reader, PaginaActual)
                                    pdfCpy.AddPage(page)
                                    doc.Close()
                                Next
                            End If
                            reader.Close()
                            fileReader.Close()
                            My.Computer.FileSystem.DeleteFile(sourcePdf & "\" & ListaArchivos(Contador) & ".PDF")
                            My.Computer.FileSystem.DeleteFile(sourcePdf & "\" & ListaArchivos(Contador) & ".TXT")
                        Catch ex As Exception
                            MessageBox.Show("Error al leer el archivo pdf, favor de contactar a sistemas y dar como referencia el siguiente número " & ListaArchivos(Contador), "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End Try
                    Catch ex As Exception
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        MessageBox.Show("Error al leer el archivo de texto, favor de consultar con sistemas y dar como referencia el siguiente número " & ListaArchivos(Contador), "Error de lectura", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End Try
                Next
                MessageBox.Show("El archivo se separo correctamente", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Sin archivos para subir a sistema.", "Proceso", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If
    End Sub
End Class

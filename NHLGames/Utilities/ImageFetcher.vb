Imports System.IO
Imports System.Reflection

Namespace Utilities
    Public Class ImageFetcher
        Public Shared Function GetEmbeddedImage(fileName As String, Optional isPngFormat As Boolean = False) As Image
            Dim image As Image = Nothing
            Dim myAssembly As Assembly = Assembly.GetExecutingAssembly()
            Dim myStream As Stream = myAssembly.GetManifestResourceStream($"NHLGames.{fileName}{If(isPngFormat, ".png", ".gif")}")

            If myStream IsNot Nothing Then
                image = Image.FromStream(myStream)
                myStream.Close()
            End If

            Return image
        End Function
    End Class
End Namespace

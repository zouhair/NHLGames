Imports System.IO

Namespace Utilities

    Public Class ImageFetcher

        Public Shared Function GetEmbeddedImage(fileName As String) As Image
            Dim image As Image = Nothing
            Dim myAssembly As Reflection.Assembly = Reflection.Assembly.GetExecutingAssembly()
            Dim myStream As Stream = myAssembly.GetManifestResourceStream("NHLGames." & fileName & ".gif")

            If myStream IsNot Nothing Then
                image = Image.FromStream(myStream)
            End If

            myStream.Close()

            Return image
        End Function

    End Class
End Namespace

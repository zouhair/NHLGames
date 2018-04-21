Imports System.IO
Imports System.Reflection
Imports System.Text
Imports Svg

Namespace Utilities
    Public Class ImageFetcher
        Public Shared Function GetEmbeddedImage(fileName As String, Optional isPngFormat As Boolean = False) As Image
            Dim image As Image = Nothing
            Dim myAssembly As Assembly = Assembly.GetExecutingAssembly()
            Dim myStream As Stream =
                    myAssembly.GetManifestResourceStream($"NHLGames.{fileName.ToLower()}{If(isPngFormat, ".png", ".gif")}")

            If myStream IsNot Nothing Then
                image = Image.FromStream(myStream)
                myStream.Close()
            End If

            Return image
        End Function

        Public Shared Function GetImageFromEmbeddedSvg(fileName As String) As Bitmap
            Dim myAssembly As Assembly = Assembly.GetExecutingAssembly()
            Using s As Stream = myAssembly.GetManifestResourceStream($"NHLGames.{fileName.ToLower()}.svg")
                s.Position = 0
                Return (SvgDocument.Open(Of SvgDocument)(s)).Draw()
            End Using
        End Function
    End Class
End Namespace

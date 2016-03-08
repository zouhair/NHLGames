Imports Newtonsoft.Json

Public Class Games
    Public Class dates
        <JsonProperty("dates")>
        Public game As Game
    End Class

    Public Class Game
        <JsonProperty("@gamePk")>
        Public gamePK As String
    End Class
End Class

Imports System.Data.OleDb
Imports System.IO
Module Module1
    Public dateFrom As Double
    Public dateTo As Double
    Public patch = New System.IO.FileInfo(Application.ExecutablePath).DirectoryName & "\settings.txt"
    Public dbase As String
    Public Function getsettingitem(ByVal file As String, ByVal identifier As String) As String
        Dim s As New IO.StreamReader(file) : Dim result As String = ""
        Do While (s.Peek <> -1)
            Dim line As String = s.ReadLine
            If line.ToLower.StartsWith(identifier.ToLower & ":") Then
                result = line.Substring(identifier.Length + 2)
            End If
        Loop
        Return result
    End Function
End Module

Imports System.Net
Imports System.IO

Public Class Form1

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Public Function gci() As String 'get client ip

        Dim client As New WebClient
        '// Add a user agent header in case the requested URI contains a query.
        client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR1.0.3705;)")
        Dim baseurl As String = "http://checkip.dyndns.org/"
        ' with proxy server only:
        Dim proxy As IWebProxy = WebRequest.GetSystemWebProxy()
        proxy.Credentials = CredentialCache.DefaultNetworkCredentials
        client.Proxy = proxy
        Dim data As Stream
        Try
            data = client.OpenRead(baseurl)
        Catch ex As Exception
            MsgBox("open url " & ex.Message)
            'Exit Function
        End Try
        Dim reader As StreamReader = New StreamReader(data)
        Dim s As String = reader.ReadToEnd()
        data.Close()
        reader.Close()
        s = s.Replace("<html><head><title>Current IP Check</title></head><body>", "").Replace("</body></html>", "").ToString()
        'MessageBox.Show(s)
        Dim ip_split() As String = Split(s)
        Return ip_split(3)

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TextBox1.Text = gci()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim lic, txt, str As String
        lic = "C:\Program Files (x86)\TSplus\UserDesktop\files\license.lic"
        txt = "C:\Program Files (x86)\TSplus\UserDesktop\files\license.txt"
        str = ""

        If File.Exists(lic) Then
            Try
                My.Computer.FileSystem.CopyFile(lic, txt,
                            Microsoft.VisualBasic.FileIO.UIOption.AllDialogs,
                            Microsoft.VisualBasic.FileIO.UICancelOption.DoNothing)

                Dim objReader As New StreamReader(txt)
                Dim sLine As String = ""
                Dim arrText As New ArrayList()

                Do
                    sLine = objReader.ReadLine()
                    If Not sLine Is Nothing Then
                        arrText.Add(sLine)
                        'MsgBox(sLine)
                    End If

                Loop Until sLine Is Nothing
                objReader.Close()
                TextBox1.Text = arrText.ToString
                System.IO.File.Delete(txt)
            Catch ex As Exception

            End Try



            'str = arrText(2)
            '' Split string based on spaces.
            'Dim str_split As String() = str.Split(New Char() {"="c})

            ''serial con sal
            'str = "L0L!" & str_split(1).Trim & "?!#E("
            'gi = gi & str
            '
        Else
            MsgBox("no existe la ruta")
        End If
    End Sub
End Class

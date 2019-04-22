Imports MySql.Data.MySqlClient

Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim frm As New regkunde
        frm.ShowDialog()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim frm As New regansatt
        frm.ShowDialog()

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Dim frm As New Regsykkel
        frm.ShowDialog()

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click

        Dim frm As New Regutstyr
        frm.ShowDialog()

    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim frm As New Utvikler
        frm.ShowDialog()
    End Sub

    ' Denne funksjonen kan benyttes fra flere steder i koden, slår opp poststed basert på postnr
    Public Function Hentpoststed(ByVal postnr As String)

        Dim tilkobling As New MySqlConnection(
        "Server=mysql-ait.stud.idi.ntnu.no;" _
        & "Database=stigp;" _
        & "Uid=stigp;" _
        & "Pwd=srZqo8k4;")

        tilkobling = New MySqlConnection("Server=mysql-ait.stud.idi.ntnu.no;Database=stigp;Uid=stigp;Pwd=srZqo8k4;")
        tilkobling.Open()

        'Dim input = TextBox1.Text
        Dim poststed As String = ""

        Dim sql3 As New MySqlCommand("Select poststed from poststd, postnr where poststd.postnrid=postnr.id and postnr.postnummer=@postnummer", tilkobling)
        sql3.Parameters.AddWithValue("@postnummer", postnr)

        'Dim leser = sql3.ExecuteReader()
        'While leser.Read()
        'MsgBox(leser("poststed"))
        'End While

        Using leser = sql3.ExecuteReader()
            If leser.HasRows Then
                While leser.Read()
                    'MsgBox(leser("poststed"))
                    poststed = leser("poststed")

                End While
            End If
        End Using

        tilkobling.Close()

        Return poststed

    End Function

    ' pre test
    'Public Sub Populerlokasjon()

    'Dim RegBest As New Regbestilling
    'RegBest.Show()
    'RegBest.ComboBox4.Items.Add("TEST")

    'End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim frm As New Reglokasjon
        frm.ShowDialog()

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click

        Dim frm As New Regbestilling
        frm.ShowDialog()

    End Sub
End Class

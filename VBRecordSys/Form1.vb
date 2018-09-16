Imports MySql.Data.MySqlClient
Public Class Form1
    Public conn As New MySqlConnection("Server=localhost; User Id=root1; Password=''; Database=db_vbrecords")
    Public adapter As New MySqlDataAdapter
    Public command As New MySqlCommand
    Dim ds As DataSet

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If TextBox3.Text = TextBox5.Text Then
            ds = New DataSet
            adapter = New MySqlDataAdapter("INSERT INTO tbl_accounts (username, password, privilege) VALUES " &
                                           "('" & TextBox4.Text & "','" & TextBox3.Text & "','" & ComboBox1.Text & "')", conn)
            adapter.Fill(ds, "tbl_accounts")
            TextBox3.Clear()
            TextBox4.Clear()
            TextBox5.Clear()
            ComboBox1.Text = ""
            MsgBox("User Registered!")
        Else
            MsgBox("Passwords does not match")
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New MySqlDataAdapter("SELECT * FROM tbl_accounts where username = '" & TextBox1.Text &
                                       "' and password = '" & TextBox2.Text & "'", conn)
        adapter.Fill(ds, "tbl_accounts")

        If ds.Tables("tbl_accounts").Rows.Count() > 0 Then
            MsgBox("Welcome")
            TextBox1.Clear()
            TextBox2.Clear()
            Form2.Show()
            Me.Hide()
        Else
            MsgBox("Wrong combination of username and password")
        End If
    End Sub
End Class

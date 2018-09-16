Imports MySql.Data.MySqlClient
Public Class Form3
    Public conn As New MySqlConnection("Server=localhost; User Id=root1; Password=''; Database=db_vbrecords")
    Public adapter As New MySqlDataAdapter
    Public command As New MySqlCommand
    Dim ds As DataSet
    Dim currentid As String

    Private Sub Form3_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Form2.Show()
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetRecords()
    End Sub

    Public Sub GetRecords()
        ds = New DataSet
        adapter = New MySqlDataAdapter("SELECT * FROM tbl_accounts", conn)
        adapter.Fill(ds, "tbl_accounts")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tbl_accounts"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New MySqlDataAdapter("INSERT INTO tbl_accounts (username, password, privilege) VALUES " &
                                       "('" & TextBox1.Text & "','" & TextBox2.Text & "','" & ComboBox1.Text & "')", conn)
        adapter.Fill(ds, "tbl_accounts")
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.Text = ""

        GetRecords()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        currentid = DataGridView1.Item(0, i).Value.ToString()

        ds = New DataSet
        adapter = New MySqlDataAdapter("DELETE FROM tbl_accounts WHERE id = " & currentid, conn)
        adapter.Fill(ds, "tbl_accounts")

        GetRecords()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        currentid = DataGridView1.Item(0, i).Value.ToString()
        TextBox1.Text = DataGridView1.Item(1, i).Value.ToString()
        TextBox2.Text = DataGridView1.Item(2, i).Value.ToString()
        ComboBox1.Text = DataGridView1.Item(3, i).Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ds = New DataSet
        adapter = New MySqlDataAdapter("UPDATE tbl_accounts SET username = '" & TextBox1.Text &
                                       "', password = '" & TextBox2.Text &
                                       "', privilege = '" & ComboBox1.Text &
                                       "' where id = " & currentid, conn)
        adapter.Fill(ds, "tbl_accounts")
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox1.Text = ""

        GetRecords()
    End Sub
End Class
Imports MySql.Data.MySqlClient
Public Class Form4
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
        adapter = New MySqlDataAdapter("SELECT * FROM tbl_records", conn)
        adapter.Fill(ds, "tbl_records")
        DataGridView1.DataSource = ds
        DataGridView1.DataMember = "tbl_records"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ds = New DataSet
        adapter = New MySqlDataAdapter("INSERT INTO tbl_records (firstname, lastname, age, gender) VALUES " &
                                       "('" & TextBox1.Text & "','" & TextBox2.Text &
                                       "','" & TextBox3.Text & "','" &
                                       ComboBox1.Text & "')", conn)
        adapter.Fill(ds, "tbl_records")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox1.Text = ""

        GetRecords()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index
        currentid = DataGridView1.Item(0, i).Value.ToString()

        ds = New DataSet
        adapter = New MySqlDataAdapter("DELETE FROM tbl_records WHERE id = " & currentid, conn)
        adapter.Fill(ds, "tbl_records")

        GetRecords()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim i As Integer
        i = DataGridView1.CurrentRow.Index

        currentid = DataGridView1.Item(0, i).Value.ToString()
        TextBox1.Text = DataGridView1.Item(1, i).Value.ToString()
        TextBox2.Text = DataGridView1.Item(2, i).Value.ToString()
        TextBox3.Text = DataGridView1.Item(3, i).Value.ToString()
        ComboBox1.Text = DataGridView1.Item(4, i).Value.ToString()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ds = New DataSet
        adapter = New MySqlDataAdapter("UPDATE tbl_records SET firstname = '" & TextBox1.Text &
                                       "', lastname = '" & TextBox2.Text &
                                       "', age = '" & TextBox3.Text &
                                       "', gender = '" & ComboBox1.Text &
                                       "' where id = " & currentid, conn)
        adapter.Fill(ds, "tbl_records")
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        ComboBox1.Text = ""

        GetRecords()
    End Sub
End Class
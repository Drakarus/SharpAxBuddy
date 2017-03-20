Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class Form2

    Dim connectionsql As New SqlConnection
    Dim command As New SqlCommand

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        connectionsql = New SqlConnection
        '"server=LEN05-THINK\DANW;userid=MAUDESPORT\danwon;password=boxing123;database=NORTHWND"
        '-CONNECTION TO SQL--
        connectionsql.ConnectionString = "Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True"
        'connectionsql.ConnectionString = "Data Source=DAN-PC;Initial Catalog=NORTHWND;Integrated Security=True"
        Dim SDA As New SqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            connectionsql.Open()
            Dim query As String
            query = "select * from products"
            command = New SqlCommand(query, connectionsql)
            SDA.SelectCommand = command
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            DataGridView1.DataSource = bSource
            SDA.Update(dbDataSet)
            connectionsql.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            connectionsql.Dispose()
        End Try


    End Sub


    Private Sub tsExit_Click(sender As Object, e As EventArgs) Handles tsExit.Click
        MainForm.tabForms.TabPages.Remove(MainForm.tabForms.SelectedTab)
    End Sub
End Class
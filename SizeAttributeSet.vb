Imports System.Data.Sql
Imports System.Data.SqlClient

Public Class SizeAttributeSet
    Dim connectionsql As New SqlConnection
    Dim command As New SqlCommand

    Private Sub SizeAttributeSet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connectionsql = New SqlConnection
        '-CONNECTION TO SQL--
        'connectionsql.ConnectionString = "Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True"
        connectionsql.ConnectionString = "Data Source=DAN-PC;Initial Catalog=NORTHWND;Integrated Security=True"
        Dim SDA As New SqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            connectionsql.Open()
            Dim query As String
            query = "select AttributeID, AttributeName from Attributes where AttributeType = '1' "
            command = New SqlCommand(query, connectionsql)
            SDA.SelectCommand = command
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            dgvSet.DataSource = bSource
            SDA.Update(dbDataSet)
            dgvSet.Columns(0).Visible = False
            connectionsql.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            connectionsql.Dispose()
        End Try

    End Sub

    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        ''Dim i = dgvSet.CurrentRow.Index
        'Dim i = dgvSet.CurrentRow.Cells(0).Value
        'MessageBox.Show(i)
        'connectionsql = New SqlConnection
        'connectionsql.ConnectionString =
        '    "Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True"
        'Dim SDA As New SqlDataAdapter
        'Dim dbDataSet As New DataTable
        'Dim bSource As New BindingSource
        'Try
        '    connectionsql.Open()
        '    Dim query As String
        '    query = "select AttributeID, AttributeName from AttributeSize where "
        '    command = New SqlCommand(query, connectionsql)
        '    SDA.SelectCommand = command
        '    SDA.Fill(dbDataSet)
        '    bSource.DataSource = dbDataSet
        '    dgvAttributes.DataSource = bSource
        '    SDA.Update(dbDataSet)
        '    dgvAttributes.Columns(0).Visible = False
        '    connectionsql.Close()
        'Catch ex As Exception
        '    MessageBox.Show(ex.Message)
        'Finally
        '    connectionsql.Dispose()
        'End Try

        'Dim i = dgvSet.CurrentRow.Index

        '----------------------------Get ID value
        Dim i = dgvSet.CurrentRow.Cells(0).Value

        '------------------------------Debugging--
        'MessageBox.Show(i)
        '------

        connectionsql = New SqlConnection
        '-CONNECTION TO SQL--
        'connectionsql.ConnectionString = "Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True"
        connectionsql.ConnectionString = "Data Source=DAN-PC;Initial Catalog=NORTHWND;Integrated Security=True"
        Dim SDA As New SqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            connectionsql.Open()
            'Dim query As String
            command = New SqlCommand("SELECT * FROM AttributeSize Where AttributeID = @Value", connectionsql)
            command.Parameters.AddWithValue("@Value", i)
            SDA.SelectCommand = command
            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            dgvAttributes.DataSource = bSource
            SDA.Update(dbDataSet)
            dgvAttributes.Columns(0).Visible = False
            dgvAttributes.Columns(1).Visible = False
            connectionsql.Close()



            'query = "select AttributeID, AttributeName from AttributeSize where "
            'command = New SqlCommand(query, connectionsql)
            'SDA.SelectCommand = command
            'SDA.Fill(dbDataSet)
            'bSource.DataSource = dbDataSet
            'dgvAttributes.DataSource = bSource
            'SDA.Update(dbDataSet)
            'dgvAttributes.Columns(0).Visible = False
            'connectionsql.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            connectionsql.Dispose()
        End Try

    End Sub

    Private Sub dgvAttributes_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles dgvAttributes.CellMouseClick
        Dim row As DataGridViewRow = dgvAttributes.CurrentRow
        'txtCode.Text = dgvAttributes.Item("SizeCode", dgvAttributes.CurrentRow.
        Me.txtSizeID.Text = row.Cells(0).Value.ToString()
        Me.txtCode.Text = row.Cells(2).Value.ToString()
        Me.txtDescription.Text = row.Cells(3).Value.ToString()

    End Sub
End Class
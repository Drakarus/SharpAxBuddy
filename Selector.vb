Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlConnection
Imports System.Data.ConnectionState
Imports System.Data.SqlClient.SqlDataReader
Imports System.Linq

Public Class Selector

    'Retrieve value from  NewStockVariable
    Public myCaller As NewStockVariable

    Dim connectionsql As New SqlConnection
    Dim command As New SqlCommand
    Dim datareader As SqlDataReader

    Private Sub Selector_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Dim selectName As String
        'selectName = txtSelectType.Text
        'MessageBox.Show(selectName)
        'Dim i = dgvFullList.CurrentRow.Cells(0).Value



        'Initialise dgvSelect
        dgvSelected.Columns.Add("test", "ID")
        dgvSelected.Columns.Add("code", "Code")
        dgvSelected.Columns.Add("Description", "Description")


        Dim i = txtSelectType.Text

        connectionsql = New SqlConnection("Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True")
        Dim SDA As New SqlDataAdapter
        Dim dbDataSet As New DataTable
        Dim bSource As New BindingSource
        Try
            connectionsql.Open()
            'Dim query As String

            'command = New SqlCommand("SELECT * FROM AttributeSize AS AttribSize LEFT JOIN Attributes AS Attrib ON AttribSize.AttributeID = Attrib.AttributeID WHERE Attrib.AttributeName = @Value", connectionsql)
            command = New SqlCommand("SELECT AttribSize.AttributeID, AttribSize.SizeID, AttribSize.SizeCode, AttribSize.SizeDescription  FROM AttributeSize AS AttribSize LEFT JOIN Attributes AS Attrib ON AttribSize.AttributeID = Attrib.AttributeID WHERE Attrib.AttributeName = @Value", connectionsql)
            command.Parameters.AddWithValue("@Value", i)
            SDA.SelectCommand = command

            'query = "select AttributeID, AttributeName from Attributes where AttributeType = '1' "
            'command = New SqlCommand(query, connectionsql)
            'SDA.SelectCommand = command

            SDA.Fill(dbDataSet)
            bSource.DataSource = dbDataSet
            dgvFullList.DataSource = bSource
            SDA.Update(dbDataSet)
            dgvFullList.Columns(0).Visible = False
            dgvFullList.Columns(1).Visible = False
            connectionsql.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            connectionsql.Dispose()
        End Try


    End Sub

    Private Sub btnMoveRight_Click(sender As Object, e As EventArgs) Handles btnMoveRight.Click
        'Dim currentMouseRow As New Integer
        'currentMouseRow = dgvFullList.SelectedRows
        ''Dim id, i As Integer
        ''Dim idList(5)
        ''For Each selectedItem As DataGridViewRow In dgvFullList.SelectedRows
        ''    id = selectedItem.Cells("SizeID").Value
        ''    idList(i) = id
        ''    i += 1
        ''Next selectedItem
        ''Dim sResult As String = ""
        ''For Each elem As String In idList
        ''    sResult &= elem ','
        ''Next
        ''MsgBox(sResult)
        'Dim id As Integer
        'Dim idList As List(Of String)
        Dim dr As New DataGridViewRow
        Dim dt As New DataTable
        Dim bind As New BindingSource
        'For Each row As DataGridViewRow In dgvFullList.SelectedRows
        'idList.Add(selectedItem.Cells.ToString())
        'idList.Add(dgvFullList.SelectedRows(0).Cells(0).Value)
        'Dim dgv()
        'Dim text As String
        'For Each cell As DataGridViewCell In dgvFullList.SelectedCells
        '    text = cell.Value.ToString
        '    For Each scheduleCell As DataGridViewCell In dgvFullList.SelectedCells
        '        scheduleCell.Value.ToString.Equals(text)
        '        dgvSelected.Rows.Add(scheduleCell)


        '    Next scheduleCell
        'Next cell
        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dgvSelected.Columns(0).Visible = False

        For Each dr In Me.dgvFullList.SelectedRows
            'dgvSelected.Columns.Add("ID", GetType(Integer))
            'dgvSelected.Columns.Add("Code", GetType(String))
            'dgvSelected.Columns.Add("Description", GetType(String))
            'dgvSelected.Columns.Add("test", "1")
            'dgvSelected.Columns.Add("code", "2")
            'dgvSelected.Columns.Add("Description", "3")
            dgvSelected.Rows.Add(dr.Cells("SizeID").Value, dr.Cells(2).Value, dr.Cells(3).Value)
            'dt.Rows.Add(dr.Cells(0).Value, dr.Cells(1).Value, dr.Cells(2).Value)

            'bind.DataSource = dt
            ''dgvFullList.DataSource = bSource
            'dgvSelected.DataSource = bind
        Next
        ' Next
        'bind.DataSource = dt
        'dgvSelected.DataSource = bind
    End Sub
End Class
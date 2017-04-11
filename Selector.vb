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

        dgvSelected.Columns.Add("test", "ID")
        dgvSelected.Columns.Add("code", "Code")
        dgvSelected.Columns.Add("Description", "Description")

        If txtSelect.Text = 1 Then

            Dim i = txtSelectType.Text
            'SQL
            connectionsql = New SqlConnection("Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True")
            'connectionsql = New SqlConnection("Data Source=DAN-PC;Initial Catalog=NORTHWND;Integrated Security=True")
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

        ElseIf txtSelect.Text = 2 Then
            Dim i = txtSelectType.Text
            'SQL
            connectionsql = New SqlConnection("Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True")
            'connectionsql = New SqlConnection("Data Source=DAN-PC;Initial Catalog=NORTHWND;Integrated Security=True")
            Dim SDA As New SqlDataAdapter
            Dim dbDataSet As New DataTable
            Dim bSource As New BindingSource
            Try
                connectionsql.Open()
                'Dim query As String

                'command = New SqlCommand("SELECT * FROM AttributeSize AS AttribSize LEFT JOIN Attributes AS Attrib ON AttribSize.AttributeID = Attrib.AttributeID WHERE Attrib.AttributeName = @Value", connectionsql)
                command = New SqlCommand("SELECT AttribCol.AttributeID, AttribCol.ColourID, AttribCol.ColourCode, AttribCol.ColourDescription  FROM AttributeColour AS AttribCol LEFT JOIN Attributes AS Attrib ON AttribCol.AttributeID = Attrib.AttributeID WHERE Attrib.AttributeName = @Value", connectionsql)
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
        Else
            MessageBox.Show("Please select colour or size from dropdown")
        End If




    End Sub

    Private Sub btnMoveRight_Click(sender As Object, e As EventArgs) Handles btnMoveRight.Click
        'https://www.youtube.com/watch?v=smyojy0v_1U
        'How to to display datagridview checked row to another datagridview [withcode]

        'SQLCODE()
        'ALTER TABLE AttributeSize ADD
        'SizeSequence int NOT NULL CONSTRAINT DF_SizeSequence_AttributeSize DEFAULT '1'
        'ALTER TABLE AttributeSize
        'DROP CONSTRAINT DF_SizeSequence_AttributeSize 

        'Update(AttributeSize)
        'SET SizeSequence = '7'
        'WHERE SizeID = '7'




        Dim dr As New DataGridViewRow
        Dim drSelect As New DataGridViewRow
        Dim dt As New DataTable
        Dim bind As New BindingSource

        dt.Columns.Add("ID", GetType(Integer))
        dt.Columns.Add("Code", GetType(String))
        dt.Columns.Add("Description", GetType(String))
        dgvSelected.Columns(0).Visible = False

        'Dim row As DataGridViewRow = dgvSelected.Rows(Of Integer)()

        Dim checkvalue As New Integer
        'For checkvalue = 0 To dgvSelected.Rows.Count
        '    If dgvSelected.Rows(checkvalue).Cells(0).Value = dr.Cells(0).Value Then



        '    End If
        'Next

        'For checkvalue = 0 To dgvSelected.Rows.Count
        '    If dgvSelected.Rows(checkvalue).Cells(0).Value = dr.Cells(0).Value Then

        '    End If
        'Next



        'If dgvSelected.Rows.Count() > 0 Then


        '    '    For j As Integer = 0 To dgvSelected.Rows.Count() - 1 + 1
        '    '    If 
        '    'Next
        '    '    For checkvalue = 0 To dgvSelected.Rows.Count
        '    '        If dgvSelected.Rows(checkvalue).Cells(0).Value = dr.Cells(0).Value Then

        '    '            For Each dr In Me.dgvSelected.Rows
        '    '            Next

        '    '        End If
        '    '    Next

        '    For Each dr In Me.dgvFullList.SelectedRows
        '        'Next
        '        For Each drSelect In Me.dgvSelected.Rows
        '            If drSelect.Cells(0).Value = dr.Cells(0).Value Then

        '            End If
        '            dgvSelected.Rows.Add(dr.Cells(0).Value, dr.Cells(2).Value, dr.Cells(3).Value)
        '        Next
        '        'dgvSelected.Rows.Add(dr.Cells(0).Value, dr.Cells(2).Value, dr.Cells(3).Value)
        '    Next


        'End If

        '--http://stackoverflow.com/questions/33065041/datagridview-value-already-exist-vb
        '--http://stackoverflow.com/questions/12307835/checking-for-duplicates-in-datagridview
        MessageBox.Show(dgvSelected.Rows.Count())
        If dgvSelected.Rows.Count() > 1 Then
            For Each dr In Me.dgvFullList.SelectedRows
                For Each drSelect In Me.dgvSelected.Rows
                    If drSelect.Cells(0).Value = dr.Cells(0).Value Then
                        MessageBox.Show("Already Exists")
                    Else
                        'drSelect.Cells(0).Value = dr.Cells(0).Value
                        dgvSelected.Rows.Add(dr.Cells(0).Value, dr.Cells(2).Value, dr.Cells(3).Value)
                    End If
                Next
            Next
        Else
            For Each dr In Me.dgvFullList.SelectedRows
                dgvSelected.Rows.Add(dr.Cells(0).Value, dr.Cells(2).Value, dr.Cells(3).Value)
            Next
        End If




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
        'Dim dr As New DataGridViewRow
        'Dim dt As New DataTable
        'Dim bind As New BindingSource
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
        'dt.Columns.Add("ID", GetType(Integer))
        'dt.Columns.Add("Code", GetType(String))
        'dt.Columns.Add("Description", GetType(String))
        'dgvSelected.Columns(0).Visible = False

        'For Each dr In Me.dgvFullList.SelectedRows
        'dgvSelected.Columns.Add("ID", GetType(Integer))
        'dgvSelected.Columns.Add("Code", GetType(String))
        'dgvSelected.Columns.Add("Description", GetType(String))
        'dgvSelected.Columns.Add("test", "1")
        'dgvSelected.Columns.Add("code", "2")
        'dgvSelected.Columns.Add("Description", "3")
        'dgvSelected.Rows.Add(dr.Cells("SizeID").Value, dr.Cells(2).Value, dr.Cells(3).Value)
        'dt.Rows.Add(dr.Cells(0).Value, dr.Cells(1).Value, dr.Cells(2).Value)

        'bind.DataSource = dt
        ''dgvFullList.DataSource = bSource
        'dgvSelected.DataSource = bind
        'Next
        ' Next
        'bind.DataSource = dt
        'dgvSelected.DataSource = bind
    End Sub

    Private Sub btnSelect_Click(sender As Object, e As EventArgs) Handles btnSelect.Click

    End Sub
End Class
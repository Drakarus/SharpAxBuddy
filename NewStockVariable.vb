Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlConnection
Imports System.Data.ConnectionState
Imports System.Data.SqlClient.SqlDataReader

Public Class NewStockVariable

    'SQL Connection
    Dim connectionsql As New SqlConnection
    Dim command As New SqlCommand


    'http://www.informit.com/articles/article.aspx?p=102148&seqNum=7
    'Passing information between two forms


    'Value to pass to Size and Colour selectors

    'Public Property selector() As String
    '    Get
    '        Return _selector
    '    End Get
    '    Set(ByVal value As Selector
    '        )
    '        _selector = value
    '    End Set
    'End Property

    'Private Shared m_Selector As Selector
    'Public Shared Property Selector() As Selector
    '    Get
    '        Return m_Selector
    '    End Get
    '    Set(ByVal Value As Selector)
    '        m_Selector = Value
    '    End Set
    'End Property
    Public Class choose
        Dim m_selector As Integer
        Public Property chooser() As Integer
            Get
                Return m_selector
            End Get
            Set(ByVal Value As Integer)
                m_selector = Value
            End Set
        End Property
    End Class



    Private Sub NewStockVariable_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'User damage reduction
        Dim tabPage As TabPage
        For Each tabPage In TabControl1.TabPages
            tabPage.Enabled = False
        Next


        'Type of product combo list
        cbTypeOfProduct.Items.Add("Clothing")
        cbTypeOfProduct.Items.Add("Sent Direct Items")
        cbTypeOfProduct.Items.Add("Stocked Equipment")
        cbTypeOfProduct.Items.Add("Packs")
        'cbStockGrade.Items.Add("

        'Stock Grade
        cbStockGrade.Items.Add("A")
        cbStockGrade.Items.Add("B")
        cbStockGrade.Items.Add("C")
        cbStockGrade.Items.Add("D")
        cbStockGrade.Items.Add("KP")
        cbStockGrade.Items.Add("NEW")
        cbStockGrade.Items.Add("NSC")
        cbStockGrade.Items.Add("NSD")
        cbStockGrade.Items.Add("SC")

        'DefaultSupplier
        cbSupplier.Items.Add("Nike")
        cbSupplier.Items.Add("Adidas")
        cbSupplier.Items.Add("Errea")
        cbSupplier.Items.Add("Prostar")

        cbCategory.Items.Add("Catalogue 7s")
        cbCategory.Items.Add("Catalogue Non 7s")
        cbCategory.Items.Add("FLO")
        cbCategory.Items.Add("None Catalogue")

        cbSupplySite.Items.Add("MS")
        cbSupplySite.Items.Add("WFD")

        cbSpecial.Items.Add("N/A")
        cbSpecial.Items.Add("Clothing/Apparel")
        cbSpecial.Items.Add("Custom Made Non Clothing")
        cbSpecial.Items.Add("BOM")
        cbSpecial.Items.Add("Kit")

        loadData()

    End Sub


    Private Sub ToolStripLabel2_Click(sender As Object, e As EventArgs) Handles ToolStripLabel2.Click
        Me.Close()
        MainForm.tabForms.TabPages.Remove(MainForm.tabForms.SelectedTab)
    End Sub



    'Clothing section generation
    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click


        'GENERATE DATA INTO STOCK ITEM DATGRIDVIEW
        Dim stockGrade = cbStockGrade.Text
        Dim stockCat = cbCategory.Text
        Dim supplySite = cbSupplySite.Text
        Dim supplier = cbSupplier.Text


        '---Code to generate CODE--
        '---Get Size Attribute Set---
        Dim size As String
        size = cbSize.Text
        'MessageBox.Show(size)

        connectionsql = New SqlConnection

        Dim SizeCode As New List(Of String)
        Dim SizeDesc As New List(Of String)
        'SQL
        'Dim constr = "Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True"
        Dim constr = "Data Source=DAN-PC;Initial Catalog=NORTHWND;Integrated Security=True"
        '-CONNECTION TO SQL--
        Using connection As New SqlConnection(constr)
            connection.Open()
            Dim sql As String = "Select SizeCode,SizeDescription From AttributeSize"
            Dim command As New SqlCommand(sql, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                '    Console.WriteLine("{0}", reader(0))
                'list.Add(reader.GetString(reader.GetString("SizeCode")))
                SizeCode.Add(reader.GetString(0))
                SizeDesc.Add(reader.GetString(1))
            End While
            connection.Close()
        End Using

        Dim ColourCode As New List(Of String)
        Dim ColourDesc As New List(Of String)
        'Dim constr = "Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True"
        'Dim constr = "Data Source=DAN-PC;Initial Catalog=NORTHWND;Integrated Security=True"
        '-CONNECTION TO SQL--
        Using connection As New SqlConnection(constr)
            connection.Open()
            Dim sql As String = "Select ColourCode, ColourDescription From AttributeColour"
            Dim command As New SqlCommand(sql, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                '    Console.WriteLine("{0}", reader(0))
                'list.Add(reader.GetString(reader.GetString("SizeCode")))
                ColourCode.Add(reader.GetString(0))
                ColourDesc.Add(reader.GetString(1))
            End While
            connection.Close()
        End Using

        'DEBUG
        'Check length
        'MessageBox.Show(Sizelist.Count)
        'MessageBox.Show(Colourlist.Count)

        'Dim table As DataTable = New DataTable("tablecode")
        'Dim tableall As DataSet = New DataSet
        'Dim tablecoder As DataTable


        Dim z As New Integer
        Dim tableCode As New List(Of String)
        Dim tableDesc As New List(Of String)

        z = 0
        For i = 0 To (ColourCode.Count - 1)
            'tableColour.Add(txtCoreCode.Text & "-" & Colourlist(i))
            'Sizelist()
            'MessageBox.Show(tableDisplay(i))
            For x = 0 To (SizeCode.Count - 1)
                tableCode.Add(txtCoreCode.Text & "-" & ColourCode(i) & "-" & SizeCode(x))
                tableDesc.Add(txtDescription.Text & " " & ColourDesc(i) & " - " & SizeDesc(x))
                'tablecoder.Add(txtCoreCode.Text & "-" & Colourlist(i) & "-" & Sizelist(x))
                'MessageBox.Show(tableColour(z))
                z = z + 1
            Next
        Next


        ' DESCRIPTION GENERATION
        Dim description As String
        description = txtDescription.Text


        'Dim tableSize As New ArrayList()
        'For i = 0 To tableColour.Count
        '    tableSize.Add(tableColour.
        'Next
        'Dim table As DataTable = New DataTable("tablecode")

        'FILL DATAGRID
        'How to populate more than one column below link
        'https://forums.asp.net/t/313268.aspx?How+do+I+populate+a+datagrid+with+values+in+an+ArrayList+

        Dim iCounter As Integer
        Dim ds As New DataSet("MyDataSet")
        Dim dTable As New DataTable("TeamData")

        dTable.Columns.Add("Code", GetType(String))
        dTable.Columns.Add("Description", GetType(String))
        dTable.Columns.Add("StockGrade", GetType(String))
        dTable.Columns.Add("StockCategory", GetType(String))
        dTable.Columns.Add("DefaultSupplySite", GetType(String))
        dTable.Columns.Add("Supplier", GetType(String))

        ds.Tables.Add(dTable)

        For iCounter = 0 To tableCode.Count - 1
            Dim dr As DataRow = dTable.NewRow()
            dr(0) = tableCode(iCounter).ToString
            dr(1) = tableDesc(iCounter).ToString
            dr(2) = stockGrade.ToString
            dr(3) = stockCat.ToString
            dr(4) = supplySite.ToString
            dr(5) = supplier.ToString

            dTable.Rows.Add(dr)
        Next


        dataGridView1.DataSource = ds.Tables("TeamData").DefaultView
        dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        'GENERATE DATA FOR UNIT OF MEASURE

        Dim listCost = txtListCost.Text
        Dim listPrice = txtListPrice.Text



    End Sub

    Private Sub btnSizeSet_Click(sender As Object, e As EventArgs) Handles btnSizeSet.Click
        Dim SizeForm As New SizeAttributeSet
        SizeForm.Show()

    End Sub

    Private Sub btnColourSet_Click(sender As Object, e As EventArgs) Handles btnColourSet.Click
        Dim ColourForm As New ColourAttributeSet
        ColourForm.Show()
    End Sub

    Private Sub loadData()
        Dim connectionsql As New SqlConnection
        Dim command As New SqlCommand
        Dim datareader As SqlDataReader
        '-CONNECTION TO SQL--
        'connectionsql = New SqlConnection("Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True")
        connectionsql = New SqlConnection("Data Source=DAN-PC;Initial Catalog=NORTHWND;Integrated Security=True")
        Try
            connectionsql.Open()
            command.Connection = connectionsql
            command.CommandText = "SELECT AttributeID, AttributeName FROM Attributes WHERE AttributeType = '1'"
            datareader = command.ExecuteReader()
            Do While datareader.Read = True
                cbSize.Items.Add(datareader.GetString(1))
            Loop
            connectionsql.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Try
            connectionsql.Open()
            command.Connection = connectionsql
            command.CommandText = "SELECT AttributeID, AttributeName FROM Attributes WHERE AttributeType = '2'"
            datareader = command.ExecuteReader()
            Do While datareader.Read = True
                cbColour.Items.Add(datareader.GetString(1))
            Loop
            connectionsql.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub


    Private Sub btnLoadType_Click(sender As Object, e As EventArgs) Handles btnLoadType.Click
        Dim value As String = cbTypeOfProduct.Text
        Select Case value
            Case "Clothing"
                TabControl1.SelectedIndex = 0
                TabControl1.TabPages(0).Enabled = True
                TabControl1.TabPages(1).Enabled = False
                TabControl1.TabPages(2).Enabled = False
                TabControl1.TabPages(3).Enabled = False

                TabControl2.SelectedIndex = 0
                TabControl2.TabPages(0).Enabled = True
                TabControl2.TabPages(1).Enabled = False
                TabControl2.TabPages(2).Enabled = False
                TabControl2.TabPages(3).Enabled = False

            Case "Sent Direct Items"
                TabControl1.SelectedIndex = 1
                TabControl1.TabPages(0).Enabled = False
                TabControl1.TabPages(1).Enabled = True
                TabControl1.TabPages(2).Enabled = False
                TabControl1.TabPages(3).Enabled = False

                TabControl2.SelectedIndex = 1
                TabControl2.TabPages(0).Enabled = False
                TabControl2.TabPages(1).Enabled = True
                TabControl2.TabPages(2).Enabled = False
                TabControl2.TabPages(3).Enabled = False

            Case "Stocked Equipment"
                TabControl1.SelectedIndex = 2
                TabControl1.TabPages(0).Enabled = False
                TabControl1.TabPages(1).Enabled = False
                TabControl1.TabPages(2).Enabled = True
                TabControl1.TabPages(3).Enabled = False


                TabControl2.SelectedIndex = 2
                TabControl2.TabPages(0).Enabled = False
                TabControl2.TabPages(1).Enabled = False
                TabControl2.TabPages(2).Enabled = True
                TabControl2.TabPages(3).Enabled = False

            Case "Packs"
                TabControl1.SelectedIndex = 3
                TabControl1.TabPages(0).Enabled = False
                TabControl1.TabPages(1).Enabled = False
                TabControl1.TabPages(2).Enabled = False
                TabControl1.TabPages(3).Enabled = True

                TabControl2.SelectedIndex = 3
                TabControl2.TabPages(0).Enabled = False
                TabControl2.TabPages(1).Enabled = False
                TabControl2.TabPages(2).Enabled = False
                TabControl2.TabPages(3).Enabled = True
        End Select

    End Sub

    Private Sub btnGenerateSD_Click(sender As Object, e As EventArgs) Handles btnGenerateSD.Click
        Dim code = txtCoreCodeSD.Text
        Dim description = txtDescriptionSD.Text
        Dim stockgrade = cbStockGradeSD.Text
        Dim supplier = cbSupplierSD.Text


    End Sub

    Private Sub txtDescription_TextChanged(sender As Object, e As EventArgs) Handles txtDescription.TextChanged

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ClearTextBox(TabPage1)
    End Sub

    Public Sub ClearTextBox(parent As Control)
        For Each child As Control In parent.Controls
            ClearTextBox(child)
        Next
        If TryCast(parent, TextBox) IsNot Nothing Then
            TryCast(parent, TextBox).Text = [String].Empty
        End If
    End Sub

    'SIZE OR COLOUR SELECTOR BUTTONS
    Private Sub btnSize_Click(sender As Object, e As EventArgs) Handles btnSize.Click
        If cbSize.Text = "" Then
            MessageBox.Show("Please select a size from the dropdown")
        Else
            Dim newSelector As Selector = New Selector()
            'Dim selector As Integer
            'Dim newSelect As New Selector
            Dim sel As New choose
            Dim Chooser As Integer = 1
            sel.chooser = Chooser
            newSelector.txtSelectType.Text = cbSize.Text
            newSelector.txtSelect.Text = 1
            newSelector.myCaller = Me
            newSelector.Show()
        End If
    End Sub

    Private Sub btnColour_Click(sender As Object, e As EventArgs) Handles btnColour.Click
        If cbColour.Text = "" Then
            MessageBox.Show("Please select a colour from the dropdown")
        Else
            Dim newSelector As Selector = New Selector()
            newSelector.txtSelectType.Text = cbColour.Text
            newSelector.txtSelect.Text = 2
            newSelector.Show()
        End If


    End Sub
End Class
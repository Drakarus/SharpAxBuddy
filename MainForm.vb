Imports System.Data.Sql
Imports System.Data.SqlClient
Imports System.Data.SqlClient.SqlDataReader


Public Class MainForm

    Dim connectionsql As New SqlConnection


    Private Sub tlsplblLoadProducts_Click(sender As Object, e As EventArgs) Handles tlsplblLoadProducts.Click
        'Dim f As New Form2
        'f.MdiParent = Me
        'f.Show()
        '   Tabbed Control Form
        Dim f As New Form2
        Dim tab As New TabPage
        f.TopLevel = False
        f.FormBorderStyle = FormBorderStyle.None
        f.Dock = DockStyle.Fill
        f.MaximizeBox = True
        tab.Text = "Products"
        'f.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        tab.Controls.Add(f)
        tabForms.Visible = True
        tabForms.TabPages.Add(tab)

        f.Show()

    End Sub

    Private Sub ToolStripLabel3_Click(sender As Object, e As EventArgs) Handles ToolStripLabel3.Click
        connectionsql = New SqlConnection

        Dim list As New List(Of Integer)
        Dim constr = "Data Source=LEN05-THINK\DANW;Initial Catalog=NORTHWND;Integrated Security=True"
        'Dim constr = "Data Source=DAN-PC;Initial Catalog=NORTHWND;Integrated Security=True"
        '-CONNECTION TO SQL--
        Using connection As New SqlConnection(constr)
            connection.Open()
            Dim sql As String = "Select ProductID From Products"
            Dim command As New SqlCommand(sql, connection)
            Dim reader As SqlDataReader = command.ExecuteReader()
            While reader.Read()
                '    Console.WriteLine("{0}", reader(0))
                list.Add(reader.GetInt32(reader.GetOrdinal("ProductID")))
            End While
            connection.Close()
        End Using
    End Sub


    Private Sub lblNewStockVariable_Click(sender As Object, e As EventArgs) Handles lblNewStockVariable.Click
        Dim formSV As New NewStockVariable
        'formSV.MdiParent = Me
        'formSV.Show()
        Dim tab As New TabPage
        formSV.TopLevel = False
        formSV.FormBorderStyle = FormBorderStyle.None
        formSV.Dock = DockStyle.Fill
        formSV.MaximizeBox = True
        tab.Text = "Stock Variable"
        tab.Controls.Add(formSV)
        tabForms.Visible = True
        tabForms.TabPages.Add(tab)
        formSV.Show()
    End Sub


    Public Sub tabButtons()
        Dim a As TabControl = tabForms
        For Each Tpage As TabPage In tabForms.TabPages
            Dim btn As New Button
            btn.Location = New Point(10, 10)
            btn.Text = "Close"
            Tpage.Controls.Add(btn)
            AddHandler btn.Click, AddressOf closetab
        Next
    End Sub

    Private Sub closetab(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim Thebutton As Button = sender
        Dim theTab As TabPage = Thebutton.Parent
        theTab.Parent.Controls.Remove(theTab)
    End Sub


    Private Sub lblStage2_Click(sender As System.Object, e As System.EventArgs) Handles lblStage2.Click

    End Sub
End Class

Public Class Customer
    'Public Property Name As String

End Class

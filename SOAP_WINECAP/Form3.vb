Imports System.Data.OleDb
Imports System.IO
Imports System.Math

Public Class Form3
    Dim ds As New DataSet()
    Dim ds1 As New DataSet()
    Private Sub Form3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        DataGridView1.DataBindings.Clear()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataMember = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Refresh()

        DataGridView2.DataBindings.Clear()
        DataGridView2.DataSource = Nothing
        DataGridView2.DataMember = Nothing
        DataGridView2.Rows.Clear()
        DataGridView2.Refresh()
        dati()
        dati1()
        numera_righe()
    End Sub

    Private Sub numera_righe()

        '------------prova numera righe
        For i As Integer = 1 To DataGridView1.Rows.Count
            DataGridView1.Rows(i - 1).HeaderCell.Value = i.ToString()
        Next i
        For i As Integer = 1 To DataGridView2.Rows.Count
            DataGridView2.Rows(i - 1).HeaderCell.Value = i.ToString()
        Next i
    End Sub
    '    
    '
    '
    Public Sub dati1()
        Dim MyConnection As New OleDbConnection
        Dim SQL As String
        Dim dbase As String
        DataGridView2.DataBindings.Clear()
        DataGridView2.DataSource = Nothing
        DataGridView2.DataMember = Nothing
        DataGridView2.Rows.Clear()
        DataGridView2.Refresh()
        ds1.Clear()

        dbase = getsettingitem(patch, "database")

        MyConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase
        MyConnection.Open()

        SQL = "SELECT set_mail.mail_To, set_mail.mail_To1, set_mail.mail_To2, set_mail.mail_To3, set_mail.mail_To4, set_mail.SONDA "
        SQL = SQL + "FROM set_mail "
        SQL = SQL + "GROUP BY set_mail.mail_To, set_mail.mail_To1, set_mail.mail_To2, set_mail.mail_To3, set_mail.mail_To4, set_mail.SONDA;"


        Dim dataadapter As New OleDbDataAdapter(SQL, MyConnection)

        dataadapter.Fill(ds1, "dati1")
        MyConnection.Close()
        DataGridView2.DataSource = ds1

        DataGridView2.DataMember = "dati1"
        DataGridView2.DataSource = ds1.Tables("dati1")
        DataGridView2.ClearSelection()

        numera_righe()
    End Sub
    Public Sub dati()
        Dim MyConnection As New OleDbConnection
        Dim SQL As String
        Dim dbase As String
        DataGridView1.DataBindings.Clear()
        DataGridView1.DataSource = Nothing
        DataGridView1.DataMember = Nothing
        DataGridView1.Rows.Clear()
        DataGridView1.Refresh()
        ds.Clear()

        dbase = getsettingitem(patch, "database")

        MyConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase
        MyConnection.Open()




        SQL = "SELECT TBL_MESSAGGI.ID, TBL_MESSAGGI.OLD, TBL_MESSAGGI.NUOVO, TBL_MESSAGGI.TENDENZA, TBL_MESSAGGI.MESSAGGIO, TBL_MESSAGGI.CODICE, TBL_MESSAGGI.BLU, TBL_MESSAGGI.GIALLI, TBL_MESSAGGI.ROSSI "
        SQL = SQL + "FROM(TBL_MESSAGGI) "
        SQL = SQL + "GROUP BY TBL_MESSAGGI.ID, TBL_MESSAGGI.OLD, TBL_MESSAGGI.NUOVO, TBL_MESSAGGI.TENDENZA, TBL_MESSAGGI.MESSAGGIO, TBL_MESSAGGI.CODICE, TBL_MESSAGGI.BLU, TBL_MESSAGGI.GIALLI, TBL_MESSAGGI.ROSSI; "


        Dim dataadapter As New OleDbDataAdapter(SQL, MyConnection)

        dataadapter.Fill(ds, "dati")
        MyConnection.Close()
        DataGridView1.DataSource = ds

        DataGridView1.DataMember = "dati"
        DataGridView1.DataSource = ds.Tables("dati")
        DataGridView1.ClearSelection()

        numera_righe()
    End Sub


    Private Sub DataGridView1_Click(sender As Object, e As System.EventArgs) Handles DataGridView1.Click
        Dim index As Integer

        Try
            index = Me.DataGridView1.SelectedRows(0).Index

            TextBox1.Text = DataGridView1.Item("messaggio", index).Value.ToString
            If DataGridView1.Item("BLU", index).Value.ToString = True Then
                CheckBox1.Checked = True
                CheckBox2.Checked = False
                CheckBox3.Checked = False
            End If

            If DataGridView1.Item("GIALLI", index).Value.ToString = True Then
                CheckBox1.Checked = False
                CheckBox2.Checked = True
                CheckBox3.Checked = False
            End If

            If DataGridView1.Item("ROSSI", index).Value.ToString = True Then
                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = True
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub DataGridView1_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView2_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView2.CellContentClick

    End Sub

    Private Sub DataGridView2_Click(sender As Object, e As System.EventArgs) Handles DataGridView2.Click
        Dim index As Integer

        Try
            index = Me.DataGridView2.SelectedRows(0).Index

            TextBox2.Text = DataGridView2.Item("mail_To", index).Value.ToString
            TextBox3.Text = DataGridView2.Item("mail_To1", index).Value.ToString
            TextBox4.Text = DataGridView2.Item("mail_To2", index).Value.ToString
            TextBox5.Text = DataGridView2.Item("mail_To3", index).Value.ToString
            TextBox6.Text = DataGridView2.Item("mail_To4", index).Value.ToString
            TextBox7.Text = DataGridView2.Item("SONDA", index).Value.ToString
        Catch ex As Exception

        End Try

    End Sub
End Class
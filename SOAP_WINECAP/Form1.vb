'Imports WindowsApplication1.ServiceReference1
Imports System.DateTime
Imports SOAP_WINECAP.ServiceReference1
Imports System.Data.OleDb
Imports System.IO
Imports System.Math

Public Class Form1

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ListSensors()
    End Sub
    Private Sub ListSensors()
        Dim ws As New winecapwsPortClient
        Dim a() As sensor
        'a = ws.getSensorList("b30a5dcd28e05e958bbfd7f44776398b", "0000367F")
        a = ws.getSensorList("b30a5dcd28e05e958bbfd7f44776398b", "0000367F")
        For i = 0 To UBound(a) - 1
            TextBox1.Text = TextBox1.Text & a(i).sensorName + vbCrLf
        Next
    End Sub
    Private Sub history()
        Dim ws As New winecapwsPortClient
        Dim a(100000000)
        Dim var_data As Date

        range_date()
        a = ws.getChannelHistory("b30a5dcd28e05e958bbfd7f44776398b", "0000367F", "00003A50", 1, dateFrom, dateTo)
        'a = ws.getCurrentValues("45015aa55cd0e3c05fdc11aab1243d81", "0000057A")  ' a = ws.getSensorList("45015aa55cd0e3c05fdc11aab1243d81", "0000057A")
        For i = 0 To UBound(a) - 1
            var_data = UnixTimeStampToDateTime(a(i).timeStamp)
            'TextBox1.Text = TextBox1.Text & var_data + vbCrLf
            'TextBox1.Text = TextBox1.Text & a(i).value.ToString + vbCrLf
            TextBox1.Text = TextBox1.Text + var_data & ";" & a(i).value.ToString + vbCrLf
        Next
    End Sub
    Private Sub history1()
        Dim ws As New winecapwsPortClient
        'Dim a(100000000)
        Dim a(100000000)
        Dim var_data As Date
        'Dim misura As Double
        'range_date()
        a = ws.getChannelHistory("b30a5dcd28e05e958bbfd7f44776398b", "0000367F", "00003A50", 1, dateFrom, dateTo)
        ' a = ws.getCurrentValues("b30a5dcd28e05e958bbfd7f44776398b", "0000367F")
        ' a = ws.getCurrentValues("b30a5dcd28e05e958bbfd7f44776398b", "00003A50")
         ' a = ws.getSensorList("45015aa55cd0e3c05fdc11aab1243d81", "0000057A")
        For i = 0 To UBound(a) - 1
            var_data = UnixTimeStampToDateTime(a(i).timeStamp)
            'TextBox1.Text = TextBox1.Text & var_data + vbCrLf
            'TextBox1.Text = TextBox1.Text & a(i).value.ToString + vbCrLf
            TextBox1.Text = TextBox1.Text + var_data & ";" & a(i).value.ToString + vbCrLf
        Next
    End Sub
    Private Sub history_test()
        Dim ws As New winecapwsPortClient
        Dim a(100000000)
        Dim var_data As Date

        range_date()
        a = ws.getChannelHistory("b30a5dcd28e05e958bbfd7f44776398b", "0000367F", "00003A50", 1, dateFrom, dateTo)
        'a = ws.getCurrentValues("45015aa55cd0e3c05fdc11aab1243d81", "0000057A")  ' a = ws.getSensorList("45015aa55cd0e3c05fdc11aab1243d81", "0000057A")
        For i = 0 To UBound(a) - 1
            var_data = UnixTimeStampToDateTime(a(i).timeStamp)
            'TextBox1.Text = TextBox1.Text & var_data + vbCrLf
            'TextBox1.Text = TextBox1.Text & a(i).value.ToString + vbCrLf
            TextBox1.Text = TextBox1.Text + var_data & ";" & a(i).value.ToString + vbCrLf
        Next
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        history()
    End Sub
    Private Shared timeStampOffset As DateTime = New DateTime(1970, 1, 1, 0, 0, 0)

    Public Shared Function DateTimeToUnixTimeStamp(ByVal d As DateTime) As Int64
        Return Convert.ToInt64(Math.Max(0, Convert.ToInt64((d - timeStampOffset).TotalSeconds) And &HFFFFFFFF))
    End Function

    Public Shared Function UnixTimeStampToDateTime(ByVal n As Int64) As DateTime
        Return timeStampOffset.AddSeconds(n)
    End Function
    Private Sub Button3_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click

        range_date()
        TextBox1.Text = dateFrom.ToString & "  " & dateTo.ToString
        ' TextBox1.Text = TextBox1.Text & CStr(TextBox1.Text + DateTimeToUnixTimeStamp(Now)) + vbCrLf
    End Sub
    Private Sub range_date()
        dateFrom = DateTimeToUnixTimeStamp(DateTimePicker1.Value)
        dateTo = DateTimeToUnixTimeStamp(DateTimePicker2.Value)
    End Sub
    Private Sub erase_TMP_ext_DATALOGGER()
        Dim MyConnection As New OleDbConnection
        Dim SQL As String
        Dim MyCommand As OleDbCommand
        Dim dbase As String
        'dbase = "C:\Users\fabio-claudia\Desktop\giorgio\posta.mdb" 'Application.StartupPath & "\posta.mdb"
        dbase = getsettingitem(patch, "database")
        MyConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase 'C:\Users\fabio-claudia\Desktop\time_tableDB.mdb"
        MyConnection.Open()

        SQL = "delete * from TMP_ext_DATALOGGER"
        ' "',"
        ' "')"
        MyCommand = New OleDbCommand(SQL, MyConnection)
        MyCommand.ExecuteNonQuery()
        MyConnection.Close()
    End Sub
    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        dbase = getsettingitem(patch, "database")
        erase_TMP_ext_DATALOGGER()
        Adodc1.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase & ";Persist Security Info=False"
        Adodc1.RecordSource = "SELECT * From TMP_ext_DATALOGGER"
        Adodc1.Refresh()
        ProgressBar1.Visible = True
        ProgressBar1.Value = 0

        ProgressBar1.Maximum = ListBox1.Items.Count
        Dim ws As New winecapwsPortClient
        Dim a(100000)
        Dim var_data As Date
        TextBox1.Text = ""
        'Dim dateStep As Date


        'dateFrom = DateTimeToUnixTimeStamp(DateTimePicker1.Value)
        'dateTo = DateTimeToUnixTimeStamp(DateTimePicker2.Value)

        'dateStep = DateTimePicker1.Value.AddDays(1)
        'If dateStep <= DateTimePicker2.Value Then
        '    'prova codice per step di dati
        'End If
        '-------------------
        Dim data_A As Date
        Dim data_b As Date
        Dim counter As Integer
        counter = 0
        Do While Not counter = ListBox1.Items.Count - 1
            ProgressBar1.Value = counter
            data_A = ListBox1.Items(counter).ToString
            data_b = ListBox1.Items(counter + 1).ToString

            dateFrom = DateTimeToUnixTimeStamp(data_A)
            dateTo = DateTimeToUnixTimeStamp(data_b)
            'interrogo il server
            'a = ws.getChannelHistory("45015aa55cd0e3c05fdc11aab1243d81", "0000057A", "WLxTGG01", 1, dateFrom, dateTo)
            a = ws.getChannelHistory("b30a5dcd28e05e958bbfd7f44776398b", "0000367F", "MWDG-ETH", 1, dateFrom, dateTo)
            'a = ws.getCurrentValues("45015aa55cd0e3c05fdc11aab1243d81", "0000057A")  ' a = ws.getSensorList("45015aa55cd0e3c05fdc11aab1243d81", "0000057A")
            For i = 0 To UBound(a) - 1
                var_data = UnixTimeStampToDateTime(a(i).timeStamp)
                Debug.Print(var_data)
                var_data = var_data.ToLocalTime()
                'Debug.Print(var_data.ToLocalTime().ToString)
                TextBox1.Text = TextBox1.Text & var_data & " Temperatura: " & a(i).value.ToString + vbCrLf
                'TextBox1.Text = TextBox1.Text & var_data + vbCrLf
                'TextBox1.Text = TextBox1.Text & a(i).value.ToString + vbCrLf
                Adodc1.Recordset.AddNew()
                Adodc1.Recordset.Fields("Data").Value = var_data
                'Adodc1.Recordset.Fields("Temp_Ext").Value = a(i).value
                Adodc1.Recordset.Fields("Temp_Ext").Value = Math.Round((a(i).value), 2, MidpointRounding.ToEven)
                Adodc1.Recordset.Update()
            Next
            'fine interrogazione
            counter = counter + 1
        Loop
        '-------------------
        'a = ws.getChannelHistory("45015aa55cd0e3c05fdc11aab1243d81", "0000057A", "WLxTGG01", 1, dateFrom, dateTo)
        ''a = ws.getCurrentValues("45015aa55cd0e3c05fdc11aab1243d81", "0000057A")  ' a = ws.getSensorList("45015aa55cd0e3c05fdc11aab1243d81", "0000057A")
        'For i = 0 To UBound(a) - 1
        '    var_data = UnixTimeStampToDateTime(a(i).timeStamp)
        '    TextBox1.Text = TextBox1.Text & var_data + vbCrLf
        '    TextBox1.Text = TextBox1.Text & a(i).value.ToString + vbCrLf
        'Next
        ProgressBar1.Visible = False
        ProgressBar1.Value = 0
        MsgBox("Fine")
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim tempo_sec As Double
        'Dim qta_date As Double
        dateFrom = DateTimeToUnixTimeStamp(DateTimePicker1.Value)
        dateTo = DateTimeToUnixTimeStamp(DateTimePicker2.Value)
        tempo_sec = dateFrom
        ListBox1.Items.Clear()
        Do While Not tempo_sec >= dateTo
            ListBox1.Items.Add(UnixTimeStampToDateTime(tempo_sec))
            tempo_sec = tempo_sec + 86400
        Loop
        ListBox1.Items.Add(DateTimePicker2.Value)

        'prova codice per recuperare le date
        Dim data_A As Date
        Dim data_b As Date
        Dim counter As Integer
        counter = 1
        Do While Not counter = ListBox1.Items.Count - 1
            data_A = ListBox1.Items(counter).ToString
            data_b = ListBox1.Items(counter + 1).ToString
            counter = counter + 1
        Loop
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ProgressBar1.Visible = False
    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        history_test()


    End Sub

    Private Sub Button7_Click(sender As System.Object, e As System.EventArgs) Handles Button7.Click
        Dim ws As New ServiceReference1.winecapwsPortClient
        Dim a() As ServiceReference1.measure
        Dim dato1a As Double
        Dim dato1b As Double
        Dim piano3 As Double
        Dim ARIA As Double
        Dim ext As Double
        Dim data1 As Date
        Dim data2 As Date
        Dim data3 As Date
        Dim data4 As Date
        Dim data5 As Date
        a = ws.getCurrentValues("b30a5dcd28e05e958bbfd7f44776398b", "0000367F")

        For i = 0 To UBound(a) - 1
            Select Case a(i).sensorMac

                Case "00003A50"
                    If a(i).channel = 3 Then
                        dato1a = a(i).value
                        TextBox2.Text = Math.Round(dato1a, 2)
                        data1 = UnixTimeStampToDateTime(a(i).timeStamp)
                        TextBox3.Text = CDate(data1).ToLocalTime
                    End If

                    If a(i).channel = 3 Then
                        dato1b = a(i).value
                        TextBox2.Text = Math.Round(dato1b, 3)
                    End If


                    'dato1b = a(i).value
                    'a(i).channel.ToString()







                    'Case "00001B9E"
                    '    piano2 = a(i).value
                    '    TextBox17.Text = Math.Round(piano2, 2)
                    '    data2 = UnixTimeStampToDateTime(a(i).timeStamp)
                    '    TextBox20.Text = CDate(data2).ToLocalTime
                    'Case "00001BA2"
                    '    piano3 = a(i).value
                    '    TextBox18.Text = Math.Round(piano3, 2)
                    '    data3 = UnixTimeStampToDateTime(a(i).timeStamp)
                    '    TextBox21.Text = CDate(data3).ToLocalTime

                    'Case "000CAP00"
                    '    ARIA = a(i).value
                    '    TextBox23.Text = Math.Round(ARIA, 2)
                    '    data4 = UnixTimeStampToDateTime(a(i).timeStamp)
                    '    TextBox22.Text = CDate(data4).ToLocalTime

                    'Case "00001BA1"
                    '    ext = a(i).value
                    '    TextBox25.Text = Math.Round(ext, 2)
                    '    data5 = UnixTimeStampToDateTime(a(i).timeStamp)
                    '    TextBox24.Text = CDate(data5).ToLocalTime
            End Select


            '    TextBox16.Text = Val(TextBox16.Text & a(1).value) + vbCrLf
        Next
    End Sub

    Private Sub TextBox2_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class




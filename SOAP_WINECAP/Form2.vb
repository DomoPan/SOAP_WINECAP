Imports System.DateTime
Imports SOAP_WINECAP.ServiceReference1
Imports System.Data.OleDb
Imports System.IO
Imports System.Math
Imports System.Net.Mail
Imports System
Imports System.Collections
Imports System.Text


Public Class Form2
    Dim ds As New DataSet()
    Dim mail As New MailMessage

    'variabili per settaggio mail
    Public mail_From As String
    Public mail_To As String
    Public mail_To1 As String
    Public mail_To2 As String
    Public mail_To3 As String
    Public mail_To4 As String
    Public smtp_Host As String
    Public smtp_Port As Integer
    Public smtp_Credentials_login As String
    Public smtp_Credentials_psw As String
    Public SmtpClient As String
    '-----------------------------------------
    Public mail_blu As Integer
    Public mail_gialli As Integer
    Public mail_rossi As Integer
    '-----------------------------------------
    Public messaggio As String


    Private Shared timeStampOffset As DateTime = New DateTime(1970, 1, 1, 0, 0, 0)

    Public Shared Function DateTimeToUnixTimeStamp(ByVal d As DateTime) As Int64
        Return Convert.ToInt64(Math.Max(0, Convert.ToInt64((d - timeStampOffset).TotalSeconds) And &HFFFFFFFF))
    End Function

    Public Shared Function UnixTimeStampToDateTime(ByVal n As Int64) As DateTime
        Return timeStampOffset.AddSeconds(n)
    End Function
    Private Sub codice_BLU()
        Dim old As String
        Dim nuovo As String = 0
        Dim tendenza As String
        Dim codice As String
        If OvalShape1.BackColor = Color.GreenYellow Then

            If RectangleShape1.BackColor = Color.GreenYellow Then
                nuovo = 0
            End If
            If RectangleShape1.BackColor = Color.Yellow Then
                nuovo = 1
            End If
            If RectangleShape1.BackColor = Color.Red Then
                nuovo = 2
            End If
            '------------------------------------------------------------------
            old = TextBox14.Text
            '------------------------------------------------------------------
            tendenza = TextBox17.Text
            '------------------------------------------------------------------
            codice = old + nuovo + tendenza

            TextBox10.Text = codice
        End If

    End Sub
    Private Sub codice_GIALLI()

        Dim old As String
        Dim nuovo As String = 0
        Dim tendenza As String
        Dim codice As String
        If OvalShape2.BackColor = Color.GreenYellow Then

            If RectangleShape2.BackColor = Color.GreenYellow Then
                nuovo = 0
            End If
            If RectangleShape2.BackColor = Color.Yellow Then
                nuovo = 1
            End If
            If RectangleShape2.BackColor = Color.Red Then
                nuovo = 2
            End If
            '------------------------------------------------------------------
            old = TextBox15.Text
            '------------------------------------------------------------------
            tendenza = TextBox18.Text
            '------------------------------------------------------------------
            codice = old + nuovo + tendenza

            TextBox20.Text = codice
        End If

    End Sub
    Private Sub codice_ROSSI()

        Dim old As String
        Dim nuovo As String = 0
        Dim tendenza As String
        Dim codice As String
        If OvalShape3.BackColor = Color.GreenYellow Then

            If RectangleShape3.BackColor = Color.GreenYellow Then
                nuovo = 0
            End If
            If RectangleShape3.BackColor = Color.Yellow Then
                nuovo = 1
            End If
            If RectangleShape3.BackColor = Color.Red Then
                nuovo = 2
            End If
            '------------------------------------------------------------------
            old = TextBox16.Text
            '------------------------------------------------------------------
            tendenza = TextBox19.Text
            '------------------------------------------------------------------
            codice = old + nuovo + tendenza

            TextBox21.Text = codice
        End If

    End Sub
    Private Sub interrogazione()
        Dim ws As New ServiceReference1.winecapwsPortClient
        Dim a() As ServiceReference1.measure
        Dim dato1a As Double
        Dim data1 As Date
        Dim co2_blu As Double
        Dim co2_gialli As Double
        Dim co2_rossi As Double
        Dim temp_blu As Date
        Dim temp_gialli As Date
        Dim temp_rossi As Date
        mail_blu = 0
        mail_gialli = 0
        mail_rossi = 0
        a = ws.getCurrentValues("b30a5dcd28e05e958bbfd7f44776398b", "0000367F")

        For i = 0 To UBound(a) - 1
            Select Case a(i).sensorMac

                Case "00003A50" ' BLU
                    If a(i).channel = 3 Then
                        dato1a = a(i).value
                        If CheckBox2.Checked = True Then
                            co2_blu = TextBox23.Text
                        Else
                            co2_blu = Math.Round(dato1a, 2)
                        End If
                        TextBox1.Text = co2_blu

                        If CheckBox2.Checked = True Then
                            data1 = Now()
                        Else
                            data1 = UnixTimeStampToDateTime(a(i).timeStamp)

                        End If

                        temp_blu = CDate(data1).ToLocalTime

                        TextBox2.Text = temp_blu

                        'VERIFICO SOGLIA
                        If co2_blu > 800 And co2_blu < 1000 Then
                            RectangleShape1.BackColor = Color.Yellow
                        End If
                        If co2_blu > 1000 Then
                            RectangleShape1.BackColor = Color.Red
                        End If
                        If co2_blu < 800 Then
                            RectangleShape1.BackColor = Color.GreenYellow
                        End If

                        'VERIFICO ULTIMO AGGIORNAMENTO
                        Try
                            If temp_blu = TextBox9.Text Then
                                OvalShape1.BackColor = Color.White
                            End If

                            If temp_blu <> TextBox9.Text Then
                                OvalShape1.BackColor = Color.GreenYellow

                                If co2_blu > TextBox13.Text Then
                                    PictureBox1.Image = ImageList1.Images(1)
                                    TextBox17.Text = 4
                                Else
                                    PictureBox1.Image = ImageList1.Images(0)
                                    TextBox17.Text = 3
                                End If

                                'registro status soglia sonda
                                If RectangleShape1.BackColor = Color.GreenYellow Then
                                    TextBox14.Text = 0
                                End If
                                If RectangleShape1.BackColor = Color.Yellow Then
                                    TextBox14.Text = 1
                                End If
                                If RectangleShape1.BackColor = Color.Red Then
                                    TextBox14.Text = 2
                                End If

                                set_mail_BLU()
                                mail_blu = 1
                                codice_BLU()
                                set_messaggio_BLU()
                                preparo_mail()
                                TextBox13.Text = co2_blu
                                TextBox9.Text = temp_blu
                            End If

                        Catch ex As Exception
                            OvalShape1.BackColor = Color.GreenYellow
                            TextBox9.Text = temp_blu
                            TextBox13.Text = co2_blu

                        End Try

                        TextBox2.Text = temp_blu

                    End If


                Case "00003A51" 'gialli
                    If a(i).channel = 3 Then
                        dato1a = a(i).value
                        If CheckBox2.Checked = True Then
                            co2_gialli = TextBox24.Text
                        Else
                            co2_gialli = Math.Round(dato1a, 2)
                        End If
                        TextBox3.Text = co2_gialli

                        If CheckBox2.Checked = True Then
                            data1 = Now()
                        Else
                            data1 = UnixTimeStampToDateTime(a(i).timeStamp)

                        End If

                        temp_gialli = CDate(data1).ToLocalTime

                        TextBox4.Text = temp_blu

                        'VERIFICO SOGLIA
                        If co2_gialli > 800 And co2_gialli < 1000 Then
                            RectangleShape2.BackColor = Color.Yellow
                        End If
                        If co2_gialli > 1000 Then
                            RectangleShape2.BackColor = Color.Red
                        End If
                        If co2_gialli < 800 Then
                            RectangleShape2.BackColor = Color.GreenYellow
                        End If

                        'VERIFICO ULTIMO AGGIORNAMENTO
                        Try
                            If temp_gialli = TextBox7.Text Then
                                OvalShape2.BackColor = Color.White
                            End If

                            If temp_gialli <> TextBox7.Text Then
                                OvalShape2.BackColor = Color.GreenYellow

                                If co2_gialli > TextBox11.Text Then
                                    PictureBox2.Image = ImageList1.Images(1)
                                    TextBox18.Text = 4
                                Else
                                    PictureBox2.Image = ImageList1.Images(0)
                                    TextBox18.Text = 3
                                End If

                                'registro status soglia sonda
                                If RectangleShape2.BackColor = Color.GreenYellow Then
                                    TextBox15.Text = 0
                                End If
                                If RectangleShape2.BackColor = Color.Yellow Then
                                    TextBox15.Text = 1
                                End If
                                If RectangleShape2.BackColor = Color.Red Then
                                    TextBox15.Text = 2
                                End If

                                set_mail_GIALLI()
                                mail_gialli = 1
                                codice_GIALLI()
                                set_messaggio_GIALLI()
                                preparo_mail()
                                TextBox11.Text = co2_gialli
                                TextBox7.Text = temp_gialli
                            End If

                        Catch ex As Exception
                            OvalShape2.BackColor = Color.GreenYellow
                            TextBox7.Text = temp_gialli
                            TextBox11.Text = co2_gialli

                        End Try

                        TextBox4.Text = temp_gialli

                    End If
                    ''If a(i).channel = 3 Then
                    ''    dato1a = a(i).value
                    ''    TextBox3.Text = Math.Round(dato1a, 2)
                    ''    data1 = UnixTimeStampToDateTime(a(i).timeStamp)
                    ''    TextBox4.Text = CDate(data1).ToLocalTime
                    ''End If
                    'If a(i).channel = 3 Then
                    '    dato1a = a(i).value
                    '    co2_gialli = Math.Round(dato1a, 2)
                    '    TextBox3.Text = co2_gialli
                    '    data1 = UnixTimeStampToDateTime(a(i).timeStamp)
                    '    temp_gialli = CDate(data1).ToLocalTime


                    '    'VERIFICO ULTIMO AGGIORNAMENTO
                    '    Try
                    '        If temp_gialli = TextBox7.Text Then
                    '            OvalShape2.BackColor = Color.White
                    '            'TextBox9.Text = temp_blu_old
                    '        End If

                    '        If temp_gialli <> TextBox7.Text Then
                    '            OvalShape2.BackColor = Color.GreenYellow

                    '            set_mail_GIALLI()
                    '            mail_gialli = 1
                    '            set_messaggio_GIALLI()
                    '            preparo_mail()


                    '            TextBox7.Text = temp_gialli
                    '            If co2_gialli > TextBox11.Text Then
                    '                PictureBox2.Image = ImageList1.Images(1)
                    '                TextBox18.Text = 4
                    '            Else
                    '                PictureBox2.Image = ImageList1.Images(0)
                    '                TextBox18.Text = 3
                    '            End If
                    '            TextBox11.Text = co2_gialli
                    '        End If
                    '    Catch ex As Exception
                    '        OvalShape2.BackColor = Color.GreenYellow
                    '        TextBox7.Text = temp_gialli
                    '        TextBox11.Text = co2_gialli
                    '        'temp_blu_old = temp_blu
                    '    End Try

                    '    TextBox4.Text = temp_gialli
                    '    'registro status soglia sonda
                    '    If RectangleShape2.BackColor = Color.GreenYellow Then
                    '        TextBox15.Text = 0
                    '    End If
                    '    If RectangleShape2.BackColor = Color.Yellow Then
                    '        TextBox15.Text = 1
                    '    End If
                    '    If RectangleShape2.BackColor = Color.Red Then
                    '        TextBox15.Text = 2
                    '    End If

                    '    'VERIFICO SOGLIA
                    '    If co2_gialli > 800 And co2_gialli < 1000 Then
                    '        RectangleShape2.BackColor = Color.Yellow
                    '    End If
                    '    If co2_gialli > 1000 Then
                    '        RectangleShape2.BackColor = Color.Red
                    '    End If
                    '    If co2_gialli < 800 Then
                    '        RectangleShape2.BackColor = Color.GreenYellow
                    '    End If
                    'End If


                Case "00003A5B" 'rossi
                    If a(i).channel = 3 Then
                        dato1a = a(i).value
                        If CheckBox2.Checked = True Then
                            co2_rossi = TextBox25.Text
                        Else
                            co2_rossi = Math.Round(dato1a, 2)
                        End If
                        TextBox5.Text = co2_rossi

                        If CheckBox2.Checked = True Then
                            data1 = Now()
                        Else
                            data1 = UnixTimeStampToDateTime(a(i).timeStamp)

                        End If

                        temp_rossi = CDate(data1).ToLocalTime

                        TextBox6.Text = temp_rossi

                        'VERIFICO SOGLIA
                        If co2_rossi > 800 And co2_rossi < 1000 Then
                            RectangleShape3.BackColor = Color.Yellow
                        End If
                        If co2_rossi > 1000 Then
                            RectangleShape3.BackColor = Color.Red
                        End If
                        If co2_rossi < 800 Then
                            RectangleShape3.BackColor = Color.GreenYellow
                        End If

                        'VERIFICO ULTIMO AGGIORNAMENTO
                        Try
                            If temp_rossi = TextBox8.Text Then
                                OvalShape3.BackColor = Color.White
                            End If

                            If temp_rossi <> TextBox8.Text Then
                                OvalShape3.BackColor = Color.GreenYellow

                                If co2_rossi > TextBox12.Text Then
                                    PictureBox3.Image = ImageList1.Images(1)
                                    TextBox19.Text = 4
                                Else
                                    PictureBox3.Image = ImageList1.Images(0)
                                    TextBox19.Text = 3
                                End If

                                'registro status soglia sonda
                                If RectangleShape3.BackColor = Color.GreenYellow Then
                                    TextBox16.Text = 0
                                End If
                                If RectangleShape3.BackColor = Color.Yellow Then
                                    TextBox16.Text = 1
                                End If
                                If RectangleShape3.BackColor = Color.Red Then
                                    TextBox16.Text = 2
                                End If

                                set_mail_ROSSI()
                                mail_rossi = 1
                                codice_ROSSI()
                                set_messaggio_ROSSI()
                                preparo_mail()
                                TextBox12.Text = co2_rossi
                                TextBox8.Text = temp_rossi
                            End If

                        Catch ex As Exception
                            OvalShape3.BackColor = Color.GreenYellow
                            TextBox8.Text = temp_rossi
                            TextBox12.Text = co2_rossi

                        End Try

                        TextBox6.Text = temp_rossi

                    End If
                    ''If a(i).channel = 3 Then
                    ''    dato1a = a(i).value
                    ''    TextBox5.Text = Math.Round(dato1a, 2)
                    ''    data1 = UnixTimeStampToDateTime(a(i).timeStamp)
                    ''    TextBox6.Text = CDate(data1).ToLocalTime
                    ''End If
                    'If a(i).channel = 3 Then
                    '    dato1a = a(i).value
                    '    co2_rossi = Math.Round(dato1a, 2)
                    '    TextBox5.Text = co2_rossi
                    '    data1 = UnixTimeStampToDateTime(a(i).timeStamp)
                    '    temp_rossi = CDate(data1).ToLocalTime


                    '    'VERIFICO ULTIMO AGGIORNAMENTO
                    '    Try
                    '        If temp_rossi = TextBox8.Text Then
                    '            OvalShape3.BackColor = Color.White
                    '            'TextBox9.Text = temp_blu_old
                    '        End If

                    '        If temp_rossi <> TextBox8.Text Then
                    '            OvalShape3.BackColor = Color.GreenYellow

                    '            set_mail_ROSSI()
                    '            mail_rossi = 1
                    '            set_messaggio_ROSSI()
                    '            preparo_mail()


                    '            TextBox8.Text = temp_rossi
                    '            If co2_rossi > TextBox12.Text Then
                    '                PictureBox3.Image = ImageList1.Images(1)
                    '                TextBox19.Text = 4
                    '            Else
                    '                PictureBox3.Image = ImageList1.Images(0)
                    '                TextBox19.Text = 3
                    '            End If
                    '            TextBox12.Text = co2_rossi
                    '        End If
                    '    Catch ex As Exception
                    '        OvalShape3.BackColor = Color.GreenYellow
                    '        TextBox8.Text = temp_rossi
                    '        TextBox12.Text = co2_rossi
                    '        'temp_blu_old = temp_blu
                    '    End Try

                    '    TextBox6.Text = temp_rossi
                    '    'registro status soglia sonda
                    '    If RectangleShape3.BackColor = Color.GreenYellow Then
                    '        TextBox16.Text = 0
                    '    End If
                    '    If RectangleShape3.BackColor = Color.Yellow Then
                    '        TextBox16.Text = 1
                    '    End If
                    '    If RectangleShape3.BackColor = Color.Red Then
                    '        TextBox16.Text = 2
                    '    End If

                    '    'VERIFICO SOGLIA
                    '    If co2_rossi > 800 And co2_rossi < 1000 Then
                    '        RectangleShape3.BackColor = Color.Yellow
                    '    End If
                    '    If co2_rossi > 1000 Then
                    '        RectangleShape3.BackColor = Color.Red
                    '    End If
                    '    If co2_rossi < 800 Then
                    '        RectangleShape3.BackColor = Color.GreenYellow
                    '    End If
                    'End If

            End Select
        Next

        'genera codice status
        codice_BLU()
        codice_GIALLI()
        codice_ROSSI()
        'assegna ora
        ToolStripStatusLabel1.Text = "Ultimo aggiornamento: " & Now
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Timer1.Enabled = False
        Button2.BackColor = Color.Red
        Button3.BackColor = Color.GreenYellow
        interrogazione()

    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        ' Timer1.Interval = NumericUpDown1.Value * 60 * 1000
        Timer1.Interval = NumericUpDown1.Value * 1000
        Timer1.Enabled = True
        Button2.BackColor = Color.GreenYellow
        Button3.BackColor = Color.Red
        interrogazione()
        ToolStripStatusLabel1.Text = "Start timer: " & Now
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Timer1.Enabled = False
        Button2.BackColor = Color.Red
        Button3.BackColor = Color.GreenYellow
        ToolStripStatusLabel1.Text = "Stop timer: " & Now
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        ' Timer1.Interval = NumericUpDown1.Value * 60 * 1000
        Timer1.Interval = NumericUpDown1.Value * 1000
        interrogazione()

    End Sub


    Private Sub Button4_Click_1(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Form3.Show()

    End Sub

    Private Sub preparo_mail()
        Dim strB As StringBuilder = New StringBuilder()
        If mail_blu = 1 Then
            'INTESTAZIONE MAIL
            strB.AppendLine("<p>MESSAGGIO SONDA BLU: " & messaggio & "</p>")
            strB.AppendLine("<p>valore CO2: " & TextBox1.Text & "</p>")
            strB.AppendLine("<p>Orario evento: " & TextBox2.Text & "</p>")
            strB.AppendLine("<p>Cordiali saluti.</p>")
            strB.AppendLine("<p>La Segreteria</p>")

            TextBox22.Text = strB.ToString()
            If messaggio <> "NULLA" Then
                invia_mail()
            End If

        End If
        TextBox22.Text = ""
        mail_blu = 0

        If mail_gialli = 1 Then
            'INTESTAZIONE MAIL

            strB.AppendLine("<p>MESSAGGIO SONDA GIALLI: " & messaggio & "</p>")
            strB.AppendLine("<p>valore CO2: " & TextBox3.Text & "</p>")
            strB.AppendLine("<p>Orario evento: " & TextBox4.Text & "</p>")
            strB.AppendLine("<p>Cordiali saluti.</p>")
            strB.AppendLine("<p>La Segreteria</p>")

            TextBox22.Text = strB.ToString()
            If messaggio <> "NULLA" Then
                invia_mail()
            End If
        End If
        TextBox22.Text = ""
        mail_gialli = 0

        If mail_rossi = 1 Then
            'INTESTAZIONE MAIL

            strB.AppendLine("<p>MESSAGGIO SONDA ROSSI:" & messaggio & "</p>")
            strB.AppendLine("<p>valore CO2: " & TextBox5.Text & "</p>")
            strB.AppendLine("<p>Orario evento: " & TextBox6.Text & "</p>")
            strB.AppendLine("<p>Cordiali saluti.</p>")
            strB.AppendLine("<p>La Segreteria</p>")

            TextBox22.Text = strB.ToString()
            mail_rossi = 0
            If messaggio <> "NULLA" Then
                invia_mail()
            End If
        End If
    End Sub
    Private Sub set_messaggio_BLU()
        Dim MyConnection As New OleDbConnection
        Dim SQL As String
        Dim dbase As String
        Dim MyCommand As OleDbCommand
        Dim myreader As OleDbDataReader
        MyConnection.Close()

        dbase = getsettingitem(patch, "database")
        MyConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase 'C:\Users\fabio-claudia\Desktop\time_tableDB.mdb"
        MyConnection.Open()

        SQL = "Select TBL_MESSAGGI.MESSAGGIO  "
        SQL = SQL + "FROM(TBL_MESSAGGI) "
        SQL = SQL + "WHERE(((TBL_MESSAGGI.CODICE) = """ & TextBox10.Text & """) And ((TBL_MESSAGGI.BLU) = True)) "
        SQL = SQL + "GROUP BY TBL_MESSAGGI.MESSAGGIO;"


        MyCommand = New OleDbCommand(SQL, MyConnection)
        myreader = MyCommand.ExecuteReader()

        Do While myreader.Read

            messaggio = myreader("MESSAGGIO").ToString

        Loop

    End Sub
    Private Sub set_messaggio_GIALLI()
        Dim MyConnection As New OleDbConnection
        Dim SQL As String
        Dim dbase As String
        Dim MyCommand As OleDbCommand
        Dim myreader As OleDbDataReader
        MyConnection.Close()

        dbase = getsettingitem(patch, "database")
        MyConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase 'C:\Users\fabio-claudia\Desktop\time_tableDB.mdb"
        MyConnection.Open()

        SQL = "Select TBL_MESSAGGI.MESSAGGIO  "
        SQL = SQL + "FROM(TBL_MESSAGGI) "
        SQL = SQL + "WHERE(((TBL_MESSAGGI.CODICE) = """ & TextBox20.Text & """) And ((TBL_MESSAGGI.GIALLI) = True)) "
        SQL = SQL + "GROUP BY TBL_MESSAGGI.MESSAGGIO;"


        MyCommand = New OleDbCommand(SQL, MyConnection)
        myreader = MyCommand.ExecuteReader()

        Do While myreader.Read

            messaggio = myreader("MESSAGGIO").ToString

        Loop

    End Sub
    Private Sub set_messaggio_ROSSI()
        Dim MyConnection As New OleDbConnection
        Dim SQL As String
        Dim dbase As String
        Dim MyCommand As OleDbCommand
        Dim myreader As OleDbDataReader
        MyConnection.Close()

        dbase = getsettingitem(patch, "database")
        MyConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase 'C:\Users\fabio-claudia\Desktop\time_tableDB.mdb"
        MyConnection.Open()

        SQL = "Select TBL_MESSAGGI.MESSAGGIO  "
        SQL = SQL + "FROM(TBL_MESSAGGI) "
        SQL = SQL + "WHERE(((TBL_MESSAGGI.CODICE) = """ & TextBox21.Text & """) And ((TBL_MESSAGGI.ROSSI) = True)) "
        SQL = SQL + "GROUP BY TBL_MESSAGGI.MESSAGGIO;"


        MyCommand = New OleDbCommand(SQL, MyConnection)
        myreader = MyCommand.ExecuteReader()

        Do While myreader.Read

            messaggio = myreader("MESSAGGIO").ToString

        Loop

    End Sub
    Private Sub Button5_Click(sender As System.Object, e As System.EventArgs) Handles Button5.Click
        mail_gialli = 1
        mail_blu = 1
        mail_rossi = 1
        preparo_mail()

    End Sub

    Public Sub invia_mail()

        Dim smtp As New SmtpClient(SmtpClient)
        mail = New MailMessage
        
        mail.Subject = ("ALLERTA SONDA CO2")


        mail.From = New MailAddress(mail_From)

        mail.To.Add(mail_To)
        'mail.To.Add(mail_To1)
        'mail.Bcc.Add(mail_To)

        mail.Body = TextBox22.Text
        mail.IsBodyHtml = True
        smtp.Host = smtp_Host
        If CheckBox3.Checked <> True Then
            smtp.EnableSsl = True
        End If

        smtp.Port = smtp_Port
        If CheckBox3.Checked <> True Then
            smtp.Credentials = New Net.NetworkCredential(smtp_Credentials_login, smtp_Credentials_psw)
        End If

        Try
            smtp.Send(mail)
            ' MsgBox("Mail Inviata")

        Catch ex As Exception
            MsgBox("Attenzione, ci sono problemi per l'invio delle mail")

        End Try

        mail_blu = 0
        mail_gialli = 0
        mail_rossi = 0

    End Sub

    Private Sub Button6_Click(sender As System.Object, e As System.EventArgs) Handles Button6.Click
        invia_mail()
    End Sub
    Private Sub set_mail_BLU()
        Dim MyConnection As New OleDbConnection
        Dim SQL As String
        Dim dbase As String
        Dim MyCommand As OleDbCommand
        Dim myreader As OleDbDataReader

        dbase = getsettingitem(patch, "database")
        MyConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase 'C:\Users\fabio-claudia\Desktop\time_tableDB.mdb"
        MyConnection.Open()

        SQL = "SELECT set_mail.ID, set_mail.mail_From, set_mail.mail_To,  "
        SQL = SQL + "set_mail.mail_To1, set_mail.mail_To2, set_mail.mail_To3, "
        SQL = SQL + "set_mail.mail_To4, set_mail.smtp_Host, set_mail.smtp_Port, "
        SQL = SQL + "set_mail.smtp_Credentials_login, set_mail.smtp_Credentials_psw, set_mail.SmtpClient "
        SQL = SQL + "FROM set_mail "
        If CheckBox3.Checked = True Then
            SQL = SQL + "WHERE (((set_mail.ID)=6)); "
        Else
            SQL = SQL + "WHERE (((set_mail.ID)=2)); "
        End If


        MyCommand = New OleDbCommand(SQL, MyConnection)
        myreader = MyCommand.ExecuteReader()

        Do While myreader.Read

            mail_From = myreader("mail_From").ToString
            mail_To = myreader("mail_To").ToString
            mail_To1 = myreader("mail_To1").ToString
            mail_To2 = myreader("mail_To2").ToString
            mail_To3 = myreader("mail_To3").ToString
            mail_To4 = myreader("mail_To4").ToString
            smtp_Host = myreader("smtp_Host").ToString
            smtp_Port = myreader("smtp_Port").ToString
            smtp_Credentials_login = myreader("smtp_Credentials_login").ToString
            smtp_Credentials_psw = myreader("smtp_Credentials_psw").ToString
            SmtpClient = myreader("SmtpClient").ToString
        Loop

    End Sub
    Private Sub set_mail_GIALLI()
        Dim MyConnection As New OleDbConnection
        Dim SQL As String
        Dim dbase As String
        Dim MyCommand As OleDbCommand
        Dim myreader As OleDbDataReader

        dbase = getsettingitem(patch, "database")
        MyConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase 'C:\Users\fabio-claudia\Desktop\time_tableDB.mdb"
        MyConnection.Open()

        SQL = "SELECT set_mail.ID, set_mail.mail_From, set_mail.mail_To,  "
        SQL = SQL + "set_mail.mail_To1, set_mail.mail_To2, set_mail.mail_To3, "
        SQL = SQL + "set_mail.mail_To4, set_mail.smtp_Host, set_mail.smtp_Port, "
        SQL = SQL + "set_mail.smtp_Credentials_login, set_mail.smtp_Credentials_psw, set_mail.SmtpClient "
        SQL = SQL + "FROM set_mail "
        If CheckBox3.Checked = True Then
            SQL = SQL + "WHERE (((set_mail.ID)=7)); "
        Else
            SQL = SQL + "WHERE (((set_mail.ID)=3)); "
        End If


        MyCommand = New OleDbCommand(SQL, MyConnection)
        myreader = MyCommand.ExecuteReader()

        Do While myreader.Read

            mail_From = myreader("mail_From").ToString
            mail_To = myreader("mail_To").ToString
            mail_To1 = myreader("mail_To1").ToString
            mail_To2 = myreader("mail_To2").ToString
            mail_To3 = myreader("mail_To3").ToString
            mail_To4 = myreader("mail_To4").ToString
            smtp_Host = myreader("smtp_Host").ToString
            smtp_Port = myreader("smtp_Port").ToString
            smtp_Credentials_login = myreader("smtp_Credentials_login").ToString
            smtp_Credentials_psw = myreader("smtp_Credentials_psw").ToString
            SmtpClient = myreader("SmtpClient").ToString
        Loop

    End Sub
    Private Sub set_mail_ROSSI()
        Dim MyConnection As New OleDbConnection
        Dim SQL As String
        Dim dbase As String
        Dim MyCommand As OleDbCommand
        Dim myreader As OleDbDataReader

        dbase = getsettingitem(patch, "database")
        MyConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & dbase 'C:\Users\fabio-claudia\Desktop\time_tableDB.mdb"
        MyConnection.Open()

        SQL = "SELECT set_mail.ID, set_mail.mail_From, set_mail.mail_To,  "
        SQL = SQL + "set_mail.mail_To1, set_mail.mail_To2, set_mail.mail_To3, "
        SQL = SQL + "set_mail.mail_To4, set_mail.smtp_Host, set_mail.smtp_Port, "
        SQL = SQL + "set_mail.smtp_Credentials_login, set_mail.smtp_Credentials_psw, set_mail.SmtpClient "
        SQL = SQL + "FROM set_mail "
        If CheckBox3.Checked = True Then
            SQL = SQL + "WHERE (((set_mail.ID)=8)); "
        Else
            SQL = SQL + "WHERE (((set_mail.ID)=4)); "
        End If

        MyCommand = New OleDbCommand(SQL, MyConnection)
        myreader = MyCommand.ExecuteReader()

        Do While myreader.Read

            mail_From = myreader("mail_From").ToString
            mail_To = myreader("mail_To").ToString
            mail_To1 = myreader("mail_To1").ToString
            mail_To2 = myreader("mail_To2").ToString
            mail_To3 = myreader("mail_To3").ToString
            mail_To4 = myreader("mail_To4").ToString
            smtp_Host = myreader("smtp_Host").ToString
            smtp_Port = myreader("smtp_Port").ToString
            smtp_Credentials_login = myreader("smtp_Credentials_login").ToString
            smtp_Credentials_psw = myreader("smtp_Credentials_psw").ToString
            SmtpClient = myreader("SmtpClient").ToString
        Loop

    End Sub

End Class
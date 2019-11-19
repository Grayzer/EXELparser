Imports System.Diagnostics.Process
Public Class Form1

    Friend PID As New Integer
    Friend AppID As String
    Friend Hndl As New Integer
    Friend namefile As String = ".\SaveWork.txt"


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim nnn As New Integer
        Dim mmm As String
        Dim ppp As New Integer

        ppp = TextBox3.Text
        nnn = TextBox2.Lines.Count
        mmm = ""
        PID = TextBox1.Text
        Label3.Text = TextBox2.Lines.Count
        If PID <> 0 Then AppActivate(PID)
        Label6.Visible = True
        For nnn = 1 To 5
            Label6.Text = (6 - nnn).ToString
            Label6.Refresh()
            System.Threading.Thread.Sleep(2000)
        Next
        Beep()
        Label6.Visible = False
        Label6.Text = "5"
        For nnn = 1 To TextBox2.Lines.Count
            Label5.Text = nnn.ToString
            System.Threading.Thread.Sleep(ppp)
            SendKeys.SendWait("{insert}")
            System.Threading.Thread.Sleep(ppp)
            mmm = Trim(TextBox2.Lines(nnn - 1))
            If RadioButton3.Checked = True Then
                If mmm.Length > 10 Then mmm = Strings.Left(mmm, 10)
                If mmm.Length < 10 Then
                    If Strings.Left(mmm, 1) = "N" Then GoTo skipaem
                    mmm += " "
                End If
            End If
            If RadioButton1.Checked = True Then
                Clipboard.SetText(mmm)
                SendKeys.SendWait("+({insert})")
                GoTo skipaem
            End If
            If RadioButton2.Checked = True Then
                SendKeys.SendWait(mmm)
                GoTo skipaem
            End If

skipaem:    System.Threading.Thread.Sleep(ppp)
            SendKeys.SendWait("{enter}")
            'TextBox2.Lines(nnn - 1) = mmm + " ready" & Environment.NewLine)

            'TextBox2.Refresh()
        Next
        TextBox2.Refresh()
        Clipboard.Clear()
        Beep()
        Label5.Text = "0"


    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load, TextBox2.TextChanged

        If IO.File.Exists(namefile) = True Then Button10.Enabled = True Else Button10.Enabled = False

        Label3.Text = TextBox2.Lines.Count
        'TextBox4.Text = Process.GetCurrentProcess.ProcessName
        'TextBox1.Text = Process.GetCurrentProcess.Id.ToString
        'TextBox5.Text = Form1.ActiveForm.Handle.ToString
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If RadioButton1.Checked = True Then
            RadioButton2.Checked = False
        End If
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If RadioButton2.Checked = True Then
            RadioButton1.Checked = False
        End If
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.TopMost = False
        Form2.Visible = True
        Form2.Activate()
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If RadioButton3.Checked = True Then RadioButton4.Checked = False
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If RadioButton4.Checked = True Then RadioButton3.Checked = False
    End Sub

    Private Sub Button6_Click_1(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim zzz As Integer = 0
        Dim sss As String = ""
        Dim ttt As String = ""
        Dim ppp As Integer

        Label7.Visible = True
        ListBox1.Items.Clear()

        For zzz = 1 To 5
            Label7.Text = (6 - zzz).ToString
            Label7.Refresh()
            System.Threading.Thread.Sleep(2000)
        Next
        Beep()
        Label7.Visible = False
        PID = TextBox1.Text
        ppp = TextBox3.Text
        If PID <> 0 Then AppActivate(PID)
        System.Threading.Thread.Sleep(2000)
        zzz = 0
geting: SendKeys.SendWait("^(c)")
        System.Threading.Thread.Sleep(ppp)
        sss = Clipboard.GetText
        If sss = ttt Then GoTo konec
        ListBox1.Items.Add(sss)
        ttt = sss
        SendKeys.SendWait("{DOWN}")
        System.Threading.Thread.Sleep(ppp)
        zzz += 1
        GoTo geting

konec:  Beep()

    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim zzz As Integer = 0
        Dim qqq As Integer = ListBox1.Items.Count
        TextBox2.Clear()
        For zzz = 0 To qqq - 1
            TextBox2.AppendText(ListBox1.Items.Item(zzz).ToString & Environment.NewLine)
        Next

        Beep()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim Massiv(ListBox1.Items.Count - 1) As String
        ListBox1.Items.CopyTo(Massiv, 0)
        IO.File.WriteAllLines(namefile, Massiv, System.Text.Encoding.UTF8)
        Beep()
        If IO.File.Exists(namefile) = True Then Button10.Enabled = True Else Button10.Enabled = False

    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        ListBox1.Items.Clear()
        ListBox1.Items.AddRange(IO.File.ReadAllLines(namefile, System.Text.Encoding.UTF8))
        Beep()

    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        ListBox1.Items.Clear()
        Beep()
    End Sub
End Class

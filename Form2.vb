Public Class Form2
    Friend Hndl_List As New List(Of String)
    Friend PID_List As New List(Of Integer)
    Friend Pr_Count As New Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim num As Integer = 0
        If ListBox1.Items.Contains("mstsc") Then
            num = ListBox1.Items.IndexOf("mstsc")
            ListBox1.SetSelected(num, True)
            TextBox3.Text = PID_List(num).ToString
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Form1.TextBox1.Text = Me.TextBox1.Text
        Close()
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Form1.TopMost = True
        Me.Visible = False
        Form1.Activate()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        PID_List.Clear()
        Hndl_List.Clear()
        TextBox2.Clear()
        For Each p As Process In Process.GetProcesses
            ListBox1.Items.Add(p.ProcessName.ToString)
            PID_List.Add(p.Id)
            'Hndl_List.Add(p.SafeHandle)

        Next
        ListBox1.Refresh()
        Pr_Count = ListBox1.Items.Count
    End Sub
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        Dim num As Integer
        num = ListBox1.SelectedIndex
        TextBox1.Text = PID_List.Item(num).ToString
        'TextBox1.Refresh()
        'TextBox2.Refresh()
        'TextBox2.Text = Hndl_List.Item(num)

    End Sub
End Class
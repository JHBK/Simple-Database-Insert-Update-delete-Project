
Imports System.Data.SqlClient


Public Class Form1

    Dim cn As New SqlConnection("Data Source=JOBAYER-HOSSAIN\SQLEXPRESS;Initial Catalog=assignment;Integrated Security=True")
    Dim cmd As New SqlCommand
    Dim dr As SqlDataReader




    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmd.Connection = cn
        loadlistbox()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        If TextBox1.Text <> "" And TextBox2.Text <> "" And TextBox3.Text <> "" And TextBox4.Text <> "" And TextBox5.Text <> "" Then

            cn.Open()
            cmd.CommandText = "insert into info(Client_Id,Name,Loan_Id,Amount,Branch) values('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & TextBox5.Text & "')"
            cmd.ExecuteNonQuery()
            cn.Close()
            TextBox1.Text = ""
            TextBox2.Text = ""
            TextBox3.Text = ""
            TextBox4.Text = ""
            TextBox5.Text = ""
            loadlistbox()
            MessageBox.Show("Record Inserted in database")



        End If





    End Sub

    Private Sub loadlistbox()
        ListBox1.Items.Clear()
        ListBox2.Items.Clear()
        ListBox3.Items.Clear()
        ListBox4.Items.Clear()
        ListBox5.Items.Clear()

        TextBox6.Text = ""
        TextBox7.Text = ""
        TextBox8.Text = ""
        TextBox9.Text = ""
        TextBox10.Text = ""



        cn.Open()

        cmd.CommandText = "select Client_Id,Name,Loan_Id,Amount,Branch from info"
        dr = cmd.ExecuteReader()

        If dr.HasRows Then

            While (dr.Read())

                ListBox1.Items.Add(dr("Client_Id"))
                ListBox2.Items.Add(dr("Name"))
                ListBox3.Items.Add(dr("Loan_Id"))
                ListBox4.Items.Add(dr("Amount"))
                ListBox5.Items.Add(dr("Branch"))



            End While


        End If


        cn.Close()

    End Sub

    Private Sub ListBox5_MouseClick(sender As Object, e As MouseEventArgs) Handles ListBox5.MouseClick, ListBox4.MouseClick, ListBox3.MouseClick, ListBox2.MouseClick, ListBox1.MouseClick

        Dim lb As New ListBox
        lb = sender
        If lb.SelectedIndex <> -1 Then

            ListBox1.SelectedIndex = lb.SelectedIndex
            ListBox2.SelectedIndex = lb.SelectedIndex
            ListBox3.SelectedIndex = lb.SelectedIndex
            ListBox4.SelectedIndex = lb.SelectedIndex
            ListBox5.SelectedIndex = lb.SelectedIndex

            TextBox10.Text = ListBox1.SelectedItem
            TextBox9.Text = ListBox2.SelectedItem
            TextBox8.Text = ListBox3.SelectedItem
            TextBox7.Text = ListBox4.SelectedItem
            TextBox6.Text = ListBox5.SelectedItem


        End If


    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        If TextBox6.Text <> "" And TextBox7.Text <> "" And TextBox8.Text <> "" And TextBox9.Text <> "" And TextBox10.Text <> "" Then


            cn.Open()

            cmd.CommandText = "update info set Client_Id='" & TextBox10.Text & "',Name='" & TextBox9.Text & "' ,Loan_Id='" & TextBox8.Text & "'    ,Amount='" & TextBox7.Text & "'     ,Branch='" & TextBox6.Text & "'      where Client_Id = '" & ListBox1.SelectedItem & "'"



            cmd.ExecuteNonQuery()
            cn.Close()


            TextBox10.Text = ""
            TextBox9.Text = ""
            TextBox8.Text = ""
            TextBox7.Text = ""
            TextBox6.Text = ""


            loadlistbox()




            MessageBox.Show("Record is Updated in database")
        Else
            MessageBox.Show("Input filed can not be empty")



        End If




    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click


        If TextBox6.Text <> "" Or TextBox7.Text <> "" Or TextBox8.Text <> "" Or TextBox9.Text <> "" Or TextBox10.Text <> "" Then


            cn.Open()


            cmd.CommandText = "delete from info where Client_Id='" & TextBox10.Text & "'"


            cmd.ExecuteNonQuery()
            cn.Close()


            TextBox7.Text = ""
            TextBox8.Text = ""
            TextBox9.Text = ""
            TextBox10.Text = ""

            loadlistbox()

            MessageBox.Show("Record is Deleted from database")

        End If


    End Sub

    Private Sub TextBox8_TextChanged(sender As Object, e As EventArgs) Handles TextBox8.TextChanged

    End Sub
End Class
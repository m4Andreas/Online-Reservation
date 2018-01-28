using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Online_reservation
{
    public partial class ownerlogin : Form
    {
        public ownerlogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Login Login = new Login();
            this.Hide();
            Login.Show();
        }

        private void ownerlogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }


        int p;

        string[] date_array = new string[10];

       



       



        private void button2_Click(object sender, EventArgs e)
        {



            try
            {

                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30");

                string query = "Select * from Login where Username = '" + textBox1.Text.Trim() + "'"; //sending a query to our database





                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);






                if (dtbl.Rows.Count == 1)
                {

                    MessageBox.Show("User " + textBox1.Text + " already exists!");
                }
                else
                {
                    sqlcon.Open();
                    SqlCommand cmd = new SqlCommand("SELECT SCOPE_IDENTITY() INSERT INTO [dbo].[Login] ([Username],[Password],[Type]) VALUES ('" + textBox1.Text + "', '" + textBox2.Text + "', '" + comboBox1.Text + "');");


                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.Connection = sqlcon;

                    SqlDataReader reader = cmd.ExecuteReader();

                    reader.Read();

                    string id = reader[0].ToString();


                    sqlcon.Close();

                    MessageBox.Show("User Added!");

                    created_users();
                }

            }
            catch 
            {
                MessageBox.Show("Something went Wrong, please try again!");
            }








        }

        private void ownerlogin_Load(object sender, EventArgs e)
        {


            Chart1.ChartAreas[0].AxisY.Minimum = 0;
            Chart1.ChartAreas[0].AxisY.Maximum = 100;








           



            
            created_users();






        }

        private void created_users()
        {
            try
            {

                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30");

                
                sqlcon.Open();
                SqlCommand cmd = new SqlCommand(
         "SELECT count(*) FROM Login;", sqlcon);

                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlcon;

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                string ammount = reader[0].ToString();
                label8.Text = "Total Users: " + ammount;
                sqlcon.Close();





                string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30";
                string sql = "SELECT * FROM Rooms";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataadapter.Fill(ds, "Authors_table");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Authors_table";




                string sql2 = "SELECT * FROM Clients";
                SqlConnection connection2 = new SqlConnection(connectionString);
                SqlDataAdapter dataadapter2 = new SqlDataAdapter(sql2, connection2);
                DataSet ds2 = new DataSet();
                connection2.Open();
                dataadapter2.Fill(ds2, "Authors_table");
                connection2.Close();
                dataGridView2.DataSource = ds2;
                dataGridView2.DataMember = "Authors_table";


               

                


                foreach (DataGridViewRow row in dataGridView2.Rows)
                {


                    date_array[p] = row.Cells[6].Value.ToString();

                    p = p + 1;
                    break;

                }
             int z = DateTime.Now.Year;
            int q = DateTime.Now.Month;
            int r = DateTime.Now.Day;



            var endDate = new DateTime(z, q, r);



            for (int i = 0; i < 8; i++)
            {

                Chart1.Series[0].Points.AddXY(endDate, "50");
                endDate = endDate.AddDays(1);


                



               

            }

            }

            catch
            {

            }


         


        }

        private void button3_Click(object sender, EventArgs e)
        {


            try
            {
               

                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30");

               


                sqlcon.Open();
               

                SqlCommand cmd2 = new SqlCommand(
                "delete from Login where Username = '" + textBox3.Text.Trim() + "'", sqlcon);


                int result = cmd2.ExecuteNonQuery();




                if (result == 1)
                {
                    MessageBox.Show("User " + textBox3.Text + " is now deleted!");
                    created_users();
                }
                else
                {
                    MessageBox.Show("Something went Wrong, please try again!");
                }
                sqlcon.Close();
            }
            catch 
            {
                MessageBox.Show("Something went Wrong, please try again!");
            }






        }

        private void button4_Click(object sender, EventArgs e)
        {


            if (textBox4.Text != String.Empty)
            {


                 try
            {



                Boolean i = false;


                String searchValue = textBox4.Text;
                int rowIndex = -1;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        i = true;
                        rowIndex = row.Index;
                        textBox6.Text = dataGridView1.Rows[rowIndex].Cells["Costpernight"].Value.ToString();

                        button6.Visible = true;
                        button5.Visible = true;
                        break;
                    }
                }


                if (i == true)
                {

                    

                }


                else
                {


                    button6.Visible = false;
                    button5.Visible = false;

                    MessageBox.Show("This Reservation ID does not exist!");

                }




            }
                 catch 
                 {
                     button6.Visible = false;
                     button5.Visible = false;

                     MessageBox.Show("This Reservation ID does not exist!");
                 }



              
            }

            else
            {


                MessageBox.Show("Please type a reservation ID!");
            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox7.Text != String.Empty)
            {

                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30");

                string query4 = "UPDATE Rooms SET Costpernight = '" + textBox7.Text.Trim() + "' WHERE Id= '" + textBox4.Text.Trim() + "'";
                SqlDataAdapter sda4 = new SqlDataAdapter(query4, sqlcon);
                DataTable dtbl4 = new DataTable();
                sda4.Fill(dtbl4);


               

                MessageBox.Show("Room with id: " + textBox4.Text + " updated!");



            }

            else
            {
                MessageBox.Show("Please insert the new price!");

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

             if (textBox6.Text != String.Empty)
             {

                 int x = Int32.Parse(textBox6.Text);

                 int y = Int32.Parse(textBox5.Text);


                 textBox7.Text = ((x * y) / 100).ToString();

                 int z = Int32.Parse(textBox7.Text);



                 textBox7.Text = (x - z).ToString();



             }

             else
             {
                 MessageBox.Show("Please search for a room first!");

             }
            


        }

    }

}

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
using System.Text.RegularExpressions;


namespace Online_reservation
{


    

    public partial class NewRes : Form
    {

        String date1;
        String date2;
        object Roomnum = 0;
        public int RoomID = 0;
        public NewRes()
        {
            InitializeComponent();
        }


        private void updatingrooms()
        {

            try
            {


                string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename="+"C:\\Users\\"+Environment.UserName+"\\Documents\\hoteldatabase.mdf"+";Integrated Security=True;Connect Timeout=30";
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






            }
            catch 
            {

            }
        }


        private void SearchforRooms()
        {


            SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30");

            sqlcon.Open();
            

            SqlCommand cmd2 = new SqlCommand(
            "Select * from Rooms where Hotel = '" + comboBox1.Text.Trim() + "'", sqlcon);


            int result = cmd2.ExecuteNonQuery();




            if (result == 1)
            {
                MessageBox.Show("Hotels found");
               
            }
            else
            {
                MessageBox.Show("Hotels not found");
            }
            sqlcon.Close();




        }


        private void checkavailability()
        {



            for (int i = dataGridView1.RowCount - 2; i >= 0; i--)
            {
                for (int j = 0; j < dataGridView2.RowCount - 1; j++)
                {

                    string grid2 = dataGridView2.Rows[j].Cells[5].Value.ToString();
                    string grid1 = dataGridView1.Rows[i].Cells[0].Value.ToString();


                    if (grid1 == grid2)
                    {

                        string startdate = dataGridView2.Rows[j].Cells[6].Value.ToString(); //clients check in row
                        string endate = dataGridView2.Rows[j].Cells[7].Value.ToString();//clients check out row


                        DateTime startdate1 = DateTime.Parse(startdate);
                        DateTime endate1 = DateTime.Parse(endate);

                        DateTime currentcheckin = DateTime.Parse(monthCalendar1.SelectionStart.ToString("d/M/yyyy"));
                        DateTime currentcheckout = DateTime.Parse(monthCalendar2.SelectionStart.ToString("d/M/yyyy"));


                        //ti prepei na isxuei
                        if ((currentcheckin.Date > endate1.Date) || (currentcheckout.Date < startdate1.Date))
                        {

                        }
                        else
                        {//se authn tin periptosh uparxoun atoma p 4axoun idio domatio tis idies meres


                            for (int k = 0; k < listBox1.Items.Count; ++k) //trying to remove room where is not available due to current dates
                            {
                                string input = listBox1.Items[k].ToString();

                                // Here we call Regex.Match.
                                Match match = Regex.Match(input, @"Room Number: " + dataGridView1.Rows[i].Cells[2].Value.ToString(), RegexOptions.IgnoreCase);

                                // Here we check the Match instance.
                                if (match.Success)
                                {

                                    listBox1.Items.RemoveAt(k--);

                                }

                            }



                           
                        }


                    }
                }
            }




        }



        private void NewRes_Load(object sender, EventArgs e)
        {
           

            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            this.comboBox2.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        }

        private void NewRes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            listBox1.Items.Clear();

           

            updatingrooms();
            groupBox1.Visible = true;

        
            ClientsInfo ClientsInfo = new ClientsInfo();

            ClientsInfo.Checkin = monthCalendar1.SelectionStart.ToString("M/d/yyyy");
            date1 = monthCalendar1.SelectionStart.ToString("M/d/yyyy");
            date2 = monthCalendar2.SelectionStart.ToString("M/d/yyyy");
           

          

            ClientsInfo.Checkout = monthCalendar2.SelectionStart.ToString("M/d/yyyy");
            
          

            try
            {

                


                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    

                    if (row.Cells[1].Value.ToString().Trim().Equals(comboBox1.Text.Trim()) && row.Cells[3].Value.ToString().Trim().Equals("1") && row.Cells[6].Value.ToString().Trim().Equals(comboBox2.Text.Trim()) && row.Cells[7].Value.ToString().Trim().Equals(numericUpDown1.Text.Trim()) && row.Cells[8].Value.ToString().Trim().Equals(numericUpDown2.Text.Trim()))
                    {
                        
                        Roomnum = row.Cells[2].Value;
                        listBox1.Items.Add("Room Number: " + row.Cells[2].Value.ToString() + " *Price per night " + row.Cells[9].Value.ToString() + "€");
                       


                    }
                }

            }
            catch 
            {
                

                if (listBox1.Items.Count > 0)
                {
                    
                    label7.Visible = true;
                    checkavailability();


                }
                else
                {
                    label7.Visible = false;
                    MessageBox.Show("No room Found");
                }

                
            }


            

           

            
            
          
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome Welcome = new Welcome();
            Welcome.Show();
        }

        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.SelectedIndex = listBox1.IndexFromPoint(e.X, e.Y);

        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void listBox1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            string first_string = listBox1.SelectedItem.ToString();
            string second_string = string.Empty;
            string third_string = listBox1.SelectedItem.ToString();
            string four_string = string.Empty;


            DialogResult dialogResult = MessageBox.Show("Are you sure you want to book this room?", "Booking this Room", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {

                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30");

                sqlcon.Open();
               

                SqlCommand cmd = new SqlCommand( "Select * from Rooms where Hotel = '" + comboBox1.Text.Trim() + "' and RoomNumber = '" + Roomnum + "'");


                cmd.CommandType = System.Data.CommandType.Text;
                cmd.Connection = sqlcon;

                SqlDataReader reader = cmd.ExecuteReader();

                reader.Read();

                ClientsInfo ClientsInfo = new ClientsInfo();
                Checkininfo Checkininfo = new Checkininfo();
                ClientsInfo.RoomID = Int32.Parse(reader[0].ToString());

              
                sqlcon.Close();

                ClientsInfo.textBox5.Text = monthCalendar2.SelectionStart.ToString("d/M/yyyy");
                ClientsInfo.textBox6.Text = comboBox1.Text;
                ClientsInfo.textBox7.Text = monthCalendar1.SelectionStart.ToString("d/M/yyyy");

               


               
                this.Hide();
                
                ClientsInfo.Show();
            }
            else if (dialogResult == DialogResult.No)
            {
                
            }

            
        }

        private void button3_Click(object sender, EventArgs e)
        {


           


            
        }
    }
}

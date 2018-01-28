using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_reservation
{
    public partial class CancelRes : Form
    {
        public CancelRes()
        {
            InitializeComponent();
        }

        private void CancelRes_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }


        private void updatinclients()
        {

            try
            {
                string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30";
                string sql = "SELECT * FROM Clients";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                connection.Open();
                dataadapter.Fill(ds, "Authors_table");
                connection.Close();
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Authors_table";
            }
            catch 
            {

            }
        }


        private void CancelRes_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome Welcome = new Welcome();
            Welcome.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text != string.Empty) //make sure that textbox1 is NOT empty

            {
            
             try
            {

                Boolean k = false;
                Boolean i = false;


                String searchValue = textBox1.Text;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[9].Value.ToString().Equals(searchValue))
                    {
                                           
                        
                        if (row.Cells[8].Value.ToString().Equals("True"))
                        {

                            MessageBox.Show("Reservation is already Canceled!");
                            k = true;
                        }

                        else
                        {

                            i = true;
                        }

                       break;


                    }
                }


                if (i == true)
                {

                  

                    SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30");
                    string query4 = "UPDATE Clients SET Canceled = 'True' WHERE ReservationId= '" + textBox1.Text.Trim() + "'";
                    SqlDataAdapter sda4 = new SqlDataAdapter(query4, sqlcon);
                    DataTable dtbl4 = new DataTable();
                    sda4.Fill(dtbl4);
                    MessageBox.Show("Reservation Canceled!");

                  

                }
                else
                {

                    if (k == false)
                    {
                        MessageBox.Show("This Reservation ID does not exist!");
                    }

                    

                }

                updatinclients(); //updating to datagridview to opoio periexei ta stoixeia ths vashs


                
               




            }
             catch 
             {
                 MessageBox.Show("Something went Wrong, please try again.");
             }
            
            
            }

            else
            {

                MessageBox.Show("Please Insert Reservation ID");

            }
           


        }

        private void CancelRes_Load(object sender, EventArgs e)
        {
            updatinclients(); //updating to datagridview to opoio periexei ta stoixeia ths vashs


        }
    }
}

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
    public partial class RoomsManager : Form
        
    {
        public RoomsManager()
        {
            InitializeComponent();
        }

        private void updatingsql()
        {

            try
            {


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
            }
            catch 
            {

            }
        }

        private void RoomsManager_Load(object sender, EventArgs e)
        {
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            updatingsql();

        }

        private void checkBox2_MouseEnter(object sender, EventArgs e)
        {
           



        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == false)
            {
                label1.Text = "Please insert room ID:";
                

            }
            else
            {
                label1.Text = "Please insert room Number:";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String searchValue = textBox1.Text;
                int rowIndex = -1;
                int i = 10;
                if (label1.Text == "Please insert room ID:")
                {
                    i = 0;

                }
                else
                {
                    i = 2;

                }
                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[i].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }


                if (dataGridView1.Rows[rowIndex].Cells["Room_Type"].Value.ToString().Trim() == "Regular")
                {
                    comboBox1.SelectedIndex = 0;
                }
                else
                {
                    comboBox1.SelectedIndex = 1;

                }
               

                if (dataGridView1.Rows[rowIndex].Cells["Singe_Beds"].Value.ToString().Trim() == "1")
                {
                    numericUpDown1.Value = 1;
                }
                else if (dataGridView1.Rows[rowIndex].Cells["Singe_Beds"].Value.ToString().Trim() == "2")
                {
                    numericUpDown1.Value = 2;

                }
                else if (dataGridView1.Rows[rowIndex].Cells["Singe_Beds"].Value.ToString().Trim() == "3")
                {
                    numericUpDown1.Value = 3;

                }

                else if (dataGridView1.Rows[rowIndex].Cells["Singe_Beds"].Value.ToString().Trim() == "4")
                {
                    numericUpDown1.Value = 4;

                }



                if (dataGridView1.Rows[rowIndex].Cells["Double_Beds"].Value.ToString().Trim() == "1")
                {
                    numericUpDown2.Value = 1;
                }
                else if (dataGridView1.Rows[rowIndex].Cells["Double_Beds"].Value.ToString().Trim() == "2")
                {
                    numericUpDown2.Value = 2;

                }
                else if (dataGridView1.Rows[rowIndex].Cells["Double_Beds"].Value.ToString().Trim() == "3")
                {
                    numericUpDown2.Value = 3;

                }

                else if (dataGridView1.Rows[rowIndex].Cells["Double_Beds"].Value.ToString().Trim() == "4")
                {
                    numericUpDown2.Value = 4;

                }


                textBox2.Text = dataGridView1.Rows[rowIndex].Cells["Costpernight"].Value.ToString().Trim();


                if (dataGridView1.Rows[rowIndex].Cells["Available"].Value.ToString().Trim() == "0")
                {
                    checkBox1.Checked = false;

                }
                else
                {
                    checkBox1.Checked = true;
                }


            }

            catch 
            {
                MessageBox.Show("Room not Found!");
            }


            

               
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {

                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30");

                if (checkBox1.Checked == false)
                {
                    string query = "UPDATE Rooms SET Available = 0 WHERE Id= '" + textBox1.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                }

                else
                {

                    string query = "UPDATE Rooms SET Available = 1 WHERE Id= '" + textBox1.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                }


                if (comboBox1.SelectedIndex == 0)
                {
                    string query = "UPDATE Rooms SET Room_Type = 'Regular' WHERE Id= '" + textBox1.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                }

                else
                {

                    string query = "UPDATE Rooms SET Room_Type = 'Vip' WHERE Id= '" + textBox1.Text.Trim() + "'";
                    SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                    DataTable dtbl = new DataTable();
                    sda.Fill(dtbl);
                }



                string query2 = "UPDATE Rooms SET Singe_Beds = '" + numericUpDown1.Text.Trim() + "' WHERE Id= '" + textBox1.Text.Trim() + "'";
                SqlDataAdapter sda2 = new SqlDataAdapter(query2, sqlcon);
                DataTable dtbl2 = new DataTable();
                sda2.Fill(dtbl2);

                string query3 = "UPDATE Rooms SET Double_Beds = '" + numericUpDown2.Text.Trim() + "' WHERE Id= '" + textBox1.Text.Trim() + "'";
                SqlDataAdapter sda3 = new SqlDataAdapter(query3, sqlcon);
                DataTable dtbl3 = new DataTable();
                sda3.Fill(dtbl3);



                string query4 = "UPDATE Rooms SET Costpernight = '" + textBox2.Text.Trim() + "' WHERE Id= '" + textBox1.Text.Trim() + "'";
                SqlDataAdapter sda4 = new SqlDataAdapter(query4, sqlcon);
                DataTable dtbl4 = new DataTable();
                sda4.Fill(dtbl4);


                updatingsql();

                MessageBox.Show("Room "+ textBox1.Text+ " updated!");
                


                
                







            }
            catch 
            {
                MessageBox.Show("Something went Wrong, please try again!");
            }
        }

        private void RoomsManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            employeeLogin employeeLogin = new employeeLogin();
            employeeLogin.Show();
        }
    }
}

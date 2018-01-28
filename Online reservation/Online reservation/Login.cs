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
    public partial class Login : Form
    {


       public int count;


        public Login()
        {
            InitializeComponent();
        }

        public string TheValue
        {
            get { return label1.Text; }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome Welcome = new Welcome();
            Welcome.Show();

       

        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            try
            {

                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30");

                string query = "Select * from Login where Username = '" + textBox1.Text.Trim() + "' and Password = '" + textBox2.Text.Trim() + "'";

              



                SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
                DataTable dtbl = new DataTable();
                sda.Fill(dtbl);






                if (dtbl.Rows.Count == 1)
                {
                    


                    String searchValue = textBox1.Text;
                    int rowIndex = -1;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.Cells[1].Value.ToString().Equals(searchValue))
                        {
                            rowIndex = row.Index;
                            break;
                        }
                    }

                   
                    string output = dataGridView1.Rows[rowIndex].Cells["Type"].Value.ToString();

                    output = Regex.Replace(output, @"\s", "");




                    if (output == "Admin") //o xrisths einai admin
                    {
                        
                        this.Hide();
                        ownerlogin ownerlogin = new ownerlogin();
                        ownerlogin.Show();


                    }

                    else
                    {
                        // o xristis den einai admin
                        this.Hide();
                        employeeLogin employeeLogin = new employeeLogin();
                        employeeLogin.Show();

                    }








                }

                else
                {
                    MessageBox.Show("Invalid Username or password");
                }


            }
            catch 
            {
                MessageBox.Show("Something Went Wrong"); 
            }



           



           


        }

        private void Login_Load(object sender, EventArgs e)
        {


            try
            {
                string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30";
                string sql = "SELECT * FROM Login";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

      //  public static 
       
    }
}

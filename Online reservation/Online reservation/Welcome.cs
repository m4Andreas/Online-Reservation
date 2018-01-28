using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_reservation
{
    public partial class Welcome : Form
    {
        public Welcome()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CancelRes CancelRes1 = new CancelRes();
            this.Hide();
            CancelRes1.Show();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            NewRes NewRes1 = new NewRes();
            this.Hide();
            NewRes1.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login Login1 = new Login();
            this.Hide();
            Login1.Show();

        }

        private void Welcome_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();

        }

        private void Welcome_Load(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo("C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf");

            if (file.Exists)
            {
                // an to arxeio ths vashs uparxei sthn 8esh tou


                try //prospa8oume na testaroume an h vash leitourgei kanonika
                {
                    string connectionString = @"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30";
                    string sql = "SELECT * FROM Login";
                    SqlConnection connection = new SqlConnection(connectionString);
                    SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
                    DataSet ds = new DataSet();
                    connection.Open();
                    dataadapter.Fill(ds, "Authors_table");
                    connection.Close();

                }
                catch
                {
                    label1.Text = "Database is not running.";
                    label1.ForeColor = Color.Red;

                }
                

            }
            else
            {

                // an to arxeio ths vashs DEN vre8ei sthn 8esh tou

               // MessageBox.Show(@"Database file is missing from the directory. Please insert the .mdf file(hoteldatabase.mdf) on the following path: C:\Users\(username)\Documents");
                DialogResult dialogResult = MessageBox.Show(@"Database file is missing from the directory. Please insert the .mdf file(hoteldatabase.mdf) on the following path: "+Environment.NewLine + @"C:\Users\(username)\Documents" +Environment.NewLine + @"Do you want to continue any way?", "Warning", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    //do something
                }
                else if (dialogResult == DialogResult.No)
                {
                    Application.ExitThread();
                    //closing the app
                }

            }


        }
    }
}

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

using System.Runtime.InteropServices;

using System.Drawing.Imaging;


namespace Online_reservation
{
    public partial class Checkininfo : Form
    {
        public Checkininfo()
        {
            InitializeComponent();
        }

        public ClientsInfo ClientsInfo = new ClientsInfo();

        private void Checkininfo_Load(object sender, EventArgs e)
        {
            try
            {
                //updating to datagridview to opoio periexei ta stoixeia ths vashs


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




                string sql2 = "SELECT * FROM Rooms";
                SqlConnection connection2 = new SqlConnection(connectionString);
                SqlDataAdapter dataadapter2 = new SqlDataAdapter(sql2, connection2);
                DataSet ds2 = new DataSet();
                connection2.Open();
                dataadapter2.Fill(ds2, "Authors_table");
                connection2.Close();
                dataGridView2.DataSource = ds2;
                dataGridView2.DataMember = "Authors_table";




                
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[9].Value.ToString().Trim().Equals(textBox1.Text))
                    {
                        label9.Text = row.Cells["PhoneNumber"].Value.ToString();

                        label14.Text = row.Cells["Email"].Value.ToString();
                        label10.Text = row.Cells["CheckIN"].Value.ToString();

                        label8.Text = row.Cells["ReservationId"].Value.ToString();



                        label10.Text = textBox4.Text;

                        label16.Text = textBox5.Text;

                        
                        DateTime myDate = DateTime.ParseExact(textBox4.Text, "d/M/yyyy",
                                       System.Globalization.CultureInfo.InvariantCulture);


                        DateTime myDate2 = DateTime.ParseExact(textBox2.Text, "d/M/yyyy",
                                      System.Globalization.CultureInfo.InvariantCulture);


                        

                        try
                        {

                            label11.Text = (myDate2.Subtract(myDate)).ToString();


                            var s = label11.Text;
                            var firstWord = s.Substring(0, s.IndexOf(":"));

                         


                            var s2 = firstWord;
                            var firstWord2 = s2.Substring(0, s.IndexOf("."));

                            


                            label11.Text = firstWord2;

                        }


                        catch 
                        {

                            label11.Text = "1";// Day";



                            



                        }

                        break;


                    }
                }



                foreach (DataGridViewRow row in dataGridView2.Rows)
                {
                    if (row.Cells[0].Value.ToString().Trim().Equals(textBox3.Text))
                    {

                        label12.Text = row.Cells[9].Value.ToString();
                        label7.Text = row.Cells[2].Value.ToString();

                        int x = Int32.Parse(label12.Text);

                        int y = Int32.Parse(label11.Text);



                        x = (y * x);

                        label12.Text = x.ToString() + "€ " + "(" + row.Cells[9].Value.ToString() + " € per Day)";
                        break;

                    }

                }


                label11.Text = label11.Text + " Day(s)";


            }
            catch 
            {


              
            }
        
    }


        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Welcome Welcome = new Welcome();
            Welcome.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                Rectangle bounds = this.Bounds;
                using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(new Point(bounds.Left, bounds.Top), Point.Empty, bounds.Size);
                    }

                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

                  

                    bitmap.Save(path+"\\booking_receipt.png", ImageFormat.Jpeg);

                    MessageBox.Show("Booking info saved to your desktop!");

                }
            }
            
            catch 
            {
                MessageBox.Show("Something Went Wrong.Please try Again");
            }



            



        }
    }
}

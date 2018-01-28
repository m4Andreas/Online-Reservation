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
    public partial class ClientsInfo : Form
    {

        public String Checkin =""; 
        public String Checkout = "";
        public int RoomID = 0;
        public string sixDigitNumber;
        int i = 7;
        public ClientsInfo()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != String.Empty && textBox2.Text != String.Empty && textBox3.Text != String.Empty && textBox4.Text != String.Empty && textBox3.Text.Contains("@"))
            {
                

                

                SqlConnection sqlcon = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=" + "C:\\Users\\" + Environment.UserName + "\\Documents\\hoteldatabase.mdf" + ";Integrated Security=True;Connect Timeout=30");

                    
                        sqlcon.Open();
          


                        

                        NewRes NewRes = new NewRes();
                        
                        Random r = new Random();
                        int randNum = r.Next(1000000);
                         sixDigitNumber = randNum.ToString("D6"); //creating a random 6 digit number
                        


                        SqlCommand cmd = new SqlCommand("SELECT SCOPE_IDENTITY() INSERT INTO [dbo].[Clients] ([FirstName],[LastName],[Email],[PhoneNumber],[Canceled], [RoomId],[CheckIN],[CheckOUT],[ReservationId]) VALUES ('" + textBox1.Text.Trim() + "', '" + textBox2.Text.Trim() + "', '" + textBox3.Text.Trim() + "', '" + textBox4.Text.Trim() + "', '" + "0" + "', '" + RoomID.ToString() + "', '" + Checkin + "', '" + Checkout + "', '" + sixDigitNumber + "');");


                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.Connection = sqlcon;

                        SqlDataReader reader = cmd.ExecuteReader();

                        reader.Read();

                      


                        sqlcon.Close();

                       
                        label6.Visible = true;
                        label7.Visible = true;

                

                       



                        
                            
                        LabelupdatingTimer.Start();


               
                
            }
            else
            {

                MessageBox.Show("Make sure that you have fill all of the blanks below");
            }
           

        }

        private void ClosingTimer_Tick(object sender, EventArgs e)
        {
            ClosingTimer.Stop();

            this.Hide();
            Welcome Welcome = new Welcome();
            Welcome.Show();

            
        }

        private void LabelupdatingTimer_Tick(object sender, EventArgs e)
        {

            label7.Text = "Redirecting in (" + i + ")";
            i = i - 1;

            if (i<0)
            {
                LabelupdatingTimer.Stop();

                MessageBox.Show("Thank you for your booking, Have a nice day.");

                this.Hide();
                Checkininfo Checkininfo = new Checkininfo();
                Checkininfo.textBox1.Text = sixDigitNumber;
               
                Checkininfo.textBox2.Text = textBox5.Text;

                Checkininfo.textBox3.Text = RoomID.ToString();

               

                Checkininfo.textBox4.Text = textBox7.Text;
                Checkininfo.textBox5.Text = textBox6.Text;

                Checkininfo.Show();
            }

        }

        private void ClientsInfo_Load(object sender, EventArgs e)
        {
            Checkin = textBox7.Text;
            Checkout = textBox5.Text;
        }

        private void ClientsInfo_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&  //do not let user, inserting a letters.
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Online_reservation
{
    public partial class employeeLogin : Form
    {
        public employeeLogin()
        {
            InitializeComponent();
        }



        private void employeeLogin_Load(object sender, EventArgs e)
        {
            
         


           


         

        }

       
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void employeeLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.ExitThread();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            RoomsManager RoomsManager = new RoomsManager();
            this.Hide();
            RoomsManager.Show();
            
            

         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CancelRes CancelRes1 = new CancelRes();
            this.Hide();
            CancelRes1.Show();
            

        }

        private void button2_Click(object sender, EventArgs e)
        {
          
            NewRes newres = new NewRes();
            this.Hide();
            newres.Show();

        }

        private void button4_Click(object sender, EventArgs e)
        {

            Login Login = new Login();
            this.Hide();
            Login.Show();

        }
    }
}

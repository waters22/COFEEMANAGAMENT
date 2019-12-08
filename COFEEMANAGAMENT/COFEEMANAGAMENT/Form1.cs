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

namespace COFEEMANAGAMENT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            // string usr = textuser.Text;
            //string pass = textpass.Text;
            SqlConnection con;
            string str;

            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True");
            con.Open();
            str = "SELECT *from USERLOGIN where Name='" + txtUserName.Text + "' and Password='" + txtPassword.Text + "'";
            SqlCommand com = new SqlCommand(str, con);
            SqlDataReader read = com.ExecuteReader();
            if (read.Read())
            {
                this.Hide();
                Main mainfrm = new Main();
                mainfrm.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Sorry wrong username and password");
            }
            con.Close();
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

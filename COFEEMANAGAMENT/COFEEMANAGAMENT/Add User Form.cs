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
    public partial class Add_User_Form : Form
    {
        public Add_User_Form()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "update  USERLOGIN  set Name='" + txtUserName.Text + "',Password='" + txtPassword.Text + "'where Name='" +txtUserName.Text + "'";

            SqlCommand command = new SqlCommand(query, con);

            try
            {
                con.Open();

                command.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Executed");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}

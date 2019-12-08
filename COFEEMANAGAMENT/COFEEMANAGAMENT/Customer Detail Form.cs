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
    public partial class Customer_Detail_Form : Form
    {
        public Customer_Detail_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string customerID = txtCustomerID.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string contact = txtContact.Text;
            string email = txtEmail.Text;

           

           

            string query = "insert into tblCustomer values ('" + customerID + "','" + name + "','" + address + "','" + city + "','" + contact + "','" +email + "')";

            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);



            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Executed");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string customerID = txtCustomerID.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string contact = txtContact.Text;
            string email = txtEmail.Text;
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "update  tblCustomer  set Name='" + name + "',Address='" + address + "',City='" + city+ "',Contact='" + contact + "',Email='" + email + "' where CustomerID='" + customerID + "'";

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

        private void button3_Click(object sender, EventArgs e)
        {
            string customerID = txtCustomerID.Text;
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "delete from tblCustomer where CustomerID='" + customerID + "'";

            SqlCommand command = new SqlCommand(query, con);


            con.Open();

            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Executed");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "select * from tblCustomer where CustomerID= '" + txtSearch.Text + "'";
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtName.Text = reader["Name"].ToString();
                txtAddress.Text = reader["Address"].ToString();
                txtCity.Text = reader["City"].ToString();
                txtContact.Text = reader["Contact"].ToString();
                txtEmail.Text = reader["Email"].ToString();




                con.Close();
                MessageBox.Show("Executed");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            Main mainfrm = new Main();
            mainfrm.Show();
        }
    }
}

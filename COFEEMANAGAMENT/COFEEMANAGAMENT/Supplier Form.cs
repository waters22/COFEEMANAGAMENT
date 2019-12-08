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
    public partial class Supplier_Form : Form
    {
        public Supplier_Form()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string supplierID = txtEmployeeID.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string email = txtMail.Text;
            string contact = txtContact.Text;
            string supplierof = txtSupplierOf.Text;
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "update  tblSupplier  set Name='" + name + "',Address='" + address + "',City='" + city + "',Email='" + email + "',Contact='" + contact + "',SupplierOf='" + supplierof + "' where SupplierID='" + supplierID + "'";

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

        private void button1_Click(object sender, EventArgs e)
        {
            string supplierID = txtEmployeeID.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string email = txtMail.Text;
            string contact = txtContact.Text;
            string supplierof = txtSupplierOf.Text;
            string query = "insert into tblSupplier values ('" + supplierID + "','" + name + "','" + address + "','" + city + "','" + email + "','" + contact + "','" + supplierof + "')";

            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);



            SqlCommand command = new SqlCommand(query, con);
            con.Open();
            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Executed");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string supplierID = txtEmployeeID.Text;
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "delete from tblCustomer where CustomerID='" + supplierID + "'";

            SqlCommand command = new SqlCommand(query, con);


            con.Open();

            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Executed");

        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "select * from tblSupplier where SupplierID= '" + txtSearch.Text + "'";
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtEmployeeID.Text = reader["SupplierID"].ToString();
                txtName.Text = reader["Name"].ToString();
                txtAddress.Text = reader["Address"].ToString();
                txtCity.Text = reader["City"].ToString();
                txtMail.Text = reader["Email"].ToString();
                txtContact.Text = reader["Contact"].ToString();
                txtSupplierOf.Text = reader["SupplierOf"].ToString();




                con.Close();
                MessageBox.Show("Executed");
            }
        }
    }
}
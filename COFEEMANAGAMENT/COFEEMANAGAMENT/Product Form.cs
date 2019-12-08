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
    public partial class Product_Form : Form
    {
        public Product_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
           
        {
            string productID = txtProductID.Text;
            string name = txtProductName.Text;
            string brand = txtBrand.Text;
            string totalprice = txtTotalPrice.Text;
            string quantity = txtQuantity.Text;
            string query = "insert into tblProduct values ('" +productID + "','" + name + "','" + brand + "','" + totalprice + "','" + quantity + "')";

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
            string productID = txtProductID.Text;
            string name = txtProductName.Text;
            string brand = txtBrand.Text;
            string price = txtTotalPrice.Text;
            string quantity = txtQuantity.Text;
           
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "update  tblProduct  set Name='" + name + "',Brand='" + brand + "',TotalPrice='" + price + "',Quantity='" + quantity + "' where ProductID='" + productID + "'";

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
            string productID = txtProductID.Text;
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "delete from tblProduct where ProductID='" + productID + "'";

            SqlCommand command = new SqlCommand(query, con);


            con.Open();

            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Executed");


        }

        private void button5_Click(object sender, EventArgs e)
        {
            string query = "select * from tblProduct where ProductID= '" + txtSearch.Text + "'";
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtProductName.Text = reader["Name"].ToString();
                txtBrand.Text = reader["Brand"].ToString();
                txtTotalPrice.Text = reader["TotalPrice"].ToString();
                txtQuantity.Text = reader["Quantity"].ToString();
                con.Close();
                MessageBox.Show("Executed");
            }
        }
    }
}

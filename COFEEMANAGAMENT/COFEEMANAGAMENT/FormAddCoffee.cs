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
    public partial class FormAddCoffee : Form
    {
        public FormAddCoffee()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string itemid = txtItemID.Text;
            string name = txtCoffeeName.Text;
            string price = txtPrice.Text;
           
            string query = "insert into tblCoffee values ('" + itemid + "','" + name + "','" + price + "')";

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
            string ID = txtItemID.Text;
            string name = txtCoffeeName.Text;
            string price = txtPrice.Text;
           

            
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "update  tblCoffee  set ItemName='" + name + "',Price='" + price + "' where ItemID ='" + ID + "'";

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

        private void button4_Click(object sender, EventArgs e)
        {
            string itemID = txtItemID.Text;
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "delete from tblCoffee where ItemID='" + itemID + "'";

            SqlCommand command = new SqlCommand(query, con);


            con.Open();

            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Executed");


        }

        private void button6_Click(object sender, EventArgs e)
        {
            string query = "select * from tblCoffee where itemID= '" + txtSearch.Text + "'";
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            con.Open();
            SqlCommand command = new SqlCommand(query, con);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                txtCoffeeName.Text = reader["ItemName"].ToString();
                txtPrice.Text = reader["Price"].ToString();
                con.Close();
                MessageBox.Show("Executed");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainfrm = new Main();
            mainfrm.Show();
        }
    }
    }


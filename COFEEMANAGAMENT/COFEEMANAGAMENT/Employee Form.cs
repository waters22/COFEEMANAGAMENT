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
    public partial class Employee_Form : Form
    {
        string gender;
        public Employee_Form()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string employeeID = txtEmployeeID.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string contact = txtContact.Text;

            if (radioButtonFemale.Checked)
                gender = "Female";
            else
                gender = "Male";
            string email = txtEmail.Text;
            DateTime date = dateTimePicker1.Value;
            double salary = Convert.ToDouble(numericUpDownSalary.Value);
            string query = "insert into tblEmployee values ('" + employeeID + "','" + name + "','" + address + "','" + city + "','" + contact + "','" + gender + "','" + email + "','" + date + "','" + salary + "')";

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
            string customerID = txtEmployeeID.Text;
            string name = txtName.Text;
            string address = txtAddress.Text;
            string city = txtCity.Text;
            string contact = txtContact.Text;
            string email = txtEmail.Text;

            if (radioButtonFemale.Checked)
                gender = "Female";
            else
                gender = "Male";
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "update  tblEmployee  set Name='" + name + "',Address='" + address + "',City='" + city + "',Contact='" + contact + "',Gender='" + gender + "',Email='" + email + "' where EmployeeID='" + txtEmployeeID.Text + "'";

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

        private void Employee_Form_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string empID = txtEmployeeID.Text;
            string Connectionsrting = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\My VS projects\COFEEMANAGAMENT\COFEEMANAGAMENT\COFEEMANAGEMENT.mdf;Integrated Security=True";
            SqlConnection con = new SqlConnection(Connectionsrting);
            string query = "delete from tblEmployee where EmployeeID='" + empID + "'";

            SqlCommand command = new SqlCommand(query, con);


            con.Open();

            command.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Executed");


        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            string query = "select * from tblEmployee where EmployeeID= '" + txtSearch.Text+ "'";
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
                gender = reader["Gender"].ToString();
                if (gender != "Male")            
                    
                    radioButtonFemale.Checked = true;
                
                txtEmail.Text = reader["Email"].ToString();
                dateTimePicker1.Text = reader["DOJ"].ToString();
                numericUpDownSalary.Text = reader["Salary"].ToString();



                con.Close();
                MessageBox.Show("Executed");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Main mainfrm = new Main();
            mainfrm.Show();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COFEEMANAGAMENT
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void newProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAddCoffee frmcoffee = new FormAddCoffee();
            frmcoffee.Show();
            this.Hide();
        }

        private void customersDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Customer_Detail_Form frmcustomerdetails = new Customer_Detail_Form();
            frmcustomerdetails.Show();
          
        }

        private void employeeDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Employee_Form employeeform = new Employee_Form();
            employeeform.Show();
            this.Hide();
        }

        private void productStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Product_Form productform = new Product_Form();
            productform.Show();
            this.Hide();
        }

        private void stockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock_Details_Form stockform = new Stock_Details_Form();
            stockform.Show();
            this.Hide();
        }

        private void addUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_User_Form adduser = new Add_User_Form();
            adduser.Show();
            this.Hide();
        }

        private void billToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Place_Order_Form order = new Place_Order_Form();
            order.Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 loginfrm = new Form1();
            loginfrm.Show();
        }

        private void supplierDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Supplier_Form supfrm = new Supplier_Form();
            supfrm.Show();
            this.Hide();
        }
    }
}

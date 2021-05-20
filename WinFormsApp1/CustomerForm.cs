using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class CustomerForm : Form
    {
        public CustomerForm()
        {
            InitializeComponent();
        }

        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        Customer customer = new Customer();
        private void CustomerForm_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("ID", 25);
            listView1.Columns.Add("Firstname", 100);
            listView1.Columns.Add("Lastname", 100);
            listView1.Columns.Add("Email", 100);
            listView1.Columns.Add("Phone Number", 100);
            GetAllCustomers();

        }

        private void AddCustomer()
        {
            Customer customer = new Customer
            {
                FirstName = textBox2.Text.ToString(),
                LastName = textBox3.Text.ToString(),
                Email = textBox4.Text.ToString(),
                PhoneNumber = textBox5.Text.ToString(),
            };

            customerManager.Add(customer);
        }
        private void UpdateCustomer()
        {
            customer.Id = Int32.Parse(textBox1.Text.ToString());
            customer.FirstName = textBox2.Text;
            customer.LastName = textBox3.Text;
            customer.Email = textBox4.Text;
            customer.PhoneNumber = textBox5.Text;
            customerManager.Update(customer);
        }
        private void DeleteCustomer()
        {
            customer.Id = Int32.Parse(textBox1.Text.ToString());
            customer.FirstName = textBox2.Text;
            customer.LastName = textBox3.Text;
            customer.Email = textBox4.Text;
            customer.PhoneNumber = textBox5.Text;
            customerManager.Delete(customer);

        }
        private void GetAllCustomers()
        {
            listView1.Items.Clear();
            foreach (var customer in customerManager.GetAll().Data)
            {
                string[] row = { customer.Id.ToString(), customer.FirstName.ToString(), customer.LastName.ToString(), customer.Email.ToString(), customer.PhoneNumber.ToString() };
                var cst = new ListViewItem(row);
                listView1.Items.Add(cst);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void SelectCustomer()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                Clear();
            }
            else
            {
                foreach (ListViewItem customer in listView1.SelectedItems)
                {
                    textBox1.Text = customer.SubItems[0].Text.ToString();
                    textBox2.Text = customer.SubItems[1].Text.ToString();
                    textBox3.Text = customer.SubItems[2].Text.ToString();
                    textBox4.Text = customer.SubItems[3].Text.ToString();
                    textBox5.Text = customer.SubItems[4].Text.ToString();
                }
            }
        }

        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectCustomer();
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                AddCustomer();
                GetAllCustomers();
                Clear();
            }
            else
            {
                MessageBox.Show("ID ERROR!");
                Clear();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateCustomer();
            GetAllCustomers();
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteCustomer();
            GetAllCustomers();
            Clear();
        }
    }
}

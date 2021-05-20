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
    public partial class RentalForm : Form
    {
        public RentalForm()
        {
            InitializeComponent();
        }
        RentalManager rentalManager = new RentalManager(new EfRentalDal());
        MovieManager movieManager = new MovieManager(new EfMovieDal());
        CustomerManager customerManager = new CustomerManager(new EfCustomerDal());
        Rental rental = new Rental();
        private void RentalForm_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            dateTimePicker1.Enabled = false;
            dateTimePicker1.Text = DateTime.Now.ToString();
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("MovieID", 75);
            listView1.Columns.Add("CustomerID", 75);
            listView1.Columns.Add("Movie Name", 100);
            listView1.Columns.Add("Customer Name", 100);
            listView1.Columns.Add("Rent Date", 100);
            listView1.Columns.Add("Return Date", 100);
            GetAllMovies();
            GetAllCustomers();
            GetAllRentals();
        }
        private int MovieId()
        {
            return movieManager.GetByName(comboBox1.Text).Data.Id;
        }
        private int CustomerId()
        {
            return customerManager.GetByName(comboBox2.Text).Data.Id;
        }
        private bool CheckInputs()
        {
            if (comboBox2.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Error!");
                return false;
            }
            else
            {
                return true;
            }

        }
        private void AddRental()
        {
            var result = CheckInputs();
            if (result)
            {
                Rental rental = new Rental
                {
                    MovieId = MovieId(),
                    CustomerId = CustomerId(),
                    RentDate = DateTime.Parse(dateTimePicker1.Text.ToString()),
                    ReturnDate = DateTime.Parse(dateTimePicker2.Text.ToString()),

                };
                rentalManager.Add(rental);
            }
        }
        private void Clear()
        {
            textBox1.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
            dateTimePicker1.Text = DateTime.Now.ToString();
            dateTimePicker2.Text = "";
        }
        private void GetAllMovies()
        {
            foreach (var movie in movieManager.GetAll().Data)
            {
                comboBox1.Items.Add(movie.Name);
            }
        }
        private void GetAllCustomers()
        {
            foreach (var customer in customerManager.GetAll().Data)
            {
                comboBox2.Items.Add($"{customer.FirstName} {customer.LastName}");
            }
        }
        private void SelectRental()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                Clear();
            }
            else
            {
                foreach (ListViewItem item in listView1.SelectedItems)
                {
                    textBox1.Text = item.SubItems[0].Text.ToString();
                    textBox1.Enabled = false;
                    comboBox1.Text = $"{item.SubItems[3].Text.ToString()}";
                    comboBox2.Text = $"{item.SubItems[4].Text.ToString()}";
                    dateTimePicker1.Text = item.SubItems[5].Text.ToString();
                    dateTimePicker2.Text = item.SubItems[6].Text.ToString();

                }
            }
        }
        private void DeleteRental()
        {
            rental.Id = Int32.Parse(textBox1.Text);
            rental.MovieId = MovieId();
            rental.CustomerId = CustomerId();
            rental.RentDate = DateTime.Parse(dateTimePicker1.Text);
            rental.ReturnDate = DateTime.Parse(dateTimePicker2.Text);
            rentalManager.Delete(rental);

        }
        private void UpdateRental()
        {
            rental.Id = Int32.Parse(textBox1.Text);
            rental.MovieId = MovieId();
            rental.CustomerId = CustomerId();
            rental.RentDate = DateTime.Parse(dateTimePicker1.Text);
            rental.ReturnDate = DateTime.Parse(dateTimePicker2.Text);
            rentalManager.Update(rental);
        }
        private void GetAllRentals()
        {
            listView1.Items.Clear();


            var result = rentalManager.GetRentalsDetails();
            foreach (var rental in result.Data)
            {
                string[] row = { rental.Id.ToString(),rental.MovieId.ToString(),rental.CustomerId.ToString(),
                    rental.MovieName,rental.CustomerName,rental.RentDate.ToString(),rental.ReturnDate.ToString() };
                var getRental = new ListViewItem(row);
                listView1.Items.Add(getRental);
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectRental();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddRental();
            GetAllRentals();
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateRental();
            GetAllRentals();
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteRental();
            GetAllRentals();
            Clear();
        }
    }
}

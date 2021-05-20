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
    public partial class DirectorForm : Form
    {
        public DirectorForm()
        {
            InitializeComponent();
        }
        DirectorManager directorManager = new DirectorManager(new EfDirectorDal());
        Director director = new Director();
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void DirectorForm_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("ID", 25);
            listView1.Columns.Add("Firstname", 100);
            listView1.Columns.Add("Lastname", 100);
            listView1.Columns.Add("Nationality", 100);
            listView1.Columns.Add("Birth", 100);
            GetAllDirectors();
        }
        private void GetAllDirectors()
        {
            listView1.Items.Clear();
            foreach (var director in directorManager.GetAll().Data)
            {
                string[] row = { director.Id.ToString(), director.FirstName, director.LastName, director.Nationality, director.Birth.ToString() };
                var drctr = new ListViewItem(row);
                listView1.Items.Add(drctr);
            }
        }
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            dateTimePicker1.Text = "";
        }
        private void AddDirector()
        {
            Director director = new Director
            {
                FirstName = textBox2.Text,
                LastName = textBox3.Text,
                Nationality = textBox4.Text,
                Birth = DateTime.Parse(dateTimePicker1.Text.ToString()),
            };

            directorManager.Add(director);
        }
        private void UpdateDirector()
        {
            director.Id = Int32.Parse(textBox1.Text);
            director.FirstName = textBox2.Text;
            director.LastName = textBox3.Text;
            director.Nationality = textBox4.Text;
            director.Birth = DateTime.Parse(dateTimePicker1.Text.ToString());
            directorManager.Update(director);
        }
        private void DeleteDirector()
        {
            director.Id = Int32.Parse(textBox1.Text);
            director.FirstName = textBox2.Text;
            director.LastName = textBox3.Text;
            director.Nationality = textBox4.Text;
            director.Birth = DateTime.Parse(dateTimePicker1.Text.ToString());
            directorManager.Delete(director);
        }
        private void SelectDirector()
        {
            if (listView1.SelectedItems.Count == 0)
            {
                Clear();
            }
            else
            {
                foreach (ListViewItem director in listView1.SelectedItems)
                {
                    textBox1.Text = director.SubItems[0].Text.ToString();
                    textBox2.Text = director.SubItems[1].Text.ToString();
                    textBox3.Text = director.SubItems[2].Text.ToString();
                    textBox4.Text = director.SubItems[3].Text.ToString();
                    dateTimePicker1.Text = director.SubItems[4].Text.ToString();
                }
            }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectDirector();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                AddDirector();
                GetAllDirectors();
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
            UpdateDirector();
            GetAllDirectors();
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteDirector();
            GetAllDirectors();
            Clear();
        }
    }
}

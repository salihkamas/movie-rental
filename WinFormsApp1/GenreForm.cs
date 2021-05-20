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
    public partial class GenreForm : Form
    {
        public GenreForm()
        {
            InitializeComponent();
        }
        GenreManager genreManager = new GenreManager(new EfGenreDal());
        Genre genre = new Genre();
        private void GenreForm_Load(object sender, EventArgs e)
        {

            textBox1.Enabled = false;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("Name", 100);
            GetAllGenres();
        }
        private void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
        }
        private void SelectGenre()
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
                    textBox2.Text = item.SubItems[1].Text.ToString();
                }
            }
        }
        private void AddGenre()
        {
            Genre genre = new Genre
            {
                Name = textBox2.Text
            };
            genreManager.Add(genre);

        }
        private void UpdateGenre()
        {
            genre.Id = Int32.Parse(textBox1.Text);
            genre.Name = textBox2.Text.ToString();
            genreManager.Update(genre);
        }
        private void DeleteGenre()
        {
            genre.Id = Int32.Parse(textBox1.Text);
            genre.Name = textBox2.Text.ToString();
            genreManager.Delete(genre);
        }

        private void GetAllGenres()
        {
            listView1.Items.Clear();
            foreach (var genre in genreManager.GetAll().Data)
            {
                string[] row = { genre.Id.ToString(), genre.Name.ToString() };
                var gnr = new ListViewItem(row);
                listView1.Items.Add(gnr);
            }
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
            AddGenre();
            GetAllGenres();
            Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpdateGenre();
            GetAllGenres();
            Clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeleteGenre();
            GetAllGenres();
            Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectGenre();
        }
    }
}

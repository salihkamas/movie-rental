using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MovieManager movieManager = new MovieManager(new EfMovieDal());
        DirectorManager directorManager = new DirectorManager(new EfDirectorDal());
        GenreManager genreManager = new GenreManager(new EfGenreDal());
        Movie movie = new Movie();

        private void Form1_Load(object sender, EventArgs e)
        {

            textBox1.Enabled = false;
            listView1.View = View.Details;
            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.Columns.Add("ID", 50);
            listView1.Columns.Add("DirectorID", 75);
            listView1.Columns.Add("GenreID", 75);
            listView1.Columns.Add("Director Name", 100);
            listView1.Columns.Add("Genre", 100);
            listView1.Columns.Add("Name", 100);
            listView1.Columns.Add("Title", 100);
            listView1.Columns.Add("Release Year", 100);
            listView1.Columns.Add("Rating", 50);
            listView1.Columns.Add("Movie Length", 100);
            listView1.Columns.Add("Daily Price", 100);
            GetAllMovies();
            GetAllDirectors();
            GetAllGenres();

        }
        private int GenreId()
        {
            return genreManager.GetByName(comboBox2.Text).Data.Id;
        }
        private int DirectorId()
        {
            return directorManager.GetByName(comboBox1.Text).Data.Id;
        }
        private void AddMovie()
        {
            var result = CheckInputs();
            if (result)
            {
                Movie movie = new Movie
                {
                    GenreId = GenreId(),
                    DirectorId = DirectorId(),
                    Name = textBox2.Text.ToString(),
                    Title = textBox3.Text.ToString(),
                    Rating = double.Parse(textBox5.Text.ToString()),
                    ReleaseYear = textBox4.Text.ToString(),
                    MovieLength = Int32.Parse(textBox6.Text.ToString()),
                    dailyPrice = double.Parse(textBox7.Text.ToString()),

                };
                movieManager.Add(movie);
            }


        }

        public void Clear()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            comboBox1.Text = "";
            comboBox2.Text = "";
        }
        private void GetAllDirectors()
        {

            foreach (var director in directorManager.GetAll().Data)
            {
                comboBox1.Items.Add($"{director.FirstName} {director.LastName}");
            }
        }
        private void SelectMovie()
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
                    textBox2.Text = item.SubItems[5].Text.ToString();
                    textBox3.Text = item.SubItems[6].Text.ToString();
                    textBox4.Text = item.SubItems[7].Text.ToString();
                    textBox5.Text = item.SubItems[8].Text.ToString();
                    textBox6.Text = item.SubItems[9].Text.ToString();
                    textBox7.Text = item.SubItems[10].Text.ToString();

                }
            }
        }
        private void DeleteMovie()
        {
            var result = CheckInputs();
            if (result)
            {
                movie.Id = Int32.Parse(listView1.SelectedItems[0].SubItems[0].Text);
                movie.DirectorId = DirectorId();
                movie.GenreId = GenreId();
                movie.Name = listView1.SelectedItems[0].SubItems[5].Text;
                movie.Title = listView1.SelectedItems[0].SubItems[6].Text;
                movie.ReleaseYear = listView1.SelectedItems[0].SubItems[7].Text;
                movie.Rating = double.Parse(listView1.SelectedItems[0].SubItems[8].Text);
                movie.MovieLength = Int32.Parse(listView1.SelectedItems[0].SubItems[9].Text);
                movie.dailyPrice = double.Parse(listView1.SelectedItems[0].SubItems[10].Text);
                movieManager.Delete(movie);
            }

        }
        private void GetAllGenres()
        {

            foreach (var genre in genreManager.GetAll().Data)
            {
                comboBox2.Items.Add($"{genre.Name}");
            }
        }
        private void UpdateMovie()
        {
            var result = CheckInputs();
            if (result)
            {
                movie.Id = Int32.Parse(textBox1.Text.ToString());
                movie.GenreId = GenreId();
                movie.DirectorId = DirectorId();
                movie.Name = textBox2.Text.ToString();
                movie.Title = textBox3.Text.ToString();
                movie.Rating = double.Parse(textBox5.Text.ToString());
                movie.ReleaseYear = textBox4.Text.ToString();
                movie.MovieLength = Int32.Parse(textBox6.Text.ToString());
                movie.dailyPrice = double.Parse(textBox7.Text.ToString());
                movieManager.Update(movie);
            }

        }
        private void GetAllMovies()
        {
            listView1.Items.Clear();


            var result = movieManager.GetMoviesDetails();
            foreach (var movie in result.Data)
            {
                string[] row = { movie.MovieId.ToString(),movie.DirectorId.ToString(),movie.GenreId.ToString(), movie.DirectorName.ToString(), movie.GenreName.ToString(), movie.MovieName, movie.Title,
                    movie.ReleaseYear, movie.Rating.ToString(), movie.MovieLength.ToString(), movie.DailyPrice.ToString() };
                var getMovie = new ListViewItem(row);
                listView1.Items.Add(getMovie);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                AddMovie();
                GetAllMovies();
                Clear();
            }
            else
            {
                MessageBox.Show("ID ERROR!");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {

            DeleteMovie();
            GetAllMovies();
            Clear();
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectMovie();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UpdateMovie();
            GetAllMovies();
            Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            CustomerForm customerForm = new CustomerForm();
            customerForm.Show();
            this.Hide();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool CheckInputs()
        {
            if (comboBox2.Text == "" || comboBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "")
            {
                MessageBox.Show("Error!");
                return false;
            }
            else
            {
                return true;
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DirectorForm directorForm = new DirectorForm();
            directorForm.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GenreForm genreForm = new GenreForm();
            genreForm.Show();
            this.Hide();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            RentalForm rentalForm = new RentalForm();
            rentalForm.Show();
            this.Hide();
        }
    }
}

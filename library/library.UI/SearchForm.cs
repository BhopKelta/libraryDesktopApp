using library.UI.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace library.UI
{
    public partial class SearchForm : Form
    {
        private readonly libraryEntities _database;
        public SearchForm()
        {
            _database = new libraryEntities();
            InitializeComponent();

            List<Genre> genres = _database.Genre.ToList();
            List <AuthorLovesGenres>data = null;

            comboBox1.DataSource = genres;
            comboBox1.DisplayMember = "genrename";
        }

        private void SearchForm_Load(object sender, EventArgs e)
        {
        }
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            Genre genreSelected = _database.Genre.FirstOrDefault(x => x.genrename == comboBox1.Text);
            List<AuthorLovesGenres>data = new List<AuthorLovesGenres>();

            if (genreSelected != null)
            {
                data = _database.AuthorLovesGenres.Where(x => x.Genre.genrename == genreSelected.genrename).ToList();
            }

            comboBox2.DataSource = data;
            comboBox2.DisplayMember = "GetAuthorName";
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            Genre genreSelected = _database.Genre.FirstOrDefault(x => x.genrename == comboBox1.Text);
            Author authorSelected = _database.Author.FirstOrDefault(x => x.authorname == comboBox2.Text);

            if(genreSelected!=null && authorSelected!=null)
            {
                List<Book> data = _database.Book.Include(z =>z.Author).Include(z=>z.Genre).Include(z=>z.Publisher)
                    .Where(x => x.AuthorId == authorSelected.Id && x.GenreId == genreSelected.Id).ToList();
                dataGridView1.DataSource = data;
                this.Close();
            }

        }
    }
}

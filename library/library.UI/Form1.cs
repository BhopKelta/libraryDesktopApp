using System;
using System.Linq;
using System.Windows.Forms;
using library.UI.Model;
using System.Data.Entity;
using System.Data.Common;
using library.UI.EntityModel;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using library.UI.Static;
using Newtonsoft.Json;

namespace library.UI
{
    public partial class Form1 : Form
    {
        private readonly libraryEntities _database;
        public Form1()
        {
            _database = new libraryEntities();
             InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Get list of books and list of genres.
            List<BookList> dataBooks = new List<BookList>();
            List<Genre> genres = _database.Genre.ToList();

            comboBoxGenres.DataSource = genres;
            comboBoxGenres.DisplayMember = "genrename";

            //Placeholder
            textBoxDate.Text = "dd/mm/yyyy format";

            dataBooks = _database.Book.
                Select(x => new BookList
                {
                    Id = x.Id,
                    Author = x.Author.authorname,
                    BookName = x.bookname,
                    Genre = x.Genre.genrename,
                    Publisher = x.Publisher.publishername??"",
                    ReleaseDate = x.releasedate!=null?x.releasedate.ToString():""
                }).ToList();

            if(dataBooks != null)
            {
                bookGridView.DataSource = dataBooks;
            }
        }

        private void buttonAddBook_Click(object sender, EventArgs e)
        {
            if (textBoxDate.Text == "dd/mm/yyyy format")
                textBoxDate.Text = "";

            //Validate required fields..
            if (string.IsNullOrEmpty(textBoxBook.Text) || string.IsNullOrEmpty(textBoxAuthor.Text))
            {
                MessageBox.Show("Please input required fields to add, bookname and Author");
                return;
            }

            DateTime? release = null;
            Publisher publisher = null;

            Author author = new Author
            {
                authorname = textBoxAuthor.Text
            };
            _database.Author.Add(author);

            Genre genre = _database.Genre.FirstOrDefault(x => x.genrename == comboBoxGenres.Text);

            if (textBoxPublisher.Text != "")
            {
                 publisher = new Publisher { publishername = textBoxPublisher.Text };
            }


            //Try to add a new book
            ConvertStringToDate.ConvertDate(textBoxDate.Text, ref release);

            //Add new book
            Book book = new Book();
            book.Author = author;
            book.bookname = textBoxBook.Text;
            book.Genre = genre;
            book.Publisher = publisher;
            book.releasedate = release;
          
            _database.Book.Add(book);
            _database.SaveChanges();

            Form1_Load(sender, e);
            MessageBox.Show("Successfully added a new book to the library");

        }

        private void bookGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //Display values from existing selected row.
            int indexRow = e.RowIndex;
            DataGridViewRow row = bookGridView.Rows[indexRow];

            //Set inputs from selected row (bookname,genre ..)
            textBoxBook.Text = row.Cells["BookName"].Value.ToString();
            comboBoxGenres.Text = row.Cells["Genre"].Value.ToString();
            textBoxAuthor.Text = row.Cells["Author"].Value.ToString();
            textBoxId.Text = row.Cells["Id"].Value.ToString();

            if (row.Cells["Publisher"].Value!=null){
                textBoxPublisher.Text = row.Cells["Publisher"].Value.ToString();
            }

            if (row.Cells["ReleaseDate"].Value!="")
            {
                textBoxDate.Text = row.Cells["ReleaseDate"].Value.ToString();
            }

        }

        private void buttonUpdateBook_Click(object sender, EventArgs e)
        {
            if (textBoxDate.Text == "dd/mm/yyyy format")
                textBoxDate.Text = "";

            if (string.IsNullOrEmpty(textBoxBook.Text) || string.IsNullOrEmpty(textBoxAuthor.Text))
            {
                MessageBox.Show("Please first specify a book to update");
                return;
            }
            DateTime? release = null;
            Publisher publisher = null;


            Author author = new Author
            {
                authorname = textBoxAuthor.Text
            };

            Genre genre = _database.Genre.FirstOrDefault(x => x.genrename == comboBoxGenres.Text);

            if (textBoxPublisher.Text != "")
            {
                publisher = new Publisher { publishername = textBoxPublisher.Text };
            }

            string date = textBoxDate.Text;
            
            ConvertStringToDate.ConvertDate(date,ref release);

            int id = Convert.ToInt32(textBoxId.Text);

            //Book to update.
            Book book = _database.Book.FirstOrDefault(x => x.Id == id);
            if (book != null)
            {
                book.bookname = textBoxBook.Text;
                book.Author = author;
                book.Genre = genre;
                book.Publisher = publisher;
                book.releasedate = release;

                //Reload the data.
                _database.SaveChanges();
                Form1_Load(sender, e);
                MessageBox.Show("Successfully changed a  book in the library");
            }

        }

        private void buttonDeleteBook_Click(object sender, EventArgs e)
        {
            if (textBoxId.Text != "")
            {
                int id = Convert.ToInt32(textBoxId.Text);
                Book book = _database.Book.FirstOrDefault(x => x.Id == id);
                string prompt = Prompt.ShowDialog("Do you want to delete this book press enter", "Enter to delete, x cancel");

                if (prompt != "")
                {

                    if (book != null)
                    {
                        _database.Book.Remove(book);
                        _database.SaveChanges();
                        Form1_Load(sender, e);
                        MessageBox.Show("Successfully deleted a book");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please specify a book to delete");
            }
        }

        private void bookGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //Show another form extra.
            DataGridViewRow row = bookGridView.Rows[e.RowIndex];
            Form2 form2 = new Form2();

            form2.textBoxBook2.Text = row.Cells["BookName"].Value.ToString();
            form2.textBoxAuthor2.Text = row.Cells["Author"].Value.ToString();
            form2.textBoxPublisher2.Text = row.Cells["Publisher"].Value.ToString();
            form2.comboBoxGenre2.Text = row.Cells["Genre"].Value.ToString();
            form2.textBoxDate2.Text = row.Cells["ReleaseDate"].Value.ToString();
            form2.textBoxId2.Text = row.Cells["Id"].Value.ToString();

            form2.ShowDialog();
        }

        //Export books as json.
        private void button1_Click(object sender, EventArgs e)
        {
            var data = _database.Book.ToList();
            string json = JsonConvert.SerializeObject(data, new JsonSerializerSettings()
            {
                PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                Formatting = Formatting.Indented
            });
            MessageBox.Show(json);
        }

        //Import books from json
        private void button2_Click(object sender, EventArgs e)
        {
            string jsonResult = Prompt.ShowDialog("[{\"bookname\":\"Nova\",\"releasedate\":null,\"Author\":{ \"authorname\":\"Novipisac\"},\"Genre\":{\"genrename\":\"Roman\"},\"Publisher\":null},{\"bookname\":\"Nova2\",\"releasedate\":null,\"Author\":{ \"authorname\":\"Novipisac2\"},\"Genre\":{\"genrename\":\"Roman\"},\"Publisher\":null}]", "Convert from json to obj");

            var data = JsonConvert.DeserializeObject<List<Book>>(jsonResult);

            foreach (var item in data)
            {
                Book book = new Book
                {
                    bookname = item.bookname,
                    Publisher = item.Publisher,
                    releasedate = item.releasedate
                };
                book.Genre = _database.Genre.FirstOrDefault(x => x.genrename == item.Genre.genrename) ?? item.Genre;
                book.Author = _database.Author.FirstOrDefault(x => x.authorname == item.Author.authorname) ?? item.Author;

                _database.Book.Add(book);
            }
           
            _database.SaveChanges();

            MessageBox.Show("Successfully imported new books");
            Form1_Load(sender, e);
        }

        //Search books
        private void button3_Click(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm();
            form.ShowDialog();

            //Reload the main books with parameters from search.
            if (form.dataGridView1.DataSource != null)
            {
                List<BookList> dataBooks = new List<BookList>();
                List<Book> books = new List<Book>();

                var json = JsonConvert.SerializeObject(form.dataGridView1.DataSource,new JsonSerializerSettings()
                {
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects,
                    Formatting = Formatting.Indented
                });
                books = JsonConvert.DeserializeObject<List<Book>>(json);

                dataBooks = books.
                Select(x => new BookList
                {
                    Id = x.Id,
                    Author = x.Author.authorname,
                    BookName = x.bookname,
                    Genre = x.Genre.genrename
                    //Publisher = x.Publisher.publishername??"",
                    //ReleaseDate = x.releasedate ?? DateTime.Now
                }).ToList();
                bookGridView.DataSource = dataBooks;
            }
        }
    }
}

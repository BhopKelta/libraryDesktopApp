using library.UI.Model;
using library.UI.Static;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace library.UI
{
    public partial class Form2 : Form
    {
        private readonly libraryEntities _database;

        public Form2()
        {
            _database = new libraryEntities();
            InitializeComponent();
            List<Genre> genres = _database.Genre.ToList();

            comboBoxGenre2.DataSource = genres;
            comboBoxGenre2.DisplayMember = "genrename";
        }

        private void buttonUpdate2_Click(object sender, EventArgs e)
        {
            DateTime? release = null;

            int id = Convert.ToInt32(textBoxId2.Text);
            Publisher publisher = null;

            Book book = _database.Book.FirstOrDefault(x => x.Id == id);
            book.bookname = textBoxBook2.Text;
            book.Genre.genrename = comboBoxGenre2.Text;

            if (textBoxPublisher2.Text != "")
            {
                publisher = new Publisher
                {
                    publishername = textBoxPublisher2.Text
                };
            }
             
            book.Publisher = publisher;
            ConvertStringToDate.ConvertDate(textBoxDate2.Text,ref release);
            book.releasedate = release;
            _database.SaveChanges();
            this.Close();
        }

    }
}

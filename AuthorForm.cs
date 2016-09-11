using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReferenceGenerator
{
    public partial class AuthorForm : Form
    {
        private Author author;
        private Work w;
        public AuthorForm(Work w)
        {
            this.w = w;
            InitializeComponent();
        }
        public AuthorForm(Author a, Work w)
        {
            this.w = w;
            author = a;
            InitializeComponent();
            textBox1.Text = author.name;
            textBox2.Text = author.surname;
            textBox3.Text = author.middleName;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (author == null)
            {
                author = new Author();
                w.authors.Add(author);
            }
            author.name = textBox1.Text;
            author.surname = textBox2.Text;
            author.middleName = textBox3.Text;
            Connection.getInstance().workPreview.refreshAuthors();
            Close();
        }
    }
}

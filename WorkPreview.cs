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
    public partial class WorkPreview : Form
    {

        private Work work;
        public WorkPreview()
        {
            InitializeComponent();
            Connection.getInstance().workPreview = this;
            work = new Work();
            myType = TYPE.BOOK;
            book.Checked = true;
            bookChecked();

        }
        public WorkPreview(Work w)
        {
            Connection.getInstance().workPreview = this;
            InitializeComponent();
            work = w;
            name.Text = work.name;
            publisher.Text=work.publisher;
            release.Text=work.release;
            location.Text=work.location;
            vol.Text = Convert.ToString(work.vol);
            no.Text = Convert.ToString(work.no);
            pp1.Text=work.pp1;
            pp2.Text=work.pp2;
           if(work.type.Equals("BOOK"))
           {
               myType=TYPE.BOOK;
               book.Checked=true;
               bookChecked();
           }
           else
               if (work.type.Equals("SITE"))
               {
                   myType = TYPE.SITE;
                   site.Checked = true;
                   siteChecked();
               }
               else
                   if (work.type.Equals("JOURNAL"))
                   {
                       myType = TYPE.JOURNAL;
                       journal.Checked = true;
                       journalChecked();
                   }
            url.Text=work.url;
            foreach (Author a in w.authors)
            {
                dataGridView2.Rows.Add(a.name+" "+ a.middleName+" "+a.surname);
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Tag = a;
            }
        }

        public void refreshAuthors()
        {
            dataGridView2.Rows.Clear();
            foreach (Author a in work.authors)
            {
                dataGridView2.Rows.Add(a.name + " " + a.middleName + " " + a.surname);
                dataGridView2.Rows[dataGridView2.Rows.Count - 1].Tag = a;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
        enum TYPE { BOOK, SITE, JOURNAL };
        TYPE myType;
        private void ok_Click(object sender, EventArgs e)
        {
            if (work == null)
            {
                work = new Work();
            }
            work.name = name.Text;
            work.publisher = publisher.Text;
            work.release = release.Text;
            work.location = location.Text;
            work.vol = Convert.ToInt32(vol.Text);
            work.no = Convert.ToInt32(no.Text);
            work.pp1 = pp1.Text;
            work.pp2 = pp2.Text;
            switch (myType)
            {
                case TYPE.BOOK:
                    work.type = "BOOK";
                    break;
                case TYPE.SITE:
                    work.type = "SITE";
                    break;
                case TYPE.JOURNAL:
                    work.type = "JOURNAL";
                    break;
            }
            work.url = url.Text;
            Connection.getInstance().addOrEditWork(work);
            Connection.getInstance().refreshForm1();
            Close();
        }

        private void book_CheckedChanged(object sender, EventArgs e)
        {
            if (book.Checked)
            {
                myType = TYPE.BOOK;
                bookChecked();
            }
        }
        private void bookChecked()
        {
            url.Visible = false;
            vol.Visible = false;
            no.Visible = false;
            pp1.Visible = false;
            pp2.Visible = false;
            label7.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
        }
        private void journal_CheckedChanged(object sender, EventArgs e)
        {
            if (journal.Checked)
            {
                myType = TYPE.JOURNAL;
                journalChecked();
            }
        }
        private void journalChecked()
        {
            url.Visible = false;
            label7.Visible = false;

            vol.Visible = true;
            no.Visible = true;
            pp1.Visible = true;
            pp2.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label8.Visible = true;
            label9.Visible = true;
        }
        private void site_CheckedChanged(object sender, EventArgs e)
        {
            if (site.Checked)
            {
                myType = TYPE.SITE;
                siteChecked();
            }
        }
        private void siteChecked()
        {
            vol.Visible = false;
            no.Visible = false;
            pp1.Visible = false;
            pp2.Visible = false;
            label5.Visible = false;
            label6.Visible = false;
            label8.Visible = false;
            label9.Visible = false;

            url.Visible = true;
            label7.Visible = true;
        }

        private void authorAdd_Click(object sender, EventArgs e)
        {
            AuthorForm af = new AuthorForm(work);
            af.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Selected)
                {
                    AuthorForm af = new AuthorForm((Author)dataGridView2.Rows[i].Tag,work);
                    af.Show();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count; i++)
            {
                if (dataGridView2.Rows[i].Selected)
                {
                    Author a=(Author)dataGridView2.Rows[i].Tag;
                    Connection.getInstance().deleteAuthor(a);
                    work.authors.Remove(a);
                    refreshAuthors();

                }
            }
        }
    }
}

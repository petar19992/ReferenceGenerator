using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SQLite;

namespace ReferenceGenerator 
{
    public partial class Form1 : Form,Connection.IConnectionListener
    {
        public Form1()
        {
            InitializeComponent();
            Connection.getInstance().setListener(this);
            Connection.getInstance().openConnection();
            Connection.getInstance().form1 = this;
            getAllWorks();
            radioButton1.Checked = true;
        }

        public void getAllWorks()
        {
            dataGridView1.Rows.Clear();
            SQLiteCommand command = new SQLiteCommand("select * from WORK;",Connection.getInstance().getConn());

            SQLiteDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[1],dr[2],dr[3],dr[4],dr[5],dr[6],dr[7]+"-"+dr[8],dr[9],dr[10]);
                Work w = new Work(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(),Convert.ToInt32(dr[5]), Convert.ToInt32(dr[6]), dr[7].ToString(), dr[8].ToString(), dr[9].ToString(), dr[10].ToString());
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = w;
                getAuthors(w);
            }
            dr.Close();
        }

        public void connectionOpen()
        {
           
        }

        public void connectionClosed()
        {
            
        }

        public void connectionOpenError()
        {
            MessageBox.Show(Connection.errorOpenMessage);
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            WorkPreview wp = new WorkPreview();
            wp.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    WorkPreview wp = new WorkPreview((Work)dataGridView1.Rows[i].Tag);
                    wp.Show();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    Connection.getInstance().delete((Work)dataGridView1.Rows[i].Tag);
                }
            }
            dataGridView2.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        public void getAuthors(Work w)
        {
            w.authors.Clear();
            SQLiteCommand command = new SQLiteCommand("select * from AUTHOR where WORK_ID="+w.ID+";",Connection.getInstance().getConn());
            SQLiteDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                Author a = new Author(Convert.ToInt32(dr[0]),dr[1].ToString(),dr[2].ToString(),dr[3].ToString(),w.ID);
                w.authors.Add(a);

            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            int index = e.RowIndex;
            dataGridView1.Rows[index].Selected = true;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    Work w=(Work)dataGridView1.Rows[i].Tag;
                    dataGridView2.Rows.Clear();
                    
                    foreach(Author a in w.authors)
                    {
                        dataGridView2.Rows.Add(a.name + " " + a.middleName + " " + a.surname);
                    }
                }
            }
        }
        enum STANDART { IEEE, APA, CHICAGO }
        STANDART standard=STANDART.IEEE;

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                standard = STANDART.IEEE;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                standard = STANDART.APA;
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                standard = STANDART.CHICAGO;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (standard)
            {
                case  STANDART.IEEE:
                    generateIEEE();
                    break;
                case STANDART.APA:
                    generateAPA();
                    break;
                case STANDART.CHICAGO:
                    generateChicago();
                    break;
            }
        }

        private void generateAPA()
        {
            output.Text = "";
            int counter = 1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    output.Text += " [" + (counter++) + "]    ";
                    Work w = (Work)dataGridView1.Rows[i].Tag;
                    if (w.type.Equals("BOOK"))
                    {
                        showAuthors(w);
                        output.Text += " (";
                        showRelease(w);
                        output.Text += ")";
                        output.Text += ".";
                        showBookName(w);
                        output.Text += ",";
                        showPublisher(w);
                        output.Text += ",";
                        showLocation(w);
                        output.Text += ".";
                    }
                    else
                        if (w.type.Equals("SITE"))
                        {
                            showAuthors(w);
                            output.Text += "("; showRelease(w); output.Text += ")    ";
                            output.Text += "The ";
                            showBookName(w);
                            output.Text += " Online. ";
                            showUlr(w);
                            output.Text += ".";
                        }
                        else if (w.type.Equals("JOURNAL"))
                        {
                            showAuthors(w);
                            output.Text += "(";
                            showRelease(w);
                            output.Text += ")";
                            output.Text += ".";
                            showBookName(w);
                            output.Text += ",";
                            showPublisher(w);
                            output.Text += ",";
                            showVol(w);
                            showNo(w);
                            showPP(w);
                            output.Text += ".";
                        }
                    output.Text += "";
                    output.Text += "\n\t";
                }
            }
        }

        private void generateChicago()
        {
            output.Text = "";
            int counter = 1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    output.Text += " [" + (counter++) + "]    ";
                    Work w = (Work)dataGridView1.Rows[i].Tag;
                    if (w.type.Equals("BOOK"))
                    {
                        showAuthorsChicago(w);
                        output.Text += ",";
                        showBookName(w);
                        output.Text += ",";
                        showPublisher(w);
                        output.Text += ",";
                        showLocation(w);
                        output.Text += ",";
                        showRelease(w);
                        output.Text += ".";
                    }
                    else
                        if (w.type.Equals("SITE"))
                        {
                            showAuthorsChicago(w);
                            output.Text += " ("; showRelease(w); output.Text += ")    ";
                            output.Text += "The ";
                            showBookName(w);
                            output.Text += " website.[Online]. Available: ";
                            showUlr(w);
                        }
                        else if (w.type.Equals("JOURNAL"))
                        {
                            showAuthorsChicago(w);
                            showBookName(w);
                            output.Text += ",";
                            showPublisher(w);
                            output.Text += ",";
                            showVolChicago(w);
                            showNoChicago(w);
                            showPPChicago(w);
                            showRelease(w);
                            output.Text += ".";
                        }
                    output.Text += "";
                    output.Text += "\n\t";
                }
            }
        }
        private void generateIEEE()
        {
            output.Text = "";
            int counter = 1;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    output.Text += "[" + (counter++) + "]    ";
                    Work w = (Work)dataGridView1.Rows[i].Tag;
                    if (w.type.Equals("BOOK"))
                    {
                        showAuthors(w);
                        showBookName(w);
                        output.Text += ",";
                        showPublisher(w);
                        output.Text += ",";
                        showLocation(w);
                        output.Text += ",";
                        showRelease(w);
                        output.Text += ".";
                    }
                    else
                        if (w.type.Equals("SITE"))
                    {
                        showAuthors(w);
                        output.Text += "("; showRelease(w); output.Text += ")    ";
                        output.Text += "The ";
                        showBookName(w);
                        output.Text += " website.[Online]. Available: ";
                        showUlr(w);
                    }
                        else if (w.type.Equals("JOURNAL"))
                        {
                            showAuthors(w);
                            showBookName(w);
                            output.Text += ",";
                            showPublisher(w);
                            output.Text += ",";
                            showVol(w);
                            showNo(w);
                            showPP(w);
                            showRelease(w);
                            output.Text += ".";
                        }
                    output.Text += "";
                    output.Text += "\n\t";
                }
            }
        }


        private void showAuthors(Work w)
        {
            for (int j = 0; j < w.authors.Count; j++)
            {
                Author a = w.authors[j];
                if (j == w.authors.Count - 1&& j!=0)
                    output.Text += " and ";
                else if(j!=0)
                    output.Text += ", ";
                if (!a.name.Equals(""))
                {
                    output.Text += " " + a.name;
                }
                if (!a.middleName.Equals(""))
                {
                    output.Text += " " + a.middleName ;
                }
                if (!a.surname.Equals(""))
                {
                    output.Text += " " + a.surname;
                }
                
            }
        }
        private void showAuthorsChicago(Work w)
        {
            for (int j = 0; j < w.authors.Count; j++)
            {
                Author a = w.authors[j];
                if (j == w.authors.Count - 1 && j != 0)
                    output.Text += " and ";
                else if (j != 0)
                    output.Text += ", ";
                if (!a.surname.Equals(""))
                {
                    output.Text += " " + a.surname+", ";
                }
                if (!a.middleName.Equals(""))
                {
                    output.Text += " " + a.middleName.Substring(0,1)+".";
                }
                if (!a.name.Equals(""))
                {
                    output.Text += " " + a.name.Substring(0, 1) + ".";
                }
            }
        }

        private void showBookName(Work w)
        {
            output.Text += " " + w.name;
        }
        private void showPublisher(Work w)
        {
            output.Text += " " + w.publisher;
        }
        private void showLocation(Work w)
        {
            output.Text += " " + w.location;
        }

        private void showRelease(Work w)
        {
            output.Text += " " + w.release;
        }
        private void showVol(Work w)
        {
            if (w.vol != 0)
            {
                output.Text += "Vol. " + w.vol+ ",";
            }
        }
        private void showVolChicago(Work w)
        {
            if (w.vol != 0)
            {
                output.Text += "Volume " + w.vol + ",";
            }
        }
        private void showNo(Work w)
        {
            if (w.no != 0)
            {
                output.Text += "No. " + w.no + ",";
            }
        }
        private void showNoChicago(Work w)
        {
            if (w.no != 0)
            {
                output.Text += "Number " + w.no + ",";
            }
        }
        private void showPP(Work w)
        {
            if (!w.pp1.Equals(""))
            {
                output.Text += "pp. " + w.pp1 ;
                if (!w.pp2.Equals(""))
                {
                    output.Text += "- " + w.pp2+",";
                }
            }
        }
        private void showPPChicago(Work w)
        {
            if (!w.pp1.Equals(""))
            {
                output.Text += "pg. " + w.pp1;
                if (!w.pp2.Equals(""))
                {
                    output.Text += "- " + w.pp2 + ",";
                }
            }
        }
        private void showUlr(Work w)
        {
            if (!w.url.Equals(""))
            {
                output.Text +=" "+ w.url;
            }
        }
    }
}

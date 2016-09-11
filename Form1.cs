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
                    break;
                case STANDART.APA:
                    break;
                case STANDART.CHICAGO:
                    break;
            }
        }

        private void generateIEEE()
        {
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    Work w = (Work)dataGridView1.Rows[i].Tag;
                    for (int j = 0; j < w.authors.Count; j++)
                    {
                        Author a = w.authors[j];
                        if (j == w.authors.Count - 1)
                            output.Text += " and ";
                        output.Text += a.name+" "+a.middleName+" "+a.surname+" ,";
                    }
                    output.Text += "";
                }
            }
        }

    }
}

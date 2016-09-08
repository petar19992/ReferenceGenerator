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
            getAllWorks();
        }

        private void getAllWorks()
        {
            SQLiteCommand command = new SQLiteCommand("select * from WORK;",Connection.getInstance().getConn());

            SQLiteDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[1],dr[2],dr[3],dr[4],dr[5],dr[6],dr[7]+"-"+dr[8],dr[9],dr[10]);
                Work w = new Work(Convert.ToInt32(dr[0]), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), Convert.ToInt32(dr[4]), Convert.ToInt32(dr[5]), dr[6].ToString(), dr[7].ToString(), dr[8].ToString(), dr[9].ToString());
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Tag = w;
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
    }
}

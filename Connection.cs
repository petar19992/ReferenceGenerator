using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace ReferenceGenerator
{
    class Connection
    {
        public Form1 form1;
        public WorkPreview workPreview;
        public void refreshForm1()
        {
            if (form1 != null)
            {
                form1.getAllWorks();
            }
        }
        private SQLiteConnection sqlite;
        public SQLiteConnection getConn()
        {
            return sqlite;
        }

        private Connection()
        {
            sqlite = new SQLiteConnection("Data Source=reference.db");

            ////SQLiteCommand comm = new SQLiteCommand("select * from WORK;", sqlite);
            ////SQLiteDataReader dr= comm.ExecuteReader();
            ////while (dr.Read())
            ////{
            ////    Console.WriteLine(dr[0]);
            ////}
        }

        public void delete(Work w)
        {
            if (w != null)
            {
                SQLiteCommand comand;
                comand = new SQLiteCommand("DELETE from WORK WHERE WORK_ID=" + w.ID + ";", sqlite);
                comand.ExecuteNonQuery();
                foreach (Author a in w.authors)
                {
                    deleteAuthor(a);
                }
                refreshForm1();
            }
        }
        public void addOrEditWork(Work w)
        {

            SQLiteCommand comand;
            if (w.ID != 0)
            {
                comand = new SQLiteCommand("update WORK set NAME='" + w.name + "',PUBLISHER='" + w.publisher + "',LOCATION='" + w.location + "',RELEASE='" + w.release + "',VOL=" + w.vol + ",NO=" + w.no + ",PP1='" + w.pp1 + "',PP2='" + w.pp2 + "',TYPE='" + w.type + "',URL='" + w.url + "' WHERE WORK_ID=" + w.ID + ";", sqlite);
                comand.ExecuteNonQuery();

            }
            else
            {
                comand = new SQLiteCommand("INSERT INTO WORK (NAME, PUBLISHER, LOCATION, RELEASE, VOL, NO, PP1, PP2,TYPE, URL)" +
            "VALUES ('" + w.name + "','" + w.publisher + "','" + w.location + "','" + w.release + "'," + w.vol + "," + w.no + ",'" + w.pp1 + "','" + w.pp2 + "','" + w.type + "','" + w.url + "')", sqlite);
                comand.ExecuteNonQuery();

                comand = new SQLiteCommand(@"select last_insert_rowid()",sqlite);
                int lastId = Convert.ToInt32(comand.ExecuteScalar());
                w.ID = lastId;
            }
            
            foreach (Author a in w.authors)
            {
                a.WORK_ID = w.ID;
                addOrEditAuthor(a);
            }
            refreshForm1();
        }
        public void addOrEditAuthor(Author a)
        {

            SQLiteCommand comand;
            if (a.AUTHOR_ID != 0)
                comand = new SQLiteCommand("update AUTHOR set NAME='" + a.name + "',SURNAME='" + a.surname + "',MIDDLE_NAME='" + a.middleName + "' WHERE AUTHOR_ID=" + a.AUTHOR_ID + ";", sqlite);
            else
                comand = new SQLiteCommand("INSERT INTO AUTHOR (NAME, SURNAME, MIDDLE_NAME, WORK_ID)" +
            "VALUES ('" + a.name + "','" + a.surname + "','" + a.middleName + "'," + a.WORK_ID + ")", sqlite);

            comand.ExecuteNonQuery();
        }
        public void deleteAuthor(Author a)
        {
            SQLiteCommand comand;
            comand = new SQLiteCommand("DELETE FROM AUTHOR WHERE AUTHOR_ID=" + a.AUTHOR_ID + ";", sqlite);
            comand.ExecuteNonQuery();
        }
        public void openConnection()
        {
            try
            {
                sqlite.Open();
                if (listener != null)
                {
                    listener.connectionOpen();
                }
            }
            catch
            {
                if (listener != null)
                {
                    listener.connectionOpenError();
                }
            }
        }

        private static Connection myInstance;
        public static Connection getInstance()
        {
            if (myInstance == null)
            {
                myInstance = new Connection();
            }
            return myInstance;
        }

        IConnectionListener listener;
        public void setListener(IConnectionListener l)
        {
            this.listener = l;
        }
        public interface IConnectionListener
        {
            void connectionOpen();
            void connectionClosed();
            void connectionOpenError();
        }



        //Konstante

        public static String errorOpenMessage = "Error while opening the connection";
    }
}

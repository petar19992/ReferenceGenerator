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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace DBapplication
{
    public class DBConnection
    {

        private DBConnection() { }
        private string databaseName = "Advance Project";
        public string DatabaseName
        {
            get { return databaseName; }
            set { databaseName = value; }
        }
        public string Password { get; set; }
        private MySqlConnection Connection = null;
        private static DBConnection _instance = null;
        public static DBConnection Instance()
        {
            if (_instance == null)
                _instance = new DBConnection();
            return _instance;

        }

        public bool IsConnect()
        {
            bool result = true;
            if (Connection == null)
            {
                if (databaseName == string.Empty)
                    result = false;
                //string StrCon = "SERVER=z12itfj4c1vgopf8.cbetxkdyhwsb.us-east-1.rds.amazonaws.com;DATABASE=e8c4k59ix7x15kmt;UID=tnamvbua4tev69kk;PASSWORD=o3dynp856x3f9ten";
                string StrCon = "Database=Advance Project;Data Source=eu-cdbr-azure-west-c.cloudapp.net;User Id=b05c485a20f5f8;Password=fc3fd947";
                Connection = new MySqlConnection(StrCon);
                Connection.Open();
                result = true;
            }

            return result;
        }

        public MySqlConnection GetConnection()
        {
            return Connection;
        }



        public void Close()
        {
            Connection.Close();
        }
    }
}

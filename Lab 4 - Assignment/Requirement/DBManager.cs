using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Requirement
{
    class DBManager
    {
        //SQL Connection object
        SqlConnection sqlConnection;
        /// <summary>
        /// Constructor to initialize and open the sql connection
        /// using the sql connection string given in the txt file
        /// </summary>
        public DBManager()
        {
            //Database connection string
            string dbConnectionString;
            dbConnectionString = Utility.ReadFromFile("dbConnectionString.txt");
            try
            {
                //Initialize the connection with the given string
                sqlConnection = new SqlConnection(dbConnectionString);
                //Open the sql connection
                sqlConnection.Open();
                //Log sql connection succeeded
                Console.WriteLine("SQL connection succeeded in opening");
            }
            catch (Exception e)
            {
                //Log sql connection failed
                Console.WriteLine("SQL connection failed in opening");
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// Executes a sql query
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns>number of rows affected</returns>
        public int ExecuteNonQuery(string sqlQuery)
        {
            try
            {
                int result;
                //Create and execute command
                SqlCommand sqlCMD = new SqlCommand(sqlQuery, sqlConnection);
                result = sqlCMD.ExecuteNonQuery();
                //Log query succeeded
                Console.WriteLine("SQL query succeeded");
                return result;
            }
            catch (Exception e)
            {
                //Log query failed
                Console.WriteLine("SQL query failed");
                Console.WriteLine(e.ToString());
                return 0;
            }
        }
        /// <summary>
        /// Executes a sql query
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns>datatable containing the rows returned from sql server</returns>
        public DataTable ExecuteReader(string sqlQuery)
        {
            try
            {
                //Create and execute command and extract datatable
                SqlCommand sqlCMD = new SqlCommand(sqlQuery, sqlConnection);
                SqlDataReader sqlDR = sqlCMD.ExecuteReader();
                if (sqlDR.HasRows)
                {
                    DataTable dt = new DataTable();
                    dt.Load(sqlDR);
                    sqlDR.Close();
                    //Log query succeeded
                    Console.WriteLine("SQL query succeeded");
                    return dt;
                }
                else
                {
                    sqlDR.Close();
                    //Log query succeeded but no rows returned
                    Console.WriteLine("SQL query succeeded but no rows returned");
                    return default(DataTable);
                }
            }
            catch (Exception e)
            {
                //Log query failed
                Console.WriteLine("SQL query failed");
                Console.WriteLine(e.ToString());
                return default(DataTable);
            }
        }
        /// <summary>
        /// Executes a sql query
        /// </summary>
        /// <param name="sqlQuery"></param>
        /// <returns>return value returned from sql server</returns>
        public int ExecuteScalar(string sqlQuery)
        {
            try
            {
                int result;
                //Create and execute command and return value returned from sql server
                SqlCommand sqlCMD = new SqlCommand(sqlQuery, sqlConnection);
                result = (int)sqlCMD.ExecuteScalar();
                //Log query succeeded
                Console.WriteLine("SQL query succeeded");
                return result;
            }
            catch (Exception e)
            {
                //Log query failed
                Console.WriteLine("SQL query failed");
                Console.WriteLine(e.ToString());
                return 0;
            }
        }
        /// <summary>
        /// Close the sql connection
        /// </summary>
        public void CloseConnection()
        {
            try
            {
                sqlConnection.Close();
                //Log query succeeded
                Console.WriteLine("SQL connection succeeded in closing");
            }
            catch (Exception e)
            {
                Console.WriteLine("SQL connection failed in closing");
                Console.WriteLine(e.ToString());
            }
        }
    }
}

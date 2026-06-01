using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace App_Gestion_lots_M3.Model
{
    public class FileName
    {
        static private MySqlConnection _connection;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="databaseName"></param>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="host"></param>
        /// <param name="port"></param>
        public static void ConnectToDB(string databaseName, string userName, string password, string host = "localhost", int port = 3306)
        {
            string connectionString =
                $"server={host};database={databaseName};user={userName};password={password};port={port}";

            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        /// <summary>
        /// 
        /// </summary>
        public static void CloseDBConnection()
        {
            if (_connection != null)
                _connection.Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static MySqlConnection GetDBConnection()
        {
            return _connection;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool IsConnected()
        {
            return _connection != null && _connection.State == System.Data.ConnectionState.Open;
        }



    }
}

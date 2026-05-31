using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace App_Gestion_lots_M3.AccesDonnees
{
    internal class DbManager
    {
        static private MySqlConnection _connection;

        public static void ConnectToDB(string databaseName, string userName, string password, string host = "localhost", int port = 3306)
        {
            string connectionString =
                $"server={host};database={databaseName};user={userName};password={password};port={port}";

            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        public static void CloseDBConnection()
        {
            if (_connection != null)
                _connection.Close();
        }

        public static MySqlConnection GetDBConnection()
        {
            return _connection;
        }

        public static bool IsConnected()
        {
            return _connection != null && _connection.State == System.Data.ConnectionState.Open;
        }


    }
}

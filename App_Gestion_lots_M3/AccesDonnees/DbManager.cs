using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace App_Gestion_lots_M3.AccesDonnees
{
    internal class DbManager
    {
        static private MySqlConnection _connection;

        /// <summary>
        /// Crée la connexion à la base de données MySQL en utilisant les paramètres fournis et ouvre la connexion
        /// </summary>
        /// <param name="databaseName"> nom de la db </param>
        /// <param name="userName"> username </param>
        /// <param name="password"> mdp </param>
        /// <param name="host"> server sur lequel il tourne </param>
        /// <param name="port"> port ouvert </param>
        public static void ConnectToDB(string databaseName, string userName, string password, string host = "localhost", int port = 3306)
        {
            string connectionString =
                $"server={host};database={databaseName};user={userName};password={password};port={port}";

            _connection = new MySqlConnection(connectionString);
            _connection.Open();
        }

        /// <summary>
        /// Ferme la connexion à la base de données si elle est ouverte
        /// </summary>
        public static void CloseDBConnection()
        {
            if (_connection != null)
                _connection.Close();
        }

        /// <summary>
        /// connection à la base de données, si elle n'est pas déjà établie, sinon retourne la connexion existante
        /// </summary>
        /// <returns> Objet MySqlConnection représentant la connexion active à la base de données </returns>
        public static MySqlConnection GetDBConnection()
        {
            return _connection;
        }

        /// <summary>
        /// Vérifie si la connexion à la base de données est établie et ouverte
        /// </summary>
        /// <returns> true si la connexion existe et est ouverte ; sinon false </returns>
        public static bool IsConnected()
        {
            return _connection != null && _connection.State == System.Data.ConnectionState.Open;
        }


    }
}

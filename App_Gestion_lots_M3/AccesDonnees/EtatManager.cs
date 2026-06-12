using App_Gestion_lots_M3.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Gestion_lots_M3.AccesDonnees
{
    internal class EtatManager
    {
        /// <summary>
        /// Retourne la liste de tous les états disponibles.
        /// </summary>
        /// <returns></returns>
        public static List<Etat> GetEtats()
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            List<Etat> etats = new List<Etat>();

            string sql = "SELECT Id_Etat, ETA_Libelle FROM Etat";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    etats.Add(new Etat
                    {
                        idEtat = reader.GetInt32("Id_Etat"),
                        libEtat = reader.GetString("ETA_Libelle")
                    });
                }
            }

            return etats;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="libelleEtat"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int GetIdEtat(string libelleEtat)
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            string sql = "SELECT Id_Etat FROM Etat WHERE ETA_Libelle = @libelle LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@libelle", libelleEtat);
                object result = cmd.ExecuteScalar();
                if (result == null)
                    throw new Exception("État introuvable : " + libelleEtat);
                return Convert.ToInt32(result);
            }
        }
    }
}

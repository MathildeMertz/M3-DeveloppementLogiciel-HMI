using App_Gestion_lots_M3.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Gestion_lots_M3.AccesDonnees
{
    internal class EvenementManager
    {
        /// <summary>
        /// Retourne uniquement les événements de début, fin et erreurs pour un lot donné
        /// </summary>
        /// <param name="idLot">Identifiant du lot</param>
        /// <returns>Liste des événements filtrés</returns>
        public static List<Evenement> GetEvenements(int idLot)
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            List<Evenement> evenements = new List<Evenement>();

            // Filtre uniquement début, fin et erreurs/alarmes
            string sql = @"SELECT Id_Evenement, EVE_DateHeure, EVE_Message, Id_Lot
               FROM Evenement
               WHERE Id_Lot = @idLot
               AND (
                    EVE_Message LIKE '%début de la production du lot%'
                    OR EVE_Message LIKE '%fin de la production du lot%'
                    OR EVE_Message LIKE '%erreur%'
                    OR EVE_Message LIKE '%alarme%'
                    OR EVE_Message LIKE '%barrière%'
                    OR EVE_Message LIKE '%supprimé%'
                    OR EVE_Message LIKE '%Création%'
                )
               ORDER BY EVE_DateHeure DESC";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idLot", idLot);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Evenement eve = new Evenement();

                        eve.idEve = reader.GetInt32("Id_Evenement");

                        if (reader.IsDBNull(reader.GetOrdinal("EVE_DateHeure")))
                            eve.dateHeureEve = DateTime.MinValue;
                        else
                            eve.dateHeureEve = reader.GetDateTime("EVE_DateHeure");

                        if (reader.IsDBNull(reader.GetOrdinal("EVE_Message")))
                            eve.messageEve = "";
                        else
                            eve.messageEve = reader.GetString("EVE_Message");

                        if (reader.IsDBNull(reader.GetOrdinal("Id_Lot")))
                            eve.idLot = 0;
                        else
                            eve.idLot = reader.GetInt32("Id_Lot");

                        try
                        {
                            evenements.Add(eve);

                        }
                        catch (Exception erreurLectureEven)
                        {
                            Console.WriteLine("Erreur lors de la lecture d’un événement : " + erreurLectureEven.Message);
                        }


                    }
                }
            }

            return evenements;
        }
        /// <summary>
        /// Ajoute un événement de traçabilité pour un lot
        /// </summary>
        /// <param name="idLot">Identifiant du lot</param>
        /// <param name="message">Message de l'événement</param>
        public static void AjouterEvenement(int idLot, string message)
        {
            MySqlConnection conn = DbManager.GetDBConnection();

            string sql = @"INSERT INTO Evenement (EVE_DateHeure, EVE_Message, Id_Lot)
                   VALUES (@dateHeure, @message, @idLot)";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@dateHeure", DateTime.Now);
                cmd.Parameters.AddWithValue("@message", message);
                cmd.Parameters.AddWithValue("@idLot", idLot);
                cmd.ExecuteNonQuery();
            }
        }
        /// <summary>
        /// Retourne la date de début de production d'un lot
        /// null si aucun événement de début trouvé
        /// </summary>
        /// <param name="idLot">Identifiant du lot</param>
        /// <returns>Date de début ou null</returns>
        public static DateTime? GetDateDebut(int idLot)
        {
            MySqlConnection conn = DbManager.GetDBConnection();

            string sql = @"SELECT EVE_DateHeure FROM Evenement
                   WHERE Id_Lot = @idLot
                   AND EVE_Message LIKE '%début de la production du lot%'
                   ORDER BY EVE_DateHeure ASC
                   LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idLot", idLot);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return null;
                return Convert.ToDateTime(result);
            }
        }

        /// <summary>
        /// Retourne la date de fin de production d'un lot
        /// null si aucun événement de fin trouvé
        /// </summary>
        /// <param name="idLot">Identifiant du lot</param>
        /// <returns>Date de fin ou null</returns>
        public static DateTime? GetDateFin(int idLot)
        {
            MySqlConnection conn = DbManager.GetDBConnection();

            string sql = @"SELECT EVE_DateHeure FROM Evenement
                   WHERE Id_Lot = @idLot
                   AND EVE_Message LIKE '%fin de la production du lot%'
                   ORDER BY EVE_DateHeure DESC
                   LIMIT 1";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idLot", idLot);
                object result = cmd.ExecuteScalar();
                if (result == null || result == DBNull.Value)
                    return null;
                return Convert.ToDateTime(result);
            }
        }
    }
}

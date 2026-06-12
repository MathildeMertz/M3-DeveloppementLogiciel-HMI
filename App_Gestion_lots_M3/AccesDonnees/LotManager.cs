using App_Gestion_lots_M3.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Gestion_lots_M3.AccesDonnees
{
    internal class LotManager
    {
        /// <summary>
        /// Retourne la liste de tous les lots avec leur état et recette associés.
        /// </summary>
        /// <returns> la liste des lots </returns>
        public static List<Lot> GetLots()
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            List<Lot> lots = new List<Lot>();

            string sql = @"SELECT l.Id_Lot, l.LOT_Nom, l.LOT_Quantite, l.LOT_DateHeureCreation,
                                  l.Id_Etat, e.ETA_Libelle, l.Id_Recette, r.REC_Nom
                           FROM Lot l
                           JOIN Etat e ON l.Id_Etat = e.Id_Etat
                           JOIN Recette r ON l.Id_Recette = r.Id_Recette";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    lots.Add(new Lot
                    {
                        idLot = reader.GetInt32("Id_Lot"),
                        LOT_Nom = reader.GetString("LOT_Nom"),
                        LOT_Quantite = reader.GetInt32("LOT_Quantite"),
                        LOT_DateHeureCreation = reader.GetDateTime("LOT_DateHeureCreation"),
                        Id_Etat = reader.GetInt32("Id_Etat"),
                        ETA_Libelle = reader.GetString("ETA_Libelle"),
                        Id_Recette = reader.GetInt32("Id_Recette"),
                        REC_Nom = reader.GetString("REC_Nom")
                    });
                }
            }

            return lots;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomLot"></param>
        /// <param name="quantite"></param>
        /// <param name="idEtat"></param>
        /// <param name="idRecette"></param>
        public static void ModifierLot(string nomLot, int quantite, int idEtat, int idRecette)
        {
            MySqlConnection conn = DbManager.GetDBConnection();

            string sql = @"UPDATE Lot 
                   SET LOT_Quantite = @quantite, Id_Etat = @idEtat, Id_Recette = @idRecette
                   WHERE LOT_Nom = @nom";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@nom", nomLot);
                cmd.Parameters.AddWithValue("@quantite", quantite);
                cmd.Parameters.AddWithValue("@idEtat", idEtat);
                cmd.Parameters.AddWithValue("@idRecette", idRecette);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erreur lors de la modification du lot : " + ex.Message);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nomLot"></param>
        public static void SupprimerLot(string nomLot)
        {
            MySqlConnection conn = DbManager.GetDBConnection();

            string sql = "DELETE FROM Lot WHERE LOT_Nom = @nom";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@nom", nomLot);

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erreur lors de la suppression du lot : " + ex.Message);
                }
            }
        }

        /// <summary>
        /// Requete permettant d'ajouter un lot à la DB, en précisant son nom,
        /// sa quantité d'éléments, son état et la recette associée
        /// </summary>
        /// <param name="nomLot"> nom du lot </param> 
        /// <param name="quantiteElementsLot"> quantité d'éléments dans le lot </param>
        /// <param name="idEtatLot"> id de l'état du lot généré automatiquement </param>
        /// <param name="idRecette"> id de la recette choisis par utilisateur </param>
        public static void AjouterLot(string nomLot, int quantiteElementsLot, int idEtatLot, int idRecette)
        {
            MySqlConnection conn = DbManager.GetDBConnection();

            string insertLot = @"INSERT INTO Lot (LOT_Nom, LOT_Quantite, LOT_DateHeureCreation, Id_Etat, Id_Recette) 
                        VALUES (@nom, @quantite, @dateHeure, @idEtat, @idRecette)";

            using (MySqlCommand cmd = new MySqlCommand(insertLot, conn))
            {
                cmd.Parameters.AddWithValue("@nom", nomLot);
                cmd.Parameters.AddWithValue("@quantite", quantiteElementsLot);
                cmd.Parameters.AddWithValue("@dateHeure", DateTime.Now);
                cmd.Parameters.AddWithValue("@idEtat", idEtatLot);
                cmd.Parameters.AddWithValue("@idRecette", idRecette);

                try
                {
                    // L'exception remonte au formulaire qui affiche le MessageBox
                    cmd.ExecuteNonQuery();

                }
                catch (Exception erreurInsertLot)
                {
                    Console.WriteLine("Erreur lors de l'insertion d'un lot : " + erreurInsertLot.Message);
                }

            }
        }
    }
}

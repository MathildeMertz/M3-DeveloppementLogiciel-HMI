using App_Gestion_lots_M3.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Gestion_lots_M3.AccesDonnees
{
    internal class RecetteManager
    {
        /// <summary>
        /// Requete permettant d'ajouter une recette à la DB, 
        /// en précisant son nom et la liste des opérations associées
        /// </summary>
        /// <param name="nomRecette"> nom de la recette </param>
        /// <param name="operations"> liste des opérations souhaité </param>
        public static void AjouterRecette(string nomRecette, List<Operation> operations)
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            MySqlTransaction transaction = conn.BeginTransaction();

            try
            {
                // 1 — Insérer la recette
                string insertRecette = @"INSERT INTO Recette (REC_Nom, REC_DateHeureCreation) 
                                VALUES (@nom, @date)";

                int idRecette;

                using (MySqlCommand cmd = new MySqlCommand(insertRecette, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@nom", nomRecette);
                    cmd.Parameters.AddWithValue("@date", DateTime.Now);
                    cmd.ExecuteNonQuery();
                    idRecette = (int)cmd.LastInsertedId;
                }

                // 2 — Insérer les opérations via InsererOperations
                OperationManager.InsererOperations(idRecette, operations, conn, transaction);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Supprime les opérations existantes d'une recette et les remplace par les nouvelles.
        /// </summary>
        /// <param name="idRecette"></param>
        /// <param name="operations"></param>
        public static void ModifierRecette(int idRecette, List<Operation> operations)
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            MySqlTransaction transaction = conn.BeginTransaction();

            try
            {
                // 1 — Supprimer les liens dans contenir
                string deleteContenir = "DELETE FROM Contenir WHERE Id_Recette = @idRecette";
                using (MySqlCommand cmd = new MySqlCommand(deleteContenir, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@idRecette", idRecette);
                    cmd.ExecuteNonQuery();
                }

                // 2 — Insérer les nouvelles opérations
                OperationManager.InsererOperations(idRecette, operations, conn, transaction);

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Retourne la liste de toutes les recettes.
        /// </summary>
        /// <returns></returns>
        public static List<Recette> GetRecettes()
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            List<Recette> recettes = new List<Recette>();

            string sql = "SELECT Id_Recette, REC_Nom, REC_DateHeureCreation FROM Recette";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    recettes.Add(new Recette
                    {
                        Id_Recette = reader.GetInt32("Id_Recette"),
                        REC_Nom = reader.GetString("REC_Nom"),
                        REC_DateHeureCreation = reader.GetDateTime("REC_DateHeureCreation")
                    });
                }
            }

            return recettes;
        }

        public static int GetIdRecette(string nomRecette)
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            string sql = "SELECT Id_Recette FROM Recette WHERE REC_Nom = @nom LIMIT 1";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@nom", nomRecette);
                object result = cmd.ExecuteScalar();
                if (result == null)
                    throw new Exception("Recette introuvable : " + nomRecette);
                return Convert.ToInt32(result);
            }
        }

        /// <summary>
        /// Supprime une recette et ses opérations associées de la base de données
        /// </summary>
        /// <param name="idRecette">Id de la recette à supprimer</param>
        /// <param name="nomRecette">Nom de la recette à supprimer</param>
        public static void SupprimerRecette(int idRecette, string nomRecette)
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            MySqlTransaction transaction = conn.BeginTransaction();

            try
            {
                // 1 — Supprimer les liens dans contenir
                string sqlContenir = "DELETE FROM Contenir WHERE Id_Recette = @idRecette";
                using (MySqlCommand cmd = new MySqlCommand(sqlContenir, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@idRecette", idRecette);
                    cmd.ExecuteNonQuery();
                }

                // 2 — Supprimer la recette
                string sqlRecette = "DELETE FROM Recette WHERE REC_Nom = @nom";
                using (MySqlCommand cmd = new MySqlCommand(sqlRecette, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@nom", nomRecette);
                    cmd.ExecuteNonQuery();
                }

                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        /// <summary>
        /// Vérifie si une recette est utilisée dans au moins un lot
        /// </summary>
        /// <param name="nomRecette">Nom de la recette à vérifier</param>
        /// <returns>True si utilisée, false sinon</returns>
        public static bool RecetteEstUtilisee(string nomRecette)
        {
            List<Lot> lots = LotManager.GetLots();
            foreach (Lot lot in lots)
            {
                if (lot.REC_Nom == nomRecette)
                {
                    return true;
                }
            }
            return false;
        }
    }
}

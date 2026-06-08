using App_Gestion_lots_M3.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Gestion_lots_M3.AccesDonnees
{
    internal class DataManager
    {
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
                               VALUE (@nom, @quantite, @dateHeure, @idEtat, @idRecette)";

            using (MySqlCommand cmd = new MySqlCommand(insertLot, conn))
            {
                cmd.Parameters.AddWithValue("@nom", nomLot);
                cmd.Parameters.AddWithValue("@quantite", quantiteElementsLot);
                cmd.Parameters.AddWithValue("@dateHeure", DateTime.Now);
                cmd.Parameters.AddWithValue("@idRecette", idRecette);

                try
                {
                    cmd.ExecuteNonQuery();
                    Console.WriteLine("Lot ajouté avec succès.");
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Erreur lors de l'ajout du lot : " + ex.Message);
                }

            }
        }

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
                        Id_Lot = reader.GetInt32("Id_Lot"),
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

        // sup un lot de la DB

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
                // Insertion de la recette
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

                // Insertion de chaque opération liée à la recette
                foreach (Operation op in operations)
                {
                    string insertOperation = @"INSERT INTO Operation (OPE_Position, OPE_TempsArret, OPE_Quittance, Id_Recette)
                                       VALUES (@position, @tempsArret, @quittance, @idRecette)";

                    using (MySqlCommand cmd = new MySqlCommand(insertOperation, conn, transaction))
                    {
                        cmd.Parameters.AddWithValue("@position", op.posMoteurOpe);
                        cmd.Parameters.AddWithValue("@tempsArret", op.tempsAttenteOpe);
                        cmd.Parameters.AddWithValue("@quittance", op.quittanceOpe);
                        cmd.Parameters.AddWithValue("@idRecette", idRecette);
                        cmd.ExecuteNonQuery();
                    }
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
                string deleteOps = "DELETE FROM Operation WHERE Id_Recette = @idRecette";

                using (MySqlCommand cmd = new MySqlCommand(deleteOps, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@idRecette", idRecette);
                    cmd.ExecuteNonQuery();
                }

                InsererOperations(idRecette, operations, conn, transaction);

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

        /// <summary>
        /// Insère une liste d'opérations dans la transaction en cours.
        /// </summary>
        /// <param name="idRecette"></param>
        /// <param name="operations"></param>
        /// <param name="conn"></param>
        /// <param name="transaction"></param>
        private static void InsererOperations(int idRecette, List<Operation> operations, MySqlConnection conn, MySqlTransaction transaction)
        {
            string sql = @"INSERT INTO Operation (CON_NoOperation, OPE_Nom, OPE_Position,
                                                  OPE_SensRotation, OPE_NbTours, OPE_TempsArret,
                                                  OPE_CycleVerin, OPE_Quittance, Id_Recette)
                           VALUES (@noOpe, @nom, @position, @sens, @nbTours,
                                   @tempsArret, @cycleVerin, @quittance, @idRecette)";

            foreach (Operation op in operations)
            {
                using (MySqlCommand cmd = new MySqlCommand(sql, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@noOpe", op.noOpe);
                    cmd.Parameters.AddWithValue("@nom", op.nomOpe);
                    cmd.Parameters.AddWithValue("@position", op.posMoteurOpe);
                    cmd.Parameters.AddWithValue("@sens", op.sensMoteurOpe);
                    cmd.Parameters.AddWithValue("@nbTours", op.nbreToursOpe);
                    cmd.Parameters.AddWithValue("@tempsArret", op.tempsAttenteOpe);
                    cmd.Parameters.AddWithValue("@cycleVerin", op.cycleVerrinOpe);
                    cmd.Parameters.AddWithValue("@quittance", op.quittanceOpe);
                    cmd.Parameters.AddWithValue("@idRecette", idRecette);

                    try 
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    
                }
            }
        }

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
                        Id_Etat = reader.GetInt32("Id_Etat"),
                        ETA_Libelle = reader.GetString("ETA_Libelle")
                    });
                }
            }

            return etats;
        }
    }
}

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
                        VALUES (@nom, @quantite, @dateHeure, @idEtat, @idRecette)";

            using (MySqlCommand cmd = new MySqlCommand(insertLot, conn))
            {
                cmd.Parameters.AddWithValue("@nom", nomLot);
                cmd.Parameters.AddWithValue("@quantite", quantiteElementsLot);
                cmd.Parameters.AddWithValue("@dateHeure", DateTime.Now);
                cmd.Parameters.AddWithValue("@idEtat", idEtatLot);
                cmd.Parameters.AddWithValue("@idRecette", idRecette);

                // L'exception remonte au formulaire qui affiche le MessageBox
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Retourne la liste des événements pour un lot donné
        /// </summary>
        /// <param name="idLot">Identifiant du lot</param>
        /// <returns>Liste des événements</returns>
        public static List<Evenement> GetEvenements(int idLot)
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            List<Evenement> evenements = new List<Evenement>();

            string sql = @"SELECT Id_Evenement, EVE_DateHeure, EVE_Message, Id_Lot
                   FROM Evenement
                   WHERE Id_Lot = @idLot
                   ORDER BY EVE_DateHeure DESC";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idLot", idLot);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Evenement eve = new Evenement();

                        // Lecture de l'id
                        eve.idEve = reader.GetInt32("Id_Evenement");

                        // Lecture de la date — peut être null dans la BDD
                        if (reader.IsDBNull(reader.GetOrdinal("EVE_DateHeure")))
                            eve.dateHeureEve = DateTime.MinValue;
                        else
                            eve.dateHeureEve = reader.GetDateTime("EVE_DateHeure");

                        // Lecture du message — peut être null dans la BDD
                        if (reader.IsDBNull(reader.GetOrdinal("EVE_Message")))
                            eve.messageEve = "";
                        else
                            eve.messageEve = reader.GetString("EVE_Message");

                        // Lecture de l'id du lot — peut être null dans la BDD
                        if (reader.IsDBNull(reader.GetOrdinal("Id_Lot")))
                            eve.idLot = 0;
                        else
                            eve.idLot = reader.GetInt32("Id_Lot");

                        evenements.Add(eve);
                    }
                }
            }

            return evenements;
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
                string deleteContenir = "DELETE FROM contenir WHERE Id_Recette = @idRecette";
                using (MySqlCommand cmd = new MySqlCommand(deleteContenir, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@idRecette", idRecette);
                    cmd.ExecuteNonQuery();
                }

                // 2 — Insérer les nouvelles opérations
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
        /// Insère une liste d'opérations et les lie à la recette via la table contenir
        /// </summary>
        /// <param name="idRecette"></param>
        /// <param name="operations"></param>
        /// <param name="conn"></param>
        /// <param name="transaction"></param>
        public static void InsererOperations(int idRecette, List<Operation> operations, MySqlConnection conn, MySqlTransaction transaction)
        {
            int noOperation = 1;

            foreach (Operation op in operations)
            {
                // 1 — Insérer l'opération dans la table Operation
                string sqlOperation = @"INSERT INTO Operation (OPE_Nom, OPE_PositionMoteur, OPE_SensMoteur, 
                                                        OPE_TempsAttente, OPE_CycleVerin, OPE_Quittance)
                                VALUES (@nom, @position, @sens, @tempsAttente, @cycleVerin, @quittance)";

                int idOperation;

                using (MySqlCommand cmd = new MySqlCommand(sqlOperation, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@nom", op.nomOpe);
                    cmd.Parameters.AddWithValue("@position", op.posMoteurOpe);
                    cmd.Parameters.AddWithValue("@sens", op.sensMoteurOpe);
                    cmd.Parameters.AddWithValue("@tempsAttente", op.tempsAttenteOpe);
                    cmd.Parameters.AddWithValue("@cycleVerin", op.cycleVerrinOpe);
                    cmd.Parameters.AddWithValue("@quittance", op.quittanceOpe);
                    cmd.ExecuteNonQuery();

                    // Récupère l'id de l'opération insérée
                    idOperation = (int)cmd.LastInsertedId;
                }

                // 2 — Lier l'opération à la recette via la table contenir
                string sqlContenir = @"INSERT INTO contenir (Id_Operation_est_contenu_dans, Id_Recette, CON_NoOperation)
                                VALUES (@idOperation, @idRecette, @noOperation)";

                using (MySqlCommand cmd = new MySqlCommand(sqlContenir, conn, transaction))
                {
                    cmd.Parameters.AddWithValue("@idOperation", idOperation);
                    cmd.Parameters.AddWithValue("@idRecette", idRecette);
                    cmd.Parameters.AddWithValue("@noOperation", noOperation);
                    cmd.ExecuteNonQuery();
                }

                noOperation++;
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

        /// <summary>
        /// Retourne la liste des opérations pour une recette donnée
        /// </summary>
        public static List<Operation> GetOperations(int idRecette)
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            List<Operation> operations = new List<Operation>();

            // On joint Operation et contenir pour récupérer les opérations liées à la recette
            string sql = @"SELECT o.Id_Operation, o.OPE_Nom, o.OPE_PositionMoteur, o.OPE_SensMoteur,
                          o.OPE_TempsAttente, o.OPE_CycleVerin, o.OPE_Quittance, c.CON_NoOperation
                   FROM Operation o
                   JOIN contenir c ON o.Id_Operation = c.Id_Operation_est_contenu_dans
                   WHERE c.Id_Recette = @idRecette
                   ORDER BY c.CON_NoOperation";

            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idRecette", idRecette);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Operation op = new Operation();

                        op.noOpe = reader.GetInt32("CON_NoOperation");
                        op.nomOpe = reader.GetString("OPE_Nom");
                        op.posMoteurOpe = reader.GetInt32("OPE_PositionMoteur");
                        op.sensMoteurOpe = reader.GetInt32("OPE_SensMoteur");
                        op.tempsAttenteOpe = reader.GetInt32("OPE_TempsAttente");
                        op.cycleVerrinOpe = reader.GetInt32("OPE_CycleVerin");
                        op.quittanceOpe = reader.GetBoolean("OPE_Quittance");

                        // OPE_Nom peut être null
                        if (reader.IsDBNull(reader.GetOrdinal("OPE_Nom")))
                            op.nomOpe = "";
                        else
                            op.nomOpe = reader.GetString("OPE_Nom");

                        operations.Add(op);
                    }
                }
            }

            return operations;
        }

    }
}

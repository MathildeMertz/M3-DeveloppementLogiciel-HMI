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
        /// 
        /// </summary>
        /// <param name="nomLot"></param>
        /// <param name="quantiteElementsLot"></param>
        /// <param name="idEtatLot"></param>
        /// <param name="idRecette"></param>
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
        /// 
        /// </summary>
        /// <param name="nomRecette"></param>
        /// <param name="operations"></param>
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
    }
}

/* ECOLE TECHNIQUE PORRENTRUY          
   Département informatique            
   Enseignant responsable : D. Montavon
   _____________________________________
    Nom du fichier  : OperationManager.cs
    Type de fichier : Programme C#
    Auteur          : Ryf Frédéric / Mertz Mathilde
    Date            : 16 juin 2026
    But             : Requête des opérations
*/

using App_Gestion_lots_M3.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace App_Gestion_lots_M3.AccesDonnees
{
    internal class OperationManager
    {
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
                string sqlContenir = @"INSERT INTO Contenir (Id_Operation_est_contenu_dans, Id_Recette, CON_NoOperation)
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
                   JOIN Contenir c ON o.Id_Operation = c.Id_Operation_est_contenu_dans
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
        /// <summary>
        /// Retourne le nombre d'opérations d'une recette
        /// </summary>
        /// <param name="idRecette">Id de la recette</param>
        /// <returns>Nombre d'opérations</returns>
        public static int GetNombreOperations(int idRecette)
        {
            MySqlConnection conn = DbManager.GetDBConnection();
            string sql = "SELECT COUNT(*) FROM Contenir WHERE Id_Recette = @idRecette";
            using (MySqlCommand cmd = new MySqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@idRecette", idRecette);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }
    }
}

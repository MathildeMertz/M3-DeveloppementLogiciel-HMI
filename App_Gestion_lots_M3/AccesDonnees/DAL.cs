using App_Gestion_lots_M3.Model;

namespace App_Gestion_lots_M3.AccesDonnees
{
    public class DAL
    {
        // ================================================
        // ÉTATS
        // ================================================

        /// <summary>
        /// Retourne la liste de tous les états possibles d'un lot
        /// </summary>
        /// <returns>Liste des états</returns>
        public static List<Etat> GetEtats()
        {
            // Les états sont fixes, pas besoin de liste statique
            return new List<Etat>
            {
                new Etat { Id_Etat = 1, ETA_Libelle = "En attente"    },
                new Etat { Id_Etat = 2, ETA_Libelle = "En production" },
                new Etat { Id_Etat = 3, ETA_Libelle = "En erreur"     },
                new Etat { Id_Etat = 4, ETA_Libelle = "Terminé"       },
            };
        }

        // ================================================
        // RECETTES
        // ================================================

        /// <summary>
        /// Liste statique des recettes pour persister les données en session
        /// </summary>
        private static List<Recette> listeRecettes = null;

        /// <summary>
        /// Retourne la liste de toutes les recettes
        /// </summary>
        /// <returns>Liste des recettes</returns>
        public static List<Recette> GetRecettes()
        {
            if (listeRecettes == null)
            {
                // Données de démonstration — sera remplacé par SELECT MySQL
                listeRecettes = new List<Recette>
                {
                    new Recette { Id_Recette = 1, REC_Nom = "AM203", REC_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0) },
                    new Recette { Id_Recette = 2, REC_Nom = "BM450", REC_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0) },
                    new Recette { Id_Recette = 3, REC_Nom = "CX120", REC_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0) },
                    new Recette { Id_Recette = 4, REC_Nom = "DX900", REC_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0) },
                    new Recette { Id_Recette = 5, REC_Nom = "EX310", REC_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0) },
                };
            }
            return listeRecettes;
        }

        /// <summary>
        /// Ajoute une nouvelle recette dans la liste
        /// </summary>
        /// <param name="nouvelleRecette">Recette à ajouter</param>
        public static void AjouterRecette(Recette nouvelleRecette)
        {
            // TODO : remplacer par INSERT MySQL
            nouvelleRecette.Id_Recette = GetRecettes().Count + 1;
            GetRecettes().Add(nouvelleRecette);
        }

        /// <summary>
        /// Modifie une recette existante dans la liste
        /// </summary>
        /// <param name="nomRecette">Nom de la recette à modifier</param>
        /// <param name="recetteModifiee">Nouvelles données de la recette</param>
        public static void ModifierRecette(string nomRecette, Recette recetteModifiee)
        {
            // TODO : remplacer par UPDATE MySQL
            List<Recette> recettes = GetRecettes();
            for (int i = 0; i < recettes.Count; i++)
            {
                if (recettes[i].REC_Nom == nomRecette)
                {
                    recettes[i] = recetteModifiee;
                    break;
                }
            }
        }

        // ================================================
        // LOTS
        // ================================================

        /// <summary>
        /// Liste statique des lots pour persister les données en session
        /// </summary>
        private static List<Lot> listeLots = null;

        /// <summary>
        /// Retourne la liste de tous les lots
        /// </summary>
        /// <returns>Liste des lots</returns>
        public static List<Lot> GetLots()
        {
            if (listeLots == null)
            {
                // Données de démonstration — sera remplacé par SELECT MySQL
                listeLots = new List<Lot>
                {
                    new Lot { Id_Lot = 1, LOT_Nom = "LOT001", LOT_Quantite = 1500, LOT_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0), Id_Etat = 2, ETA_Libelle = "En production", Id_Recette = 1, REC_Nom = "AM203" },
                    new Lot { Id_Lot = 2, LOT_Nom = "LOT002", LOT_Quantite = 1000, LOT_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0), Id_Etat = 4, ETA_Libelle = "Terminé",       Id_Recette = 2, REC_Nom = "BM450" },
                    new Lot { Id_Lot = 3, LOT_Nom = "LOT003", LOT_Quantite = 750,  LOT_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0), Id_Etat = 1, ETA_Libelle = "En attente",    Id_Recette = 3, REC_Nom = "CX120" },
                    new Lot { Id_Lot = 4, LOT_Nom = "LOT004", LOT_Quantite = 500,  LOT_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0), Id_Etat = 3, ETA_Libelle = "En erreur",     Id_Recette = 4, REC_Nom = "DX900" },
                    new Lot { Id_Lot = 5, LOT_Nom = "LOT005", LOT_Quantite = 2000, LOT_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0), Id_Etat = 4, ETA_Libelle = "Terminé",       Id_Recette = 5, REC_Nom = "EX310" },
                };
            }
            return listeLots;
        }

        /// <summary>
        /// Ajoute un nouveau lot dans la liste
        /// </summary>
        /// <param name="nouveauLot">Lot à ajouter</param>
        public static void AjouterLot(Lot nouveauLot)
        {
            // TODO : remplacer par INSERT MySQL
            nouveauLot.Id_Lot = GetLots().Count + 1;
            GetLots().Add(nouveauLot);
        }

        /// <summary>
        /// Modifie un lot existant dans la liste
        /// </summary>
        /// <param name="nomLot">Nom du lot à modifier</param>
        /// <param name="lotModifie">Nouvelles données du lot</param>
        public static void ModifierLot(string nomLot, Lot lotModifie)
        {
            // TODO : remplacer par UPDATE MySQL
            List<Lot> lots = GetLots();
            for (int i = 0; i < lots.Count; i++)
            {
                if (lots[i].LOT_Nom == nomLot)
                {
                    lots[i] = lotModifie;
                    break;
                }
            }
        }

        /// <summary>
        /// Supprime un lot de la liste
        /// </summary>
        /// <param name="nomLot">Nom du lot à supprimer</param>
        public static void SupprimerLot(string nomLot)
        {
            // TODO : remplacer par DELETE MySQL
            List<Lot> lots = GetLots();
            for (int i = 0; i < lots.Count; i++)
            {
                if (lots[i].LOT_Nom == nomLot)
                {
                    lots.Remove(lots[i]);
                    break;
                }
            }
        }

        // ================================================
        // ÉVÉNEMENTS PAR LOT
        // ================================================

        /// <summary>
        /// Retourne la liste des événements pour un lot donné
        /// </summary>
        /// <param name="idLot">Identifiant du lot</param>
        /// <returns>Liste des événements filtrés par lot</returns>
        public static List<Evenement> GetEvenements(int idLot)
        {
            // Données de démonstration — sera remplacé par SELECT MySQL
            var tousEvenements = new List<Evenement>
            {
                new Evenement { Id_Evenement = 1,  EVE_Message = "Début du lot LOT001",       EVE_DateHeure = new DateTime(2026, 5, 4, 9, 4, 6),  Id_Lot = 1 },
                new Evenement { Id_Evenement = 2,  EVE_Message = "Début pièce 1",             EVE_DateHeure = new DateTime(2026, 5, 4, 9, 5, 0),  Id_Lot = 1 },
                new Evenement { Id_Evenement = 3,  EVE_Message = "Fin pièce 1",               EVE_DateHeure = new DateTime(2026, 5, 4, 9, 6, 0),  Id_Lot = 1 },
                new Evenement { Id_Evenement = 4,  EVE_Message = "Barrière lumineuse coupée", EVE_DateHeure = new DateTime(2026, 5, 4, 9, 7, 0),  Id_Lot = 1 },
                new Evenement { Id_Evenement = 5,  EVE_Message = "Reprise production",        EVE_DateHeure = new DateTime(2026, 5, 4, 9, 8, 0),  Id_Lot = 1 },
                new Evenement { Id_Evenement = 6,  EVE_Message = "Fin du lot LOT001",         EVE_DateHeure = new DateTime(2026, 5, 4, 10, 0, 0), Id_Lot = 1 },
                new Evenement { Id_Evenement = 7,  EVE_Message = "Début du lot LOT002",       EVE_DateHeure = new DateTime(2026, 5, 4, 9, 4, 6),  Id_Lot = 2 },
                new Evenement { Id_Evenement = 8,  EVE_Message = "Début pièce 1",             EVE_DateHeure = new DateTime(2026, 5, 4, 9, 5, 0),  Id_Lot = 2 },
                new Evenement { Id_Evenement = 9,  EVE_Message = "Fin pièce 1",               EVE_DateHeure = new DateTime(2026, 5, 4, 9, 6, 0),  Id_Lot = 2 },
                new Evenement { Id_Evenement = 10, EVE_Message = "Fin du lot LOT002",         EVE_DateHeure = new DateTime(2026, 5, 4, 10, 0, 0), Id_Lot = 2 },
                new Evenement { Id_Evenement = 11, EVE_Message = "Début du lot LOT003",       EVE_DateHeure = new DateTime(2026, 5, 4, 9, 4, 6),  Id_Lot = 3 },
                new Evenement { Id_Evenement = 12, EVE_Message = "Début du lot LOT004",       EVE_DateHeure = new DateTime(2026, 5, 4, 9, 4, 6),  Id_Lot = 4 },
                new Evenement { Id_Evenement = 13, EVE_Message = "Alarme - Barrière coupée",  EVE_DateHeure = new DateTime(2026, 5, 4, 9, 15, 0), Id_Lot = 4 },
                new Evenement { Id_Evenement = 14, EVE_Message = "Début du lot LOT005",       EVE_DateHeure = new DateTime(2026, 5, 4, 7, 0, 0),  Id_Lot = 5 },
                new Evenement { Id_Evenement = 15, EVE_Message = "Fin du lot LOT005",         EVE_DateHeure = new DateTime(2026, 5, 4, 14, 0, 0), Id_Lot = 5 },
            };

            // Filtrer les événements par lot
            List<Evenement> resultat = new List<Evenement>();
            foreach (Evenement evt in tousEvenements)
            {
                if (evt.Id_Lot == idLot)
                    resultat.Add(evt);
            }
            return resultat;
        }

        // ================================================
        // OPÉRATIONS PAR RECETTE
        // ================================================

        /// <summary>
        /// Dictionnaire statique des opérations par recette pour persister les données en session
        /// </summary>
        private static Dictionary<int, List<Operation>> listeOperations = null;

        /// <summary>
        /// Retourne la liste des opérations pour une recette donnée
        /// </summary>
        /// <param name="idRecette">Identifiant de la recette</param>
        /// <returns>Liste des opérations de la recette</returns>
        public static List<Operation> GetOperations(int idRecette)
        {
            if (listeOperations == null)
            {
                // Données de démonstration — sera remplacé par SELECT MySQL
                listeOperations = new Dictionary<int, List<Operation>>
                {
                    {
                        1, new List<Operation>
                        {
                            new Operation { Id_Operation = 1, OPE_Nom = "Pas 1", OPE_Position = "3H",  OPE_SensRotation = "Horaire",       OPE_NbTours = 2, OPE_TempsArret = 5,  OPE_CycleVerin = true,  OPE_Quittance = true,  CON_NoOperation = 1 },
                            new Operation { Id_Operation = 2, OPE_Nom = "Pas 2", OPE_Position = "6H",  OPE_SensRotation = "Anti-Horaire",  OPE_NbTours = 1, OPE_TempsArret = 8,  OPE_CycleVerin = false, OPE_Quittance = false, CON_NoOperation = 2 },
                            new Operation { Id_Operation = 3, OPE_Nom = "Pas 3", OPE_Position = "12H", OPE_SensRotation = "Horaire",       OPE_NbTours = 3, OPE_TempsArret = 10, OPE_CycleVerin = true,  OPE_Quittance = true,  CON_NoOperation = 3 },
                        }
                    },
                    {
                        2, new List<Operation>
                        {
                            new Operation { Id_Operation = 4, OPE_Nom = "Pas 1", OPE_Position = "3H", OPE_SensRotation = "Horaire",      OPE_NbTours = 1, OPE_TempsArret = 3, OPE_CycleVerin = false, OPE_Quittance = false, CON_NoOperation = 1 },
                            new Operation { Id_Operation = 5, OPE_Nom = "Pas 2", OPE_Position = "9H", OPE_SensRotation = "Anti-Horaire", OPE_NbTours = 2, OPE_TempsArret = 6, OPE_CycleVerin = true,  OPE_Quittance = true,  CON_NoOperation = 2 },
                        }
                    },
                    {
                        3, new List<Operation>
                        {
                            new Operation { Id_Operation = 6, OPE_Nom = "Pas 1", OPE_Position = "6H",  OPE_SensRotation = "Horaire",      OPE_NbTours = 1, OPE_TempsArret = 4, OPE_CycleVerin = false, OPE_Quittance = false, CON_NoOperation = 1 },
                            new Operation { Id_Operation = 7, OPE_Nom = "Pas 2", OPE_Position = "12H", OPE_SensRotation = "Anti-Horaire", OPE_NbTours = 2, OPE_TempsArret = 7, OPE_CycleVerin = true,  OPE_Quittance = true,  CON_NoOperation = 2 },
                            new Operation { Id_Operation = 8, OPE_Nom = "Pas 3", OPE_Position = "3H",  OPE_SensRotation = "Horaire",      OPE_NbTours = 1, OPE_TempsArret = 2, OPE_CycleVerin = false, OPE_Quittance = false, CON_NoOperation = 3 },
                        }
                    },
                    {
                        4, new List<Operation>
                        {
                            new Operation { Id_Operation = 9,  OPE_Nom = "Pas 1", OPE_Position = "9H",  OPE_SensRotation = "Horaire",      OPE_NbTours = 3, OPE_TempsArret = 5, OPE_CycleVerin = true,  OPE_Quittance = true,  CON_NoOperation = 1 },
                            new Operation { Id_Operation = 10, OPE_Nom = "Pas 2", OPE_Position = "12H", OPE_SensRotation = "Anti-Horaire", OPE_NbTours = 1, OPE_TempsArret = 3, OPE_CycleVerin = false, OPE_Quittance = false, CON_NoOperation = 2 },
                        }
                    },
                    {
                        5, new List<Operation>
                        {
                            new Operation { Id_Operation = 11, OPE_Nom = "Pas 1", OPE_Position = "3H", OPE_SensRotation = "Horaire",      OPE_NbTours = 2, OPE_TempsArret = 8, OPE_CycleVerin = true,  OPE_Quittance = true,  CON_NoOperation = 1 },
                            new Operation { Id_Operation = 12, OPE_Nom = "Pas 2", OPE_Position = "6H", OPE_SensRotation = "Anti-Horaire", OPE_NbTours = 1, OPE_TempsArret = 5, OPE_CycleVerin = true,  OPE_Quittance = true,  CON_NoOperation = 2 },
                            new Operation { Id_Operation = 13, OPE_Nom = "Pas 3", OPE_Position = "9H", OPE_SensRotation = "Horaire",      OPE_NbTours = 3, OPE_TempsArret = 3, OPE_CycleVerin = false, OPE_Quittance = false, CON_NoOperation = 3 },
                        }
                    },
                };
            }

            // Retourne les opérations de la recette ou liste vide si inexistante
            if (listeOperations.ContainsKey(idRecette))
                return listeOperations[idRecette];

            return new List<Operation>();
        }

        /// <summary>
        /// Ajoute ou met à jour les opérations d'une recette
        /// </summary>
        /// <param name="idRecette">Identifiant de la recette</param>
        /// <param name="operations">Liste des opérations à enregistrer</param>
        public static void AjouterOperations(int idRecette, List<Operation> operations)
        {
            // TODO : remplacer par INSERT MySQL
            if (listeOperations == null)
                GetOperations(0); // Initialise le dictionnaire

            listeOperations[idRecette] = operations;
        }
    }
}
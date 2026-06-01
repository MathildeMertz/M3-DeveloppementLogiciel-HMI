using App_Gestion_lots_M3.Model;

namespace App_Gestion_lots_M3.AccesDonnees
{
    public class DAL
    {
        // ================================================
        // ÉTATS
        // ================================================
        public static List<Etat> GetEtats()
        {
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
        // Initialisé une seule fois (mirroir du pattern listeLots ci-dessous)
        // pour que AjouterRecette / ModifierRecette persistent au sein de
        // la session.
        private static readonly List<Recette> listeRecettes = new List<Recette>
        {
            new Recette { Id_Recette = 1, REC_Nom = "AM203", REC_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0) },
            new Recette { Id_Recette = 2, REC_Nom = "BM450", REC_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0) },
            new Recette { Id_Recette = 3, REC_Nom = "CX120", REC_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0) },
            new Recette { Id_Recette = 4, REC_Nom = "DX900", REC_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0) },
            new Recette { Id_Recette = 5, REC_Nom = "EX310", REC_DateHeureCreation = new DateTime(2026, 5, 4, 9, 0, 0) },
        };

        // ================================================
        // ================================================
        // Le store des opérations est indexé par Id_Recette. Toutes les
        // recettes mockées partagent le même catalogue par défaut
        // (la spec hardcodée avant cette refonte) pour rester cohérent
        // avec le comportement précédent.
        private static readonly Dictionary<int, List<Operation>> operationsParRecette = SeedOperations();

        private static Dictionary<int, List<Operation>> SeedOperations()
        {
            var defautOps = new List<Operation>
            {
                new Operation { Id_Operation = 1, OPE_Nom = "Position 1", OPE_PositionMoteur = 1, OPE_TempsAttente = 1, OPE_CycleVerin = 1, OPE_Quittance = true,  OPE_SensMoteur = 1, CON_NoOperation = 1 },
                new Operation { Id_Operation = 2, OPE_Nom = "Position 2", OPE_PositionMoteur = 2, OPE_TempsAttente = 2, OPE_CycleVerin = 0, OPE_Quittance = false, OPE_SensMoteur = 1, CON_NoOperation = 2 },
                new Operation { Id_Operation = 3, OPE_Nom = "Position 3", OPE_PositionMoteur = 3, OPE_TempsAttente = 3, OPE_CycleVerin = 1, OPE_Quittance = false, OPE_SensMoteur = 0, CON_NoOperation = 3 },
            };

            var dict = new Dictionary<int, List<Operation>>();
            foreach (var r in listeRecettes)
            {
                // Copie défensive — chaque recette a son propre buffer.
                dict[r.Id_Recette] = defautOps.Select(o => new Operation
                {
                    Id_Operation = o.Id_Operation,
                    OPE_Nom = o.OPE_Nom,
                    OPE_PositionMoteur = o.OPE_PositionMoteur,
                    OPE_TempsAttente = o.OPE_TempsAttente,
                    OPE_CycleVerin = o.OPE_CycleVerin,
                    OPE_Quittance = o.OPE_Quittance,
                    OPE_SensMoteur = o.OPE_SensMoteur,
                    CON_NoOperation = o.CON_NoOperation,
                }).ToList();
            }
            return dict;
        }

        public static List<Recette> GetRecettes()
        {
            // Copie défensive : les callers ne doivent pas pouvoir muter
            // le store interne directement.
            return new List<Recette>(listeRecettes);
        }

        public static void AjouterRecette(Recette nouvelle)
        {
            nouvelle.Id_Recette = listeRecettes.Count == 0
                ? 1
                : listeRecettes.Max(r => r.Id_Recette) + 1;
            listeRecettes.Add(nouvelle);
            operationsParRecette[nouvelle.Id_Recette] = new List<Operation>(nouvelle.Operations);
        }

        public static void ModifierRecette(int idRecette, Recette modifiee)
        {
            var idx = listeRecettes.FindIndex(r => r.Id_Recette == idRecette);
            if (idx >= 0)
            {
                modifiee.Id_Recette = idRecette;
                listeRecettes[idx] = modifiee;
            }
            operationsParRecette[idRecette] = new List<Operation>(modifiee.Operations);
        }

        // ================================================
        // LOTS
        // ================================================
        // Ajoute cette variable statique en haut de la classe DAL
        private static List<Lot>? listeLots = null;

        public static List<Lot> GetLots()
        {
            if (listeLots == null)
            {
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

        // ================================================
        // ÉVÉNEMENTS PAR LOT
        // ================================================
        public static List<Evenement> GetEvenements(int idLot)
        {
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

            List<Evenement> resultat = new List<Evenement>();
            foreach (Evenement evt in tousEvenements)
            {
                if (evt.Id_Lot == idLot)
                    resultat.Add(evt);
            }
            return resultat;
        }

        // ================================================
        // OPÉRATIONS PAR RECETTE — LECTURE
        // ================================================
        public static List<Operation> GetOperations(int idRecette)
        {
            return operationsParRecette.TryGetValue(idRecette, out var ops)
                ? new List<Operation>(ops)
                : new List<Operation>();
        }

        // ================================================
        // AJOUTER UN LOT
        // ================================================
        public static void AjouterLot(Lot nouveauLot)
        {
            // TODO : remplacer par INSERT MySQL
            nouveauLot.Id_Lot = listeLots.Count + 1;
            listeLots.Add(nouveauLot);
        }

        // ================================================
        // MODIFIER UN LOT
        // ================================================
        public static void ModifierLot(string nomLot, Lot lotModifie)
        {
            // TODO : remplacer par UPDATE MySQL
            for (int i = 0; i < listeLots.Count; i++)
            {
                if (listeLots[i].LOT_Nom == nomLot)
                {
                    listeLots[i] = lotModifie;
                    break;
                }
            }
        }

        // ================================================
        // SUPPRIMER UN LOT
        // ================================================
        public static void SupprimerLot(string nomLot)
        {
            // TODO : remplacer par DELETE MySQL
            for (int i = 0; i < listeLots.Count; i++)
            {
                if (listeLots[i].LOT_Nom == nomLot)
                {
                    listeLots.Remove(listeLots[i]);
                    break;
                }
            }
        }
    }
}

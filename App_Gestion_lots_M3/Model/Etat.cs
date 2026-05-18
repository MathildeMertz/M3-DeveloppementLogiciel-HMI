using System;
using System.Collections.Generic;
using System.Text;

namespace App_Gestion_lots_M3.Model
{
    
        public enum EtatEnum
        {
            EnAttente,
            EnCours,
            Termine,
            Erreur
        }

        public class Etat
        {
            private int idEtat;
            private EtatEnum libelle;

            public EtatEnum GetLibelle() => libelle;
            public override string ToString() => libelle.ToString();
        }
    
}

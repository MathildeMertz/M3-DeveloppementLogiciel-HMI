namespace App_Gestion_lots_M3.Model
{
    public class Operation
    {
        /// <summary>
        /// Identifiant unique de l'opération
        /// </summary>
        public int Id_Operation { get; set; }

        /// <summary>
        /// Nom du pas de l'opération
        /// </summary>
        public string OPE_Nom { get; set; }

        /// <summary>
        /// Position d'arrêt du moteur (3H, 6H, 9H, 12H)
        /// </summary>
        public string OPE_Position { get; set; }

        /// <summary>
        /// Sens de rotation (Horaire, Anti-Horaire)
        /// </summary>
        public string OPE_SensRotation { get; set; }

        /// <summary>
        /// Nombre de tours
        /// </summary>
        public int OPE_NbTours { get; set; }

        /// <summary>
        /// Temps d'arrêt en secondes
        /// </summary>
        public int OPE_TempsArret { get; set; }

        /// <summary>
        /// Indique si un cycle vérin est présent
        /// </summary>
        public bool OPE_CycleVerin { get; set; }

        /// <summary>
        /// Indique si une quittance manuelle est requise
        /// </summary>
        public bool OPE_Quittance { get; set; }

        /// <summary>
        /// Numéro d'ordre de l'opération dans la recette
        /// </summary>
        public int CON_NoOperation { get; set; }
    }
}
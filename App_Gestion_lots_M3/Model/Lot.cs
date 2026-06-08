namespace App_Gestion_lots_M3.Model
{
    public class Lot

    {
        public int idLot { get; set; }
        public string LOT_Nom { get; set; }
        public int LOT_Quantite { get; set; }
        public DateTime LOT_DateHeureCreation { get; set; }
        public int Id_Etat { get; set; }
        public string ETA_Libelle { get; set; }
        public int Id_Recette { get; set; }
        public string REC_Nom { get; set; }
    }
}
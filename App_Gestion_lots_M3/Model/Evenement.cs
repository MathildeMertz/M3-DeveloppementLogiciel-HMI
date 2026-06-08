namespace App_Gestion_lots_M3.Model
{
    public class Evenement
    {
        public int idEve { get; set; }
        public string messageEve { get; set; }
        public DateTime dateHeureEve { get; set; }
        public int idLot { get; set; }
    }
}
namespace App_Gestion_lots_M3.Model
{
    public class Evenement
    {
        public int Id_Evenement { get; set; }
        public string EVE_Message { get; set; }
        public DateTime EVE_DateHeure { get; set; }
        public int Id_Lot { get; set; }
    }
}
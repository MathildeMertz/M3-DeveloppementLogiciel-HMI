namespace App_Gestion_lots_M3.Model
{
    public class Recette
    {
        public int Id_Recette { get; set; }
        public string REC_Nom { get; set; }
        public DateTime REC_DateHeureCreation { get; set; }
        public List<Operation> Operations { get; set; }

        public Recette()
        {
            Operations = new List<Operation>();
        }
    }
}
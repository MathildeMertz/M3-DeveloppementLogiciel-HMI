namespace App_Gestion_lots_M3.Model
{
    public class Operation
    {
        public int Id_Operation { get; set; }
        public string OPE_Nom { get; set; }
        public int OPE_PositionMoteur { get; set; }
        public int OPE_TempsAttente { get; set; }
        public int OPE_CycleVerin { get; set; }
        public bool OPE_Quittance { get; set; }
        public int OPE_SensMoteur { get; set; }
        public int CON_NoOperation { get; set; }
    }
}
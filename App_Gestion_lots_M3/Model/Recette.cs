/* ECOLE TECHNIQUE PORRENTRUY          
   Département informatique            
   Enseignant responsable : D. Montavon
   _____________________________________
    Nom du fichier  : Recette.cs
    Type de fichier : Programme C#
    Auteur          : Ryf Frédéric / Mertz Mathilde
    But             : Classe modèle représentant une recette
*/

namespace App_Gestion_lots_M3.Model
{
    public class Recette
    {
        public int Id_Recette { get; set; }
        public string REC_Nom { get; set; }
        public DateTime REC_DateHeureCreation { get; set; }
        public List<Operation> Operations { get; set; }

        /// <summary>
        /// Constructeur de la classe Recette. Initialise la liste des opérations et définit la date de création à l'heure actuelle.
        /// </summary>
        public Recette()
        {
            Operations = new List<Operation>();
            REC_DateHeureCreation = DateTime.Now;
        }

        /// <summary>
        /// Ajoute une nouvelle opération à la recette, vérifie que le nbre
        /// d'opéaration existante ne soient pas supérieur a 10.
        /// </summary>
        /// <param name="nouvelleOperation"> Parametre contenant l'ensemble des données d'une opéaration </param>
        /// <exception cref="InvalidOperationException"> Exception qui signale qu'il y a plus de 10 opération dans la recette </exception>
        public void AddOperation(Operation nouvelleOperation)
        {
            if (Operations.Count >= 10)
                throw new InvalidOperationException("Une recette ne peut pas contenir plus de 10 opérations.");

            Operations.Add(nouvelleOperation);
        }

        /// <summary>
        /// Supprimer une opération de la recette. 
        /// </summary>
        /// <param name="idOperation"></param>
        public void RemoveOperation(int idOperation)
        {
            Operations.RemoveAll(opearationRamove => opearationRamove.noOpe == idOperation);
        }

        /// <summary>
        /// Vérifie si l'oéparation existe déja dans la recette.
        /// </summary>
        /// <param name="idOperation"></param>
        /// <returns></returns>
        public bool HasOperation(int idOperation)
        {
            return Operations.Any(o => o.noOpe == idOperation);
        }




    }


}
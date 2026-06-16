/* ECOLE TECHNIQUE PORRENTRUY          
   Département informatique            
   Enseignant responsable : D. Montavon
   _____________________________________
    Nom du fichier  : Program.cs
    Type de fichier : Programme C#
    Auteur          : Ryf Frédéric / Mertz Mathilde
    Date            : 16 juin 2026
    But             : programme de base qui permet de geré la première page et la connexion
*/

using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.UI;

namespace App_Gestion_lots_M3
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            Application.ApplicationExit += (s, e) => DbManager.CloseDBConnection();

            // Ouvre le login d'abord
            FormLogin formLogin = new FormLogin();
            if (formLogin.ShowDialog() == DialogResult.OK)
            {
                // Login réussi → ouvre Form1
                Application.Run(new Form1());
            }

            
        }
    }
}
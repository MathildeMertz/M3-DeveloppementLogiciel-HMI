using App_Gestion_lots_M3.AccesDonnees;
using Microsoft.Extensions.Configuration;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormLogin : Form
    {
        // ================================================
        // CONSTRUCTEUR
        // ================================================

        /// <summary>
        /// Constructeur du formulaire de login
        /// </summary>
        public FormLogin()
        {
            InitializeComponent();
        }


        // ================================================
        // CHARGEMENT DU FORMULAIRE
        // ================================================

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormLogin_Load(object sender, EventArgs e)
        {
            // Lecture du fichier appsettings.json
            try
            {
                IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json", optional: true)
                    .Build();

                string connectionString = config.GetConnectionString("DefaultConnection");

                if (!string.IsNullOrEmpty(connectionString))
                {
                    // Parse la connection string pour remplir les champs
                    foreach (string partie in connectionString.Split(';'))
                    {
                        if (partie.StartsWith("Server="))
                            txtServeur.Text = partie.Replace("Server=", "");
                        else if (partie.StartsWith("Port="))
                            txtPort.Text = partie.Replace("Port=", "");
                        else if (partie.StartsWith("Database="))
                            txtBaseDonnee.Text = partie.Replace("Database=", "");
                        else if (partie.StartsWith("Uid="))
                            txtUtilisateur.Text = partie.Replace("Uid=", "");
                        else if (partie.StartsWith("Pwd="))
                            txtMotDePasse.Text = partie.Replace("Pwd=", "");
                    }
                }
            }
            catch (Exception)
            {
                // Si le fichier n'existe pas, valeurs par défaut
                txtServeur.Text = "127.0.0.1";
                txtPort.Text = "3306";
                txtBaseDonnee.Text = "Production_M3";
                txtUtilisateur.Text = "root";
            }

            SetStatutDeconnecte();
            txtMotDePasse.Focus();
        }

        // ================================================
        // GESTION DU STATUT
        // ================================================

        /// <summary>
        /// Affiche le statut connecté avec le cercle vert
        /// </summary>
        private void SetStatutConnecte()
        {
            btnConnexion.Enabled = false;
        }

        /// <summary>
        /// Affiche le statut déconnecté avec le cercle rouge
        /// </summary>
        private void SetStatutDeconnecte()
        {
            btnConnexion.Enabled = true;
        }

        // ================================================
        // ÉVÉNEMENTS BOUTONS
        // ================================================

        /// <summary>
        /// Bouton de connexion — se connecte à la base de données
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            // Validation des champs obligatoires
            if (string.IsNullOrWhiteSpace(txtServeur.Text) ||
                string.IsNullOrWhiteSpace(txtPort.Text) ||
                string.IsNullOrWhiteSpace(txtBaseDonnee.Text) ||
                string.IsNullOrWhiteSpace(txtUtilisateur.Text))
            {
                MessageBox.Show("Veuillez remplir tous les champs obligatoires.",
                    "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validation du port
            if (!int.TryParse(txtPort.Text, out int port))
            {
                MessageBox.Show("Le port doit être un nombre entier.",
                    "Port invalide", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtPort.Focus();
                return;
            }

            try
            {
                // Tentative de connexion à MySQL
                DbManager.ConnectToDB(
                    txtBaseDonnee.Text,
                    txtUtilisateur.Text,
                    txtMotDePasse.Text,
                    txtServeur.Text,
                    port
                );

                SetStatutConnecte();

                // Connexion réussie → ferme le login et ouvre Form1
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Impossible de se connecter à la base de données.\n\n" + ex.Message,
                    "Erreur de connexion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                SetStatutDeconnecte();
            }
        }

        /// <summary>
        /// Bouton annuler — ferme l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAnnuler_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Bouton enregistrer — sauvegarde les paramètres
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            // TODO : sauvegarder dans appsettings.json
            MessageBox.Show("Paramètres enregistrés.",
                "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // ================================================
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txtUtilisateur_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void txtMotDePasse_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void txtBaseDonnee_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void txtServeur_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }

        private void txtPort_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtServeur_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void txtBaseDonnee_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {

        }

        /// <summary>
        /// Bouton enregistrer — sauvegarde les paramètres dans appsettings.json
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrer_Click_1(object sender, EventArgs e)
        {
            try
            {
                string cheminFichier = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");

                // Construire la nouvelle connection string
                string connectionString = $"Server={txtServeur.Text};" +
                                          $"Port={txtPort.Text};" +
                                          $"Database={txtBaseDonnee.Text};" +
                                          $"Uid={txtUtilisateur.Text};" +
                                          $"Pwd={txtMotDePasse.Text};";

                // Construire le contenu JSON
                string jsonContent = "{\n" +
                                     "  \"ConnectionStrings\": {\n" +
                                     $"    \"DefaultConnection\": \"{connectionString}\"\n" +
                                     "  }\n" +
                                     "}";

                // Écrire dans le fichier
                File.WriteAllText(cheminFichier, jsonContent);

                MessageBox.Show("Paramètres enregistrés avec succès !",
                    "Enregistrement", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureEMT_Click(object sender, EventArgs e)
        {

        }

        private void labelTitre_Click(object sender, EventArgs e)
        {

        }
    }
}
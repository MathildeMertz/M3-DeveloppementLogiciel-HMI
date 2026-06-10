using System;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormLogin : Form
    {
        // ================================================
        // IDENTIFIANTS HARDCODÉS
        // ================================================

        /// <summary>
        /// Identifiants valides pour la connexion
        /// </summary>
        private const string UTILISATEUR_VALIDE = "admin";
        private const string MOT_DE_PASSE_VALIDE = "1234";

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
            // Met le focus sur le champ utilisateur au démarrage
            txtUtilisateur.Focus();
        }

        // ================================================
        // ÉVÉNEMENTS BOUTONS
        // ================================================

        /// <summary>
        /// Bouton de connexion — vérifie les identifiants
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string utilisateur = txtUtilisateur.Text.Trim();
            string motDePasse = txtMotDePasse.Text.Trim();

            // Vérification des champs vides
            if (string.IsNullOrWhiteSpace(utilisateur))
            {
                MessageBox.Show("Veuillez entrer un nom d'utilisateur.",
                    "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUtilisateur.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(motDePasse))
            {
                MessageBox.Show("Veuillez entrer un mot de passe.",
                    "Champ manquant", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMotDePasse.Focus();
                return;
            }

            // Vérification des identifiants
            if (utilisateur == UTILISATEUR_VALIDE && motDePasse == MOT_DE_PASSE_VALIDE)
            {
                // Login réussi
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                // Login échoué
                MessageBox.Show("Identifiants incorrects. Veuillez réessayer.",
                    "Connexion refusée", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMotDePasse.Clear();
                txtMotDePasse.Focus();
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

        // ================================================
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void txtUtilisateur_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
        private void txtMotDePasse_MaskInputRejected(object sender, MaskInputRejectedEventArgs e) { }
<<<<<<< Updated upstream
=======
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
>>>>>>> Stashed changes
    }
}
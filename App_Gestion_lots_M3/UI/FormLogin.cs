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
    }
}
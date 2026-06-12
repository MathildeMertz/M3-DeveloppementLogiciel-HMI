using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormGestionLot : Form
    {
        // ================================================
        // VARIABLES
        // ================================================

        /// <summary>
        /// Lot en cours de modification, null si nouveau lot
        /// </summary>
        private Lot lotEnCours;

        /// <summary>
        /// Indique si on crée un nouveau lot ou si on modifie un existant
        /// </summary>
        private bool estNouveauLot;

        // ================================================
        // CONSTRUCTEUR
        // ================================================

        /// <summary>
        /// Constructeur du formulaire de gestion de lot
        /// </summary>
        /// <param name="lot">Lot à modifier, null pour un nouveau lot</param>
        public FormGestionLot(Lot lot)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            lotEnCours = lot;
            estNouveauLot = (lot == null);
        }

        // ================================================
        // CHARGEMENT DU FORMULAIRE
        // ================================================

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormGestionLot_Load(object sender, EventArgs e)
        {
            RemplirComboBoxRecette();
            ConfigurerFormulaire();
        }

        // ================================================
        // REMPLISSAGE DES COMBOBOX
        // ================================================

        /// <summary>
        /// Remplit le ComboBox des recettes disponibles
        /// </summary>
        private void RemplirComboBoxRecette()
        {
            cboRecette.Items.Clear();
            List<Recette> recettes = RecetteManager.GetRecettes();
            foreach (Recette recette in recettes)
            {
                cboRecette.Items.Add(recette.REC_Nom);
            }
            if (cboRecette.Items.Count > 0)
                cboRecette.SelectedIndex = 0;
        }

        // ================================================
        // CONFIGURATION DU FORMULAIRE
        // ================================================

        /// <summary>
        /// Configure le formulaire selon le mode nouveau ou modification
        /// </summary>
        private void ConfigurerFormulaire()
        {
            txtDateCreation.ReadOnly = true;
            txtDateCreation.BackColor = Color.FromArgb(240, 240, 240);

            if (estNouveauLot)
            {
                this.Text = "Nouveau Lot";
                txtNomLot.Text = "";
                txtQuantite.Text = "";
                txtDateCreation.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                btnModifier.Visible = false;
            }
            else
            {
                this.Text = "Modifier Lot - " + lotEnCours.LOT_Nom;
                txtNomLot.Text = lotEnCours.LOT_Nom;
                txtNomLot.ReadOnly = true;
                txtNomLot.BackColor = Color.FromArgb(240, 240, 240);
                txtQuantite.Text = lotEnCours.LOT_Quantite.ToString();
                txtDateCreation.Text = lotEnCours.LOT_DateHeureCreation.ToString("dd/MM/yyyy HH:mm");
                cboRecette.SelectedItem = lotEnCours.REC_Nom;
                btnEnregistrer.Visible = false;
            }
        }

        // ================================================
        // VALIDATION
        // ================================================

        /// <summary>
        /// Valide les données du formulaire avant enregistrement
        /// </summary>
        /// <returns>True si les données sont valides, false sinon</returns>
        private bool ValiderFormulaire()
        {
            if (string.IsNullOrWhiteSpace(txtNomLot.Text))
            {
                MessageBox.Show("Le nom du lot est obligatoire.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomLot.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantite.Text))
            {
                MessageBox.Show("La quantité est obligatoire.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantite.Focus();
                return false;
            }

            int quantite;
            if (!int.TryParse(txtQuantite.Text, out quantite) || quantite <= 0)
            {
                MessageBox.Show("La quantité doit être un nombre entier positif.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantite.Focus();
                return false;
            }

            if (cboRecette.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une recette.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRecette.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Vérifie si un lot avec ce nom existe déjà dans la base de données
        /// </summary>
        /// <param name="nomLot">Nom à vérifier</param>
        /// <returns>True si le nom existe déjà, false sinon</returns>
        private bool NomLotExisteDeja(string nomLot)
        {
            List<Lot> lots = LotManager.GetLots();
            foreach (Lot lot in lots)
            {
                if (lot.LOT_Nom.ToLower() == nomLot.ToLower())
                    return true;
            }
            return false;
        }

        // ================================================
        // ÉVÉNEMENTS BOUTONS
        // ================================================

        /// <summary>
        /// Bouton pour enregistrer un nouveau lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            if (NomLotExisteDeja(txtNomLot.Text))
            {
                MessageBox.Show("Un lot avec ce nom existe déjà.",
                    "Nom déjà utilisé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomLot.Focus();
                return;
            }

            try
            {
                // L'état est toujours "En attente" à la création
                // C'est la machine virtuelle qui gère l'état ensuite
                LotManager.AjouterLot(
                    txtNomLot.Text,
                    int.Parse(txtQuantite.Text),
                    EtatManager.GetIdEtat("En attente"),
                    RecetteManager.GetIdRecette(cboRecette.SelectedItem.ToString())
                );

                MessageBox.Show("Lot enregistré avec succès !",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bouton pour modifier un lot existant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            try
            {
                // On garde l'état actuel du lot lors d'une modification
                LotManager.ModifierLot(
                    lotEnCours.LOT_Nom,
                    int.Parse(txtQuantite.Text),
                    lotEnCours.Id_Etat,
                    RecetteManager.GetIdRecette(cboRecette.SelectedItem.ToString())
                );

                MessageBox.Show("Lot modifié avec succès !",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bouton pour créer une nouvelle recette sans perdre les données du lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNouvelleRecette_Click(object sender, EventArgs e)
        {
            FormGestionRecette formGestionRecette = new FormGestionRecette(null);
            formGestionRecette.ShowDialog();

            // Recharge les recettes et sélectionne la dernière créée
            cboRecette.Items.Clear();
            foreach (Recette recette in RecetteManager.GetRecettes())
            {
                cboRecette.Items.Add(recette.REC_Nom);
            }

            if (cboRecette.Items.Count > 0)
                cboRecette.SelectedIndex = cboRecette.Items.Count - 1;
        }

        /// <summary>
        /// Bouton pour fermer le formulaire sans enregistrer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================================================
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void txtNomLot_TextChanged(object sender, EventArgs e) { }
    }
}
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
        private Lot lotEnCours;
        private bool estNouveauLot;

        // ================================================
        // CONSTRUCTEUR
        // ================================================
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
        private void FormGestionLot_Load(object sender, EventArgs e)
        {
            RemplirComboBoxRecette();
            RemplirComboBoxEtat();
            ConfigurerFormulaire();
        }

        // ================================================
        // INITIALISATION DES COMBOBOX
        // ================================================
        private void RemplirComboBoxRecette()
        {
            cboRecette.Items.Clear();
            List<Recette> recettes = DataManager.GetRecettes();
            foreach (Recette recette in recettes)
            {
                cboRecette.Items.Add(recette.REC_Nom);
            }
            if (cboRecette.Items.Count > 0)
                cboRecette.SelectedIndex = 0;
        }

        private void RemplirComboBoxEtat()
        {
            cboEtat.Items.Clear();
            List<Etat> etats = DataManager.GetEtats();
            foreach (Etat etat in etats)
            {
                cboEtat.Items.Add(etat.libEtat);
            }
            if (cboEtat.Items.Count > 0)
                cboEtat.SelectedIndex = 0;
        }

        // ================================================
        // CONFIGURATION SELON NOUVEAU OU MODIFIER
        // ================================================
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
                cboEtat.SelectedItem = "En attente";
                btnModifier.Visible = false;
                btnSupprimer.Visible = false;
            }
            else
            {
                this.Text = "Modifier Lot - " + lotEnCours.LOT_Nom;
                txtNomLot.Text = lotEnCours.LOT_Nom;
                txtNomLot.ReadOnly = true;
                txtQuantite.Text = lotEnCours.LOT_Quantite.ToString();
                txtDateCreation.Text = lotEnCours.LOT_DateHeureCreation.ToString("dd/MM/yyyy HH:mm");
                cboRecette.SelectedItem = lotEnCours.REC_Nom;
                cboEtat.SelectedItem = lotEnCours.ETA_Libelle;
                btnEnregistrer.Visible = false;
            }
        }

        // ================================================
        // VALIDATION
        // ================================================
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

            return true;
        }

        private bool NomLotExisteDeja(string nomLot)
        {
            List<Lot> lots = DataManager.GetLots();
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

            DataManager.AjouterLot(new Lot
            {
                LOT_Nom = txtNomLot.Text,
                LOT_Quantite = int.Parse(txtQuantite.Text),
                ETA_Libelle = cboEtat.SelectedItem.ToString(),
                REC_Nom = cboRecette.SelectedItem.ToString()
                
            });

            MessageBox.Show("Lot enregistré avec succès !",
                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            DataManager.ModifierLot(lotEnCours.LOT_Nom, new Lot
            {
                LOT_Nom = txtNomLot.Text,
                LOT_Quantite = int.Parse(txtQuantite.Text),
                LOT_DateHeureCreation = lotEnCours.LOT_DateHeureCreation,
                REC_Nom = cboRecette.SelectedItem.ToString(),
                ETA_Libelle = cboEtat.SelectedItem.ToString()
            });

            MessageBox.Show("Lot modifié avec succès !",
                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show(
                "Êtes-vous sûr de vouloir supprimer le lot " + lotEnCours.LOT_Nom + " ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (reponse == DialogResult.Yes)
            {
                DataManager.SupprimerLot(lotEnCours.LOT_Nom);
                MessageBox.Show("Lot supprimé avec succès.",
                    "Suppression", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================================================
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void txtNomLot_TextChanged(object sender, EventArgs e) { }


        /// <summary>
        /// Bouton pour créer une nouvelle recette sans perdre les données du lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNouvelleRecette_Click(object sender, EventArgs e)
        {
            // Ouvre FormGestionRecette sans cacher le formulaire actuel
            FormGestionRecette formGestionRecette = new FormGestionRecette(null);
            formGestionRecette.ShowDialog();

            // Recharge les recettes dans le ComboBox après fermeture
            string recetteSelectionnee = cboRecette.SelectedItem?.ToString();
            cboRecette.Items.Clear();
            foreach (Recette recette in DataManager.GetRecettes())
            {
                cboRecette.Items.Add(recette.REC_Nom);
            }

            // Resélectionner la dernière recette créée (la dernière de la liste)
            if (cboRecette.Items.Count > 0)
                cboRecette.SelectedIndex = cboRecette.Items.Count - 1;
        }
    }
}
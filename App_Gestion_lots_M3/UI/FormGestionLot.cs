using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormGestionLot : Form
    {
        // ================================================
        // CONSTRUCTEUR
        // ================================================
        public FormGestionLot()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            RemplirComboBoxEtat();
        }

        // ================================================
        // INITIALISATION DES COMBOBOX
        // ================================================
        private void RemplirComboBoxEtat()
        {
            cboEtat.Items.Clear();
            cboEtat.Items.Add("En Attente");
            cboEtat.Items.Add("En Production");
            cboEtat.Items.Add("Terminé");
            cboEtat.Items.Add("En Erreur");
            cboEtat.SelectedIndex = 0;
        }

        private void RemplirComboBoxRecette()
        {
            // Sera rempli depuis la base de données plus tard
            cboRecette.Items.Clear();
            cboRecette.Items.Add("AM203");
            cboRecette.Items.Add("BX105");
            cboRecette.Items.Add("CX300");
        }

        // ================================================
        // VALIDATION DU FORMULAIRE
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

        // ================================================
        // ÉVÉNEMENTS BOUTONS
        // ================================================
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            // Connexion base de données à faire plus tard
            MessageBox.Show("Lot enregistré avec succès !",
                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            // Connexion base de données à faire plus tard
            MessageBox.Show("Lot modifié avec succès !",
                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            DialogResult reponse = MessageBox.Show(
                "Êtes-vous sûr de vouloir supprimer ce lot ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (reponse == DialogResult.Yes)
            {
                // Connexion base de données à faire plus tard
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
        // ÉVÉNEMENTS NON UTILISÉS POUR L'INSTANT
        // ================================================
        private void FormGestionLot_Load(object sender, EventArgs e)
        {
            RemplirComboBoxRecette();
        }

        private void cboEtat_SelectedIndexChanged(object sender, EventArgs e) { }
        private void cboRecette_SelectedIndexChanged(object sender, EventArgs e) { }
        private void txtQuantite_TextChanged(object sender, EventArgs e) { }
        private void txtNomLot_TextChanged(object sender, EventArgs e) { }
        private void dtpDu_ValueChanged(object sender, EventArgs e) { }
    }
}
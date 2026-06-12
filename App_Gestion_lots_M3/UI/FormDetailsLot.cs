using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormDetailsLot : Form


    {
        private List<Lot> listeLots;
        private int indexCourant;

        public FormDetailsLot(string nomLot = null)
        {
            InitializeComponent();
            listeLots = LotManager.GetLots();
            RemplirComboBox();

            if (listeLots.Count == 0) return;

            if (nomLot != null)
                indexCourant = listeLots.FindIndex(l => l.LOT_Nom == nomLot);

            if (indexCourant < 0) indexCourant = 0;

            AfficherLot(indexCourant);
        }


        // ================================================
        // INITIALISATION DU COMBOBOX
        // ================================================
        private void RemplirComboBox()
        {
            cboSelectLot.Items.Clear();
            foreach (Lot lot in listeLots)
            {
                cboSelectLot.Items.Add(lot.LOT_Nom);
            }
        }

        // ================================================
        // AFFICHAGE D'UN LOT
        // ================================================
        private void AfficherLot(int index)
        {
            if (index < 0 || index >= listeLots.Count) return;

            Lot lot = listeLots[index];

            lblRecette.Text = lot.REC_Nom;
            lblQuantite.Text = lot.LOT_Quantite + " pièces";
            lblEtat.Text = lot.ETA_Libelle;
            lblDateCreation.Text = lot.LOT_DateHeureCreation.ToString("dd/MM/yyyy HH:mm");
            lblDateDebut.Text = "-";
            lblDateFin.Text = "-";

            // Mettre à jour le titre
            this.Text = "Détails du Lot - " + lot.LOT_Nom;

            // Gérer les boutons Précédent/Suivant
            btnPrecedent.Enabled = index > 0;
            btnSuivant.Enabled = index < listeLots.Count - 1;

            // Mettre à jour le ComboBox sans déclencher l'événement
            cboSelectLot.SelectedIndexChanged -= cboSelectLot_SelectedIndexChanged;
            cboSelectLot.SelectedIndex = index;
            cboSelectLot.SelectedIndexChanged += cboSelectLot_SelectedIndexChanged;

            ChargerEvenements(lot.idLot);
        }

        // ================================================
        // CHARGEMENT DES ÉVÉNEMENTS
        // ================================================
        private void ChargerEvenements(int idLot)
        {
            dataGridView1.Rows.Clear();

            List<Evenement> evenements = EvenementManager.GetEvenements(idLot);
            foreach (Evenement evt in evenements)
            {
                dataGridView1.Rows.Add(
                    evt.dateHeureEve.ToString("dd/MM/yyyy"),
                    evt.dateHeureEve.ToString("HH:mm:ss"),
                    evt.messageEve,
                    ""
                );
            }
        }

        // ================================================
        // ÉVÉNEMENTS NAVIGATION
        // ================================================
        private void cboSelectLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherLot(cboSelectLot.SelectedIndex);
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (cboSelectLot.SelectedIndex > 0)
                AfficherLot(cboSelectLot.SelectedIndex - 1);
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            if (cboSelectLot.SelectedIndex < listeLots.Count - 1)
                AfficherLot(cboSelectLot.SelectedIndex + 1);
        }

        // ================================================
        // ÉVÉNEMENTS BOUTONS
        // ================================================
        /// <summary>
        /// Bouton pour voir la traçabilité du lot affiché
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVoirTracabilite_Click(object sender, EventArgs e)
        {
            // Récupère le nom du lot actuellement affiché
            string nomLot = listeLots[cboSelectLot.SelectedIndex].LOT_Nom;

            this.Hide();
            FormTracabilite formTracabilite = new FormTracabilite(nomLot);
            formTracabilite.ShowDialog();
            this.Show();
        }

        private void btnModifierLot_Click(object sender, EventArgs e)
        {
            // Récupérer le lot actuellement affiché
            Lot lotActuel = listeLots[cboSelectLot.SelectedIndex];

            this.Hide();
            FormGestionLot formGestionLot = new FormGestionLot(lotActuel);
            formGestionLot.WindowState = FormWindowState.Maximized;
            formGestionLot.ShowDialog();

            // Recharger les lots après modification
            listeLots = LotManager.GetLots();
            AfficherLot(cboSelectLot.SelectedIndex);
            this.Show();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Supprime le lot seulement s'il est en attente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (listeLots == null || listeLots.Count == 0 || cboSelectLot.SelectedIndex < 0)
            {
                MessageBox.Show("Aucun lot sélectionné.",
                    "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Lot lotActuel = listeLots[cboSelectLot.SelectedIndex];

            // Vérifier que le lot est en attente
            if (lotActuel.ETA_Libelle != "En attente")
            {
                MessageBox.Show("Seuls les lots en attente peuvent être supprimés.",
                    "Suppression impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult reponse = MessageBox.Show(
                "Êtes-vous sûr de vouloir supprimer le lot " + lotActuel.LOT_Nom + " ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reponse == DialogResult.Yes)
            {
                LotManager.SupprimerLot(lotActuel.LOT_Nom);

                MessageBox.Show("Lot supprimé avec succès.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recharger la liste
                listeLots = LotManager.GetLots();

                if (listeLots.Count == 0)
                {
                    this.Close();
                    return;
                }

                RemplirComboBox();
                AfficherLot(0);
            }
        }

        // ================================================
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void lblEtat_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void lblDateCreation_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void lblDateDebut_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void lblDateFin_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormDetailsLot : Form
    {
        // ================================================
        // VARIABLES
        // ================================================
        private List<Lot> listeLots;
        private string lotInitial;

        // ================================================
        // CONSTRUCTEUR
        // ================================================
        public FormDetailsLot(string nomLot)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            lotInitial = nomLot;
            listeLots = DAL.GetLots();

            // Désactiver l'événement pendant le chargement
            cboSelectLot.SelectedIndexChanged -= cboSelectLot_SelectedIndexChanged;
            RemplirComboBox();

            int indexInitial = 0;
            if (lotInitial != null)
            {
                for (int i = 0; i < listeLots.Count; i++)
                {
                    if (listeLots[i].LOT_Nom == lotInitial)
                    {
                        indexInitial = i;
                        break;
                    }
                }
            }

            cboSelectLot.SelectedIndex = indexInitial;

            // Réactiver l'événement
            cboSelectLot.SelectedIndexChanged += cboSelectLot_SelectedIndexChanged;

            // Afficher le lot initial
            AfficherLot(indexInitial);
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

            ChargerEvenements(lot.Id_Lot);
        }

        // ================================================
        // CHARGEMENT DES ÉVÉNEMENTS
        // ================================================
        private void ChargerEvenements(int idLot)
        {
            dataGridView1.Rows.Clear();

            List<Evenement> evenements = DAL.GetEvenements(idLot);
            foreach (Evenement evt in evenements)
            {
                dataGridView1.Rows.Add(
                    evt.EVE_DateHeure.ToString("dd/MM/yyyy"),
                    evt.EVE_DateHeure.ToString("HH:mm:ss"),
                    evt.EVE_Message,
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
        private void btnVoirTracabilite_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTracabilite formTracabilite = new FormTracabilite();
            formTracabilite.WindowState = FormWindowState.Maximized;
            formTracabilite.ShowDialog();
            this.Show();
        }

        private void btnModifierLot_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionLot formGestionLot = new FormGestionLot(null);
            formGestionLot.WindowState = FormWindowState.Maximized;
            formGestionLot.ShowDialog();
            listeLots = DAL.GetLots();
            AfficherLot(cboSelectLot.SelectedIndex);
            this.Show();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
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
    }
}
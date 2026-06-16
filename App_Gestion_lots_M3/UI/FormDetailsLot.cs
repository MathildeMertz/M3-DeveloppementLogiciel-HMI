/* ECOLE TECHNIQUE PORRENTRUY          
   Département informatique            
   Enseignant responsable : D. Montavon
   _____________________________________
    Nom du fichier  : FormDetailLot.cs
    Type de fichier : Programme C#
    Auteur          : Ryf Frédéric / Mertz Mathilde
    Date            : 16 juin 2026
    But             : Fenêtre du détail des lots
*/

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

        /// <summary>
        /// Concepteur
        /// </summary>
        /// <param name="nomLot"></param>
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


        /// <summary>
        /// Initialisation du combo box
        /// </summary>
        private void RemplirComboBox()
        {
            cboSelectLot.Items.Clear();
            foreach (Lot lot in listeLots)
            {
                cboSelectLot.Items.Add(lot.LOT_Nom);
            }
        }

        /// <summary>
        /// Affiche les lots
        /// </summary>
        /// <param name="index"></param>
        private void AfficherLot(int index)
        {
            if (index < 0 || index >= listeLots.Count) return;

            Lot lot = listeLots[index];

            lblRecette.Text = lot.REC_Nom;
            lblQuantite.Text = lot.LOT_Quantite + " pièces";
            lblEtat.Text = lot.ETA_Libelle;
            lblDateCreation.Text = lot.LOT_DateHeureCreation.ToString("dd/MM/yyyy HH:mm");
            DateTime? dateDebut = EvenementManager.GetDateDebut(lot.idLot);
            lblDateDebut.Text = dateDebut.HasValue
                ? dateDebut.Value.ToString("dd/MM/yyyy HH:mm")
                : "-";

            DateTime? dateFin = EvenementManager.GetDateFin(lot.idLot);
            lblDateFin.Text = dateFin.HasValue
                ? dateFin.Value.ToString("dd/MM/yyyy HH:mm")
                : "-";

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

        /// <summary>
        /// Permet de chargé les évenement pour les afffichées par la suite
        /// </summary>
        /// <param name="idLot"></param>
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

        /// <summary>
        /// Panel de navigation pour choisir le lot qu'on désir
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSelectLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherLot(cboSelectLot.SelectedIndex);
        }

        /// <summary>
        /// Passe au lot précédent
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (cboSelectLot.SelectedIndex > 0)
                AfficherLot(cboSelectLot.SelectedIndex - 1);
        }

        /// <summary>
        /// Passe au lot suivant
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// bouton qui permet de modifier le lot sous certaines conditions
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// bouton qui ferme cette page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Supprime le lot seulement s'il est en attente
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <summary>
        /// Met le lot en état "En erreur" avec le message "Supprimé" pour conserver la traçabilité
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (listeLots == null || listeLots.Count == 0 || cboSelectLot.SelectedIndex < 0)
            {
                MessageBox.Show("Aucun lot sélectionné.",
                    "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Lot lotActuel = listeLots[cboSelectLot.SelectedIndex];

            // Vérifier que le lot est en attente
            if (lotActuel.ETA_Libelle != "En attente")
            {
                MessageBox.Show("Seuls les lots en attente peuvent être supprimés.",
                    "Impossible", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DialogResult reponse = MessageBox.Show(
                "Voulez-vous vraiment supprimer le lot \"" + lotActuel.LOT_Nom + "\" ?\nLe lot sera marqué comme supprimé.",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reponse != DialogResult.Yes) return;

            try
            {
                // Passer l'état à "En erreur"
                int idErreur = EtatManager.GetIdEtat("En erreur");
                LotManager.ModifierLot(lotActuel.LOT_Nom, lotActuel.LOT_Quantite, idErreur, lotActuel.Id_Recette);

                // Ajouter un événement de traçabilité
                EvenementManager.AjouterEvenement(lotActuel.idLot, "Supprimé");

                MessageBox.Show("Lot marqué comme supprimé.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recharger
                listeLots = LotManager.GetLots();
                RemplirComboBox();
                AfficherLot(0);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Ouvre les détails de la recette associée au lot affiché
        /// </summary>
        private void btnDetailRecette_Click(object sender, EventArgs e)
        {
            Lot lotActuel = listeLots[cboSelectLot.SelectedIndex];

            this.Hide();
            FormDetailsRecette formDetailsRecette = new FormDetailsRecette(lotActuel.REC_Nom);
            formDetailsRecette.ShowDialog();
            this.Show();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lblDateDebut_Click(object sender, EventArgs e)
        {

        }

        private void lblDateFin_Click(object sender, EventArgs e)
        {

        }

        private void lblDateCreation_Click(object sender, EventArgs e)
        {

        }

        private void lblEtat_Click(object sender, EventArgs e)
        {

        }

        private void lblQuantite_Click(object sender, EventArgs e)
        {

        }

        private void lblRecette_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}

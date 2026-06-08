using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormStatistiques : Form
    {
        // ================================================
        // CONSTRUCTEUR
        // ================================================

        /// <summary>
        /// Constructeur du formulaire de statistiques
        /// </summary>
        public FormStatistiques()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        // ================================================
        // CHARGEMENT DU FORMULAIRE
        // ================================================

        /// <summary>
        /// Chargement du formulaire — initialise les contrôles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormStatistiques_Load(object sender, EventArgs e)
        {
            // Remplir le ComboBox des périodes
            cboPeriode.Items.Clear();
            cboPeriode.Items.AddRange(new string[] { "Jour", "Semaine", "Mois", "Année", "Tout" });
            cboPeriode.SelectedIndex = 4; // "Tout" par défaut

            // Dates par défaut
            dtpDu.Value = DateTime.Now.AddMonths(-1);
            dtpAu.Value = DateTime.Now;

            // Calculer les statistiques au chargement
            CalculerStatistiques();
        }

        // ================================================
        // CALCUL DES STATISTIQUES
        // ================================================

        /// <summary>
        /// Calcule et affiche les statistiques des lots selon la période sélectionnée
        /// </summary>
        private void CalculerStatistiques()
        {
            List<Lot> lots = DataManager.GetLots();

            int enAttente = 0;
            int enProduction = 0;
            int termines = 0;
            int enErreur = 0;
            int total = 0;

            foreach (Lot lot in lots)
            {
                // Filtre par période si pas "Tout"
                if (cboPeriode.SelectedItem?.ToString() != "Tout")
                {
                    if (lot.LOT_DateHeureCreation.Date < dtpDu.Value.Date) continue;
                    if (lot.LOT_DateHeureCreation.Date > dtpAu.Value.Date) continue;
                }

                total++;

                // Compter par état
                switch (lot.ETA_Libelle)
                {
                    case "En attente":
                        enAttente++;
                        break;
                    case "En production":
                        enProduction++;
                        break;
                    case "Terminé":
                        termines++;
                        break;
                    case "En erreur":
                        enErreur++;
                        break;
                }
            }

            // Afficher les résultats
            lblEnAttente.Text = enAttente.ToString();
            lblEnProduction.Text = enProduction.ToString();
            lblTermines.Text = termines.ToString();
            lblEnErreur.Text = enErreur.ToString();
            lblTotal.Text = total.ToString();
        }

        // ================================================
        // ÉVÉNEMENTS FILTRES
        // ================================================

        /// <summary>
        /// Changement de période — met à jour les dates automatiquement
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string periode = cboPeriode.SelectedItem?.ToString();

            // Ajuste les dates selon la période choisie
            switch (periode)
            {
                case "Jour":
                    dtpDu.Value = DateTime.Now.Date;
                    dtpAu.Value = DateTime.Now.Date;
                    break;
                case "Semaine":
                    dtpDu.Value = DateTime.Now.AddDays(-7).Date;
                    dtpAu.Value = DateTime.Now.Date;
                    break;
                case "Mois":
                    dtpDu.Value = DateTime.Now.AddMonths(-1).Date;
                    dtpAu.Value = DateTime.Now.Date;
                    break;
                case "Année":
                    dtpDu.Value = DateTime.Now.AddYears(-1).Date;
                    dtpAu.Value = DateTime.Now.Date;
                    break;
                case "Tout":
                    dtpDu.Enabled = false;
                    dtpAu.Enabled = false;
                    break;
            }

            // Réactive les dates si pas "Tout"
            if (periode != "Tout")
            {
                dtpDu.Enabled = true;
                dtpAu.Enabled = true;
            }

            CalculerStatistiques();
        }

        /// <summary>
        /// Changement de la date de début
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDu_ValueChanged(object sender, EventArgs e)
        {
            CalculerStatistiques();
        }

        /// <summary>
        /// Changement de la date de fin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpAu_ValueChanged(object sender, EventArgs e)
        {
            CalculerStatistiques();
        }

        /// <summary>
        /// Bouton actualiser — recalcule les statistiques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnActualiser_Click(object sender, EventArgs e)
        {
            CalculerStatistiques();
        }

        /// <summary>
        /// Bouton fermer
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
        private void label2_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label10_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void lblEnAttente_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void lblEnProduction_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void lblTermines_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void lblEnErreur_Click(object sender, EventArgs e) { }
    }
}
using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormTracabilite : Form
    {
        // ================================================
        // VARIABLES
        // ================================================

        /// <summary>
        /// Liste de tous les événements chargés pour le lot sélectionné
        /// </summary>
        private List<Evenement> tousEvenements = new List<Evenement>();

        /// <summary>
        /// Nom du lot à présélectionner au chargement
        /// </summary>
        private string lotInitial = null;

        // ================================================
        // CONSTRUCTEUR
        // ================================================

        /// <summary>
        /// Constructeur du formulaire de traçabilité
        /// </summary>
        /// <param name="nomLot">Nom du lot à présélectionner, null pour le premier lot</param>
        public FormTracabilite(string nomLot = null)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            dgvEvenements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvenements.ReadOnly = true;
            dgvEvenements.AllowUserToAddRows = false;
            dgvEvenements.RowHeadersVisible = false;
            dgvEvenements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            // Stocker le lot initial pour le sélectionner au Load
            lotInitial = nomLot;
        }

        // ================================================
        // CHARGEMENT DU FORMULAIRE
        // ================================================

        /// <summary>
        /// Chargement du formulaire — remplit le ComboBox des lots
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormTracabilite_Load(object sender, EventArgs e)
        {
            // Initialise les dates par défaut
            dtpDu.Value = DateTime.Now.AddMonths(-1);
            dtpAu.Value = DateTime.Now;

            // Sélectionne "Tous" par défaut
            rbTous.Checked = true;

            // Case cochée de base pour voir toutes les dates
            chkToutesLesDates.Checked = true;

            // Remplit le ComboBox avec les lots
            ChargerComboBoxLots();

            // Présélectionner le lot si fourni
            if (lotInitial != null)
            {
                for (int i = 0; i < cboSelectLot.Items.Count; i++)
                {
                    if (cboSelectLot.Items[i].ToString() == lotInitial)
                    {
                        cboSelectLot.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        // ================================================
        // CHARGEMENT DES DONNÉES
        // ================================================

        /// <summary>
        /// Remplit le ComboBox avec la liste des lots disponibles
        /// </summary>
        private void ChargerComboBoxLots()
        {
            cboSelectLot.Items.Clear();
            List<Lot> lots = DataManager.GetLots();
            foreach (Lot lot in lots)
            {
                cboSelectLot.Items.Add(lot.LOT_Nom);
            }

            if (cboSelectLot.Items.Count > 0)
                cboSelectLot.SelectedIndex = 0;
        }

        /// <summary>
        /// Charge les événements du lot sélectionné
        /// </summary>
        private void ChargerEvenements()
        {
            tousEvenements.Clear();

            if (cboSelectLot.SelectedItem == null) return;

            string nomLot = cboSelectLot.SelectedItem.ToString();

            // Trouver le lot correspondant
            List<Lot> lots = DataManager.GetLots();
            Lot lotTrouve = null;
            foreach (Lot lot in lots)
            {
                if (lot.LOT_Nom == nomLot)
                {
                    lotTrouve = lot;
                    break;
                }
            }

            if (lotTrouve == null) return;

            // Charger tous les événements du lot
            tousEvenements = DataManager.GetEvenements(lotTrouve.idLot);

            // Appliquer les filtres
            AppliquerFiltres();
        }

        /// <summary>
        /// Applique les filtres de date et d'événement sur la liste
        /// </summary>
        private void AppliquerFiltres()
        {
            dgvEvenements.Rows.Clear();

            foreach (Evenement evt in tousEvenements)
            {
                // Filtre par date — ignoré si "Tout afficher" est coché
                if (!chkToutesLesDates.Checked)
                {
                    if (evt.dateHeureEve.Date < dtpDu.Value.Date) continue;
                    if (evt.dateHeureEve.Date > dtpAu.Value.Date) continue;
                }

                // Filtre par type d'événement
                if (rbDebut.Checked && !evt.messageEve.ToLower().Contains("début")) continue;
                if (rbFin.Checked && !evt.messageEve.ToLower().Contains("fin")) continue;
                if (rbAlarmes.Checked &&
                    !evt.messageEve.ToLower().Contains("alarme") &&
                    !evt.messageEve.ToLower().Contains("barrière") &&
                    !evt.messageEve.ToLower().Contains("erreur")) continue;

                // Ajouter la ligne
                dgvEvenements.Rows.Add(
                    evt.dateHeureEve.ToString("dd/MM/yyyy"),
                    evt.dateHeureEve.ToString("HH:mm:ss"),
                    evt.messageEve
                );
            }
        }

        // ================================================
        // ÉVÉNEMENTS FILTRES
        // ================================================

        /// <summary>
        /// Sélection d'un lot dans le ComboBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSelectLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerEvenements();
        }

        /// <summary>
        /// Changement de la date de début
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpDu_ValueChanged(object sender, EventArgs e)
        {
            AppliquerFiltres();
        }

        /// <summary>
        /// Changement de la date de fin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtpAu_ValueChanged(object sender, EventArgs e)
        {
            AppliquerFiltres();
        }

        /// <summary>
        /// Filtre — Tous les événements
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbTous_CheckedChanged(object sender, EventArgs e)
        {
            if (rbTous.Checked) AppliquerFiltres();
        }

        /// <summary>
        /// Filtre — Événements de début
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbDebut_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDebut.Checked) AppliquerFiltres();
        }

        /// <summary>
        /// Filtre — Événements de fin
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbFin_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFin.Checked) AppliquerFiltres();
        }

        /// <summary>
        /// Filtre — Alarmes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rbAlarmes_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAlarmes.Checked) AppliquerFiltres();
        }

        /// <summary>
        /// Case à cocher pour ignorer le filtre de date
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void chkToutesLesDates_CheckedChanged(object sender, EventArgs e)
        {
            // Désactive les DateTimePickers si toutes les dates sont affichées
            dtpDu.Enabled = !chkToutesLesDates.Checked;
            dtpAu.Enabled = !chkToutesLesDates.Checked;
            AppliquerFiltres();
        }

        // ================================================
        // ÉVÉNEMENTS BOUTONS
        // ================================================

        /// <summary>
        /// Bouton pour exporter les événements en PDF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExporterPDF_Click(object sender, EventArgs e)
        {
            if (dgvEvenements.Rows.Count == 0)
            {
                MessageBox.Show("Aucun événement à exporter.",
                    "Export PDF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "Fichier PDF (*.pdf)|*.pdf";
            saveDialog.FileName = "Tracabilite_" + cboSelectLot.SelectedItem.ToString() + "_" + DateTime.Now.ToString("yyyyMMdd");

            if (saveDialog.ShowDialog() != DialogResult.OK) return;

            try
            {
                PdfSharp.Pdf.PdfDocument document = new PdfSharp.Pdf.PdfDocument();
                document.Info.Title = "Historique de Tracabilite";

                PdfSharp.Pdf.PdfPage page = document.AddPage();
                PdfSharp.Drawing.XGraphics gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);

                // Polices
                PdfSharp.Drawing.XFont fontTitre = new PdfSharp.Drawing.XFont("Arial", 16);
                PdfSharp.Drawing.XFont fontNormal = new PdfSharp.Drawing.XFont("Arial", 10);
                PdfSharp.Drawing.XFont fontEntete = new PdfSharp.Drawing.XFont("Arial", 10);

                double y = 40;

                // Titre
                gfx.DrawString("Historique de Tracabilite - Lot : " + cboSelectLot.SelectedItem.ToString(),
                    fontTitre, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(40, y, page.Width - 80, 30),
                    PdfSharp.Drawing.XStringFormats.TopLeft);
                y += 30;

                // Date export
                gfx.DrawString("Exporte le : " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"),
                    fontNormal, PdfSharp.Drawing.XBrushes.Black,
                    new PdfSharp.Drawing.XRect(40, y, page.Width - 80, 20),
                    PdfSharp.Drawing.XStringFormats.TopLeft);
                y += 30;

                // Colonnes
                double colDate = 40;
                double colHeure = 140;
                double colEvenement = 240;
                double hauteurLigne = 20;

                // En-têtes
                gfx.DrawRectangle(PdfSharp.Drawing.XBrushes.LightGray,
                    colDate, y, page.Width - 80, hauteurLigne);
                gfx.DrawString("Date", fontEntete, PdfSharp.Drawing.XBrushes.Black, colDate + 2, y + 14);
                gfx.DrawString("Heure", fontEntete, PdfSharp.Drawing.XBrushes.Black, colHeure + 2, y + 14);
                gfx.DrawString("Evenement", fontEntete, PdfSharp.Drawing.XBrushes.Black, colEvenement + 2, y + 14);
                y += hauteurLigne;

                // Lignes
                foreach (DataGridViewRow row in dgvEvenements.Rows)
                {
                    // Nouvelle page si nécessaire
                    if (y > page.Height - 60)
                    {
                        page = document.AddPage();
                        gfx = PdfSharp.Drawing.XGraphics.FromPdfPage(page);
                        y = 40;
                    }

                    string date = row.Cells[0].Value?.ToString() ?? "";
                    string heure = row.Cells[1].Value?.ToString() ?? "";
                    string evenement = row.Cells[2].Value?.ToString() ?? "";

                    gfx.DrawString(date, fontNormal, PdfSharp.Drawing.XBrushes.Black, colDate + 2, y + 14);
                    gfx.DrawString(heure, fontNormal, PdfSharp.Drawing.XBrushes.Black, colHeure + 2, y + 14);
                    gfx.DrawString(evenement, fontNormal, PdfSharp.Drawing.XBrushes.Black, colEvenement + 2, y + 14);

                    // Ligne séparatrice
                    gfx.DrawLine(PdfSharp.Drawing.XPens.LightGray,
                        colDate, y + hauteurLigne, page.Width - 40, y + hauteurLigne);

                    y += hauteurLigne;
                }

                document.Save(saveDialog.FileName);

                MessageBox.Show("PDF exporte avec succes !\n" + saveDialog.FileName,
                    "Export PDF", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'export PDF : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Bouton pour fermer le formulaire
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
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
        private void dgvEvenements_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void checkBox1_CheckedChanged(object sender, EventArgs e) { }
    }
}
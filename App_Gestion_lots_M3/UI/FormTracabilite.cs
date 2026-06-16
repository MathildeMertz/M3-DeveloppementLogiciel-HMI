/* ECOLE TECHNIQUE PORRENTRUY          
   Département informatique            
   Enseignant responsable : D. Montavon
   _____________________________________
    Nom du fichier  : FormTracabilite.cs
    Type de fichier : Programme C#
    Auteur          : Ryf Frédéric / Mertz Mathilde
    Date            : 16 juin 2026
    But             : Fenêtre pour voir l'historique du projet
*/

using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormTracabilite : Form
    {
        /// <summary>
        /// Liste de tous les événements chargés pour le lot sélectionné
        /// </summary>
        private List<Evenement> tousEvenements = new List<Evenement>();

        /// <summary>
        /// Nom du lot à présélectionner au chargement
        /// </summary>
        private string lotInitial = null;

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

        /// <summary>
        /// Remplit le ComboBox avec la liste des lots disponibles
        /// </summary>
        private void ChargerComboBoxLots()
        {
            cboSelectLot.Items.Clear();
            List<Lot> lots = LotManager.GetLots();
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
            List<Lot> lots = LotManager.GetLots();
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
            tousEvenements = EvenementManager.GetEvenements(lotTrouve.idLot);

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
                QuestPDF.Settings.License = LicenseType.Community;

                string nomLot = cboSelectLot.SelectedItem.ToString();
                string dateExport = DateTime.Now.ToString("dd/MM/yyyy HH:mm");

                // Récupérer le lot pour avoir la recette
                Lot lotActuel = null;
                foreach (Lot l in LotManager.GetLots())
                {
                    if (l.LOT_Nom == nomLot)
                    {
                        lotActuel = l;
                        break;
                    }
                }

                // Récupérer les opérations de la recette du lot
                List<Operation> operations = new List<Operation>();
                if (lotActuel != null)
                    operations = OperationManager.GetOperations(lotActuel.Id_Recette);

                // Copie les lignes du tableau événements
                List<string[]> lignes = new List<string[]>();
                foreach (DataGridViewRow row in dgvEvenements.Rows)
                {
                    string date = row.Cells[0].Value?.ToString() ?? "";
                    string heure = row.Cells[1].Value?.ToString() ?? "";
                    string evenement = row.Cells[2].Value?.ToString() ?? "";
                    lignes.Add(new string[] { date, heure, evenement });
                }

                Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(40);

                        page.Content().Column(col =>
                        {
                            col.Item().Text("Historique de Tracabilite - Lot : " + nomLot)
                                .FontSize(16);

                            col.Item().PaddingTop(5).Text("Exporte le : " + dateExport)
                                .FontSize(10);

                            col.Item().PaddingTop(15).Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(6);
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Background("#CCCCCC").Padding(5).Text("Date").FontSize(10);
                                    header.Cell().Background("#CCCCCC").Padding(5).Text("Heure").FontSize(10);
                                    header.Cell().Background("#CCCCCC").Padding(5).Text("Evenement").FontSize(10);
                                });

                                foreach (string[] ligne in lignes)
                                {
                                    table.Cell().BorderBottom(1).BorderColor("#DDDDDD").Padding(5).Text(ligne[0]).FontSize(9);
                                    table.Cell().BorderBottom(1).BorderColor("#DDDDDD").Padding(5).Text(ligne[1]).FontSize(9);
                                    table.Cell().BorderBottom(1).BorderColor("#DDDDDD").Padding(5).Text(ligne[2]).FontSize(9);
                                }
                            });

                            if (lotActuel != null)
                            {
                                col.Item().PaddingTop(25).Text("Recette associee : " + lotActuel.REC_Nom)
                                    .FontSize(13);

                                col.Item().PaddingTop(5).Text("Nombre d'operations : " + operations.Count)
                                    .FontSize(10);

                                col.Item().PaddingTop(10).Table(table =>
                                {
                                    table.ColumnsDefinition(columns =>
                                    {
                                        columns.RelativeColumn(1); // No
                                        columns.RelativeColumn(3); // Nom
                                        columns.RelativeColumn(2); // Position
                                        columns.RelativeColumn(2); // Sens
                                        columns.RelativeColumn(2); // Temps
                                        columns.RelativeColumn(2); // Cycle vérin
                                        columns.RelativeColumn(2); // Quittance
                                    });

                                    table.Header(header =>
                                    {
                                        header.Cell().Background("#CCCCCC").Padding(5).Text("No").FontSize(10);
                                        header.Cell().Background("#CCCCCC").Padding(5).Text("Nom").FontSize(10);
                                        header.Cell().Background("#CCCCCC").Padding(5).Text("Position").FontSize(10);
                                        header.Cell().Background("#CCCCCC").Padding(5).Text("Sens").FontSize(10);
                                        header.Cell().Background("#CCCCCC").Padding(5).Text("Temps (s)").FontSize(10);
                                        header.Cell().Background("#CCCCCC").Padding(5).Text("Cycle verin").FontSize(10);
                                        header.Cell().Background("#CCCCCC").Padding(5).Text("Quittance").FontSize(10);
                                    });

                                    foreach (Operation op in operations)
                                    {
                                        table.Cell().BorderBottom(1).BorderColor("#DDDDDD").Padding(5).Text(op.noOpe.ToString()).FontSize(9);
                                        table.Cell().BorderBottom(1).BorderColor("#DDDDDD").Padding(5).Text(op.nomOpe).FontSize(9);
                                        table.Cell().BorderBottom(1).BorderColor("#DDDDDD").Padding(5).Text(op.posMoteurOpe.ToString()).FontSize(9);
                                        table.Cell().BorderBottom(1).BorderColor("#DDDDDD").Padding(5).Text(op.sensMoteurOpe.ToString()).FontSize(9);
                                        table.Cell().BorderBottom(1).BorderColor("#DDDDDD").Padding(5).Text(op.tempsAttenteOpe.ToString()).FontSize(9);
                                        table.Cell().BorderBottom(1).BorderColor("#DDDDDD").Padding(5).Text(op.cycleVerrinOpe.ToString()).FontSize(9);
                                        table.Cell().BorderBottom(1).BorderColor("#DDDDDD").Padding(5).Text(op.quittanceOpe ? "Oui" : "Non").FontSize(9);
                                    }
                                });
                            }
                        });
                    });
                }).GeneratePdf(saveDialog.FileName);

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
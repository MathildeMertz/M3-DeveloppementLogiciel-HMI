using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using App_Gestion_lots_M3.UI;

namespace App_Gestion_lots_M3
{
    public partial class Form1 : Form
    {
        // ================================================
        // CONSTRUCTEUR
        // ================================================
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ChargerLots();
            ChargerRecettes();
        }

        // ================================================
        // CHARGEMENT DES DONNÉES
        // ================================================
        private void ChargerLots()
        {
            dgvLots.Rows.Clear();

            List<Lot> lots = DAL.GetLots();
            foreach (Lot lot in lots)
            {
                dgvLots.Rows.Add(
                    lot.LOT_Nom,
                    lot.LOT_Quantite,
                    lot.REC_Nom,
                    lot.ETA_Libelle
                );
            }
        }

        private void ChargerRecettes()
        {
            dgvRecettes.Rows.Clear();

            List<Recette> recettes = DAL.GetRecettes();
            foreach (Recette recette in recettes)
            {
                dgvRecettes.Rows.Add(
                    recette.REC_Nom,
                    recette.REC_DateHeureCreation.ToString("dd/MM/yyyy HH:mm")
                );
            }
        }

        // ================================================
        // NAVIGATION LOTS
        // ================================================
        private void btnNouveauLot_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionLot formGestionLot = new FormGestionLot(null);
            formGestionLot.ShowDialog();
            ChargerLots();
            this.Show();
        }

        private void btnModifierLot_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (dgvLots.SelectedRows.Count > 0)
            {
                // Lot sélectionné → ouvre FormGestionLot en mode modification
                string nomLot = dgvLots.SelectedRows[0].Cells["colNomLot"].Value.ToString();
                Lot lotSelectionne = DAL.GetLots().Find(l => l.LOT_Nom == nomLot);
                FormGestionLot formGestionLot = new FormGestionLot(lotSelectionne);
                formGestionLot.ShowDialog();
            }
            else
            {
                // Aucun lot sélectionné → ouvre FormDetailsLot sur le premier lot
                FormDetailsLot formDetailLot = new FormDetailsLot(null);
                formDetailLot.ShowDialog();
            }

            ChargerLots();
            this.Show();
        }

        private void dgvLots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nomLot = dgvLots.Rows[e.RowIndex].Cells["colNomLot"].Value.ToString();

            this.Hide();
            FormDetailsLot formDetailLot = new FormDetailsLot(nomLot);
            formDetailLot.ShowDialog();
            ChargerLots();
            this.Show();
        }

        // ================================================
        // NAVIGATION RECETTES
        // ================================================
        private void btnNouvelleRecette_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionRecette formGestionRecette = new FormGestionRecette();
            formGestionRecette.ShowDialog();
            ChargerRecettes();
            this.Show();
        }

        // ================================================
        // NAVIGATION TRAÇABILITÉ
        // ================================================
        private void btnVoirTracabilite_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTracabilite formTracabilite = new FormTracabilite();
            formTracabilite.ShowDialog();
            this.Show();
        }

        // ================================================
        // NAVIGATION STATISTIQUES
        // ================================================
        private void btnVoirStatistiques_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormStatistiques formStatistiques = new FormStatistiques();
            formStatistiques.ShowDialog();
            this.Show();
        }

        // ================================================
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void dgvLots_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvRecettes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Lots_Click(object sender, EventArgs e) { }
    }
}
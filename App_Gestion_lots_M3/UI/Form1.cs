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
        // NAVIGATION
        // ================================================
        private void btnNouveauLot_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionLot formGestionLot = new FormGestionLot();
            formGestionLot.ShowDialog();
            ChargerLots();
            this.Show();
        }

        private void btnNouvelleRecette_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionRecette formGestionRecette = new FormGestionRecette();
            formGestionRecette.ShowDialog();
            ChargerRecettes();
            this.Show();
        }

        private void btnModifierLot_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormDetailsLot formDetailLot;

            if (dgvLots.SelectedRows.Count > 0)
            {
                // Un lot est sélectionné → on l'ouvre directement
                string nomLot = dgvLots.SelectedRows[0].Cells["colNomLot"].Value.ToString();
                formDetailLot = new FormDetailsLot(nomLot);
            }
            else
            {
                // Aucun lot sélectionné → on ouvre LOT001 par défaut
                formDetailLot = new FormDetailsLot(null);
            }

            formDetailLot.ShowDialog();
            ChargerLots();
            this.Show();
        }

        private void btnVoirTracabilite_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTracabilite formTracabilite = new FormTracabilite();
            formTracabilite.ShowDialog();
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormStatistiques formStatistique = new FormStatistiques();
            formStatistique.ShowDialog();
            this.Show();
        }

        // ================================================
        // DOUBLE CLIC SUR UN LOT → FormDetailsLot
        // ================================================
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
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void dgvLots_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Lots_Click(object sender, EventArgs e) { }

        private void dgvRecettes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
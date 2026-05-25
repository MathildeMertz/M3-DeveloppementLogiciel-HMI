using App_Gestion_lots_M3.UI;

namespace App_Gestion_lots_M3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void btnNouveauLot_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionLot formGestionLot = new FormGestionLot();
            formGestionLot.ShowDialog();
            this.Show();
        }

        private void btnNouvelleRecette_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionRecette formGestionRecette = new FormGestionRecette();
            formGestionRecette.ShowDialog();
            this.Show();
        }

        // Bouton "Modifier Lots" → ouvre FormDetailsLot
        private void btnModifierLot_Click(object sender, EventArgs e)
        {
            this.Hide();
<<<<<<< Updated upstream
            FormGestionLot formGestionLot = new FormGestionLot();
            formGestionLot.ShowDialog();
            this.Show();
        }

=======

            if (dgvLots.SelectedRows.Count > 0)
            {
                string nomLot = dgvLots.SelectedRows[0].Cells["colNomLot"].Value.ToString();
                FormDetailsLot formDetailLot = new FormDetailsLot(nomLot);
                formDetailLot.ShowDialog();
            }
            else
            {
                FormDetailsLot formDetailLot = new FormDetailsLot(null);
                formDetailLot.ShowDialog();
            }

            ChargerLots();
            this.Show();
        }

        // Double-clic sur un lot → ouvre FormDetailsLot
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
            FormGestionRecette formGestionRecette = new FormGestionRecette(null);
            formGestionRecette.ShowDialog();
            ChargerRecettes();
            this.Show();
        }

        // ================================================
        // NAVIGATION TRAÇABILITÉ
        // ================================================
>>>>>>> Stashed changes
        private void btnVoirTracabilite_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTracabilite formTracabilite = new FormTracabilite();
            formTracabilite.ShowDialog();
            this.Show();
        }

        private void Historique_Click(object sender, EventArgs e)
        {

        }

<<<<<<< Updated upstream
        private void Recette_Click(object sender, EventArgs e)
        {

        }

        private void dgvLots_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Lots_Click(object sender, EventArgs e)
        {

        }
=======
        // ================================================
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void dgvLots_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvRecettes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Lots_Click(object sender, EventArgs e) { } 
>>>>>>> Stashed changes
    }
}
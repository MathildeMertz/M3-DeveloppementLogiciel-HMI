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
            FormGestionLot formGestionLot = new FormGestionLot(null);
            formGestionLot.ShowDialog();
            this.Show();
        }

        private void btnModifierLot_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (dgvLots.SelectedRows.Count > 0)
            {
                string nomLot = dgvLots.SelectedRows[0].Cells["colNomLot"].Value.ToString();
                FormDetailsLot formDetailLot = new FormDetailsLot(nomLot);
                formDetailLot.ShowDialog();
            }

            this.Show();
        }

        private void dgvLots_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nomLot = dgvLots.Rows[e.RowIndex].Cells["colNomLot"].Value.ToString();
            this.Hide();
            FormDetailsLot formDetailLot = new FormDetailsLot(nomLot);
            formDetailLot.ShowDialog();
            this.Show();
        }

        private void btnNouvelleRecette_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionRecette formGestionRecette = new FormGestionRecette(null);
            formGestionRecette.ShowDialog();
            this.Show();
        }

        private void btnVoirTracabilite_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTracabilite formTracabilite = new FormTracabilite();
            formTracabilite.ShowDialog();
            this.Show();
        }

        private void Historique_Click(object sender, EventArgs e) { }
        private void Recette_Click(object sender, EventArgs e) { }
        private void Lots_Click(object sender, EventArgs e) { }
        private void dgvLots_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvRecettes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
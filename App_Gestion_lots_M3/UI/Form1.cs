using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using App_Gestion_lots_M3.UI;

namespace App_Gestion_lots_M3
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            ChargerLots();
            ChargerRecettes();
        }

        /// <summary>
        /// Chargement des données du Lot
        /// </summary>
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
        /// <summary>
        /// Chargement des données de la Recette
        /// </summary>
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

        /// <summary>
        /// Bouton pour un nouveau lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNouveauLot_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionLot formGestionLot = new FormGestionLot(null);
            formGestionLot.ShowDialog();
            ChargerLots();
            this.Show();
        }
        /// <summary>
        /// Bouton Détail lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailLot_Click(object sender, EventArgs e)
        {
            this.Hide();

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
        /// <summary>
        /// Double clique pour le lot
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Bouton nouvelle recette
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNouvelleRecette_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionRecette formGestionRecette = new FormGestionRecette(null);
            formGestionRecette.ShowDialog();
            ChargerRecettes();
            this.Show();
        }
        /// <summary>
        /// Bouton détail de la recette
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDetailRecette_Click(object sender, EventArgs e)
        {
            this.Hide();

            if (dgvRecettes.SelectedRows.Count > 0)
            {
                string nomRecette = dgvRecettes.SelectedRows[0].Cells["colNomRecette"].Value.ToString();
                FormDetailsRecette formDetailsRecette = new FormDetailsRecette(nomRecette);
                formDetailsRecette.ShowDialog();
            }
            else
            {
                FormDetailsRecette formDetailsRecette = new FormDetailsRecette(null);
                formDetailsRecette.ShowDialog();
            }

            ChargerRecettes();
            this.Show();
        }
        /// <summary>
        /// Double clique pour le tableau de la recette
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvRecettes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            string nomRecette = dgvRecettes.Rows[e.RowIndex].Cells["colNomRecette"].Value.ToString();
            this.Hide();
            FormDetailsRecette formDetailsRecette = new FormDetailsRecette(nomRecette);
            formDetailsRecette.ShowDialog();
            ChargerRecettes();
            this.Show();
        }

        /// <summary>
        /// Boutuon pour voir l'historique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVoirTracabilite_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTracabilite formTracabilite = new FormTracabilite();
            formTracabilite.ShowDialog();
            this.Show();
        }

       /// <summary>
       /// Bouton pour voir les statistique
       /// </summary>
       /// <param name="sender"></param>
       /// <param name="e"></param>
        private void btnVoirStatistiques_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormStatistiques formStatistiques = new FormStatistiques();
            formStatistiques.ShowDialog();
            this.Show();
        }

        // ================================================
        // Autres
        // ================================================
        private void dgvLots_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvRecettes_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvRecettes_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void dgvTracabilite_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void cboSelectLotTrace_SelectedIndexChanged(object sender, EventArgs e) { }
        private void Lots_Click(object sender, EventArgs e) { }
        private void Historique_Click(object sender, EventArgs e) { }
        private void Recette_Click(object sender, EventArgs e) { }
    }
}
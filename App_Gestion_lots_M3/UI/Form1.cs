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

            // Configuration des grilles APRÈS InitializeComponent
            dgvLots.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvRecettes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTracabilite.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            ChargerLots();
            ChargerRecettes();
            ChargerDerniersEvenements();
        }

        // ================================================
        // CHARGEMENT DES DONNÉES
        // ================================================

        /// <summary>
        /// Chargement des données des lots dans le tableau
        /// </summary>
        private void ChargerLots()
        {
            dgvLots.Rows.Clear();
            List<Lot> lots = LotManager.GetLots();
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
        /// Chargement des données des recettes dans le tableau
        /// </summary>
        private void ChargerRecettes()
        {
            dgvRecettes.Rows.Clear();
            List<Recette> recettes = RecetteManager.GetRecettes();
            foreach (Recette recette in recettes)
            {
                int nbOperations = OperationManager.GetNombreOperations(recette.Id_Recette);
                dgvRecettes.Rows.Add(
                    recette.REC_Nom,
                    recette.REC_DateHeureCreation.ToString("dd/MM/yyyy HH:mm"),
                    nbOperations
                );
            }
        }

        /// <summary>
        /// Charge les 10 derniers événements de tous les lots dans l'onglet Traçabilité
        /// </summary>
        private void ChargerDerniersEvenements()
        {
            dgvTracabilite.Rows.Clear();

            // Récupère tous les événements de tous les lots
            List<Evenement> tousEvenements = new List<Evenement>();
            List<Lot> lots = LotManager.GetLots();
            foreach (Lot lot in lots)
            {
                List<Evenement> evts = EvenementManager.GetEvenements(lot.idLot);
                foreach (Evenement evt in evts)
                    tousEvenements.Add(evt);
            }

            // Trier par date décroissante
            tousEvenements.Sort((a, b) => b.dateHeureEve.CompareTo(a.dateHeureEve));

            // Afficher les 10 derniers
            int compteur = 0;
            foreach (Evenement evt in tousEvenements)
            {
                if (compteur >= 10) break;
                dgvTracabilite.Rows.Add(
                    evt.dateHeureEve.ToString("dd/MM/yyyy"),
                    evt.dateHeureEve.ToString("HH:mm:ss"),
                    evt.messageEve
                );
                compteur++;
            }
        }

        // ================================================
        // NAVIGATION LOTS
        // ================================================

        /// <summary>
        /// Bouton pour créer un nouveau lot
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
        /// Bouton pour voir le détail d'un lot
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
        /// Double clic sur un lot pour voir son détail
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

        // ================================================
        // NAVIGATION RECETTES
        // ================================================

        /// <summary>
        /// Bouton pour créer une nouvelle recette
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
        /// Bouton pour voir le détail d'une recette
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
        /// Double clic sur une recette pour voir son détail
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

        // ================================================
        // NAVIGATION TRAÇABILITÉ
        // ================================================

        /// <summary>
        /// Bouton pour voir l'historique complet dans FormTracabilite
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVoirTracabilite_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTracabilite formTracabilite = new FormTracabilite();
            formTracabilite.ShowDialog();
            ChargerDerniersEvenements();
            this.Show();
        }

        /// <summary>
        /// Bouton pour voir les statistiques
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVoirStatistiques_Click_1(object sender, EventArgs e)
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
        private void dgvRecettes_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void dgvTracabilite_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Lots_Click(object sender, EventArgs e) { }
        private void Historique_Click(object sender, EventArgs e) { }
        private void Recette_Click(object sender, EventArgs e) { }
    }
}
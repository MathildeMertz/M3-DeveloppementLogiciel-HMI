namespace App_Gestion_lots_M3.UI
{
    public partial class FormTracabilite : Form
    {
        // ================================================
        // CONSTRUCTEUR
        // ================================================
        public FormTracabilite()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            RemplirComboBoxLots();
            rbTous.Checked = true;
            dtpDu.Value = DateTime.Now.AddDays(-7);
            dtpAu.Value = DateTime.Now;
        }

        // ================================================
        // INITIALISATION
        // ================================================
        private void RemplirComboBoxLots()
        {
            // Sera remplacé par les données de la BDD plus tard
            cboSelectLot.Items.Clear();
            cboSelectLot.Items.Add("Lot001");
            cboSelectLot.Items.Add("Lot002");
            cboSelectLot.Items.Add("Lot003");
        }

        // ================================================
        // CHARGEMENT DES ÉVÉNEMENTS
        // ================================================
        private void ChargerEvenements()
        {
            dgvEvenements.Rows.Clear();

            string lotSelectionne = cboSelectLot.SelectedItem?.ToString() ?? "";

            if (lotSelectionne == "")
            {
                MessageBox.Show("Veuillez sélectionner un lot.",
                    "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Données de démo — sera remplacé par BDD plus tard
            if (lotSelectionne == "Lot001")
            {
                AjouterEvenement("21/04/2026", "10:15", "Début du lot");
                AjouterEvenement("21/04/2026", "10:16", "Début de la pièce 1");
                AjouterEvenement("21/04/2026", "10:20", "Fin de la pièce 1");
                AjouterEvenement("21/04/2026", "10:25", "Alarme - Barrière lumineuse coupée");
            }
            else if (lotSelectionne == "Lot002")
            {
                AjouterEvenement("20/04/2026", "08:00", "Début du lot");
                AjouterEvenement("20/04/2026", "08:30", "Fin du lot");
            }

            AppliquerFiltre();
        }

        private void AjouterEvenement(string date, string heure, string evenement)
        {
            dgvEvenements.Rows.Add(date, heure, evenement);
        }

        // ================================================
        // FILTRAGE DES ÉVÉNEMENTS
        // ================================================
        private void AppliquerFiltre()
        {
            foreach (DataGridViewRow row in dgvEvenements.Rows)
            {
                if (row.IsNewRow) continue;

                string evenement = row.Cells["colEvenement"].Value?.ToString() ?? "";
                bool visible = true;

                if (rbDebut.Checked)
                    visible = evenement.Contains("Début");
                else if (rbFin.Checked)
                    visible = evenement.Contains("Fin");
                else if (rbAlarmes.Checked)
                    visible = evenement.Contains("Alarme");

                row.Visible = visible;
            }
        }

        // ================================================
        // ÉVÉNEMENTS
        // ================================================
        private void cboSelectLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerEvenements();
        }

        private void rbTous_CheckedChanged(object sender, EventArgs e)
        {
            AppliquerFiltre();
        }

        private void rbDebut_CheckedChanged(object sender, EventArgs e)
        {
            AppliquerFiltre();
        }

        private void rbFin_CheckedChanged(object sender, EventArgs e)
        {
            AppliquerFiltre();
        }

        private void rbAlarmes_CheckedChanged(object sender, EventArgs e)
        {
            AppliquerFiltre();
        }

        private void dtpDu_ValueChanged(object sender, EventArgs e)
        {
            ChargerEvenements();
        }

        private void dtpAu_ValueChanged(object sender, EventArgs e)
        {
            ChargerEvenements();
        }

        private void btnExporterPDF_Click(object sender, EventArgs e)
        {
            // Export PDF à implémenter plus tard
            MessageBox.Show("Export PDF sera disponible prochainement.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

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
    }
}
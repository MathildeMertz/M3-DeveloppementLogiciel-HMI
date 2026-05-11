namespace App_Gestion_lots_M3.UI
{
    public partial class FormGestionRecette : Form
    {
        // ================================================
        // CONSTRUCTEUR
        // ================================================
        public FormGestionRecette()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            txtDateCreation.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtDateCreation.ReadOnly = true;
        }

        // ================================================
        // VALIDATION
        // ================================================
        private bool ValiderFormulaire()
        {
            if (string.IsNullOrWhiteSpace(txtNomRecette.Text))
            {
                MessageBox.Show("Le nom de la recette est obligatoire.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomRecette.Focus();
                return false;
            }

            if (dgvOperations.Rows.Count == 0)
            {
                MessageBox.Show("La recette doit contenir au moins une opération.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        // ================================================
        // DIALOG AJOUTER OPÉRATION
        // ================================================
        private void AfficherDialogOperation()
        {
            Form dlg = new Form();
            dlg.Text = "Ajouter une Opération";
            dlg.Size = new Size(320, 220);
            dlg.StartPosition = FormStartPosition.CenterParent;
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlg.MaximizeBox = false;
            dlg.BackColor = Color.White;

            Label lblPos = new Label();
            lblPos.Text = "Position (1-5) :";
            lblPos.Location = new Point(15, 20);
            lblPos.AutoSize = true;

            NumericUpDown nudPosition = new NumericUpDown();
            nudPosition.Location = new Point(160, 17);
            nudPosition.Size = new Size(100, 25);
            nudPosition.Minimum = 1;
            nudPosition.Maximum = 5;

            Label lblTemps = new Label();
            lblTemps.Text = "Temps d'arrêt (s) :";
            lblTemps.Location = new Point(15, 60);
            lblTemps.AutoSize = true;

            NumericUpDown nudTemps = new NumericUpDown();
            nudTemps.Location = new Point(160, 57);
            nudTemps.Size = new Size(100, 25);
            nudTemps.Minimum = 0;
            nudTemps.Maximum = 9999;

            Label lblQuittance = new Label();
            lblQuittance.Text = "Quittance manuelle :";
            lblQuittance.Location = new Point(15, 100);
            lblQuittance.AutoSize = true;

            ComboBox cboQuittance = new ComboBox();
            cboQuittance.Location = new Point(160, 97);
            cboQuittance.Size = new Size(100, 25);
            cboQuittance.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuittance.Items.AddRange(new string[] { "Oui", "Non" });
            cboQuittance.SelectedIndex = 1;

            Button btnOk = new Button();
            btnOk.Text = "Ajouter";
            btnOk.Location = new Point(60, 140);
            btnOk.Size = new Size(90, 30);
            btnOk.DialogResult = DialogResult.OK;

            Button btnAnnuler = new Button();
            btnAnnuler.Text = "Annuler";
            btnAnnuler.Location = new Point(165, 140);
            btnAnnuler.Size = new Size(90, 30);
            btnAnnuler.DialogResult = DialogResult.Cancel;

            dlg.Controls.AddRange(new Control[]
            {
                lblPos, nudPosition,
                lblTemps, nudTemps,
                lblQuittance, cboQuittance,
                btnOk, btnAnnuler
            });

            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnAnnuler;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                dgvOperations.Rows.Add(
                    (int)nudPosition.Value,
                    (int)nudTemps.Value,
                    cboQuittance.SelectedItem.ToString()
                );
            }
        }

        // ================================================
        // ÉVÉNEMENTS BOUTONS
        // ================================================
        private void btnAjouterOperation_Click(object sender, EventArgs e)
        {
            if (dgvOperations.Rows.Count >= 10)
            {
                MessageBox.Show("Maximum 10 opérations par recette.",
                    "Limite atteinte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AfficherDialogOperation();
        }

        private void btnSupprimerOperation_Click(object sender, EventArgs e)
        {
            if (dgvOperations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une opération.",
                    "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult reponse = MessageBox.Show(
                "Supprimer cette opération ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reponse == DialogResult.Yes)
            {
                dgvOperations.Rows.Remove(dgvOperations.SelectedRows[0]);
            }
        }

        private void btnEnregistrerRecette_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            // Connexion base de données à faire plus tard
            MessageBox.Show("Recette enregistrée avec succès !",
                "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormGestionRecette : Form
    {

        private static readonly string[] POSITION_MOTEUR = { "Aucun", "3H", "6H", "9H", "12H" };
        private static readonly string[] SENS_ROTATION = { "Horaire", "Anti-Horaire" };
        private static readonly string[] ETAT_CYCLE_VERRIN = { "Oui", "Non" };


        // Recette en cours de modification, null si nouvelle recette
        private Recette recetteEnCours;

        // Indique si on crée une nouvelle recette ou si on modifie une existante
        private bool estNouvelleRecette;


        /// <summary>
        /// Constructeur du formulaire
        /// </summary>
        /// <param name="recette">Recette à modifier, null pour une nouvelle recette</param>
        public FormGestionRecette(Recette recette)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            recetteEnCours = recette;
            estNouvelleRecette = (recette == null);
        }


        /// <summary>
        /// Événement déclenché au chargement du formulaire
        /// </summary>
        private void FormGestionRecette_Load(object sender, EventArgs e)
        {
            ConfigurerGrille();
            ConfigurerFormulaire();
        }


        /// <summary>
        /// Configure les propriétés du DataGridView des opérations
        /// </summary>
        private void ConfigurerGrille()
        {
            // Sélection par ligne entière pour faciliter la suppression
            dgvOperations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperations.MultiSelect = false;
            dgvOperations.AllowUserToAddRows = false;
            dgvOperations.RowHeadersVisible = false;
            dgvOperations.ReadOnly = true;
            dgvOperations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }



        /// <summary>
        /// Configure le formulaire selon le mode (nouvelle recette ou modification)
        /// </summary>
        private void ConfigurerFormulaire()
        {
            // La date est toujours en lecture seule
            txtDateCreation.ReadOnly = true;
            txtDateCreation.BackColor = Color.FromArgb(240, 240, 240);

            if (estNouvelleRecette)
            {
                // Mode nouvelle recette : champs vides
                this.Text = "Nouvelle Recette";
                txtNomRecette.Text = "";
                txtDateCreation.Text = DateTime.Now.ToString("dd/MM/yyyy");
                btnEnregistrerRecette.Text = "Enregistrer Recette";
            }
            else
            {
                // Mode modification : champs pré-remplis
                this.Text = "Modifier Recette - " + recetteEnCours.REC_Nom;
                txtNomRecette.Text = recetteEnCours.REC_Nom;
                txtNomRecette.ReadOnly = true;
                txtNomRecette.BackColor = Color.FromArgb(240, 240, 240);
                txtDateCreation.Text = recetteEnCours.REC_DateHeureCreation.ToString("dd/MM/yyyy");
                btnEnregistrerRecette.Text = "Enregistrer modifications";
                ChargerOperations();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void ChargerOperations()
        {
            dgvOperations.Rows.Clear();
            List<Operation> operations = DataManager.GetOperations(recetteEnCours.Id_Recette);

            foreach (Operation op in operations)
            {
                string position = op.posMoteurOpe < POSITION_MOTEUR.Length ? POSITION_MOTEUR[op.posMoteurOpe] : op.posMoteurOpe.ToString();
                string sens = op.sensMoteurOpe < SENS_ROTATION.Length ? SENS_ROTATION[op.sensMoteurOpe] : op.sensMoteurOpe.ToString();
                string cycleVerin = op.cycleVerrinOpe == 1 ? "Oui" : "Non";

                dgvOperations.Rows.Add(
                    op.nomOpe,
                    position,
                    sens,
                    op.nbreToursOpe,
                    op.tempsAttenteOpe,
                    cycleVerin,
                    op.quittanceOpe ? "Oui" : "Non"
                );
            }
        }


        /// <summary>
        /// Valide les données du formulaire avant enregistrement
        /// </summary>
        /// <returns>True si les données sont valides, false sinon</returns>
        private bool ValiderFormulaire() {
            // Vérification du nom
            if (string.IsNullOrWhiteSpace(txtNomRecette.Text))
            {
                MessageBox.Show("Le nom de la recette est obligatoire.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomRecette.Focus();
                return false;
            }

            // Vérification du doublon uniquement pour une nouvelle recette
            if (estNouvelleRecette && NomRecetteExisteDeja(txtNomRecette.Text))
            {
                MessageBox.Show("Une recette avec ce nom existe déjà. Veuillez choisir un autre nom.",
                    "Nom déjà utilisé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomRecette.Focus();
                return false;
            }

            // Vérification du nombre d'opérations (min 1, max 10)
            if (dgvOperations.Rows.Count == 0)
            {
                MessageBox.Show("La recette doit contenir au moins 1 opération.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (dgvOperations.Rows.Count > 10)
            {
                MessageBox.Show("La recette ne peut pas contenir plus de 10 opérations.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        /// <summary>
        /// Vérifie si une recette avec ce nom existe déjà dans le DAL
        /// </summary>
        /// <param name="nomRecette">Nom à vérifier</param>
        /// <returns>True si le nom existe déjà, false sinon</returns>
        private bool NomRecetteExisteDeja(string nomRecette)
        {
            List<Recette> recettes = DataManager.GetRecettes();
            foreach (Recette r in recettes)
            {
                if (r.REC_Nom.ToLower() == nomRecette.ToLower())
                    return true;
            }
            return false;
        }

        // ================================================
        // DIALOG AJOUTER OPÉRATION
        // ================================================

        /// <summary>
        /// Affiche une boîte de dialogue pour ajouter une nouvelle opération
        /// </summary>
        private void AfficherDialogOperation()
        {
            Form dlg = new Form();
            dlg.Text = "Ajouter une Opération";
            dlg.Size = new Size(400, 320);
            dlg.StartPosition = FormStartPosition.CenterParent;
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlg.MaximizeBox = false;
            dlg.BackColor = Color.White;

            // Nom du pas
            Label lblNom = new Label();
            lblNom.Text = "Nom du pas :";
            lblNom.Location = new Point(15, 20);
            lblNom.AutoSize = true;

            TextBox txtNom = new TextBox();
            txtNom.Location = new Point(180, 17);
            txtNom.Size = new Size(170, 23);

            // Position
            Label lblPos = new Label();
            lblPos.Text = "Position :";
            lblPos.Location = new Point(15, 55);
            lblPos.AutoSize = true;

            ComboBox cboPosition = new ComboBox();
            cboPosition.Location = new Point(180, 52);
            cboPosition.Size = new Size(170, 23);
            cboPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPosition.Items.AddRange(new string[] { "Aucun", "3H", "6H", "9H", "12H" });
            cboPosition.SelectedIndex = 0;

            // Sens de rotation
            Label lblSens = new Label();
            lblSens.Text = "Sens de rotation :";
            lblSens.Location = new Point(15, 90);
            lblSens.AutoSize = true;

            ComboBox cboSens = new ComboBox();
            cboSens.Location = new Point(180, 87);
            cboSens.Size = new Size(170, 23);
            cboSens.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSens.Items.AddRange(new string[] { "Horaire", "Anti-Horaire" });
            cboSens.SelectedIndex = 0;

            // Nombre de tours
            Label lblNbTours = new Label();
            lblNbTours.Text = "Nombre de tours :";
            lblNbTours.Location = new Point(15, 125);
            lblNbTours.AutoSize = true;

            NumericUpDown nudNbTours = new NumericUpDown();
            nudNbTours.Location = new Point(180, 122);
            nudNbTours.Size = new Size(170, 23);
            nudNbTours.Minimum = 0;
            nudNbTours.Maximum = 999;

            // Temps d'arrêt
            Label lblTemps = new Label();
            lblTemps.Text = "Temps d'arrêt (s) :";
            lblTemps.Location = new Point(15, 160);
            lblTemps.AutoSize = true;

            NumericUpDown nudTemps = new NumericUpDown();
            nudTemps.Location = new Point(180, 157);
            nudTemps.Size = new Size(170, 23);
            nudTemps.Minimum = 0;
            nudTemps.Maximum = 9999;

            // Cycle vérin
            Label lblCycleVerin = new Label();
            lblCycleVerin.Text = "Cycle vérin :";
            lblCycleVerin.Location = new Point(15, 195);
            lblCycleVerin.AutoSize = true;

            ComboBox cboCycleVerin = new ComboBox();
            cboCycleVerin.Location = new Point(180, 192);
            cboCycleVerin.Size = new Size(170, 23);
            cboCycleVerin.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCycleVerin.Items.AddRange(new string[] { "Oui", "Non" });
            cboCycleVerin.SelectedIndex = 1;

            // Quittance
            Label lblQuittance = new Label();
            lblQuittance.Text = "Quittance manuelle :";
            lblQuittance.Location = new Point(15, 230);
            lblQuittance.AutoSize = true;

            ComboBox cboQuittance = new ComboBox();
            cboQuittance.Location = new Point(180, 227);
            cboQuittance.Size = new Size(170, 23);
            cboQuittance.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuittance.Items.AddRange(new string[] { "Oui", "Non" });
            cboQuittance.SelectedIndex = 1;

            // Boutons
            Button btnOk = new Button();
            btnOk.Text = "Ajouter";
            btnOk.Location = new Point(80, 265);
            btnOk.Size = new Size(90, 30);
            btnOk.DialogResult = DialogResult.OK;

            Button btnAnnuler = new Button();
            btnAnnuler.Text = "Annuler";
            btnAnnuler.Location = new Point(185, 265);
            btnAnnuler.Size = new Size(90, 30);
            btnAnnuler.DialogResult = DialogResult.Cancel;

            dlg.Controls.AddRange(new Control[]
            {
        lblNom, txtNom,
        lblPos, cboPosition,
        lblSens, cboSens,
        lblNbTours, nudNbTours,
        lblTemps, nudTemps,
        lblCycleVerin, cboCycleVerin,
        lblQuittance, cboQuittance,
        btnOk, btnAnnuler
            });

            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnAnnuler;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Ajoute la nouvelle opération dans la grille
                dgvOperations.Rows.Add(
                    txtNom.Text,
                    cboPosition.SelectedItem.ToString(),
                    cboSens.SelectedItem.ToString(),
                    (int)nudNbTours.Value,
                    (int)nudTemps.Value,
                    cboCycleVerin.SelectedItem.ToString(),
                    cboQuittance.SelectedItem.ToString()
                );
            }
        }

        // ================================================
        // ÉVÉNEMENTS BOUTONS
        // ================================================

        /// <summary>
        /// Bouton pour ajouter une opération à la recette
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAjouterOperation_Click(object sender, EventArgs e)
        {
            // Vérification de la limite maximale
            if (dgvOperations.Rows.Count >= 10)
            {
                MessageBox.Show("Maximum 10 opérations par recette.",
                    "Limite atteinte", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            AfficherDialogOperation();
        }

        /// <summary>
        /// Bouton pour supprimer l'opération sélectionnée
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSupprimerOperation_Click(object sender, EventArgs e)
        {
            if (dgvOperations.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner une opération à supprimer.",
                    "Sélection requise", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult reponse = MessageBox.Show(
                "Supprimer cette opération ?",
                "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (reponse == DialogResult.Yes)
                dgvOperations.Rows.Remove(dgvOperations.SelectedRows[0]);
        }

        private void btnEnregistrerRecette_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            try
            {
                List<Operation> operations = RecupererOperationsGrille();

                if (estNouvelleRecette)
                {
                    DataManager.AjouterRecette(txtNomRecette.Text.Trim(), operations);
                    MessageBox.Show("Recette enregistrée avec succès.",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DataManager.ModifierRecette(recetteEnCours.Id_Recette, operations);
                    MessageBox.Show("Recette modifiée avec succès.",
                        "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private List<Operation> RecupererOperationsGrille()
        {
            List<Operation> operations = new List<Operation>();

            for (int i = 0; i < dgvOperations.Rows.Count; i++)
            {
                string posStr = dgvOperations.Rows[i].Cells["colPosition"].Value?.ToString() ?? "";
                string sensStr = dgvOperations.Rows[i].Cells["colSensRotation"].Value?.ToString() ?? "";
                string cycleStr = dgvOperations.Rows[i].Cells["colCycleVerin"].Value?.ToString() ?? "Non";

                operations.Add(new Operation
                {
                    noOpe = i + 1,
                    nomOpe = dgvOperations.Rows[i].Cells["colNomPas"].Value?.ToString() ?? "",
                    posMoteurOpe = Array.IndexOf(POSITION_MOTEUR, posStr),
                    sensMoteurOpe = Array.IndexOf(SENS_ROTATION, sensStr),
                    nbreToursOpe = Convert.ToInt32(dgvOperations.Rows[i].Cells["colNbTours"].Value ?? 0),
                    tempsAttenteOpe = Convert.ToInt32(dgvOperations.Rows[i].Cells["colTempsArret"].Value ?? 0),
                    cycleVerrinOpe = cycleStr == "Oui" ? 1 : 0,
                    quittanceOpe = dgvOperations.Rows[i].Cells["colQuittance"].Value?.ToString() == "Oui"
                });
            }

            return operations;
        }

        /// <summary>
        /// Bouton pour fermer le formulaire sans enregistrer
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
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void button1_Click(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
        private void button3_Click(object sender, EventArgs e) { }
        private void txtNomRecette_TextChanged(object sender, EventArgs e) { }
        private void txtDateCreation_TextChanged(object sender, EventArgs e) { }
        private void dgvOperations_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
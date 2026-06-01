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
        // ================================================
        // VARIABLES
        // ================================================

        /// <summary>
        /// Recette en cours de modification, null si nouvelle recette
        /// </summary>
        private Recette recetteEnCours;

        /// <summary>
        /// Indique si on crée une nouvelle recette ou si on modifie une existante
        /// </summary>
        private bool estNouvelleRecette;

        // ================================================
        // CONSTRUCTEUR
        // ================================================

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

        // ================================================
        // CHARGEMENT DU FORMULAIRE
        // ================================================

        /// <summary>
        /// Événement déclenché au chargement du formulaire
        /// </summary>
        private void FormGestionRecette_Load(object sender, EventArgs e)
        {
            ConfigurerGrille();
            ConfigurerFormulaire();
        }

        // ================================================
        // CONFIGURATION DE LA GRILLE
        // ================================================

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

        // ================================================
        // CONFIGURATION SELON NOUVEAU OU MODIFIER
        // ================================================

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

        // ================================================
        // CHARGEMENT DES OPÉRATIONS EXISTANTES
        // ================================================

        /// <summary>
        /// Charge les opérations de la recette existante dans le DataGridView
        /// </summary>
        private void ChargerOperations()
        {
            dgvOperations.Rows.Clear();
            List<Operation> operations = DAL.GetOperations(recetteEnCours.Id_Recette);
            foreach (Operation op in operations)
            {
                dgvOperations.Rows.Add(
                    op.OPE_Nom,
                    op.OPE_TempsAttente,
                    op.OPE_Quittance ? "Oui" : "Non"
                );
            }
        }

        // ================================================
        // VALIDATION
        // ================================================

        /// <summary>
        /// Valide les données du formulaire avant enregistrement
        /// </summary>
        /// <returns>True si les données sont valides, false sinon</returns>
        private bool ValiderFormulaire()
        {
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
            List<Recette> recettes = DAL.GetRecettes();
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
            dlg.Size = new Size(340, 230);
            dlg.StartPosition = FormStartPosition.CenterParent;
            dlg.FormBorderStyle = FormBorderStyle.FixedDialog;
            dlg.MaximizeBox = false;
            dlg.BackColor = Color.White;

            // Position du moteur (Aucun = pas de déplacement)
            Label lblPos = new Label();
            lblPos.Text = "Position :";
            lblPos.Location = new Point(15, 20);
            lblPos.AutoSize = true;

            ComboBox cboPosition = new ComboBox();
            cboPosition.Location = new Point(160, 17);
            cboPosition.Size = new Size(120, 25);
            cboPosition.DropDownStyle = ComboBoxStyle.DropDownList;
            cboPosition.Items.AddRange(new string[] { "Aucun", "3H", "6H", "9H", "12H" });
            cboPosition.SelectedIndex = 0;

            // Temps d'arrêt en secondes
            Label lblTemps = new Label();
            lblTemps.Text = "Temps d'arrêt (s) :";
            lblTemps.Location = new Point(15, 60);
            lblTemps.AutoSize = true;

            NumericUpDown nudTemps = new NumericUpDown();
            nudTemps.Location = new Point(160, 57);
            nudTemps.Size = new Size(120, 25);
            nudTemps.Minimum = 0;
            nudTemps.Maximum = 9999;

            // Quittance manuelle requise ou non
            Label lblQuittance = new Label();
            lblQuittance.Text = "Quittance manuelle :";
            lblQuittance.Location = new Point(15, 100);
            lblQuittance.AutoSize = true;

            ComboBox cboQuittance = new ComboBox();
            cboQuittance.Location = new Point(160, 97);
            cboQuittance.Size = new Size(120, 25);
            cboQuittance.DropDownStyle = ComboBoxStyle.DropDownList;
            cboQuittance.Items.AddRange(new string[] { "Oui", "Non" });
            cboQuittance.SelectedIndex = 1;

            // Boutons de confirmation
            Button btnOk = new Button();
            btnOk.Text = "Ajouter";
            btnOk.Location = new Point(60, 150);
            btnOk.Size = new Size(90, 30);
            btnOk.DialogResult = DialogResult.OK;

            Button btnAnnuler = new Button();
            btnAnnuler.Text = "Annuler";
            btnAnnuler.Location = new Point(165, 150);
            btnAnnuler.Size = new Size(90, 30);
            btnAnnuler.DialogResult = DialogResult.Cancel;

            dlg.Controls.AddRange(new Control[]
            {
                lblPos, cboPosition,
                lblTemps, nudTemps,
                lblQuittance, cboQuittance,
                btnOk, btnAnnuler
            });

            dlg.AcceptButton = btnOk;
            dlg.CancelButton = btnAnnuler;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Ajoute la nouvelle opération dans la grille
                dgvOperations.Rows.Add(
                    cboPosition.SelectedItem.ToString(),
                    (int)nudTemps.Value,
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

        /// <summary>
        /// Bouton pour enregistrer ou modifier la recette
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEnregistrerRecette_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            if (estNouvelleRecette)
            {
                // Création d'une nouvelle recette
                Recette nouvelleRecette = new Recette
                {
                    REC_Nom = txtNomRecette.Text,
                    REC_DateHeureCreation = DateTime.Now
                };
                DAL.AjouterRecette(nouvelleRecette);
                MessageBox.Show("Recette enregistrée avec succès !",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Modification d'une recette existante
                Recette recetteModifiee = new Recette
                {
                    REC_Nom = recetteEnCours.REC_Nom,
                    REC_DateHeureCreation = recetteEnCours.REC_DateHeureCreation
                };
                DAL.ModifierRecette(recetteEnCours.REC_Nom, recetteModifiee);
                MessageBox.Show("Recette modifiée avec succès !",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            this.Close();
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
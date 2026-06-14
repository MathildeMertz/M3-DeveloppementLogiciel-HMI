using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormGestionLot : Form
    {
        /// <summary>
        /// Lot en cours de modification, null si nouveau lot
        /// </summary>
        private Lot lotEnCours;

        /// <summary>
        /// Indique si on crée un nouveau lot ou si on modifie un existant
        /// </summary>
        private bool estNouveauLot;

        /// <summary>
        /// Constructeur du formulaire de gestion de lot
        /// </summary>
        /// <param name="lot">Lot à modifier, null pour un nouveau lot</param>
        public FormGestionLot(Lot lot)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            lotEnCours = lot;
            estNouveauLot = (lot == null);
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private void FormGestionLot_Load(object sender, EventArgs e)
        {
            RemplirComboBoxRecette();
            ConfigurerFormulaire();
        }

        /// <summary>
        /// Remplit le ComboBox des recettes disponibles
        /// </summary>
        private void RemplirComboBoxRecette()
        {
            cboRecette.Items.Clear();
            List<Recette> recettes = RecetteManager.GetRecettes();
            foreach (Recette recette in recettes)
            {
                cboRecette.Items.Add(recette.REC_Nom);
            }
            if (cboRecette.Items.Count > 0)
                cboRecette.SelectedIndex = 0;
        }

        /// <summary>
        /// Configure le formulaire selon le mode nouveau ou modification
        /// </summary>
        private void ConfigurerFormulaire()
        {
            txtDateCreation.ReadOnly = true;
            txtDateCreation.BackColor = Color.FromArgb(240, 240, 240);

            if (estNouveauLot)
            {
                this.Text = "Nouveau Lot";
                txtNomLot.Text = "";
                txtQuantite.Text = "";
                txtDateCreation.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                btnModifier.Visible = false;
            }
            else
            {
                this.Text = "Modifier Lot - " + lotEnCours.LOT_Nom;
                txtNomLot.Text = lotEnCours.LOT_Nom;
                txtNomLot.ReadOnly = true;
                txtNomLot.BackColor = Color.FromArgb(240, 240, 240);
                txtQuantite.Text = lotEnCours.LOT_Quantite.ToString();
                txtDateCreation.Text = lotEnCours.LOT_DateHeureCreation.ToString("dd/MM/yyyy HH:mm");
                cboRecette.SelectedItem = lotEnCours.REC_Nom;
                btnEnregistrer.Visible = false;

                bool enAttente = lotEnCours.ETA_Libelle == "En attente";

                btnModifier.Enabled = enAttente;
                cboRecette.Enabled = enAttente;
                btnNouvelleRecette.Enabled = enAttente;
                txtQuantite.ReadOnly = !enAttente;
                txtQuantite.BackColor = enAttente ? Color.White : Color.FromArgb(240, 240, 240);
                cboRecette.BackColor = enAttente ? Color.White : Color.FromArgb(240, 240, 240);
            }

            ChargerOperationsRecette();
        }

        /// <summary>
        /// Charge les opérations de la recette sélectionnée dans le tableau
        /// </summary>
        private void ChargerOperationsRecette()
        {
            dgvOperationsRecette.Rows.Clear();

            if (cboRecette.SelectedItem == null) return;

            int idRecette = RecetteManager.GetIdRecette(cboRecette.SelectedItem.ToString());
            List<Operation> operations = OperationManager.GetOperations(idRecette);

            foreach (Operation op in operations)
            {
                dgvOperationsRecette.Rows.Add(
                    op.noOpe,
                    op.nomOpe,
                    op.posMoteurOpe,
                    op.sensMoteurOpe,
                    op.tempsAttenteOpe,
                    op.cycleVerrinOpe,
                    op.quittanceOpe ? "Oui" : "Non"
                );
            }
        }

        /// <summary>
        /// Valide les données du formulaire avant enregistrement
        /// </summary>
        /// <returns>True si les données sont valides, false sinon</returns>
        private bool ValiderFormulaire()
        {
            if (string.IsNullOrWhiteSpace(txtNomLot.Text))
            {
                MessageBox.Show("Le nom du lot est obligatoire.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomLot.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtQuantite.Text))
            {
                MessageBox.Show("La quantité est obligatoire.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantite.Focus();
                return false;
            }

            int quantite;
            if (!int.TryParse(txtQuantite.Text, out quantite) || quantite <= 0)
            {
                MessageBox.Show("La quantité doit être un nombre entier positif.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtQuantite.Focus();
                return false;
            }

            if (cboRecette.SelectedItem == null)
            {
                MessageBox.Show("Veuillez sélectionner une recette.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboRecette.Focus();
                return false;
            }

            return true;
        }

        /// <summary>
        /// Vérifie si un lot avec ce nom existe déjà dans la base de données
        /// </summary>
        /// <param name="nomLot">Nom à vérifier</param>
        /// <returns>True si le nom existe déjà, false sinon</returns>
        private bool NomLotExisteDeja(string nomLot)
        {
            List<Lot> lots = LotManager.GetLots();
            foreach (Lot lot in lots)
            {
                if (lot.LOT_Nom.ToLower() == nomLot.ToLower())
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Enregistre un nouveau lot dans la base de données
        /// </summary>
        private void btnEnregistrer_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            if (NomLotExisteDeja(txtNomLot.Text))
            {
                MessageBox.Show("Un lot avec ce nom existe déjà.",
                    "Nom déjà utilisé", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNomLot.Focus();
                return;
            }

            try
            {
                LotManager.AjouterLot(
                    txtNomLot.Text,
                    int.Parse(txtQuantite.Text),
                    EtatManager.GetIdEtat("En attente"),
                    RecetteManager.GetIdRecette(cboRecette.SelectedItem.ToString())
                );

                MessageBox.Show("Lot enregistré avec succès !",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'enregistrement : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Modifie un lot existant dans la base de données
        /// </summary>
        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (!ValiderFormulaire()) return;

            try
            {
                LotManager.ModifierLot(
                    lotEnCours.LOT_Nom,
                    int.Parse(txtQuantite.Text),
                    lotEnCours.Id_Etat,
                    RecetteManager.GetIdRecette(cboRecette.SelectedItem.ToString())
                );

                MessageBox.Show("Lot modifié avec succès !",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la modification : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Ouvre le formulaire de création d'une nouvelle recette
        /// et recharge le ComboBox après fermeture
        /// </summary>
        private void btnNouvelleRecette_Click(object sender, EventArgs e)
        {
            FormGestionRecette formGestionRecette = new FormGestionRecette(null);
            formGestionRecette.ShowDialog();

            cboRecette.Items.Clear();
            foreach (Recette recette in RecetteManager.GetRecettes())
            {
                cboRecette.Items.Add(recette.REC_Nom);
            }

            if (cboRecette.Items.Count > 0)
                cboRecette.SelectedIndex = cboRecette.Items.Count - 1;
        }

        /// <summary>
        /// Met à jour le tableau des opérations quand la recette change
        /// </summary>
        private void cboRecette_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChargerOperationsRecette();
        }

        /// <summary>
        /// Ferme le formulaire sans enregistrer
        /// </summary>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNomLot_TextChanged(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void dgvOperationsRecette_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
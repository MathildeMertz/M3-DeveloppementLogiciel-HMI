using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormDetailsRecette : Form
    {

        private List<Recette> listeRecettes;
        private string recetteInitiale;

        /// <summary>
        /// Initialise le formulaire de consultation des recettes.
        /// Charge la liste des recettes, positionne la sélection initiale
        /// et affiche les informations correspondantes.
        /// </summary>
        /// <param name="nomRecette">Nom de la recette à sélectionner à l’ouverture</param>
        public FormDetailsRecette(string nomRecette)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            recetteInitiale = nomRecette;
            listeRecettes = RecetteManager.GetRecettes();

            // Désactiver l'événement pendant le chargement
            cboSelectRecette.SelectedIndexChanged -= cboSelectRecette_SelectedIndexChanged;
            RemplirComboBox();

            int indexInitial = 0;
            if (recetteInitiale != null)
            {
                for (int i = 0; i < listeRecettes.Count; i++)
                {
                    if (listeRecettes[i].REC_Nom == recetteInitiale)
                    {
                        indexInitial = i;
                        break;
                    }
                }
            }

            cboSelectRecette.SelectedIndex = indexInitial;

            // Réactiver l'événement
            cboSelectRecette.SelectedIndexChanged += cboSelectRecette_SelectedIndexChanged;

            AfficherRecette(indexInitial);
        }

        /// <summary>
        /// Remplit la ComboBox avec la liste des noms de recettes disponibles.
        /// </summary>
        private void RemplirComboBox()
        {
            cboSelectRecette.Items.Clear();
            foreach (Recette recette in listeRecettes)
            {
                cboSelectRecette.Items.Add(recette.REC_Nom);
            }
        }

        /// <summary>
        /// Affiche les informations détaillées d’une recette sélectionnée
        /// (nom, date de création, opérations associées).
        /// Met également à jour les éléments de navigation.
        /// </summary>
        /// <param name="index">Index de la recette dans la liste</param>
        private void AfficherRecette(int index)
        {
            if (index < 0 || index >= listeRecettes.Count) return;

            Recette recette = listeRecettes[index];

            lblNomRecette.Text = recette.REC_Nom;
            lblDateCreation.Text = recette.REC_DateHeureCreation.ToString("dd/MM/yyyy HH:mm");

            // Mettre à jour le titre
            this.Text = "Détails de la Recette - " + recette.REC_Nom;

            // Gérer les boutons Précédent/Suivant
            btnPrecedent.Enabled = index > 0;
            btnSuivant.Enabled = index < listeRecettes.Count - 1;

            // Mettre à jour le ComboBox sans déclencher l'événement
            cboSelectRecette.SelectedIndexChanged -= cboSelectRecette_SelectedIndexChanged;
            cboSelectRecette.SelectedIndex = index;
            cboSelectRecette.SelectedIndexChanged += cboSelectRecette_SelectedIndexChanged;

            ChargerOperations(recette.Id_Recette);
        }


        /// <summary>
        /// Charge et affiche les opérations associées à une recette
        /// dans le DataGridView.
        /// </summary>
        /// <param name="idRecette">Identifiant unique de la recette</param>
        private void ChargerOperations(int idRecette)
        {
            dgvOperations.Rows.Clear();
            List<Operation> operations = OperationManager.GetOperations(idRecette);
            lblNbOperation.Text = operations.Count.ToString();

            foreach (Operation op in operations)
            {
                // Ordre des colonnes : NomPas, Position, SensRotation, NbTours, TempsArret, CycleVerin, Quittance
                dgvOperations.Rows.Add(
                    op.nomOpe,
                    op.posMoteurOpe,
                    op.sensMoteurOpe,
                    op.nbreToursOpe,
                    op.tempsAttenteOpe,
                    op.cycleVerrinOpe,
                    op.quittanceOpe ? "Oui" : "Non"
                );
            }
        }

        /// <summary>
        /// Gère le changement de sélection dans la ComboBox.
        /// Met à jour l’affichage de la recette correspondante.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSelectRecette_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherRecette(cboSelectRecette.SelectedIndex);
        }

        /// <summary>
        /// Permet de naviguer vers la recette précédente dans la liste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (cboSelectRecette.SelectedIndex > 0)
                AfficherRecette(cboSelectRecette.SelectedIndex - 1);
        }

        /// <summary>
        /// Permet de naviguer vers la recette suivante dans la liste.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSuivant_Click(object sender, EventArgs e)
        {
            if (cboSelectRecette.SelectedIndex < listeRecettes.Count - 1)
                AfficherRecette(cboSelectRecette.SelectedIndex + 1);
        }

        /// <summary>
        /// Ouvre le formulaire de modification de la recette sélectionnée.
        /// Recharge ensuite les données après modification.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifierRecette_Click(object sender, EventArgs e)
        {
            Recette recetteActuelle = listeRecettes[cboSelectRecette.SelectedIndex];

            this.Hide();
            FormGestionRecette formGestionRecette = new FormGestionRecette(recetteActuelle);
            formGestionRecette.WindowState = FormWindowState.Maximized;
            formGestionRecette.ShowDialog();

            listeRecettes = RecetteManager.GetRecettes();
            AfficherRecette(cboSelectRecette.SelectedIndex);
            this.Show();
        }

        /// <summary>
        /// Ferme le formulaire courant.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Événement déclenché au chargement du formulaire.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormDetailsRecette_Load(object sender, EventArgs e) { }

        /// <summary>
        /// Événements techniques liés à l’interface (non utilisés).
        /// </summary>
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void lblNomRecette_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

        /// <summary>
        /// Événement lié à l’interaction avec le DataGridView des opérations.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvOperations_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        /// <summary>
        /// Supprime la recette sélectionnée si elle n'est pas utilisée dans un lot
        /// </summary>
        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int index = cboSelectRecette.SelectedIndex;
            if (index < 0 || index >= listeRecettes.Count) return;

            Recette recette = listeRecettes[index];

            // Vérifier si la recette est utilisée dans un lot
            if (RecetteManager.RecetteEstUtilisee(recette.REC_Nom))
            {
                MessageBox.Show(
                    "Cette recette est utilisée dans un ou plusieurs lots.\nSuppression impossible.",
                    "Suppression refusée",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Confirmation avant suppression
            DialogResult reponse = MessageBox.Show(
                "Voulez-vous vraiment supprimer la recette \"" + recette.REC_Nom + "\" ?",
                "Confirmer la suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (reponse != DialogResult.Yes) return;

            try
            {
                RecetteManager.SupprimerRecette(recette.Id_Recette, recette.REC_Nom);

                MessageBox.Show("Recette supprimée avec succès.",
                    "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Recharger la liste
                listeRecettes = RecetteManager.GetRecettes();
                RemplirComboBox();

                if (listeRecettes.Count > 0)
                {
                    int nouvelIndex = Math.Min(index, listeRecettes.Count - 1);
                    AfficherRecette(nouvelIndex);
                }
                else
                {
                    // Plus aucune recette
                    lblNomRecette.Text = "";
                    lblDateCreation.Text = "";
                    dgvOperations.Rows.Clear();
                    lblNbOperation.Text = "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message,
                    "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
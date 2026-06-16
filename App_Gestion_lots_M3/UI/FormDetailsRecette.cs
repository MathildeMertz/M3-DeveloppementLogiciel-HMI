/* ECOLE TECHNIQUE PORRENTRUY          
   Département informatique            
   Enseignant responsable : D. Montavon
   _____________________________________
    Nom du fichier  : FormDetailRecette.cs
    Type de fichier : Programme C#
    Auteur          : Ryf Frédéric / Mertz Mathilde
    But             : Fenêtre du détail des recettes
*/

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
        /// Initialisation du combox
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
        /// Affichage d'une recette
        /// </summary>
        /// <param name="index"></param>
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
        /// Charge les opérations de la recette dans le DataGridView
        /// </summary>
        /// <param name="idRecette">Identifiant de la recette</param>
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

  
        private void cboSelectRecette_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherRecette(cboSelectRecette.SelectedIndex);
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (cboSelectRecette.SelectedIndex > 0)
                AfficherRecette(cboSelectRecette.SelectedIndex - 1);
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            if (cboSelectRecette.SelectedIndex < listeRecettes.Count - 1)
                AfficherRecette(cboSelectRecette.SelectedIndex + 1);
        }

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

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormDetailsRecette_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void lblNomRecette_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }

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
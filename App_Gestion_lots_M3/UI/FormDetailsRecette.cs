using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormDetailsRecette : Form
    {
        // ================================================
        // VARIABLES
        // ================================================
        private List<Recette> listeRecettes;
        private string recetteInitiale;

        // ================================================
        // CONSTRUCTEUR
        // ================================================
        public FormDetailsRecette(string nomRecette)
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            recetteInitiale = nomRecette;
            listeRecettes = DAL.GetRecettes();

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

        // ================================================
        // INITIALISATION DU COMBOBOX
        // ================================================
        private void RemplirComboBox()
        {
            cboSelectRecette.Items.Clear();
            foreach (Recette recette in listeRecettes)
            {
                cboSelectRecette.Items.Add(recette.REC_Nom);
            }
        }

        // ================================================
        // AFFICHAGE D'UNE RECETTE
        // ================================================
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

        // ================================================
        // CHARGEMENT DES OPÉRATIONS
        // ================================================
        private void ChargerOperations(int idRecette)
        {
            dgvOperations.Rows.Clear();
            List<Operation> operations = DAL.GetOperations(idRecette);
            lblNbOperation.Text = operations.Count.ToString();

            foreach (Operation op in operations)
            {
                dgvOperations.Rows.Add(
                    op.OPE_Position,        // était OPE_PositionMoteur
                    op.OPE_SensRotation,
                    op.OPE_NbTours,
                    op.OPE_TempsArret,      // était OPE_TempsAttente
                    op.OPE_CycleVerin ? "Oui" : "Non",
                    op.OPE_Quittance ? "Oui" : "Non",
                    op.OPE_Nom
                );
            }
        }

        // ================================================
        // ÉVÉNEMENTS NAVIGATION
        // ================================================
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

        // ================================================
        // ÉVÉNEMENTS BOUTONS
        // ================================================
        private void btnModifierRecette_Click(object sender, EventArgs e)
        {
            Recette recetteActuelle = listeRecettes[cboSelectRecette.SelectedIndex];

            this.Hide();
            FormGestionRecette formGestionRecette = new FormGestionRecette(recetteActuelle);
            formGestionRecette.WindowState = FormWindowState.Maximized;
            formGestionRecette.ShowDialog();

            listeRecettes = DAL.GetRecettes();
            AfficherRecette(cboSelectRecette.SelectedIndex);
            this.Show();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================================================
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void FormDetailsRecette_Load(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void lblNomRecette_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
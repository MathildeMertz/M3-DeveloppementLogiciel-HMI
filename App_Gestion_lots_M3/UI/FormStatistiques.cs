using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormStatistiques : Form
    {
        // ================================================
        // DONNÉES DE DÉMO
        // ================================================
        private List<string[]> listeLots = new List<string[]>
        {
            // NomLot, Etat, DateCreation
            new string[] { "Lot001", "En Production", "21/04/2026" },
            new string[] { "Lot002", "Terminé",       "20/04/2026" },
            new string[] { "Lot003", "En Attente",    "19/04/2026" },
            new string[] { "Lot004", "En Erreur",     "18/04/2026" },
            new string[] { "Lot005", "Terminé",       "17/04/2026" },
        };

        // ================================================
        // CONSTRUCTEUR
        // ================================================
        public FormStatistiques()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            RemplirComboBoxPeriode();
        }

        // ================================================
        // INITIALISATION
        // ================================================
        private void RemplirComboBoxPeriode()
        {
            cboPeriode.Items.Clear();
            cboPeriode.Items.Add("Jour");
            cboPeriode.Items.Add("Semaine");
            cboPeriode.Items.Add("Mois");
            cboPeriode.Items.Add("Année");
            cboPeriode.SelectedIndex = 1;
        }

        // ================================================
        // CALCUL DES STATISTIQUES
        // ================================================
        private void CalculerStatistiques()
        {
            int enAttente = 0;
            int enProduction = 0;
            int termines = 0;
            int enErreur = 0;

            foreach (string[] lot in listeLots)
            {
                switch (lot[1])
                {
                    case "En Attente": enAttente++; break;
                    case "En Production": enProduction++; break;
                    case "Terminé": termines++; break;
                    case "En Erreur": enErreur++; break;
                }
            }

            int total = enAttente + enProduction + termines + enErreur;

            lblEnAttente.Text = enAttente.ToString();
            lblEnProduction.Text = enProduction.ToString();
            lblTermines.Text = termines.ToString();
            lblEnErreur.Text = enErreur.ToString();
            lblTotal.Text = total.ToString();
        }

        // ================================================
        // ÉVÉNEMENTS
        // ================================================
        private void FormStatistiques_Load(object sender, EventArgs e)
        {
            CalculerStatistiques();
        }

        private void btnActualiser_Click(object sender, EventArgs e)
        {
            CalculerStatistiques();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cboPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalculerStatistiques();
        }

        private void dtpDu_ValueChanged(object sender, EventArgs e)
        {
            CalculerStatistiques();
        }

        private void dtpAu_ValueChanged(object sender, EventArgs e)
        {
            CalculerStatistiques();
        }

        // ================================================
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void label1_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void lblEnAttente_Click(object sender, EventArgs e) { }
        private void lblEnProduction_Click(object sender, EventArgs e) { }
        private void lblTermines_Click(object sender, EventArgs e) { }
        private void lblEnErreur_Click(object sender, EventArgs e) { }
    }
}
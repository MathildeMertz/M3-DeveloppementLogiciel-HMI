using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormDetailsLot : Form
    {
        // ================================================
        // DONNÉES DE DÉMO
        // ================================================
        private List<string[]> listeLots = new List<string[]>
        {
            // NomLot, Recette, Quantite, Etat, DateCreation, DateDebut, DateFin
            new string[] { "Lot001", "AM203", "1500 pièces", "En Production", "21/04/2026 10:30", "21/04/2026 10:30", "21/04/2026 12:15" },
            new string[] { "Lot002", "BX105", "1000 pièces", "Terminé",       "20/04/2026 08:00", "20/04/2026 08:00", "20/04/2026 10:00" },
            new string[] { "Lot003", "AM203", "750 pièces",  "En Attente",    "19/04/2026 14:00", "-",                "-"                },
            new string[] { "Lot004", "CX300", "500 pièces",  "En Erreur",     "18/04/2026 09:00", "18/04/2026 09:00", "-"               },
            new string[] { "Lot005", "BX105", "2000 pièces", "Terminé",       "17/04/2026 07:00", "17/04/2026 07:00", "17/04/2026 14:00" },
        };

        private Dictionary<string, List<string[]>> evenementsParLot = new Dictionary<string, List<string[]>>
        {
            {
                "Lot001", new List<string[]>
                {
                    new string[] { "21/04/2026", "10:30:15", "Début du lot",      "AM203"  },
                    new string[] { "21/04/2026", "10:30:18", "Début de la pièce 1", "Cycle 1" },
                    new string[] { "21/04/2026", "10:31:02", "Fin de la pièce 1",   "Cycle 1" },
                    new string[] { "21/04/2026", "10:31:05", "Début de la pièce 2", "Cycle 2" },
                }
            },
            {
                "Lot002", new List<string[]>
                {
                    new string[] { "20/04/2026", "08:00:00", "Début du lot",    "BX105"  },
                    new string[] { "20/04/2026", "08:30:00", "Fin de la pièce 1", "Cycle 1" },
                    new string[] { "20/04/2026", "10:00:00", "Fin du lot",      "BX105"  },
                }
            },
            {
                "Lot003", new List<string[]>
                {
                    new string[] { "-", "-", "Lot en attente", "-" },
                }
            },
            {
                "Lot004", new List<string[]>
                {
                    new string[] { "18/04/2026", "09:00:00", "Début du lot",              "CX300"  },
                    new string[] { "18/04/2026", "09:15:00", "Alarme - Barrière coupée",  "Erreur" },
                }
            },
            {
                "Lot005", new List<string[]>
                {
                    new string[] { "17/04/2026", "07:00:00", "Début du lot",    "BX105"  },
                    new string[] { "17/04/2026", "14:00:00", "Fin du lot",      "BX105"  },
                }
            },
        };

        // ================================================
        // CONSTRUCTEUR
        // ================================================
        public FormDetailsLot()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            RemplirComboBox();
            cboSelectLot.SelectedIndex = 0;
        }

        // ================================================
        // INITIALISATION DU COMBOBOX
        // ================================================
        private void RemplirComboBox()
        {
            cboSelectLot.Items.Clear();
            foreach (string[] lot in listeLots)
            {
                cboSelectLot.Items.Add(lot[0]);
            }
        }

        // ================================================
        // AFFICHAGE D'UN LOT
        // ================================================
        private void AfficherLot(int index)
        {
            string[] lot = listeLots[index];

            lblRecette.Text = lot[1];
            lblQuantite.Text = lot[2];
            lblEtat.Text = lot[3];
            lblDateCreation.Text = lot[4];
            lblDateDebut.Text = lot[5];
            lblDateFin.Text = lot[6];

            // Mettre à jour le ComboBox sans déclencher l'événement
            cboSelectLot.SelectedIndexChanged -= cboSelectLot_SelectedIndexChanged;
            cboSelectLot.SelectedIndex = index;
            cboSelectLot.SelectedIndexChanged += cboSelectLot_SelectedIndexChanged;

            // Mettre à jour le titre
            this.Text = "Détails du Lot - " + lot[0];

            // Gérer les boutons Précédent/Suivant
            btnPrecedent.Enabled = index > 0;
            btnSuivant.Enabled = index < listeLots.Count - 1;

            ChargerEvenements(lot[0]);
        }

        // ================================================
        // CHARGEMENT DES ÉVÉNEMENTS
        // ================================================
        private void ChargerEvenements(string nomLot)
        {
            dataGridView1.Rows.Clear();

            if (evenementsParLot.ContainsKey(nomLot))
            {
                foreach (string[] evt in evenementsParLot[nomLot])
                {
                    dataGridView1.Rows.Add(evt[0], evt[1], evt[2], evt[3]);
                }
            }
        }

        // ================================================
        // ÉVÉNEMENTS NAVIGATION
        // ================================================
        private void cboSelectLot_SelectedIndexChanged(object sender, EventArgs e)
        {
            AfficherLot(cboSelectLot.SelectedIndex);
        }

        private void btnPrecedent_Click(object sender, EventArgs e)
        {
            if (cboSelectLot.SelectedIndex > 0)
            {
                AfficherLot(cboSelectLot.SelectedIndex - 1);
            }
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            if (cboSelectLot.SelectedIndex < listeLots.Count - 1)
            {
                AfficherLot(cboSelectLot.SelectedIndex + 1);
            }
        }

        // ================================================
        // ÉVÉNEMENTS BOUTONS
        // ================================================
        private void btnVoirTracabilite_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormTracabilite formTracabilite = new FormTracabilite();
            formTracabilite.WindowState = FormWindowState.Maximized;
            formTracabilite.ShowDialog();
            this.Show();
        }

        private void btnModifierLot_Click(object sender, EventArgs e)
        {
            this.Hide();
            FormGestionLot formGestionLot = new FormGestionLot();
            formGestionLot.WindowState = FormWindowState.Maximized;
            formGestionLot.ShowDialog();
            this.Show();
        }

        private void btnFermer_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================================================
        // ÉVÉNEMENTS NON UTILISÉS
        // ================================================
        private void lblEtat_Click(object sender, EventArgs e) { }
        private void label5_Click(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void lblDateCreation_Click(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void lblDateDebut_Click(object sender, EventArgs e) { }
        private void label11_Click(object sender, EventArgs e) { }
        private void lblDateFin_Click(object sender, EventArgs e) { }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}
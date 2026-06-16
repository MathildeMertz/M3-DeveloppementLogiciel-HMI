/* ECOLE TECHNIQUE PORRENTRUY          
   Département informatique            
   Enseignant responsable : D. Montavon
   _____________________________________
    Nom du fichier  : FormStatistiques.cs
    Type de fichier : Programme C#
    Auteur          : Ryf Frédéric / Mertz Mathilde
    Date            : 16 juin 2026
    But             : Fenêtre pour voir les statistiques du projet
*/

using App_Gestion_lots_M3.AccesDonnees;
using App_Gestion_lots_M3.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace App_Gestion_lots_M3.UI
{
    public partial class FormStatistiques : Form
    {
        /// <summary>Nombre de lots en attente</summary>
        private int _enAttente = 0;

        /// <summary>Nombre de lots en production</summary>
        private int _enProduction = 0;

        /// <summary>Nombre de lots terminés</summary>
        private int _termines = 0;

        /// <summary>Nombre de lots en erreur</summary>
        private int _enErreur = 0;

        /// <summary>Total de lots dans la période</summary>
        private int _total = 0;

        /// <summary>Nombre de lots créés par jour</summary>
        private Dictionary<string, int> _lotsParJour = new Dictionary<string, int>();

        /// <summary>Nombre de lots par recette</summary>
        private Dictionary<string, int> _lotsParRecette = new Dictionary<string, int>();

        /// <summary>
        /// Constructeur du formulaire de statistiques
        /// </summary>
        public FormStatistiques()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        /// <summary>
        /// Chargement du formulaire
        /// </summary>
        private void FormStatistiques_Load(object sender, EventArgs e)
        {
            cboPeriode.Items.Clear();
            cboPeriode.Items.AddRange(new string[] { "Jour", "Semaine", "Mois", "Année", "Tout" });
            cboPeriode.SelectedIndex = 4;

            dtpDu.Value = DateTime.Now.AddMonths(-1);
            dtpAu.Value = DateTime.Now;

            CalculerStatistiques();
        }

        /// <summary>
        /// Calcule les statistiques selon la période et déclenche le redessin
        /// </summary>
        private void CalculerStatistiques()
        {
            List<Lot> lots = LotManager.GetLots();

            _enAttente = 0;
            _enProduction = 0;
            _termines = 0;
            _enErreur = 0;
            _total = 0;
            _lotsParJour.Clear();
            _lotsParRecette.Clear();

            foreach (Lot lot in lots)
            {
                if (cboPeriode.SelectedItem?.ToString() != "Tout")
                {
                    if (lot.LOT_DateHeureCreation.Date < dtpDu.Value.Date) continue;
                    if (lot.LOT_DateHeureCreation.Date > dtpAu.Value.Date) continue;
                }

                _total++;

                switch (lot.ETA_Libelle)
                {
                    case "En attente": _enAttente++; break;
                    case "En production": _enProduction++; break;
                    case "Terminé": _termines++; break;
                    case "En erreur": _enErreur++; break;
                }

                string jour = lot.LOT_DateHeureCreation.ToString("dd/MM");
                if (_lotsParJour.ContainsKey(jour))
                    _lotsParJour[jour]++;
                else
                    _lotsParJour[jour] = 1;

                if (!string.IsNullOrEmpty(lot.REC_Nom))
                {
                    if (_lotsParRecette.ContainsKey(lot.REC_Nom))
                        _lotsParRecette[lot.REC_Nom]++;
                    else
                        _lotsParRecette[lot.REC_Nom] = 1;
                }
            }

            // Garder uniquement le Top 5 des recettes les plus utilisées
            List<KeyValuePair<string, int>> triees = new List<KeyValuePair<string, int>>(_lotsParRecette);
            triees.Sort((a, b) => b.Value.CompareTo(a.Value));

            _lotsParRecette.Clear();
            int limite = Math.Min(5, triees.Count);
            for (int i = 0; i < limite; i++)
            {
                _lotsParRecette[triees[i].Key] = triees[i].Value;
            }

            panelDonut.Invalidate();
            panelLegende.Invalidate();
            panelBarresJours.Invalidate();
            panelBarresRecettes.Invalidate();
        }

        /// <summary>
        /// Dessine le graphique donut des lots par état
        /// </summary>
        private void panelDonut_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panelDonut.Width;
            int h = panelDonut.Height;
            int taille = Math.Min(w, h) - 20;
            int x = (w - taille) / 2;
            int y = (h - taille) / 2;

            Color[] couleurs = new Color[]
            {
                Color.FromArgb(240, 180, 50),
                Color.FromArgb(50, 130, 210),
                Color.FromArgb(80, 190, 120),
                Color.FromArgb(220, 70, 70)
            };

            int[] valeurs = new int[] { _enAttente, _enProduction, _termines, _enErreur };

            if (_total == 0)
            {
                g.DrawString("Aucune donnée", new Font("Segoe UI", 10), Brushes.Gray, x, y + taille / 2);
                return;
            }

            float angleDepart = -90f;

            for (int i = 0; i < valeurs.Length; i++)
            {
                if (valeurs[i] == 0) continue;

                float angle = (float)valeurs[i] / _total * 360f;

                using (SolidBrush brush = new SolidBrush(couleurs[i]))
                {
                    g.FillPie(brush, x, y, taille, taille, angleDepart, angle);
                }

                angleDepart += angle;
            }

            int trou = taille / 3;
            int xTrou = x + (taille - trou) / 2;
            int yTrou = y + (taille - trou) / 2;

            using (SolidBrush brushBlanc = new SolidBrush(panelDonut.BackColor))
            {
                g.FillEllipse(brushBlanc, xTrou, yTrou, trou, trou);
            }

            Font fontTotal = new Font("Segoe UI", 14, FontStyle.Bold);
            Font fontLabel = new Font("Segoe UI", 8);
            string texteTotal = _total.ToString();
            SizeF tailleTexte = g.MeasureString(texteTotal, fontTotal);
            SizeF tailleLabel = g.MeasureString("Total", fontLabel);

            g.DrawString(texteTotal, fontTotal, Brushes.Black,
                xTrou + (trou - tailleTexte.Width) / 2,
                yTrou + trou / 2 - tailleTexte.Height);

            g.DrawString("Total", fontLabel, Brushes.Gray,
                xTrou + (trou - tailleLabel.Width) / 2,
                yTrou + trou / 2);
        }

        /// <summary>
        /// Dessine la légende des états avec couleurs, valeurs et pourcentages
        /// </summary>
        private void panelLegende_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            string[] noms = new string[] { "En attente", "En production", "Terminés", "En erreur" };
            int[] valeurs = new int[] { _enAttente, _enProduction, _termines, _enErreur };
            Color[] couleurs = new Color[]
            {
                Color.FromArgb(240, 180, 50),
                Color.FromArgb(50, 130, 210),
                Color.FromArgb(80, 190, 120),
                Color.FromArgb(220, 70, 70)
            };

            Font font = new Font("Segoe UI", 10);
            int yPos = 10;
            int espacement = 35;

            for (int i = 0; i < noms.Length; i++)
            {
                using (SolidBrush brush = new SolidBrush(couleurs[i]))
                {
                    g.FillEllipse(brush, 10, yPos + 2, 14, 14);
                }

                string pct = _total > 0
                    ? $"{(int)Math.Round((float)valeurs[i] / _total * 100)}%"
                    : "0%";

                g.DrawString(noms[i], font, Brushes.Black, 32, yPos);

                string valTexte = $"{valeurs[i]} ({pct})";
                SizeF tailleVal = g.MeasureString(valTexte, font);
                g.DrawString(valTexte, font, Brushes.Gray,
                    panelLegende.Width - tailleVal.Width - 5, yPos);

                yPos += espacement;
            }
        }

        /// <summary>
        /// Dessine le graphique en barres verticales des lots par jour
        /// </summary>
        private void panelBarresJours_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panelBarresJours.Width;
            int h = panelBarresJours.Height;
            int margeGauche = 30;
            int margeBas = 30;
            int margeHaut = 40;
            int largeurZone = w - margeGauche - 10;
            int hauteurZone = h - margeBas - margeHaut;

            Font fontTitre = new Font("Segoe UI", 10, FontStyle.Bold);
            g.DrawString("Lots par jour", fontTitre, Brushes.Black, margeGauche, 5);

            if (_lotsParJour.Count == 0)
            {
                g.DrawString("Aucune donnée", new Font("Segoe UI", 9), Brushes.Gray, margeGauche, h / 2);
                return;
            }

            int max = 1;
            foreach (int v in _lotsParJour.Values)
            {
                if (v > max) max = v;
            }

            List<string> jours = new List<string>(_lotsParJour.Keys);
            int nbBarres = jours.Count;
            float largeurBarre = (float)largeurZone / nbBarres * 0.6f;
            float espaceEntreBarres = (float)largeurZone / nbBarres;

            Pen axe = new Pen(Color.FromArgb(180, 180, 180));
            Font fontAxe = new Font("Segoe UI", 7);

            g.DrawLine(axe, margeGauche, h - margeBas, w - 10, h - margeBas);

            for (int i = 0; i < nbBarres; i++)
            {
                int valeur = _lotsParJour[jours[i]];
                float hauteurBarre = (float)valeur / max * hauteurZone;
                float xBarre = margeGauche + i * espaceEntreBarres + (espaceEntreBarres - largeurBarre) / 2;
                float yBarre = margeHaut + (hauteurZone - hauteurBarre);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, 130, 210)))
                {
                    g.FillRectangle(brush, xBarre, yBarre, largeurBarre, hauteurBarre);
                }

                string val = valeur.ToString();
                SizeF tailleVal = g.MeasureString(val, fontAxe);
                g.DrawString(val, fontAxe, Brushes.Black,
                    xBarre + (largeurBarre - tailleVal.Width) / 2,
                    yBarre - tailleVal.Height - 2);

                SizeF tailleLabel = g.MeasureString(jours[i], fontAxe);
                g.DrawString(jours[i], fontAxe, Brushes.Gray,
                    xBarre + (largeurBarre - tailleLabel.Width) / 2,
                    h - margeBas + 3);
            }
        }

        /// <summary>
        /// Dessine le graphique en barres horizontales des recettes les plus utilisées
        /// </summary>
        private void panelBarresRecettes_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int w = panelBarresRecettes.Width;
            int h = panelBarresRecettes.Height;
            int margeGauche = 110;
            int margeDroite = 90;
            int margeHaut = 40;
            int largeurZone = w - margeGauche - margeDroite;

            Font fontTitre = new Font("Segoe UI", 10, FontStyle.Bold);
            g.DrawString("Top recettes utilisées", fontTitre, Brushes.Black, 5, 5);

            if (_lotsParRecette.Count == 0)
            {
                g.DrawString("Aucune donnée", new Font("Segoe UI", 9), Brushes.Gray, 10, h / 2);
                return;
            }

            int max = 1;
            foreach (int v in _lotsParRecette.Values)
            {
                if (v > max) max = v;
            }

            List<string> recettes = new List<string>(_lotsParRecette.Keys);
            int nbBarres = recettes.Count;
            int hauteurBarre = 18;
            int espacement = Math.Max(hauteurBarre + 8, (h - margeHaut - 10) / (nbBarres > 0 ? nbBarres : 1));

            Font fontNom = new Font("Segoe UI", 9);
            Font fontVal = new Font("Segoe UI", 8);

            for (int i = 0; i < nbBarres; i++)
            {
                int valeur = _lotsParRecette[recettes[i]];
                float largeurBarre = largeurZone > 0 ? (float)valeur / max * largeurZone : 0;
                int yBarre = margeHaut + i * espacement;

                // Nom tronqué si trop long
                string nomAffiche = recettes[i].Length > 14
                    ? recettes[i].Substring(0, 14) + "..."
                    : recettes[i];

                SizeF tailleNom = g.MeasureString(nomAffiche, fontNom);
                g.DrawString(nomAffiche, fontNom, Brushes.Black,
                    margeGauche - tailleNom.Width - 5, yBarre + 2);

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(50, 130, 210)))
                {
                    g.FillRectangle(brush, margeGauche, yBarre, largeurBarre, hauteurBarre);
                }

                string pct = _total > 0
                    ? $"{valeur} ({(int)Math.Round((float)valeur / _total * 100)}%)"
                    : $"{valeur}";

                g.DrawString(pct, fontVal, Brushes.Gray,
                    margeGauche + largeurBarre + 5, yBarre + 3);
            }
        }

        /// <summary>
        /// Changement de période — met à jour les dates et recalcule
        /// </summary>
        private void cboPeriode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string periode = cboPeriode.SelectedItem?.ToString();

            switch (periode)
            {
                case "Jour":
                    dtpDu.Value = DateTime.Now.Date;
                    dtpAu.Value = DateTime.Now.Date;
                    break;
                case "Semaine":
                    dtpDu.Value = DateTime.Now.AddDays(-7).Date;
                    dtpAu.Value = DateTime.Now.Date;
                    break;
                case "Mois":
                    dtpDu.Value = DateTime.Now.AddMonths(-1).Date;
                    dtpAu.Value = DateTime.Now.Date;
                    break;
                case "Année":
                    dtpDu.Value = DateTime.Now.AddYears(-1).Date;
                    dtpAu.Value = DateTime.Now.Date;
                    break;
                case "Tout":
                    dtpDu.Enabled = false;
                    dtpAu.Enabled = false;
                    break;
            }

            if (periode != "Tout")
            {
                dtpDu.Enabled = true;
                dtpAu.Enabled = true;
            }

            CalculerStatistiques();
        }

        /// <summary>Changement date début</summary>
        private void dtpDu_ValueChanged(object sender, EventArgs e) { CalculerStatistiques(); }

        /// <summary>Changement date fin</summary>
        private void dtpAu_ValueChanged(object sender, EventArgs e) { CalculerStatistiques(); }

        /// <summary>Bouton actualiser</summary>
        private void btnActualiser_Click(object sender, EventArgs e) { CalculerStatistiques(); }

        /// <summary>Bouton fermer</summary>
        private void btnFermer_Click(object sender, EventArgs e) { this.Close(); }

        private void label2_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
    }
}
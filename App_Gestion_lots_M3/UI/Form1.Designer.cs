namespace App_Gestion_lots_M3
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Lots = new TabPage();
            btnModifierLot = new Button();
            btnNouveauLot = new Button();
            dgvLots = new DataGridView();
            colNomLot = new DataGridViewTextBoxColumn();
            colQuantite = new DataGridViewTextBoxColumn();
            colRecette = new DataGridViewTextBoxColumn();
            colEtat = new DataGridViewTextBoxColumn();
            Recette = new TabPage();
            btnNouvelleRecette = new Button();
            Historique = new TabPage();
            btnVoirTracabilite = new Button();
            tabControl1.SuspendLayout();
            Lots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLots).BeginInit();
            Recette.SuspendLayout();
            Historique.SuspendLayout();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Lots);
            tabControl1.Controls.Add(Recette);
            tabControl1.Controls.Add(Historique);
            tabControl1.Dock = DockStyle.Fill;
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(960, 366);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 0;
            // 
            // Lots
            // 
            Lots.Controls.Add(btnModifierLot);
            Lots.Controls.Add(btnNouveauLot);
            Lots.Controls.Add(dgvLots);
            Lots.Location = new Point(4, 24);
            Lots.Name = "Lots";
            Lots.Padding = new Padding(3);
            Lots.Size = new Size(952, 338);
            Lots.TabIndex = 0;
            Lots.Text = "Lots";
            Lots.UseVisualStyleBackColor = true;
            Lots.Click += Lots_Click;
            // 
            // btnModifierLot
            // 
            btnModifierLot.Anchor = AnchorStyles.Bottom;
            btnModifierLot.Location = new Point(160, 296);
            btnModifierLot.Name = "btnModifierLot";
            btnModifierLot.Size = new Size(149, 36);
            btnModifierLot.TabIndex = 3;
            btnModifierLot.Text = "Modifier Lots";
            btnModifierLot.UseVisualStyleBackColor = true;
            btnModifierLot.Click += btnModifierLot_Click;
            // 
            // btnNouveauLot
            // 
            btnNouveauLot.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNouveauLot.Location = new Point(8, 296);
            btnNouveauLot.Name = "btnNouveauLot";
            btnNouveauLot.Size = new Size(146, 36);
            btnNouveauLot.TabIndex = 1;
            btnNouveauLot.Text = "Nouveau Lot";
            btnNouveauLot.UseVisualStyleBackColor = true;
            btnNouveauLot.Click += btnNouveauLot_Click;
            // 
            // dgvLots
            // 
            dgvLots.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvLots.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLots.Columns.AddRange(new DataGridViewColumn[] { colNomLot, colQuantite, colRecette, colEtat });
            dgvLots.Location = new Point(8, 6);
            dgvLots.Name = "dgvLots";
            dgvLots.Size = new Size(764, 282);
            dgvLots.TabIndex = 0;
            dgvLots.CellContentClick += dgvLots_CellContentClick;
            // 
            // colNomLot
            // 
            colNomLot.HeaderText = "Nom du Lot";
            colNomLot.Name = "colNomLot";
            // 
            // colQuantite
            // 
            colQuantite.HeaderText = "Quantité";
            colQuantite.Name = "colQuantite";
            // 
            // colRecette
            // 
            colRecette.HeaderText = "Recette";
            colRecette.Name = "colRecette";
            // 
            // colEtat
            // 
            colEtat.HeaderText = "État";
            colEtat.Name = "colEtat";
            // 
            // Recette
            // 
            Recette.Controls.Add(btnNouvelleRecette);
            Recette.Location = new Point(4, 24);
            Recette.Name = "Recette";
            Recette.Padding = new Padding(3);
            Recette.Size = new Size(952, 338);
            Recette.TabIndex = 1;
            Recette.Text = "Recettes";
            Recette.UseVisualStyleBackColor = true;
            Recette.Click += Recette_Click;
            // 
            // btnNouvelleRecette
            // 
            btnNouvelleRecette.Anchor = AnchorStyles.Bottom;
            btnNouvelleRecette.Location = new Point(80, 294);
            btnNouvelleRecette.Name = "btnNouvelleRecette";
            btnNouvelleRecette.Size = new Size(124, 36);
            btnNouvelleRecette.TabIndex = 3;
            btnNouvelleRecette.Text = "Nouvelle Recette";
            btnNouvelleRecette.UseVisualStyleBackColor = true;
            // 
            // Historique
            // 
            Historique.Controls.Add(btnVoirTracabilite);
            Historique.Location = new Point(4, 24);
            Historique.Name = "Historique";
            Historique.Padding = new Padding(3);
            Historique.Size = new Size(952, 338);
            Historique.TabIndex = 2;
            Historique.Text = "Traçabilité";
            Historique.UseVisualStyleBackColor = true;
            Historique.Click += Historique_Click;
            // 
            // btnVoirTracabilite
            // 
            btnVoirTracabilite.Anchor = AnchorStyles.Bottom;
            btnVoirTracabilite.Location = new Point(355, 294);
            btnVoirTracabilite.Name = "btnVoirTracabilite";
            btnVoirTracabilite.Size = new Size(120, 36);
            btnVoirTracabilite.TabIndex = 5;
            btnVoirTracabilite.Text = "Voir Historique";
            btnVoirTracabilite.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 366);
            Controls.Add(tabControl1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Gestion Lots";
            tabControl1.ResumeLayout(false);
            Lots.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLots).EndInit();
            Recette.ResumeLayout(false);
            Historique.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Lots;
        private TabPage Recette;
        private TabPage Historique;
        private DataGridView dgvLots;
        private Button btnModifierLot;
        private Button btnNouveauLot;
        private DataGridViewTextBoxColumn colNomLot;
        private DataGridViewTextBoxColumn colQuantite;
        private DataGridViewTextBoxColumn colRecette;
        private DataGridViewTextBoxColumn colEtat;
        private Button btnNouvelleRecette;
        private Button btnVoirTracabilite;
    }
}
namespace App_Gestion_lots_M3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tabControl1 = new TabControl();
            Lots = new TabPage();
            Recette = new TabPage();
            Historique = new TabPage();
            dgvLots = new DataGridView();
            btnNouveauLot = new Button();
            btnNouvelleRecette = new Button();
            btnModifierLot = new Button();
            colNomLot = new DataGridViewTextBoxColumn();
            colQuantite = new DataGridViewTextBoxColumn();
            colRecette = new DataGridViewTextBoxColumn();
            colEtat = new DataGridViewTextBoxColumn();
            tabControl1.SuspendLayout();
            Lots.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvLots).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Lots);
            tabControl1.Controls.Add(Recette);
            tabControl1.Controls.Add(Historique);
            tabControl1.Location = new Point(0, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(796, 380);
            tabControl1.SizeMode = TabSizeMode.FillToRight;
            tabControl1.TabIndex = 0;
            // 
            // Lots
            // 
            Lots.Controls.Add(btnModifierLot);
            Lots.Controls.Add(btnNouvelleRecette);
            Lots.Controls.Add(btnNouveauLot);
            Lots.Controls.Add(dgvLots);
            Lots.Location = new Point(4, 24);
            Lots.Name = "Lots";
            Lots.Padding = new Padding(3);
            Lots.Size = new Size(788, 352);
            Lots.TabIndex = 0;
            Lots.Text = "Lots";
            Lots.UseVisualStyleBackColor = true;
            Lots.Click += tabPage1_Click;
            // 
            // Recette
            // 
            Recette.Location = new Point(4, 24);
            Recette.Name = "Recette";
            Recette.Padding = new Padding(3);
            Recette.Size = new Size(788, 352);
            Recette.TabIndex = 1;
            Recette.Text = "Recettes";
            Recette.UseVisualStyleBackColor = true;
            // 
            // Historique
            // 
            Historique.Location = new Point(4, 24);
            Historique.Name = "Historique";
            Historique.Padding = new Padding(3);
            Historique.Size = new Size(788, 352);
            Historique.TabIndex = 2;
            Historique.Text = "Historique";
            Historique.UseVisualStyleBackColor = true;
            // 
            // dgvLots
            // 
            dgvLots.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLots.Columns.AddRange(new DataGridViewColumn[] { colNomLot, colQuantite, colRecette, colEtat });
            dgvLots.Location = new Point(8, 6);
            dgvLots.Name = "dgvLots";
            dgvLots.Size = new Size(764, 282);
            dgvLots.TabIndex = 0;
            dgvLots.CellContentClick += dgvLots_CellContentClick;
            // 
            // btnNouveauLot
            // 
            btnNouveauLot.Location = new Point(13, 294);
            btnNouveauLot.Name = "btnNouveauLot";
            btnNouveauLot.Size = new Size(109, 36);
            btnNouveauLot.TabIndex = 1;
            btnNouveauLot.Text = "Nouveau Lot";
            btnNouveauLot.UseVisualStyleBackColor = true;
            btnNouveauLot.Click += button1_Click_1;
            // 
            // btnNouvelleRecette
            // 
            btnNouvelleRecette.Location = new Point(128, 294);
            btnNouvelleRecette.Name = "btnNouvelleRecette";
            btnNouvelleRecette.Size = new Size(124, 36);
            btnNouvelleRecette.TabIndex = 2;
            btnNouvelleRecette.Text = "Nouvelle Recette";
            btnNouvelleRecette.UseVisualStyleBackColor = true;
            btnNouvelleRecette.Click += button2_Click_1;
            // 
            // btnModifierLot
            // 
            btnModifierLot.Location = new Point(269, 294);
            btnModifierLot.Name = "btnModifierLot";
            btnModifierLot.Size = new Size(120, 36);
            btnModifierLot.TabIndex = 3;
            btnModifierLot.Text = "Modifier Lots";
            btnModifierLot.UseVisualStyleBackColor = true;
            btnModifierLot.Click += button3_Click_1;
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(960, 366);
            Controls.Add(tabControl1);
            Margin = new Padding(2);
            Name = "Form1";
            Text = "Gestion Lots";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            Lots.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvLots).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage Lots;
        private TabPage Recette;
        private TabPage Historique;
        private DataGridView dgvLots;
        private Button btnModifierLot;
        private Button btnNouvelleRecette;
        private Button btnNouveauLot;
        private DataGridViewTextBoxColumn colNomLot;
        private DataGridViewTextBoxColumn colQuantite;
        private DataGridViewTextBoxColumn colRecette;
        private DataGridViewTextBoxColumn colEtat;
    }
}

namespace App_Gestion_lots_M3.UI
{
    partial class FormDetailsLot
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
            label1 = new Label();
            lblRecette = new Label();
            label3 = new Label();
            lblQuantite = new Label();
            label5 = new Label();
            lblEtat = new Label();
            label7 = new Label();
            lblDateCreation = new Label();
            label9 = new Label();
            lblDateDebut = new Label();
            label11 = new Label();
            lblDateFin = new Label();
            dataGridView1 = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colHeure = new DataGridViewTextBoxColumn();
            colEvenement = new DataGridViewTextBoxColumn();
            colDetails = new DataGridViewTextBoxColumn();
            btnVoirTracabilite = new Button();
            btnModifierLot = new Button();
            btnFermer = new Button();
            btnPrecedent = new Button();
            btnSuivant = new Button();
            cboSelectLot = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 42);
            label1.Name = "label1";
            label1.Size = new Size(52, 15);
            label1.TabIndex = 0;
            label1.Text = "Recette :";
            // 
            // lblRecette
            // 
            lblRecette.AutoSize = true;
            lblRecette.Location = new Point(158, 42);
            lblRecette.Name = "lblRecette";
            lblRecette.Size = new Size(12, 15);
            lblRecette.TabIndex = 1;
            lblRecette.Text = "-";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 71);
            label3.Name = "label3";
            label3.Size = new Size(118, 15);
            label3.TabIndex = 2;
            label3.Text = "Quantité demandée :";
            // 
            // lblQuantite
            // 
            lblQuantite.AutoSize = true;
            lblQuantite.Location = new Point(158, 71);
            lblQuantite.Name = "lblQuantite";
            lblQuantite.Size = new Size(12, 15);
            lblQuantite.TabIndex = 3;
            lblQuantite.Text = "-";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 104);
            label5.Name = "label5";
            label5.Size = new Size(68, 15);
            label5.TabIndex = 4;
            label5.Text = "État actuel :";
            // 
            // lblEtat
            // 
            lblEtat.AutoSize = true;
            lblEtat.Location = new Point(158, 104);
            lblEtat.Name = "lblEtat";
            lblEtat.Size = new Size(12, 15);
            lblEtat.TabIndex = 5;
            lblEtat.Text = "-";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(12, 135);
            label7.Name = "label7";
            label7.Size = new Size(99, 15);
            label7.TabIndex = 6;
            label7.Text = "Date de création :";
            // 
            // lblDateCreation
            // 
            lblDateCreation.AutoSize = true;
            lblDateCreation.Location = new Point(158, 135);
            lblDateCreation.Name = "lblDateCreation";
            lblDateCreation.Size = new Size(12, 15);
            lblDateCreation.TabIndex = 7;
            lblDateCreation.Text = "-";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(12, 169);
            label9.Name = "label9";
            label9.Size = new Size(87, 15);
            label9.TabIndex = 8;
            label9.Text = "Date de début :";
            // 
            // lblDateDebut
            // 
            lblDateDebut.AutoSize = true;
            lblDateDebut.Location = new Point(158, 169);
            lblDateDebut.Name = "lblDateDebut";
            lblDateDebut.Size = new Size(12, 15);
            lblDateDebut.TabIndex = 9;
            lblDateDebut.Text = "-";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 200);
            label11.Name = "label11";
            label11.Size = new Size(109, 15);
            label11.TabIndex = 10;
            label11.Text = "Date de fin prévue :";
            // 
            // lblDateFin
            // 
            lblDateFin.AutoSize = true;
            lblDateFin.Location = new Point(158, 200);
            lblDateFin.Name = "lblDateFin";
            lblDateFin.Size = new Size(12, 15);
            lblDateFin.TabIndex = 11;
            lblDateFin.Text = "-";
            // 
            // dataGridView1
            // 
            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { colDate, colHeure, colEvenement, colDetails });
            dataGridView1.Location = new Point(12, 226);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 180);
            dataGridView1.TabIndex = 12;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            // 
            // colHeure
            // 
            colHeure.HeaderText = "Heure";
            colHeure.Name = "colHeure";
            // 
            // colEvenement
            // 
            colEvenement.HeaderText = "Événement";
            colEvenement.Name = "colEvenement";
            // 
            // colDetails
            // 
            colDetails.HeaderText = "Détails";
            colDetails.Name = "colDetails";
            // 
            // btnVoirTracabilite
            // 
            btnVoirTracabilite.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnVoirTracabilite.Location = new Point(12, 412);
            btnVoirTracabilite.Name = "btnVoirTracabilite";
            btnVoirTracabilite.Size = new Size(109, 35);
            btnVoirTracabilite.TabIndex = 13;
            btnVoirTracabilite.Text = "Historique";
            btnVoirTracabilite.UseVisualStyleBackColor = true;
            btnVoirTracabilite.Click += btnVoirTracabilite_Click;
            // 
            // btnModifierLot
            // 
            btnModifierLot.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnModifierLot.Location = new Point(127, 412);
            btnModifierLot.Name = "btnModifierLot";
            btnModifierLot.Size = new Size(115, 35);
            btnModifierLot.TabIndex = 14;
            btnModifierLot.Text = "Modifier le lot";
            btnModifierLot.UseVisualStyleBackColor = true;
            btnModifierLot.Click += btnModifierLot_Click;
            // 
            // btnFermer
            // 
            btnFermer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFermer.Location = new Point(248, 412);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(117, 35);
            btnFermer.TabIndex = 15;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += btnFermer_Click;
            // 
            // btnPrecedent
            // 
            btnPrecedent.Location = new Point(12, 13);
            btnPrecedent.Name = "btnPrecedent";
            btnPrecedent.Size = new Size(52, 23);
            btnPrecedent.TabIndex = 16;
            btnPrecedent.Text = "<";
            btnPrecedent.UseVisualStyleBackColor = true;
            btnPrecedent.Click += btnPrecedent_Click;
            // 
            // btnSuivant
            // 
            btnSuivant.Location = new Point(225, 13);
            btnSuivant.Name = "btnSuivant";
            btnSuivant.Size = new Size(51, 24);
            btnSuivant.TabIndex = 17;
            btnSuivant.Text = ">";
            btnSuivant.UseVisualStyleBackColor = true;
            btnSuivant.Click += btnSuivant_Click;
            // 
            // cboSelectLot
            // 
            cboSelectLot.FormattingEnabled = true;
            cboSelectLot.Location = new Point(70, 13);
            cboSelectLot.Name = "cboSelectLot";
            cboSelectLot.Size = new Size(149, 23);
            cboSelectLot.TabIndex = 18;
            cboSelectLot.SelectedIndexChanged += cboSelectLot_SelectedIndexChanged;
            // 
            // FormDetailsLot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cboSelectLot);
            Controls.Add(btnSuivant);
            Controls.Add(btnPrecedent);
            Controls.Add(btnFermer);
            Controls.Add(btnModifierLot);
            Controls.Add(btnVoirTracabilite);
            Controls.Add(dataGridView1);
            Controls.Add(lblDateFin);
            Controls.Add(label11);
            Controls.Add(lblDateDebut);
            Controls.Add(label9);
            Controls.Add(lblDateCreation);
            Controls.Add(label7);
            Controls.Add(lblEtat);
            Controls.Add(label5);
            Controls.Add(lblQuantite);
            Controls.Add(label3);
            Controls.Add(lblRecette);
            Controls.Add(label1);
            Name = "FormDetailsLot";
            Text = "Détails du Lot";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblRecette;
        private Label label3;
        private Label lblQuantite;
        private Label label5;
        private Label lblEtat;
        private Label label7;
        private Label lblDateCreation;
        private Label label9;
        private Label lblDateDebut;
        private Label label11;
        private Label lblDateFin;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colHeure;
        private DataGridViewTextBoxColumn colEvenement;
        private DataGridViewTextBoxColumn colDetails;
        private Button btnVoirTracabilite;
        private Button btnModifierLot;
        private Button btnFermer;
        private Button btnPrecedent;
        private Button btnSuivant;
        private ComboBox cboSelectLot;
    }
}
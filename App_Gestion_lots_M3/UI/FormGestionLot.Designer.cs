namespace App_Gestion_lots_M3.UI
{
    partial class FormGestionLot
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGestionLot));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtNomLot = new TextBox();
            txtQuantite = new TextBox();
            txtDateCreation = new TextBox();
            cboRecette = new ComboBox();
            btnEnregistrer = new Button();
            btnModifier = new Button();
            btnFermer = new Button();
            btnNouvelleRecette = new Button();
            dgvOperationsRecette = new DataGridView();
            colOpeNo = new DataGridViewTextBoxColumn();
            colOpeNom = new DataGridViewTextBoxColumn();
            colOpePosition = new DataGridViewTextBoxColumn();
            colOpeSens = new DataGridViewTextBoxColumn();
            colOpeTemps = new DataGridViewTextBoxColumn();
            colOpeCycleVerin = new DataGridViewTextBoxColumn();
            colOpeQuittance = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvOperationsRecette).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(93, 52);
            label1.Name = "label1";
            label1.Size = new Size(77, 15);
            label1.TabIndex = 0;
            label1.Text = "Nom du Lot :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(93, 90);
            label2.Name = "label2";
            label2.Size = new Size(59, 15);
            label2.TabIndex = 1;
            label2.Text = "Quantité :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(93, 133);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 2;
            label3.Text = "Recette :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(93, 181);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 3;
            label4.Text = "Date de Création :";
            // 
            // txtNomLot
            // 
            txtNomLot.Location = new Point(206, 49);
            txtNomLot.Name = "txtNomLot";
            txtNomLot.Size = new Size(121, 23);
            txtNomLot.TabIndex = 5;
            txtNomLot.TextChanged += txtNomLot_TextChanged;
            // 
            // txtQuantite
            // 
            txtQuantite.Location = new Point(206, 90);
            txtQuantite.Name = "txtQuantite";
            txtQuantite.Size = new Size(121, 23);
            txtQuantite.TabIndex = 6;
            // 
            // txtDateCreation
            // 
            txtDateCreation.Location = new Point(206, 181);
            txtDateCreation.Name = "txtDateCreation";
            txtDateCreation.ReadOnly = true;
            txtDateCreation.Size = new Size(121, 23);
            txtDateCreation.TabIndex = 7;
            // 
            // cboRecette
            // 
            cboRecette.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRecette.FormattingEnabled = true;
            cboRecette.Location = new Point(206, 133);
            cboRecette.Name = "cboRecette";
            cboRecette.Size = new Size(121, 23);
            cboRecette.TabIndex = 8;
            cboRecette.SelectedIndexChanged += cboRecette_SelectedIndexChanged;
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Location = new Point(33, 290);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(137, 55);
            btnEnregistrer.TabIndex = 10;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click;
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(190, 290);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(137, 55);
            btnModifier.TabIndex = 11;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnFermer
            // 
            btnFermer.Location = new Point(346, 290);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(137, 55);
            btnFermer.TabIndex = 13;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += btnFermer_Click;
            // 
            // btnNouvelleRecette
            // 
            btnNouvelleRecette.Location = new Point(346, 133);
            btnNouvelleRecette.Name = "btnNouvelleRecette";
            btnNouvelleRecette.Size = new Size(128, 23);
            btnNouvelleRecette.TabIndex = 14;
            btnNouvelleRecette.Text = "Nouvelle Recette";
            btnNouvelleRecette.UseVisualStyleBackColor = true;
            btnNouvelleRecette.Click += btnNouvelleRecette_Click;
            // 
            // dgvOperationsRecette
            // 
            dgvOperationsRecette.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperationsRecette.Columns.AddRange(new DataGridViewColumn[] { colOpeNo, colOpeNom, colOpePosition, colOpeSens, colOpeTemps, colOpeCycleVerin, colOpeQuittance });
            dgvOperationsRecette.Location = new Point(489, 12);
            dgvOperationsRecette.Name = "dgvOperationsRecette";
            dgvOperationsRecette.Size = new Size(763, 657);
            dgvOperationsRecette.TabIndex = 15;
            dgvOperationsRecette.CellContentClick += dgvOperationsRecette_CellContentClick;
            // 
            // colOpeNo
            // 
            colOpeNo.HeaderText = "No";
            colOpeNo.Name = "colOpeNo";
            // 
            // colOpeNom
            // 
            colOpeNom.HeaderText = "Nom";
            colOpeNom.Name = "colOpeNom";
            // 
            // colOpePosition
            // 
            colOpePosition.HeaderText = "Position";
            colOpePosition.Name = "colOpePosition";
            // 
            // colOpeSens
            // 
            colOpeSens.HeaderText = "Sens Rotation";
            colOpeSens.MinimumWidth = 120;
            colOpeSens.Name = "colOpeSens";
            colOpeSens.Width = 120;
            // 
            // colOpeTemps
            // 
            colOpeTemps.HeaderText = "Temps (s)";
            colOpeTemps.Name = "colOpeTemps";
            // 
            // colOpeCycleVerin
            // 
            colOpeCycleVerin.HeaderText = "Cycle vérin";
            colOpeCycleVerin.Name = "colOpeCycleVerin";
            // 
            // colOpeQuittance
            // 
            colOpeQuittance.HeaderText = "Quittance";
            colOpeQuittance.Name = "colOpeQuittance";
            // 
            // FormGestionLot
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(dgvOperationsRecette);
            Controls.Add(btnNouvelleRecette);
            Controls.Add(btnFermer);
            Controls.Add(btnModifier);
            Controls.Add(btnEnregistrer);
            Controls.Add(cboRecette);
            Controls.Add(txtDateCreation);
            Controls.Add(txtQuantite);
            Controls.Add(txtNomLot);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormGestionLot";
            Text = "Gestion du Lot";
            WindowState = FormWindowState.Maximized;
            Load += FormGestionLot_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOperationsRecette).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtNomLot;
        private TextBox txtQuantite;
        private TextBox txtDateCreation;
        private ComboBox cboRecette;
        private Button btnEnregistrer;
        private Button btnModifier;
        private Button btnFermer;
        private Button btnNouvelleRecette;
        private DataGridView dgvOperationsRecette;
        private DataGridViewTextBoxColumn colOpeNo;
        private DataGridViewTextBoxColumn colOpeNom;
        private DataGridViewTextBoxColumn colOpePosition;
        private DataGridViewTextBoxColumn colOpeSens;
        private DataGridViewTextBoxColumn colOpeTemps;
        private DataGridViewTextBoxColumn colOpeCycleVerin;
        private DataGridViewTextBoxColumn colOpeQuittance;
    }
}
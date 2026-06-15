namespace App_Gestion_lots_M3.UI
{
    partial class FormDetailsRecette
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetailsRecette));
            btnPrecedent = new Button();
            btnSuivant = new Button();
            cboSelectRecette = new ComboBox();
            label1 = new Label();
            lblNomRecette = new Label();
            label4 = new Label();
            lblDateCreation = new Label();
            label6 = new Label();
            lblNbOperation = new Label();
            dgvOperations = new DataGridView();
            colNomPas = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            colSensRotation = new DataGridViewTextBoxColumn();
            colNbTours = new DataGridViewTextBoxColumn();
            colTempsArret = new DataGridViewTextBoxColumn();
            colCycleVerin = new DataGridViewTextBoxColumn();
            colQuittance = new DataGridViewTextBoxColumn();
            btnModifierRecette = new Button();
            btnFermer = new Button();
            btnSupprimer = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOperations).BeginInit();
            SuspendLayout();
            // 
            // btnPrecedent
            // 
            btnPrecedent.Location = new Point(12, 12);
            btnPrecedent.Name = "btnPrecedent";
            btnPrecedent.Size = new Size(40, 25);
            btnPrecedent.TabIndex = 0;
            btnPrecedent.Text = "<";
            btnPrecedent.UseVisualStyleBackColor = true;
            btnPrecedent.Click += btnPrecedent_Click;
            // 
            // btnSuivant
            // 
            btnSuivant.Location = new Point(244, 12);
            btnSuivant.Name = "btnSuivant";
            btnSuivant.Size = new Size(40, 25);
            btnSuivant.TabIndex = 2;
            btnSuivant.Text = ">";
            btnSuivant.UseVisualStyleBackColor = true;
            btnSuivant.Click += btnSuivant_Click;
            // 
            // cboSelectRecette
            // 
            cboSelectRecette.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSelectRecette.FormattingEnabled = true;
            cboSelectRecette.Location = new Point(58, 12);
            cboSelectRecette.Name = "cboSelectRecette";
            cboSelectRecette.Size = new Size(180, 23);
            cboSelectRecette.TabIndex = 1;
            cboSelectRecette.SelectedIndexChanged += cboSelectRecette_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 60);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 3;
            label1.Text = "Nom de la Recette :";
            // 
            // lblNomRecette
            // 
            lblNomRecette.AutoSize = true;
            lblNomRecette.Location = new Point(200, 60);
            lblNomRecette.Name = "lblNomRecette";
            lblNomRecette.Size = new Size(12, 15);
            lblNomRecette.TabIndex = 4;
            lblNomRecette.Text = "-";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(49, 90);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 5;
            label4.Text = "Date de Création :";
            // 
            // lblDateCreation
            // 
            lblDateCreation.AutoSize = true;
            lblDateCreation.Location = new Point(200, 90);
            lblDateCreation.Name = "lblDateCreation";
            lblDateCreation.Size = new Size(12, 15);
            lblDateCreation.TabIndex = 6;
            lblDateCreation.Text = "-";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(49, 120);
            label6.Name = "label6";
            label6.Size = new Size(90, 15);
            label6.TabIndex = 7;
            label6.Text = "Nb Opérations :";
            // 
            // lblNbOperation
            // 
            lblNbOperation.AutoSize = true;
            lblNbOperation.Location = new Point(200, 120);
            lblNbOperation.Name = "lblNbOperation";
            lblNbOperation.Size = new Size(12, 15);
            lblNbOperation.TabIndex = 8;
            lblNbOperation.Text = "-";
            // 
            // dgvOperations
            // 
            dgvOperations.AllowUserToAddRows = false;
            dgvOperations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOperations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperations.Columns.AddRange(new DataGridViewColumn[] { colNomPas, colPosition, colSensRotation, colNbTours, colTempsArret, colCycleVerin, colQuittance });
            dgvOperations.Location = new Point(12, 150);
            dgvOperations.Name = "dgvOperations";
            dgvOperations.ReadOnly = true;
            dgvOperations.RowHeadersVisible = false;
            dgvOperations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperations.Size = new Size(776, 220);
            dgvOperations.TabIndex = 9;
            dgvOperations.CellContentClick += dgvOperations_CellContentClick;
            // 
            // colNomPas
            // 
            colNomPas.HeaderText = "Nom Pas";
            colNomPas.Name = "colNomPas";
            colNomPas.ReadOnly = true;
            // 
            // colPosition
            // 
            colPosition.HeaderText = "Position";
            colPosition.Name = "colPosition";
            colPosition.ReadOnly = true;
            // 
            // colSensRotation
            // 
            colSensRotation.HeaderText = "Sens Rotation";
            colSensRotation.Name = "colSensRotation";
            colSensRotation.ReadOnly = true;
            // 
            // colNbTours
            // 
            colNbTours.HeaderText = "Nb Tours";
            colNbTours.Name = "colNbTours";
            colNbTours.ReadOnly = true;
            // 
            // colTempsArret
            // 
            colTempsArret.HeaderText = "Temps Arrêt (s)";
            colTempsArret.Name = "colTempsArret";
            colTempsArret.ReadOnly = true;
            // 
            // colCycleVerin
            // 
            colCycleVerin.HeaderText = "Cycle Vérin";
            colCycleVerin.Name = "colCycleVerin";
            colCycleVerin.ReadOnly = true;
            // 
            // colQuittance
            // 
            colQuittance.HeaderText = "Quittance";
            colQuittance.Name = "colQuittance";
            colQuittance.ReadOnly = true;
            // 
            // btnModifierRecette
            // 
            btnModifierRecette.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnModifierRecette.Location = new Point(12, 400);
            btnModifierRecette.Name = "btnModifierRecette";
            btnModifierRecette.Size = new Size(150, 40);
            btnModifierRecette.TabIndex = 10;
            btnModifierRecette.Text = "Modifier la recette";
            btnModifierRecette.UseVisualStyleBackColor = true;
            btnModifierRecette.Click += btnModifierRecette_Click;
            // 
            // btnFermer
            // 
            btnFermer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFermer.Location = new Point(324, 400);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(150, 40);
            btnFermer.TabIndex = 11;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += btnFermer_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSupprimer.Location = new Point(168, 400);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(150, 40);
            btnSupprimer.TabIndex = 12;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // FormDetailsRecette
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSupprimer);
            Controls.Add(btnFermer);
            Controls.Add(btnModifierRecette);
            Controls.Add(dgvOperations);
            Controls.Add(lblNbOperation);
            Controls.Add(label6);
            Controls.Add(lblDateCreation);
            Controls.Add(label4);
            Controls.Add(lblNomRecette);
            Controls.Add(label1);
            Controls.Add(cboSelectRecette);
            Controls.Add(btnSuivant);
            Controls.Add(btnPrecedent);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormDetailsRecette";
            Text = "Détails de la Recette";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)dgvOperations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnPrecedent;
        private Button btnSuivant;
        private ComboBox cboSelectRecette;
        private Label label1;
        private Label lblNomRecette;
        private Label label4;
        private Label lblDateCreation;
        private Label label6;
        private Label lblNbOperation;
        private DataGridView dgvOperations;
        private DataGridViewTextBoxColumn colNomPas;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colSensRotation;
        private DataGridViewTextBoxColumn colNbTours;
        private DataGridViewTextBoxColumn colTempsArret;
        private DataGridViewTextBoxColumn colCycleVerin;
        private DataGridViewTextBoxColumn colQuittance;
        private Button btnModifierRecette;
        private Button btnFermer;
        private Button btnSupprimer;
    }
}
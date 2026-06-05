namespace App_Gestion_lots_M3.UI
{
    partial class FormGestionRecette
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
            label2 = new Label();
            txtNomRecette = new TextBox();
            txtDateCreation = new TextBox();
            dgvOperations = new DataGridView();
            colNomPas = new DataGridViewTextBoxColumn();
            colPosition = new DataGridViewTextBoxColumn();
            colSensRotation = new DataGridViewTextBoxColumn();
            colNbTours = new DataGridViewTextBoxColumn();
            colTempsArret = new DataGridViewTextBoxColumn();
            colCycleVerin = new DataGridViewTextBoxColumn();
            colQuittance = new DataGridViewTextBoxColumn();
            btnAjouterOperation = new Button();
            btnSupprimerOperation = new Button();
            btnEnregistrerRecette = new Button();
            btnFermer = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOperations).BeginInit();
            SuspendLayout();
            // label1
            label1.AutoSize = true;
            label1.Location = new Point(95, 39);
            label1.Name = "label1";
            label1.TabIndex = 0;
            label1.Text = "Nom de la Recette :";
            // label2
            label2.AutoSize = true;
            label2.Location = new Point(95, 75);
            label2.Name = "label2";
            label2.TabIndex = 1;
            label2.Text = "Date de Création :";
            // txtNomRecette
            txtNomRecette.Location = new Point(218, 36);
            txtNomRecette.Name = "txtNomRecette";
            txtNomRecette.Size = new Size(200, 23);
            txtNomRecette.TabIndex = 2;
            txtNomRecette.TextChanged += new System.EventHandler(this.txtNomRecette_TextChanged);
            // txtDateCreation
            txtDateCreation.Location = new Point(218, 72);
            txtDateCreation.Name = "txtDateCreation";
            txtDateCreation.ReadOnly = true;
            txtDateCreation.Size = new Size(200, 23);
            txtDateCreation.TabIndex = 3;
            txtDateCreation.TextChanged += new System.EventHandler(this.txtDateCreation_TextChanged);
            // dgvOperations
            dgvOperations.AllowUserToAddRows = false;
            dgvOperations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOperations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperations.Columns.AddRange(new DataGridViewColumn[] { colNomPas, colPosition, colSensRotation, colNbTours, colTempsArret, colCycleVerin, colQuittance });
            dgvOperations.Location = new Point(12, 116);
            dgvOperations.Name = "dgvOperations";
            dgvOperations.RowHeadersVisible = false;
            dgvOperations.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOperations.MultiSelect = false;
            dgvOperations.ReadOnly = true;
            dgvOperations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOperations.Size = new Size(760, 150);
            dgvOperations.TabIndex = 4;
            dgvOperations.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvOperations_CellContentClick);
            // colNomPas
            colNomPas.HeaderText = "Nom Pas";
            colNomPas.Name = "colNomPas";
            // colPosition
            colPosition.HeaderText = "Position";
            colPosition.Name = "colPosition";
            // colSensRotation
            colSensRotation.HeaderText = "Sens Rotation";
            colSensRotation.Name = "colSensRotation";
            // colNbTours
            colNbTours.HeaderText = "Nb Tours";
            colNbTours.Name = "colNbTours";
            // colTempsArret
            colTempsArret.HeaderText = "Temps Arrêt (s)";
            colTempsArret.Name = "colTempsArret";
            // colCycleVerin
            colCycleVerin.HeaderText = "Cycle Vérin";
            colCycleVerin.Name = "colCycleVerin";
            // colQuittance
            colQuittance.HeaderText = "Quittance";
            colQuittance.Name = "colQuittance";
            // btnAjouterOperation
            btnAjouterOperation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAjouterOperation.Location = new Point(15, 284);
            btnAjouterOperation.Name = "btnAjouterOperation";
            btnAjouterOperation.Size = new Size(150, 30);
            btnAjouterOperation.TabIndex = 5;
            btnAjouterOperation.Text = "Ajouter Opération";
            btnAjouterOperation.UseVisualStyleBackColor = true;
            btnAjouterOperation.Click += new System.EventHandler(this.btnAjouterOperation_Click);
            // btnSupprimerOperation
            btnSupprimerOperation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSupprimerOperation.Location = new Point(175, 284);
            btnSupprimerOperation.Name = "btnSupprimerOperation";
            btnSupprimerOperation.Size = new Size(150, 30);
            btnSupprimerOperation.TabIndex = 6;
            btnSupprimerOperation.Text = "Supprimer Opération";
            btnSupprimerOperation.UseVisualStyleBackColor = true;
            btnSupprimerOperation.Click += new System.EventHandler(this.btnSupprimerOperation_Click);
            // btnEnregistrerRecette
            btnEnregistrerRecette.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEnregistrerRecette.Location = new Point(15, 324);
            btnEnregistrerRecette.Name = "btnEnregistrerRecette";
            btnEnregistrerRecette.Size = new Size(180, 40);
            btnEnregistrerRecette.TabIndex = 7;
            btnEnregistrerRecette.Text = "Enregistrer Recette";
            btnEnregistrerRecette.UseVisualStyleBackColor = true;
            btnEnregistrerRecette.Click += new System.EventHandler(this.btnEnregistrerRecette_Click);
            // btnFermer
            btnFermer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFermer.Location = new Point(205, 324);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(150, 40);
            btnFermer.TabIndex = 8;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // FormGestionRecette
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFermer);
            Controls.Add(btnEnregistrerRecette);
            Controls.Add(btnSupprimerOperation);
            Controls.Add(btnAjouterOperation);
            Controls.Add(dgvOperations);
            Controls.Add(txtDateCreation);
            Controls.Add(txtNomRecette);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormGestionRecette";
            Text = "Gestion de la Recette";
            WindowState = FormWindowState.Maximized;
            Load += new System.EventHandler(this.FormGestionRecette_Load);
            ((System.ComponentModel.ISupportInitialize)dgvOperations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtNomRecette;
        private TextBox txtDateCreation;
        private DataGridView dgvOperations;
        private DataGridViewTextBoxColumn colNomPas;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colSensRotation;
        private DataGridViewTextBoxColumn colNbTours;
        private DataGridViewTextBoxColumn colTempsArret;
        private DataGridViewTextBoxColumn colCycleVerin;
        private DataGridViewTextBoxColumn colQuittance;
        private Button btnAjouterOperation;
        private Button btnSupprimerOperation;
        private Button btnEnregistrerRecette;
        private Button btnFermer;
    }
}
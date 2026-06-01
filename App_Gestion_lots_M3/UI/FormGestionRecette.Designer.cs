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
            colPosition = new DataGridViewTextBoxColumn();
            colTemps = new DataGridViewTextBoxColumn();
            colQuittance = new DataGridViewTextBoxColumn();
            btnAjouterOperation = new Button();
            btnSupprimerOperation = new Button();
            btnEnregistrerRecette = new Button();
            btnFermer = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvOperations).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(95, 39);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Nom de la Recette :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 75);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 1;
            label2.Text = "Date de Création :";
            // 
            // txtNomRecette
            // 
            txtNomRecette.Location = new Point(218, 36);
            txtNomRecette.Name = "txtNomRecette";
            txtNomRecette.Size = new Size(200, 23);
            txtNomRecette.TabIndex = 2;
            txtNomRecette.TextChanged += txtNomRecette_TextChanged;
            // 
            // txtDateCreation
            // 
            txtDateCreation.Location = new Point(218, 72);
            txtDateCreation.Name = "txtDateCreation";
            txtDateCreation.ReadOnly = true;
            txtDateCreation.Size = new Size(200, 23);
            txtDateCreation.TabIndex = 3;
            txtDateCreation.TextChanged += txtDateCreation_TextChanged;
            // 
            // dgvOperations
            // 
            dgvOperations.AllowUserToAddRows = false;
            dgvOperations.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOperations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperations.Columns.AddRange(new DataGridViewColumn[] { colPosition, colTemps, colQuittance });
            dgvOperations.Location = new Point(12, 116);
            dgvOperations.Name = "dgvOperations";
            dgvOperations.RowHeadersVisible = false;
            dgvOperations.Size = new Size(400, 150);
            dgvOperations.TabIndex = 4;
            dgvOperations.CellContentClick += dgvOperations_CellContentClick;
            // 
            // colPosition
            // 
            colPosition.HeaderText = "Position";
            colPosition.Name = "colPosition";
            // 
            // colTemps
            // 
            colTemps.HeaderText = "Temps (s)";
            colTemps.Name = "colTemps";
            // 
            // colQuittance
            // 
            colQuittance.HeaderText = "Quittance Manuelle";
            colQuittance.Name = "colQuittance";
            // 
            // btnAjouterOperation
            // 
            btnAjouterOperation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnAjouterOperation.Location = new Point(15, 284);
            btnAjouterOperation.Name = "btnAjouterOperation";
            btnAjouterOperation.Size = new Size(129, 23);
            btnAjouterOperation.TabIndex = 5;
            btnAjouterOperation.Text = "Ajouter Opération";
            btnAjouterOperation.UseVisualStyleBackColor = true;
            btnAjouterOperation.Click += btnAjouterOperation_Click;
            // 
            // btnSupprimerOperation
            // 
            btnSupprimerOperation.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnSupprimerOperation.Location = new Point(240, 284);
            btnSupprimerOperation.Name = "btnSupprimerOperation";
            btnSupprimerOperation.Size = new Size(154, 23);
            btnSupprimerOperation.TabIndex = 6;
            btnSupprimerOperation.Text = "Supprimer Opération";
            btnSupprimerOperation.UseVisualStyleBackColor = true;
            btnSupprimerOperation.Click += btnSupprimerOperation_Click;
            // 
            // btnEnregistrerRecette
            // 
            btnEnregistrerRecette.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnEnregistrerRecette.Location = new Point(59, 313);
            btnEnregistrerRecette.Name = "btnEnregistrerRecette";
            btnEnregistrerRecette.Size = new Size(146, 40);
            btnEnregistrerRecette.TabIndex = 7;
            btnEnregistrerRecette.Text = "Enregistrer Recette";
            btnEnregistrerRecette.UseVisualStyleBackColor = true;
            btnEnregistrerRecette.Click += btnEnregistrerRecette_Click;
            // 
            // btnFermer
            // 
            btnFermer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFermer.Location = new Point(211, 313);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(149, 40);
            btnFermer.TabIndex = 8;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += btnFermer_Click;
            // 
            // FormGestionRecette
            // 
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
            Load += FormGestionRecette_Load;
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
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colTemps;
        private DataGridViewTextBoxColumn colQuittance;
        private Button btnAjouterOperation;
        private Button btnSupprimerOperation;
        private Button btnEnregistrerRecette;
        private Button btnFermer;
    }
}
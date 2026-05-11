namespace App_Gestion_lots_M3.UI
{
    partial class FormGestionRecette
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            dgvOperations = new DataGridView();
            colPosition = new DataGridViewTextBoxColumn();
            colTemps = new DataGridViewTextBoxColumn();
            colQuittance = new DataGridViewTextBoxColumn();
            btnAjouterOperation = new Button();
            btnSupprimerOperation = new Button();
            btnEnregistrerRecette = new Button();
            btnFermer = new Button();
            dtpDu = new DateTimePicker();
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
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(95, 75);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 1;
            label2.Text = "Date de Création :";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(218, 36);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(121, 23);
            textBox1.TabIndex = 2;
            // 
            // dgvOperations
            // 
            dgvOperations.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOperations.Columns.AddRange(new DataGridViewColumn[] { colPosition, colTemps, colQuittance });
            dgvOperations.Location = new Point(12, 116);
            dgvOperations.Name = "dgvOperations";
            dgvOperations.Size = new Size(400, 150);
            dgvOperations.TabIndex = 4;
            dgvOperations.CellContentClick += dataGridView1_CellContentClick;
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
            btnAjouterOperation.Location = new Point(15, 284);
            btnAjouterOperation.Name = "btnAjouterOperation";
            btnAjouterOperation.Size = new Size(129, 23);
            btnAjouterOperation.TabIndex = 5;
            btnAjouterOperation.Text = "Ajouter Opération";
            btnAjouterOperation.UseVisualStyleBackColor = true;
            btnAjouterOperation.Click += button1_Click;
            // 
            // btnSupprimerOperation
            // 
            btnSupprimerOperation.Location = new Point(240, 284);
            btnSupprimerOperation.Name = "btnSupprimerOperation";
            btnSupprimerOperation.Size = new Size(154, 23);
            btnSupprimerOperation.TabIndex = 6;
            btnSupprimerOperation.Text = "Supprimer Opération";
            btnSupprimerOperation.UseVisualStyleBackColor = true;
            btnSupprimerOperation.Click += button2_Click;
            // 
            // btnEnregistrerRecette
            // 
            btnEnregistrerRecette.Location = new Point(59, 313);
            btnEnregistrerRecette.Name = "btnEnregistrerRecette";
            btnEnregistrerRecette.Size = new Size(146, 40);
            btnEnregistrerRecette.TabIndex = 7;
            btnEnregistrerRecette.Text = "Enregistrer Recette";
            btnEnregistrerRecette.UseVisualStyleBackColor = true;
            btnEnregistrerRecette.Click += button3_Click;
            // 
            // btnFermer
            // 
            btnFermer.Location = new Point(211, 313);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(149, 40);
            btnFermer.TabIndex = 15;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += btnFermer_Click;
            // 
            // dtpDu
            // 
            dtpDu.Location = new Point(218, 69);
            dtpDu.Name = "dtpDu";
            dtpDu.Size = new Size(121, 23);
            dtpDu.TabIndex = 16;
            // 
            // FormGestionRecette
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(434, 381);
            Controls.Add(dtpDu);
            Controls.Add(btnFermer);
            Controls.Add(btnEnregistrerRecette);
            Controls.Add(btnSupprimerOperation);
            Controls.Add(btnAjouterOperation);
            Controls.Add(dgvOperations);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormGestionRecette";
            Text = "Gestion de la Recette";
            Load += FormGestionRecette_Load;
            ((System.ComponentModel.ISupportInitialize)dgvOperations).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private DataGridView dgvOperations;
        private DataGridViewTextBoxColumn colPosition;
        private DataGridViewTextBoxColumn colTemps;
        private DataGridViewTextBoxColumn colQuittance;
        private Button btnAjouterOperation;
        private Button btnSupprimerOperation;
        private Button btnEnregistrerRecette;
        private Button btnFermer;
        private DateTimePicker dtpDu;
    }
}
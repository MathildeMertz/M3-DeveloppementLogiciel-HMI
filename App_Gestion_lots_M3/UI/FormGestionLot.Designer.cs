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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            txtNomLot = new TextBox();
            txtQuantite = new TextBox();
            txtDateCreation = new TextBox();
            cboRecette = new ComboBox();
            cboEtat = new ComboBox();
            btnEnregistrer = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            btnFermer = new Button();
            SuspendLayout();
            // label1
            label1.AutoSize = true;
            label1.Location = new Point(216, 87);
            label1.Name = "label1";
            label1.TabIndex = 0;
            label1.Text = "Nom du Lot :";
            // label2
            label2.AutoSize = true;
            label2.Location = new Point(216, 125);
            label2.Name = "label2";
            label2.TabIndex = 1;
            label2.Text = "Quantité :";
            // label3
            label3.AutoSize = true;
            label3.Location = new Point(216, 168);
            label3.Name = "label3";
            label3.TabIndex = 2;
            label3.Text = "Recette :";
            // label4
            label4.AutoSize = true;
            label4.Location = new Point(216, 216);
            label4.Name = "label4";
            label4.TabIndex = 3;
            label4.Text = "Date de Création :";
            // label5
            label5.AutoSize = true;
            label5.Location = new Point(216, 263);
            label5.Name = "label5";
            label5.TabIndex = 4;
            label5.Text = "État :";
            // txtNomLot
            txtNomLot.Location = new Point(329, 84);
            txtNomLot.Name = "txtNomLot";
            txtNomLot.Size = new Size(121, 23);
            txtNomLot.TabIndex = 5;
            txtNomLot.TextChanged += new System.EventHandler(this.txtNomLot_TextChanged);
            // txtQuantite
            txtQuantite.Location = new Point(329, 125);
            txtQuantite.Name = "txtQuantite";
            txtQuantite.Size = new Size(121, 23);
            txtQuantite.TabIndex = 6;
            // txtDateCreation
            txtDateCreation.Location = new Point(329, 216);
            txtDateCreation.Name = "txtDateCreation";
            txtDateCreation.Size = new Size(121, 23);
            txtDateCreation.TabIndex = 7;
            txtDateCreation.ReadOnly = true;
            // cboRecette
            cboRecette.FormattingEnabled = true;
            cboRecette.DropDownStyle = ComboBoxStyle.DropDownList;
            cboRecette.Location = new Point(329, 168);
            cboRecette.Name = "cboRecette";
            cboRecette.Size = new Size(121, 23);
            cboRecette.TabIndex = 8;
            // cboEtat
            cboEtat.FormattingEnabled = true;
            cboEtat.DropDownStyle = ComboBoxStyle.DropDownList;
            cboEtat.Location = new Point(329, 260);
            cboEtat.Name = "cboEtat";
            cboEtat.Size = new Size(121, 23);
            cboEtat.TabIndex = 9;
            // btnEnregistrer
            btnEnregistrer.Location = new Point(85, 325);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(137, 55);
            btnEnregistrer.TabIndex = 10;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += new System.EventHandler(this.btnEnregistrer_Click);
            // btnModifier
            btnModifier.Location = new Point(250, 325);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(137, 55);
            btnModifier.TabIndex = 11;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += new System.EventHandler(this.btnModifier_Click);
            // btnSupprimer
            btnSupprimer.Location = new Point(416, 325);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(137, 55);
            btnSupprimer.TabIndex = 12;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // btnFermer
            btnFermer.Location = new Point(580, 325);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(137, 55);
            btnFermer.TabIndex = 13;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += new System.EventHandler(this.btnFermer_Click);
            // FormGestionLot
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnFermer);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Controls.Add(btnEnregistrer);
            Controls.Add(cboEtat);
            Controls.Add(cboRecette);
            Controls.Add(txtDateCreation);
            Controls.Add(txtQuantite);
            Controls.Add(txtNomLot);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormGestionLot";
            Text = "Gestion du Lot";
            WindowState = FormWindowState.Maximized;
            Load += new System.EventHandler(this.FormGestionLot_Load);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtNomLot;
        private TextBox txtQuantite;
        private TextBox txtDateCreation;
        private ComboBox cboRecette;
        private ComboBox cboEtat;
        private Button btnEnregistrer;
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnFermer;
    }
}
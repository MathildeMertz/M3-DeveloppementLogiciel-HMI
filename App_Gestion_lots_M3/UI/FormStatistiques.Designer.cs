namespace App_Gestion_lots_M3.UI
{
    partial class FormStatistiques
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
            label3 = new Label();
            cboPeriode = new ComboBox();
            dtpDu = new DateTimePicker();
            dtpAu = new DateTimePicker();
            btnActualiser = new Button();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            lblEnAttente = new Label();
            label9 = new Label();
            lblEnProduction = new Label();
            lblEnErreur = new Label();
            lblTermines = new Label();
            btnFermer = new Button();
            lblTotal = new Label();
            label10 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 0;
            label1.Text = "Période :";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(209, 9);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 1;
            label2.Text = "Du :";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(459, 9);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 2;
            label3.Text = "Au :";
            // 
            // cboPeriode
            // 
            cboPeriode.FormattingEnabled = true;
            cboPeriode.Location = new Point(71, 6);
            cboPeriode.Name = "cboPeriode";
            cboPeriode.Size = new Size(132, 23);
            cboPeriode.TabIndex = 3;
            // 
            // dtpDu
            // 
            dtpDu.Location = new Point(243, 6);
            dtpDu.Name = "dtpDu";
            dtpDu.Size = new Size(200, 23);
            dtpDu.TabIndex = 4;
            // 
            // dtpAu
            // 
            dtpAu.Location = new Point(493, 6);
            dtpAu.Name = "dtpAu";
            dtpAu.Size = new Size(200, 23);
            dtpAu.TabIndex = 5;
            // 
            // btnActualiser
            // 
            btnActualiser.Location = new Point(699, 6);
            btnActualiser.Name = "btnActualiser";
            btnActualiser.Size = new Size(89, 23);
            btnActualiser.TabIndex = 6;
            btnActualiser.Text = "Actualiser";
            btnActualiser.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 52);
            label4.Name = "label4";
            label4.Size = new Size(72, 15);
            label4.TabIndex = 7;
            label4.Text = "Lots par état";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(278, 109);
            label5.Name = "label5";
            label5.Size = new Size(66, 15);
            label5.TabIndex = 8;
            label5.Text = "En attente :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(278, 143);
            label6.Name = "label6";
            label6.Size = new Size(88, 15);
            label6.TabIndex = 9;
            label6.Text = "En production :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(278, 179);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 10;
            label7.Text = "Terminés :";
            // 
            // lblEnAttente
            // 
            lblEnAttente.AutoSize = true;
            lblEnAttente.Location = new Point(392, 109);
            lblEnAttente.Name = "lblEnAttente";
            lblEnAttente.Size = new Size(13, 15);
            lblEnAttente.TabIndex = 11;
            lblEnAttente.Text = "0";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(278, 214);
            label9.Name = "label9";
            label9.Size = new Size(60, 15);
            label9.TabIndex = 12;
            label9.Text = "En erreur :";
            // 
            // lblEnProduction
            // 
            lblEnProduction.AutoSize = true;
            lblEnProduction.Location = new Point(392, 143);
            lblEnProduction.Name = "lblEnProduction";
            lblEnProduction.Size = new Size(13, 15);
            lblEnProduction.TabIndex = 13;
            lblEnProduction.Text = "0";
            // 
            // lblEnErreur
            // 
            lblEnErreur.AutoSize = true;
            lblEnErreur.Location = new Point(392, 214);
            lblEnErreur.Name = "lblEnErreur";
            lblEnErreur.Size = new Size(13, 15);
            lblEnErreur.TabIndex = 14;
            lblEnErreur.Text = "0";
            // 
            // lblTermines
            // 
            lblTermines.AutoSize = true;
            lblTermines.Location = new Point(392, 179);
            lblTermines.Name = "lblTermines";
            lblTermines.Size = new Size(13, 15);
            lblTermines.TabIndex = 15;
            lblTermines.Text = "0";
            // 
            // btnFermer
            // 
            btnFermer.Location = new Point(12, 374);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(97, 36);
            btnFermer.TabIndex = 18;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += btnFermer_Click;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Location = new Point(90, 143);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(13, 15);
            lblTotal.TabIndex = 19;
            lblTotal.Text = "0";
            lblTotal.Click += label8_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(77, 158);
            label10.Name = "label10";
            label10.Size = new Size(32, 15);
            label10.TabIndex = 20;
            label10.Text = "Total";
            // 
            // FormStatistiques
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label10);
            Controls.Add(lblTotal);
            Controls.Add(btnFermer);
            Controls.Add(lblTermines);
            Controls.Add(lblEnErreur);
            Controls.Add(lblEnProduction);
            Controls.Add(label9);
            Controls.Add(lblEnAttente);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(btnActualiser);
            Controls.Add(dtpAu);
            Controls.Add(dtpDu);
            Controls.Add(cboPeriode);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormStatistiques";
            Text = "Statistiques";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private ComboBox cboPeriode;
        private DateTimePicker dtpDu;
        private DateTimePicker dtpAu;
        private Button btnActualiser;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label lblEnAttente;
        private Label label9;
        private Label lblEnProduction;
        private Label lblEnErreur;
        private Label lblTermines;
        private Button btnFermer;
        private Label lblTotal;
        private Label label10;
    }
}
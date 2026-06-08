namespace App_Gestion_lots_M3.UI
{
    partial class FormLogin
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
            txtUtilisateur = new MaskedTextBox();
            txtMotDePasse = new MaskedTextBox();
            btnConnexion = new Button();
            btnAnnuler = new Button();
            txtServeur = new MaskedTextBox();
            label3 = new Label();
            txtPort = new MaskedTextBox();
            label4 = new Label();
            txtBaseDonnee = new MaskedTextBox();
            label5 = new Label();
            btnEnregistrer = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 207);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Utilisateur :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 282);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 1;
            label2.Text = "Mot de passe :";
            label2.Click += label2_Click;
            // 
            // txtUtilisateur
            // 
            txtUtilisateur.Location = new Point(33, 225);
            txtUtilisateur.Name = "txtUtilisateur";
            txtUtilisateur.Size = new Size(203, 23);
            txtUtilisateur.TabIndex = 2;
            txtUtilisateur.MaskInputRejected += txtUtilisateur_MaskInputRejected;
            // 
            // txtMotDePasse
            // 
            txtMotDePasse.Location = new Point(33, 312);
            txtMotDePasse.Name = "txtMotDePasse";
            txtMotDePasse.PasswordChar = '*';
            txtMotDePasse.Size = new Size(203, 23);
            txtMotDePasse.TabIndex = 3;
            txtMotDePasse.MaskInputRejected += txtMotDePasse_MaskInputRejected;
            // 
            // btnConnexion
            // 
            btnConnexion.Location = new Point(33, 375);
            btnConnexion.Name = "btnConnexion";
            btnConnexion.Size = new Size(99, 42);
            btnConnexion.TabIndex = 4;
            btnConnexion.Text = "Se connecter";
            btnConnexion.UseVisualStyleBackColor = true;
            btnConnexion.Click += btnConnexion_Click;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Location = new Point(246, 375);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(99, 42);
            btnAnnuler.TabIndex = 5;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // txtServeur
            // 
            txtServeur.Location = new Point(33, 46);
            txtServeur.Name = "txtServeur";
            txtServeur.Size = new Size(203, 23);
            txtServeur.TabIndex = 7;
            txtServeur.MaskInputRejected += txtServeur_MaskInputRejected_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 28);
            label3.Name = "label3";
            label3.Size = new Size(52, 15);
            label3.TabIndex = 6;
            label3.Text = "Serveur :";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(261, 46);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(84, 23);
            txtPort.TabIndex = 9;
            txtPort.MaskInputRejected += txtPort_MaskInputRejected;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(261, 28);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 8;
            label4.Text = "Port :";
            // 
            // txtBaseDonnee
            // 
            txtBaseDonnee.Location = new Point(33, 142);
            txtBaseDonnee.Name = "txtBaseDonnee";
            txtBaseDonnee.Size = new Size(203, 23);
            txtBaseDonnee.TabIndex = 11;
            txtBaseDonnee.MaskInputRejected += txtBaseDonnee_MaskInputRejected_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(33, 124);
            label5.Name = "label5";
            label5.Size = new Size(96, 15);
            label5.TabIndex = 10;
            label5.Text = "Base de donnée :";
            // 
            // btnEnregistrer
            // 
            btnEnregistrer.Location = new Point(138, 375);
            btnEnregistrer.Name = "btnEnregistrer";
            btnEnregistrer.Size = new Size(101, 42);
            btnEnregistrer.TabIndex = 12;
            btnEnregistrer.Text = "Enregistrer";
            btnEnregistrer.UseVisualStyleBackColor = true;
            btnEnregistrer.Click += btnEnregistrer_Click_1;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnEnregistrer);
            Controls.Add(txtBaseDonnee);
            Controls.Add(label5);
            Controls.Add(txtPort);
            Controls.Add(label4);
            Controls.Add(txtServeur);
            Controls.Add(label3);
            Controls.Add(btnAnnuler);
            Controls.Add(btnConnexion);
            Controls.Add(txtMotDePasse);
            Controls.Add(txtUtilisateur);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormLogin";
            Text = "FormLogin";
            Load += FormLogin_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private MaskedTextBox txtUtilisateur;
        private MaskedTextBox txtMotDePasse;
        private Button btnConnexion;
        private Button btnAnnuler;
        private MaskedTextBox txtServeur;
        private Label label3;
        private MaskedTextBox txtPort;
        private Label label4;
        private MaskedTextBox txtBaseDonnee;
        private Label label5;
        private Button btnEnregistrer;
    }
}
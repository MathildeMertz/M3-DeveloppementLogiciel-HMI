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
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 26);
            label1.Name = "label1";
            label1.Size = new Size(66, 15);
            label1.TabIndex = 0;
            label1.Text = "Utilisateur :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(36, 108);
            label2.Name = "label2";
            label2.Size = new Size(83, 15);
            label2.TabIndex = 1;
            label2.Text = "Mot de passe :";
            label2.Click += label2_Click;
            // 
            // txtUtilisateur
            // 
            txtUtilisateur.Location = new Point(36, 65);
            txtUtilisateur.Name = "txtUtilisateur";
            txtUtilisateur.Size = new Size(203, 23);
            txtUtilisateur.TabIndex = 2;
            txtUtilisateur.MaskInputRejected += txtUtilisateur_MaskInputRejected;
            // 
            // txtMotDePasse
            // 
            txtMotDePasse.Location = new Point(36, 142);
            txtMotDePasse.Name = "txtMotDePasse";
            txtMotDePasse.PasswordChar = '*';
            txtMotDePasse.Size = new Size(203, 23);
            txtMotDePasse.TabIndex = 3;
            txtMotDePasse.MaskInputRejected += txtMotDePasse_MaskInputRejected;
            // 
            // btnConnexion
            // 
            btnConnexion.Location = new Point(36, 199);
            btnConnexion.Name = "btnConnexion";
            btnConnexion.Size = new Size(99, 42);
            btnConnexion.TabIndex = 4;
            btnConnexion.Text = "Se connecter";
            btnConnexion.UseVisualStyleBackColor = true;
            btnConnexion.Click += btnConnexion_Click;
            // 
            // btnAnnuler
            // 
            btnAnnuler.Location = new Point(141, 199);
            btnAnnuler.Name = "btnAnnuler";
            btnAnnuler.Size = new Size(99, 42);
            btnAnnuler.TabIndex = 5;
            btnAnnuler.Text = "Annuler";
            btnAnnuler.UseVisualStyleBackColor = true;
            btnAnnuler.Click += btnAnnuler_Click;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}
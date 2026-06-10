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
            btnFermer = new Button();
            panelDonut = new Panel();
            panelBarresRecettes = new Panel();
            panelBarresJours = new Panel();
            panelLegende = new Panel();
            label5 = new Label();
            label6 = new Label();
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
            label1.Click += label1_Click;
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
            label3.Click += label3_Click;
            // 
            // cboPeriode
            // 
            cboPeriode.FormattingEnabled = true;
            cboPeriode.Location = new Point(71, 6);
            cboPeriode.Name = "cboPeriode";
            cboPeriode.Size = new Size(132, 23);
            cboPeriode.TabIndex = 3;
            cboPeriode.SelectedIndexChanged += cboPeriode_SelectedIndexChanged;
            // 
            // dtpDu
            // 
            dtpDu.Location = new Point(243, 6);
            dtpDu.Name = "dtpDu";
            dtpDu.Size = new Size(200, 23);
            dtpDu.TabIndex = 4;
            dtpDu.ValueChanged += dtpDu_ValueChanged;
            // 
            // dtpAu
            // 
            dtpAu.Location = new Point(493, 6);
            dtpAu.Name = "dtpAu";
            dtpAu.Size = new Size(200, 23);
            dtpAu.TabIndex = 5;
            dtpAu.ValueChanged += dtpAu_ValueChanged;
            // 
            // btnActualiser
            // 
            btnActualiser.Location = new Point(699, 6);
            btnActualiser.Name = "btnActualiser";
            btnActualiser.Size = new Size(89, 23);
            btnActualiser.TabIndex = 6;
            btnActualiser.Text = "Actualiser";
            btnActualiser.UseVisualStyleBackColor = true;
            btnActualiser.Click += btnActualiser_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(12, 103);
            label4.Name = "label4";
            label4.Size = new Size(96, 21);
            label4.TabIndex = 7;
            label4.Text = "Lots par état";
            // 
            // btnFermer
            // 
            btnFermer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFermer.Location = new Point(12, 633);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(97, 36);
            btnFermer.TabIndex = 18;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += btnFermer_Click;
            // 
            // panelDonut
            // 
            panelDonut.Location = new Point(12, 127);
            panelDonut.Name = "panelDonut";
            panelDonut.Size = new Size(246, 233);
            panelDonut.TabIndex = 21;
            panelDonut.Paint += panelDonut_Paint;
            // 
            // panelBarresRecettes
            // 
            panelBarresRecettes.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            panelBarresRecettes.Location = new Point(12, 394);
            panelBarresRecettes.Name = "panelBarresRecettes";
            panelBarresRecettes.Size = new Size(681, 233);
            panelBarresRecettes.TabIndex = 22;
            panelBarresRecettes.Paint += panelBarresRecettes_Paint;
            // 
            // panelBarresJours
            // 
            panelBarresJours.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            panelBarresJours.Location = new Point(504, 127);
            panelBarresJours.Name = "panelBarresJours";
            panelBarresJours.Size = new Size(619, 233);
            panelBarresJours.TabIndex = 22;
            panelBarresJours.Paint += panelBarresJours_Paint;
            // 
            // panelLegende
            // 
            panelLegende.Location = new Point(264, 127);
            panelLegende.Name = "panelLegende";
            panelLegende.Size = new Size(234, 233);
            panelLegende.TabIndex = 22;
            panelLegende.Paint += panelLegende_Paint;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(504, 93);
            label5.Name = "label5";
            label5.Size = new Size(98, 21);
            label5.TabIndex = 23;
            label5.Text = "Lots par jour";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(12, 370);
            label6.Name = "label6";
            label6.Size = new Size(152, 21);
            label6.TabIndex = 24;
            label6.Text = "Top recettes utilisées";
            // 
            // FormStatistiques
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(panelBarresJours);
            Controls.Add(panelLegende);
            Controls.Add(panelBarresRecettes);
            Controls.Add(btnFermer);
            Controls.Add(label4);
            Controls.Add(btnActualiser);
            Controls.Add(dtpAu);
            Controls.Add(dtpDu);
            Controls.Add(cboPeriode);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panelDonut);
            Name = "FormStatistiques";
            Text = "Statistiques";
            Load += FormStatistiques_Load;
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
        private Button btnFermer;
        private Panel panelDonut;
        private Panel panelBarresRecettes;
        private Panel panelBarresJours;
        private Panel panelLegende;
        private Label label5;
        private Label label6;
    }
}
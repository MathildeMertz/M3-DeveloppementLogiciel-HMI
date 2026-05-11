namespace App_Gestion_lots_M3.UI
{
    partial class FormTracabilite
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
            cboSelectLot = new ComboBox();
            groupBox1 = new GroupBox();
            dtpAu = new DateTimePicker();
            label3 = new Label();
            dtpDu = new DateTimePicker();
            label2 = new Label();
            groupBox2 = new GroupBox();
            rbDebut = new RadioButton();
            rbAlarmes = new RadioButton();
            rbFin = new RadioButton();
            rbTous = new RadioButton();
            dgvEvenements = new DataGridView();
            colDate = new DataGridViewTextBoxColumn();
            colHeure = new DataGridViewTextBoxColumn();
            colEvenement = new DataGridViewTextBoxColumn();
            btnExporterPDF = new Button();
            btnFermer = new Button();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvenements).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Sélectionner le Lot :";
            // 
            // cboSelectLot
            // 
            cboSelectLot.FormattingEnabled = true;
            cboSelectLot.Location = new Point(128, 6);
            cboSelectLot.Name = "cboSelectLot";
            cboSelectLot.Size = new Size(121, 23);
            cboSelectLot.TabIndex = 1;
            cboSelectLot.SelectedIndexChanged += cboSelectLot_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dtpAu);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpDu);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(175, 101);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtrer par Date :";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // dtpAu
            // 
            dtpAu.Location = new Point(49, 56);
            dtpAu.Name = "dtpAu";
            dtpAu.Size = new Size(107, 23);
            dtpAu.TabIndex = 3;
            dtpAu.ValueChanged += dtpAu_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(15, 62);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 2;
            label3.Text = "Au :";
            // 
            // dtpDu
            // 
            dtpDu.Location = new Point(49, 22);
            dtpDu.Name = "dtpDu";
            dtpDu.Size = new Size(107, 23);
            dtpDu.TabIndex = 1;
            dtpDu.ValueChanged += dtpDu_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 28);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 0;
            label2.Text = "Du :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbDebut);
            groupBox2.Controls.Add(rbAlarmes);
            groupBox2.Controls.Add(rbFin);
            groupBox2.Controls.Add(rbTous);
            groupBox2.Location = new Point(12, 170);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(175, 198);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filtrer par Evenement:";
            groupBox2.Enter += groupBox2_Enter;
            // 
            // rbDebut
            // 
            rbDebut.AutoSize = true;
            rbDebut.Location = new Point(34, 70);
            rbDebut.Name = "rbDebut";
            rbDebut.Size = new Size(57, 19);
            rbDebut.TabIndex = 8;
            rbDebut.TabStop = true;
            rbDebut.Text = "Début";
            rbDebut.UseVisualStyleBackColor = true;
            rbDebut.CheckedChanged += rbDebut_CheckedChanged;
            // 
            // rbAlarmes
            // 
            rbAlarmes.AutoSize = true;
            rbAlarmes.Location = new Point(34, 146);
            rbAlarmes.Name = "rbAlarmes";
            rbAlarmes.Size = new Size(68, 19);
            rbAlarmes.TabIndex = 7;
            rbAlarmes.TabStop = true;
            rbAlarmes.Text = "Alarmes";
            rbAlarmes.UseVisualStyleBackColor = true;
            rbAlarmes.CheckedChanged += rbAlarmes_CheckedChanged;
            // 
            // rbFin
            // 
            rbFin.AutoSize = true;
            rbFin.Location = new Point(34, 108);
            rbFin.Name = "rbFin";
            rbFin.Size = new Size(41, 19);
            rbFin.TabIndex = 6;
            rbFin.TabStop = true;
            rbFin.Text = "Fin";
            rbFin.UseVisualStyleBackColor = true;
            rbFin.CheckedChanged += rbFin_CheckedChanged;
            // 
            // rbTous
            // 
            rbTous.AutoSize = true;
            rbTous.Location = new Point(34, 36);
            rbTous.Name = "rbTous";
            rbTous.Size = new Size(49, 19);
            rbTous.TabIndex = 5;
            rbTous.TabStop = true;
            rbTous.Text = "Tous";
            rbTous.UseVisualStyleBackColor = true;
            rbTous.CheckedChanged += rbTous_CheckedChanged;
            // 
            // dgvEvenements
            // 
            dgvEvenements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvenements.Columns.AddRange(new DataGridViewColumn[] { colDate, colHeure, colEvenement });
            dgvEvenements.Location = new Point(204, 55);
            dgvEvenements.Name = "dgvEvenements";
            dgvEvenements.Size = new Size(350, 313);
            dgvEvenements.TabIndex = 5;
            dgvEvenements.CellContentClick += dgvEvenements_CellContentClick;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            // 
            // colHeure
            // 
            colHeure.HeaderText = "Heure";
            colHeure.Name = "colHeure";
            // 
            // colEvenement
            // 
            colEvenement.HeaderText = "Evenement";
            colEvenement.Name = "colEvenement";
            // 
            // btnExporterPDF
            // 
            btnExporterPDF.Location = new Point(91, 402);
            btnExporterPDF.Name = "btnExporterPDF";
            btnExporterPDF.Size = new Size(142, 50);
            btnExporterPDF.TabIndex = 6;
            btnExporterPDF.Text = "Exporter PDF";
            btnExporterPDF.UseVisualStyleBackColor = true;
            btnExporterPDF.Click += btnExporterPDF_Click;
            // 
            // btnFermer
            // 
            btnFermer.Location = new Point(251, 402);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(142, 50);
            btnFermer.TabIndex = 7;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += btnFermer_Click;
            // 
            // FormTracabilite
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(587, 481);
            Controls.Add(btnFermer);
            Controls.Add(btnExporterPDF);
            Controls.Add(dgvEvenements);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(cboSelectLot);
            Controls.Add(label1);
            Name = "FormTracabilite";
            Text = "Historique de Traçabilité";
            WindowState = FormWindowState.Maximized;
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEvenements).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cboSelectLot;
        private GroupBox groupBox1;
        private DateTimePicker dtpDu;
        private Label label2;
        private DateTimePicker dtpAu;
        private Label label3;
        private GroupBox groupBox2;
        private RadioButton rbDebut;
        private RadioButton rbAlarmes;
        private RadioButton rbFin;
        private RadioButton rbTous;
        private DataGridView dgvEvenements;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colHeure;
        private DataGridViewTextBoxColumn colEvenement;
        private Button btnExporterPDF;
        private Button btnFermer;
    }
}
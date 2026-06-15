namespace App_Gestion_lots_M3.UI
{
    partial class FormTracabilite
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTracabilite));
            label1 = new Label();
            cboSelectLot = new ComboBox();
            groupBox1 = new GroupBox();
            chkToutesLesDates = new CheckBox();
            dtpAu = new DateTimePicker();
            label3 = new Label();
            dtpDu = new DateTimePicker();
            label2 = new Label();
            groupBox2 = new GroupBox();
            rbTous = new RadioButton();
            rbDebut = new RadioButton();
            rbFin = new RadioButton();
            rbAlarmes = new RadioButton();
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
            label1.Location = new Point(12, 12);
            label1.Name = "label1";
            label1.Size = new Size(110, 15);
            label1.TabIndex = 0;
            label1.Text = "Sélectionner le Lot :";
            // 
            // cboSelectLot
            // 
            cboSelectLot.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSelectLot.FormattingEnabled = true;
            cboSelectLot.Location = new Point(130, 9);
            cboSelectLot.Name = "cboSelectLot";
            cboSelectLot.Size = new Size(150, 23);
            cboSelectLot.TabIndex = 1;
            cboSelectLot.SelectedIndexChanged += cboSelectLot_SelectedIndexChanged;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(chkToutesLesDates);
            groupBox1.Controls.Add(dtpAu);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(dtpDu);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(12, 46);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(200, 130);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Filtrer par Date :";
            // 
            // chkToutesLesDates
            // 
            chkToutesLesDates.AutoSize = true;
            chkToutesLesDates.Location = new Point(10, 22);
            chkToutesLesDates.Name = "chkToutesLesDates";
            chkToutesLesDates.Size = new Size(92, 19);
            chkToutesLesDates.TabIndex = 4;
            chkToutesLesDates.Text = "Tout afficher";
            chkToutesLesDates.UseVisualStyleBackColor = true;
            chkToutesLesDates.CheckedChanged += chkToutesLesDates_CheckedChanged;
            // 
            // dtpAu
            // 
            dtpAu.Location = new Point(50, 87);
            dtpAu.Name = "dtpAu";
            dtpAu.Size = new Size(130, 23);
            dtpAu.TabIndex = 3;
            dtpAu.ValueChanged += dtpAu_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(10, 90);
            label3.Name = "label3";
            label3.Size = new Size(28, 15);
            label3.TabIndex = 2;
            label3.Text = "Au :";
            // 
            // dtpDu
            // 
            dtpDu.Location = new Point(50, 52);
            dtpDu.Name = "dtpDu";
            dtpDu.Size = new Size(130, 23);
            dtpDu.TabIndex = 1;
            dtpDu.ValueChanged += dtpDu_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(10, 55);
            label2.Name = "label2";
            label2.Size = new Size(28, 15);
            label2.TabIndex = 0;
            label2.Text = "Du :";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(rbTous);
            groupBox2.Controls.Add(rbDebut);
            groupBox2.Controls.Add(rbFin);
            groupBox2.Controls.Add(rbAlarmes);
            groupBox2.Location = new Point(12, 190);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(200, 160);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Filtrer par Evenement :";
            // 
            // rbTous
            // 
            rbTous.AutoSize = true;
            rbTous.Location = new Point(15, 25);
            rbTous.Name = "rbTous";
            rbTous.Size = new Size(49, 19);
            rbTous.TabIndex = 0;
            rbTous.Text = "Tous";
            rbTous.UseVisualStyleBackColor = true;
            rbTous.CheckedChanged += rbTous_CheckedChanged;
            // 
            // rbDebut
            // 
            rbDebut.AutoSize = true;
            rbDebut.Location = new Point(15, 55);
            rbDebut.Name = "rbDebut";
            rbDebut.Size = new Size(57, 19);
            rbDebut.TabIndex = 1;
            rbDebut.Text = "Début";
            rbDebut.UseVisualStyleBackColor = true;
            rbDebut.CheckedChanged += rbDebut_CheckedChanged;
            // 
            // rbFin
            // 
            rbFin.AutoSize = true;
            rbFin.Location = new Point(15, 85);
            rbFin.Name = "rbFin";
            rbFin.Size = new Size(41, 19);
            rbFin.TabIndex = 2;
            rbFin.Text = "Fin";
            rbFin.UseVisualStyleBackColor = true;
            rbFin.CheckedChanged += rbFin_CheckedChanged;
            // 
            // rbAlarmes
            // 
            rbAlarmes.AutoSize = true;
            rbAlarmes.Location = new Point(15, 115);
            rbAlarmes.Name = "rbAlarmes";
            rbAlarmes.Size = new Size(68, 19);
            rbAlarmes.TabIndex = 3;
            rbAlarmes.Text = "Alarmes";
            rbAlarmes.UseVisualStyleBackColor = true;
            rbAlarmes.CheckedChanged += rbAlarmes_CheckedChanged;
            // 
            // dgvEvenements
            // 
            dgvEvenements.AllowUserToAddRows = false;
            dgvEvenements.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvEvenements.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEvenements.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEvenements.Columns.AddRange(new DataGridViewColumn[] { colDate, colHeure, colEvenement });
            dgvEvenements.Location = new Point(225, 40);
            dgvEvenements.Name = "dgvEvenements";
            dgvEvenements.ReadOnly = true;
            dgvEvenements.RowHeadersVisible = false;
            dgvEvenements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEvenements.Size = new Size(550, 380);
            dgvEvenements.TabIndex = 5;
            dgvEvenements.CellContentClick += dgvEvenements_CellContentClick;
            // 
            // colDate
            // 
            colDate.HeaderText = "Date";
            colDate.Name = "colDate";
            colDate.ReadOnly = true;
            // 
            // colHeure
            // 
            colHeure.HeaderText = "Heure";
            colHeure.Name = "colHeure";
            colHeure.ReadOnly = true;
            // 
            // colEvenement
            // 
            colEvenement.HeaderText = "Événement";
            colEvenement.Name = "colEvenement";
            colEvenement.ReadOnly = true;
            // 
            // btnExporterPDF
            // 
            btnExporterPDF.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExporterPDF.Location = new Point(12, 440);
            btnExporterPDF.Name = "btnExporterPDF";
            btnExporterPDF.Size = new Size(150, 36);
            btnExporterPDF.TabIndex = 6;
            btnExporterPDF.Text = "Exporter PDF";
            btnExporterPDF.UseVisualStyleBackColor = true;
            btnExporterPDF.Click += btnExporterPDF_Click;
            // 
            // btnFermer
            // 
            btnFermer.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnFermer.Location = new Point(170, 440);
            btnFermer.Name = "btnFermer";
            btnFermer.Size = new Size(150, 36);
            btnFermer.TabIndex = 7;
            btnFermer.Text = "Fermer";
            btnFermer.UseVisualStyleBackColor = true;
            btnFermer.Click += btnFermer_Click;
            // 
            // FormTracabilite
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 490);
            Controls.Add(btnFermer);
            Controls.Add(btnExporterPDF);
            Controls.Add(dgvEvenements);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(cboSelectLot);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "FormTracabilite";
            Text = "Historique de Traçabilité";
            WindowState = FormWindowState.Maximized;
            Load += FormTracabilite_Load;
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
        private CheckBox chkToutesLesDates;
        private DateTimePicker dtpDu;
        private Label label2;
        private DateTimePicker dtpAu;
        private Label label3;
        private GroupBox groupBox2;
        private RadioButton rbTous;
        private RadioButton rbDebut;
        private RadioButton rbFin;
        private RadioButton rbAlarmes;
        private DataGridView dgvEvenements;
        private DataGridViewTextBoxColumn colDate;
        private DataGridViewTextBoxColumn colHeure;
        private DataGridViewTextBoxColumn colEvenement;
        private Button btnExporterPDF;
        private Button btnFermer;
    }
}
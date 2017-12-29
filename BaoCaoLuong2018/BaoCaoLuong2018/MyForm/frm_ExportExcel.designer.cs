namespace BaoCaoLuong2018.MyForm
{
    partial class frm_ExportExcel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ExportExcel));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbb_Batch = new System.Windows.Forms.ComboBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.chk_Multiple = new System.Windows.Forms.CheckBox();
            this.lb_Complete = new System.Windows.Forms.Label();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbb_City = new System.Windows.Forms.ComboBox();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.dgv = new DevExpress.XtraTab.XtraTabPage();
            this.Batch = new DevExpress.XtraTab.XtraTabPage();
            this.list_Batch = new System.Windows.Forms.ListBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.dgv.SuspendLayout();
            this.Batch.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(170, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(92, 19);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Chọn Batch";
            // 
            // cbb_Batch
            // 
            this.cbb_Batch.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_Batch.FormattingEnabled = true;
            this.cbb_Batch.Location = new System.Drawing.Point(268, 7);
            this.cbb_Batch.Name = "cbb_Batch";
            this.cbb_Batch.Size = new System.Drawing.Size(300, 26);
            this.cbb_Batch.TabIndex = 1;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Location = new System.Drawing.Point(574, 8);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(102, 25);
            this.simpleButton1.TabIndex = 2;
            this.simpleButton1.Text = "Xuất Excel";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1095, 494);
            this.dataGridView1.TabIndex = 3;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.progressBar1);
            this.panelControl1.Controls.Add(this.chk_Multiple);
            this.panelControl1.Controls.Add(this.lb_Complete);
            this.panelControl1.Controls.Add(this.simpleButton2);
            this.panelControl1.Controls.Add(this.simpleButton1);
            this.panelControl1.Controls.Add(this.labelControl2);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.cbb_City);
            this.panelControl1.Controls.Add(this.cbb_Batch);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1105, 75);
            this.panelControl1.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(31, 43);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(943, 23);
            this.progressBar1.TabIndex = 6;
            // 
            // chk_Multiple
            // 
            this.chk_Multiple.AutoSize = true;
            this.chk_Multiple.Location = new System.Drawing.Point(794, 13);
            this.chk_Multiple.Name = "chk_Multiple";
            this.chk_Multiple.Size = new System.Drawing.Size(141, 17);
            this.chk_Multiple.TabIndex = 5;
            this.chk_Multiple.Text = "Multiple export file Error";
            this.chk_Multiple.UseVisualStyleBackColor = true;
            this.chk_Multiple.CheckedChanged += new System.EventHandler(this.chk_Multiple_CheckedChanged);
            // 
            // lb_Complete
            // 
            this.lb_Complete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_Complete.AutoSize = true;
            this.lb_Complete.Location = new System.Drawing.Point(991, 48);
            this.lb_Complete.Name = "lb_Complete";
            this.lb_Complete.Size = new System.Drawing.Size(0, 13);
            this.lb_Complete.TabIndex = 4;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.Location = new System.Drawing.Point(682, 8);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(102, 25);
            this.simpleButton2.TabIndex = 2;
            this.simpleButton2.Text = "Error";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(6, 11);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(38, 19);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "City:";
            // 
            // cbb_City
            // 
            this.cbb_City.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbb_City.FormattingEnabled = true;
            this.cbb_City.Location = new System.Drawing.Point(47, 8);
            this.cbb_City.Name = "cbb_City";
            this.cbb_City.Size = new System.Drawing.Size(104, 26);
            this.cbb_City.TabIndex = 1;
            this.cbb_City.SelectedIndexChanged += new System.EventHandler(this.txt_LoaiPhieu_SelectedIndexChanged);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.xtraTabControl1);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(0, 75);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(1105, 504);
            this.panelControl2.TabIndex = 5;
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.dgv;
            this.xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabControl1.Size = new System.Drawing.Size(1101, 500);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.dgv,
            this.Batch});
            // 
            // dgv
            // 
            this.dgv.Controls.Add(this.dataGridView1);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(1095, 494);
            this.dgv.Text = "dgv";
            // 
            // Batch
            // 
            this.Batch.Controls.Add(this.list_Batch);
            this.Batch.Name = "Batch";
            this.Batch.Size = new System.Drawing.Size(1095, 494);
            this.Batch.Text = "Batch";
            // 
            // list_Batch
            // 
            this.list_Batch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_Batch.FormattingEnabled = true;
            this.list_Batch.Location = new System.Drawing.Point(0, 0);
            this.list_Batch.MultiColumn = true;
            this.list_Batch.Name = "list_Batch";
            this.list_Batch.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.list_Batch.Size = new System.Drawing.Size(1095, 494);
            this.list_Batch.TabIndex = 0;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // frm_ExportExcel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 579);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_ExportExcel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExportExcel";
            this.Load += new System.EventHandler(this.frm_ExportExcel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.dgv.ResumeLayout(false);
            this.Batch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.ComboBox cbb_Batch;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label lb_Complete;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private System.Windows.Forms.CheckBox chk_Multiple;
        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage dgv;
        private DevExpress.XtraTab.XtraTabPage Batch;
        private System.Windows.Forms.ListBox list_Batch;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.ComboBox cbb_City;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}
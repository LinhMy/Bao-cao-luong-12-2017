namespace BaoCaoLuong2018.MyForm
{
    partial class FrmTienDo
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTienDo));
            this.rb_deso = new DevExpress.XtraEditors.PanelControl();
            this.lb_soHinhUserNotGood = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lb_soHinhUserGood = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lb_TongSoHinh = new DevExpress.XtraEditors.LabelControl();
            this.ck_All = new DevExpress.XtraEditors.CheckEdit();
            this.btn_ChiTiet = new DevExpress.XtraEditors.SimpleButton();
            this.cbb_Batch = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.chartControl1 = new DevExpress.XtraCharts.ChartControl();
            this.time_CheckHinhChuaNhap = new System.Windows.Forms.Timer(this.components);
            this.pn_Select = new System.Windows.Forms.Panel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rb_dejp = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.rb_deso)).BeginInit();
            this.rb_deso.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ck_All.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_Batch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            this.pn_Select.SuspendLayout();
            this.SuspendLayout();
            // 
            // rb_deso
            // 
            this.rb_deso.Controls.Add(this.pn_Select);
            this.rb_deso.Controls.Add(this.lb_soHinhUserNotGood);
            this.rb_deso.Controls.Add(this.labelControl5);
            this.rb_deso.Controls.Add(this.lb_soHinhUserGood);
            this.rb_deso.Controls.Add(this.labelControl3);
            this.rb_deso.Controls.Add(this.labelControl2);
            this.rb_deso.Controls.Add(this.lb_TongSoHinh);
            this.rb_deso.Controls.Add(this.btn_ChiTiet);
            this.rb_deso.Controls.Add(this.cbb_Batch);
            this.rb_deso.Controls.Add(this.labelControl1);
            this.rb_deso.Dock = System.Windows.Forms.DockStyle.Top;
            this.rb_deso.Location = new System.Drawing.Point(0, 0);
            this.rb_deso.Name = "rb_deso";
            this.rb_deso.Size = new System.Drawing.Size(1082, 85);
            this.rb_deso.TabIndex = 1;
            // 
            // lb_soHinhUserNotGood
            // 
            this.lb_soHinhUserNotGood.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_soHinhUserNotGood.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lb_soHinhUserNotGood.Appearance.Options.UseFont = true;
            this.lb_soHinhUserNotGood.Appearance.Options.UseForeColor = true;
            this.lb_soHinhUserNotGood.Location = new System.Drawing.Point(868, 39);
            this.lb_soHinhUserNotGood.Name = "lb_soHinhUserNotGood";
            this.lb_soHinhUserNotGood.Size = new System.Drawing.Size(8, 14);
            this.lb_soHinhUserNotGood.TabIndex = 15;
            this.lb_soHinhUserNotGood.Text = "0";
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(677, 40);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(183, 13);
            this.labelControl5.TabIndex = 14;
            this.labelControl5.Text = "Số hình chưa nhập của User NotGood:";
            // 
            // lb_soHinhUserGood
            // 
            this.lb_soHinhUserGood.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_soHinhUserGood.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.lb_soHinhUserGood.Appearance.Options.UseFont = true;
            this.lb_soHinhUserGood.Appearance.Options.UseForeColor = true;
            this.lb_soHinhUserGood.Location = new System.Drawing.Point(868, 21);
            this.lb_soHinhUserGood.Name = "lb_soHinhUserGood";
            this.lb_soHinhUserGood.Size = new System.Drawing.Size(8, 14);
            this.lb_soHinhUserGood.TabIndex = 13;
            this.lb_soHinhUserGood.Text = "0";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(677, 22);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(166, 13);
            this.labelControl3.TabIndex = 12;
            this.labelControl3.Text = "Số hình chưa nhập của User Good:";
            // 
            // labelControl2
            // 
            this.labelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(915, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 7;
            this.labelControl2.Text = "Tổng số hình:";
            // 
            // lb_TongSoHinh
            // 
            this.lb_TongSoHinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lb_TongSoHinh.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lb_TongSoHinh.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lb_TongSoHinh.Appearance.Options.UseFont = true;
            this.lb_TongSoHinh.Appearance.Options.UseForeColor = true;
            this.lb_TongSoHinh.Location = new System.Drawing.Point(995, 58);
            this.lb_TongSoHinh.Name = "lb_TongSoHinh";
            this.lb_TongSoHinh.Size = new System.Drawing.Size(40, 19);
            this.lb_TongSoHinh.TabIndex = 6;
            this.lb_TongSoHinh.Text = "1000";
            // 
            // ck_All
            // 
            this.ck_All.Location = new System.Drawing.Point(214, 6);
            this.ck_All.Name = "ck_All";
            this.ck_All.Properties.Caption = "All";
            this.ck_All.Size = new System.Drawing.Size(31, 19);
            this.ck_All.TabIndex = 4;
            this.ck_All.CheckedChanged += new System.EventHandler(this.ck_All_CheckedChanged);
            // 
            // btn_ChiTiet
            // 
            this.btn_ChiTiet.Location = new System.Drawing.Point(550, 35);
            this.btn_ChiTiet.Name = "btn_ChiTiet";
            this.btn_ChiTiet.Size = new System.Drawing.Size(75, 23);
            this.btn_ChiTiet.TabIndex = 2;
            this.btn_ChiTiet.Text = "Detail";
            this.btn_ChiTiet.Click += new System.EventHandler(this.btn_ChiTiet_Click);
            // 
            // cbb_Batch
            // 
            this.cbb_Batch.Location = new System.Drawing.Point(46, 27);
            this.cbb_Batch.Name = "cbb_Batch";
            this.cbb_Batch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbb_Batch.Properties.NullText = "No batch";
            this.cbb_Batch.Size = new System.Drawing.Size(473, 20);
            this.cbb_Batch.TabIndex = 1;
            this.cbb_Batch.EditValueChanged += new System.EventHandler(this.cbb_Batch_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(9, 31);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Batch:";
            // 
            // chartControl1
            // 
            this.chartControl1.BorderOptions.Color = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.chartControl1.DataBindings = null;
            this.chartControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartControl1.Legend.Name = "Default Legend";
            this.chartControl1.Location = new System.Drawing.Point(0, 85);
            this.chartControl1.Name = "chartControl1";
            this.chartControl1.PaletteName = "Palette 1";
            this.chartControl1.PaletteRepository.Add("Palette 1", new DevExpress.XtraCharts.Palette("Palette 1", DevExpress.XtraCharts.PaletteScaleMode.Repeat, new DevExpress.XtraCharts.PaletteEntry[] {
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Silver, System.Drawing.Color.Silver),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64))))), System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(64)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(64))))), System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))))),
                new DevExpress.XtraCharts.PaletteEntry(System.Drawing.Color.Green, System.Drawing.Color.Green)}));
            series1.Name = "Series 1";
            series1.View = pieSeriesView1;
            this.chartControl1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.chartControl1.Size = new System.Drawing.Size(1082, 593);
            this.chartControl1.TabIndex = 2;
            this.chartControl1.CustomDrawSeriesPoint += new DevExpress.XtraCharts.CustomDrawSeriesPointEventHandler(this.chartControl1_CustomDrawSeriesPoint);
            // 
            // time_CheckHinhChuaNhap
            // 
            this.time_CheckHinhChuaNhap.Enabled = true;
            this.time_CheckHinhChuaNhap.Interval = 2000;
            this.time_CheckHinhChuaNhap.Tick += new System.EventHandler(this.time_CheckHinhChuaNhap_Tick);
            // 
            // pn_Select
            // 
            this.pn_Select.Controls.Add(this.rb_dejp);
            this.pn_Select.Controls.Add(this.radioButton1);
            this.pn_Select.Controls.Add(this.ck_All);
            this.pn_Select.Location = new System.Drawing.Point(106, 51);
            this.pn_Select.Name = "pn_Select";
            this.pn_Select.Size = new System.Drawing.Size(345, 31);
            this.pn_Select.TabIndex = 16;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(71, 7);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 5;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "DESO";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rb_dejp
            // 
            this.rb_dejp.AutoSize = true;
            this.rb_dejp.Location = new System.Drawing.Point(141, 7);
            this.rb_dejp.Name = "rb_dejp";
            this.rb_dejp.Size = new System.Drawing.Size(49, 17);
            this.rb_dejp.TabIndex = 6;
            this.rb_dejp.Text = "DEJP";
            this.rb_dejp.UseVisualStyleBackColor = true;
            // 
            // FrmTienDo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 678);
            this.Controls.Add(this.chartControl1);
            this.Controls.Add(this.rb_deso);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmTienDo";
            this.Text = "Progress";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_TienDo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.rb_deso)).EndInit();
            this.rb_deso.ResumeLayout(false);
            this.rb_deso.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ck_All.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbb_Batch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartControl1)).EndInit();
            this.pn_Select.ResumeLayout(false);
            this.pn_Select.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl rb_deso;
        private DevExpress.XtraEditors.SimpleButton btn_ChiTiet;
        private DevExpress.XtraEditors.LookUpEdit cbb_Batch;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraCharts.ChartControl chartControl1;
        private DevExpress.XtraEditors.CheckEdit ck_All;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lb_TongSoHinh;
        private System.Windows.Forms.Timer time_CheckHinhChuaNhap;
        private DevExpress.XtraEditors.LabelControl lb_soHinhUserNotGood;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lb_soHinhUserGood;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.Panel pn_Select;
        private System.Windows.Forms.RadioButton rb_dejp;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}
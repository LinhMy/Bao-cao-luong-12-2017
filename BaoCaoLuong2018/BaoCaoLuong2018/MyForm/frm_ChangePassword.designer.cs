namespace BaoCaoLuong2018.MyForm
{
    partial class frm_ChangePassword
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ChangePassword));
            this.lb_ThongBao = new DevExpress.XtraEditors.LabelControl();
            this.btn_ChangePass = new DevExpress.XtraEditors.SimpleButton();
            this.txt_PassNhapLai = new DevExpress.XtraEditors.TextEdit();
            this.txt_PassMoi = new DevExpress.XtraEditors.TextEdit();
            this.txt_PassCu = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassNhapLai.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassMoi.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassCu.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_ThongBao
            // 
            this.lb_ThongBao.Appearance.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_ThongBao.Appearance.ForeColor = System.Drawing.Color.Red;
            this.lb_ThongBao.Appearance.Options.UseFont = true;
            this.lb_ThongBao.Appearance.Options.UseForeColor = true;
            this.lb_ThongBao.Location = new System.Drawing.Point(63, 134);
            this.lb_ThongBao.Name = "lb_ThongBao";
            this.lb_ThongBao.Size = new System.Drawing.Size(67, 16);
            this.lb_ThongBao.TabIndex = 17;
            this.lb_ThongBao.Text = "Thông báo: ";
            // 
            // btn_ChangePass
            // 
            this.btn_ChangePass.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.btn_ChangePass.Appearance.Options.UseFont = true;
            this.btn_ChangePass.Location = new System.Drawing.Point(129, 97);
            this.btn_ChangePass.Name = "btn_ChangePass";
            this.btn_ChangePass.Size = new System.Drawing.Size(124, 32);
            this.btn_ChangePass.TabIndex = 16;
            this.btn_ChangePass.Text = "Đổi Password";
            this.btn_ChangePass.Click += new System.EventHandler(this.btn_ChangePass_Click);
            // 
            // txt_PassNhapLai
            // 
            this.txt_PassNhapLai.Location = new System.Drawing.Point(151, 66);
            this.txt_PassNhapLai.Name = "txt_PassNhapLai";
            this.txt_PassNhapLai.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_PassNhapLai.Properties.Appearance.Options.UseFont = true;
            this.txt_PassNhapLai.Properties.UseSystemPasswordChar = true;
            this.txt_PassNhapLai.Size = new System.Drawing.Size(214, 22);
            this.txt_PassNhapLai.TabIndex = 12;
            // 
            // txt_PassMoi
            // 
            this.txt_PassMoi.Location = new System.Drawing.Point(151, 37);
            this.txt_PassMoi.Name = "txt_PassMoi";
            this.txt_PassMoi.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_PassMoi.Properties.Appearance.Options.UseFont = true;
            this.txt_PassMoi.Properties.UseSystemPasswordChar = true;
            this.txt_PassMoi.Size = new System.Drawing.Size(214, 22);
            this.txt_PassMoi.TabIndex = 11;
            // 
            // txt_PassCu
            // 
            this.txt_PassCu.Location = new System.Drawing.Point(151, 7);
            this.txt_PassCu.Name = "txt_PassCu";
            this.txt_PassCu.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.txt_PassCu.Properties.Appearance.Options.UseFont = true;
            this.txt_PassCu.Properties.UseSystemPasswordChar = true;
            this.txt_PassCu.Size = new System.Drawing.Size(214, 22);
            this.txt_PassCu.TabIndex = 10;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.Location = new System.Drawing.Point(21, 69);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(124, 17);
            this.labelControl3.TabIndex = 7;
            this.labelControl3.Text = "Nhập lại pass mới:";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.Location = new System.Drawing.Point(44, 40);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(101, 17);
            this.labelControl2.TabIndex = 8;
            this.labelControl2.Text = "Password mới:";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(58, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(87, 16);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Password cũ:";
            // 
            // frm_ChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 159);
            this.Controls.Add(this.lb_ThongBao);
            this.Controls.Add(this.btn_ChangePass);
            this.Controls.Add(this.txt_PassNhapLai);
            this.Controls.Add(this.txt_PassMoi);
            this.Controls.Add(this.txt_PassCu);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frm_ChangePassword";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Đổi Password";
            this.Load += new System.EventHandler(this.frm_ChangePassword_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassNhapLai.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassMoi.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_PassCu.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lb_ThongBao;
        private DevExpress.XtraEditors.SimpleButton btn_ChangePass;
        private DevExpress.XtraEditors.TextEdit txt_PassNhapLai;
        private DevExpress.XtraEditors.TextEdit txt_PassMoi;
        private DevExpress.XtraEditors.TextEdit txt_PassCu;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}
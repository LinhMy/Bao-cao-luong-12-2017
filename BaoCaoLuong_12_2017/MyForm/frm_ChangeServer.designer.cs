namespace BaoCaoLuong_12_2017.MyForm
{
    partial class frm_ChangeServer
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
            this.rb_Khac = new System.Windows.Forms.RadioButton();
            this.rb_DaNang = new System.Windows.Forms.RadioButton();
            this.btn_Save = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // rb_Khac
            // 
            this.rb_Khac.AutoSize = true;
            this.rb_Khac.Location = new System.Drawing.Point(35, 59);
            this.rb_Khac.Name = "rb_Khac";
            this.rb_Khac.Size = new System.Drawing.Size(48, 17);
            this.rb_Khac.TabIndex = 10;
            this.rb_Khac.TabStop = true;
            this.rb_Khac.Text = "Khác";
            this.rb_Khac.UseVisualStyleBackColor = true;
            this.rb_Khac.CheckedChanged += new System.EventHandler(this.rb_Khac_CheckedChanged);
            // 
            // rb_DaNang
            // 
            this.rb_DaNang.AutoSize = true;
            this.rb_DaNang.Location = new System.Drawing.Point(35, 20);
            this.rb_DaNang.Name = "rb_DaNang";
            this.rb_DaNang.Size = new System.Drawing.Size(281, 17);
            this.rb_DaNang.TabIndex = 9;
            this.rb_DaNang.TabStop = true;
            this.rb_DaNang.Text = "Chi nhánh Đà Nẵng (Làm việc tại Minh Phúc Đà Nẵng)";
            this.rb_DaNang.UseVisualStyleBackColor = true;
            this.rb_DaNang.CheckedChanged += new System.EventHandler(this.rb_DaNang_CheckedChanged);
            // 
            // btn_Save
            // 
            this.btn_Save.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_Save.Location = new System.Drawing.Point(156, 94);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(91, 32);
            this.btn_Save.TabIndex = 8;
            this.btn_Save.Text = "OK";
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // frm_ChangeServer
            // 
            this.AcceptButton = this.btn_Save;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 138);
            this.Controls.Add(this.rb_Khac);
            this.Controls.Add(this.rb_DaNang);
            this.Controls.Add(this.btn_Save);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frm_ChangeServer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Server";
            this.Load += new System.EventHandler(this.frm_ChangeServer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rb_Khac;
        private System.Windows.Forms.RadioButton rb_DaNang;
        private DevExpress.XtraEditors.SimpleButton btn_Save;
    }
}
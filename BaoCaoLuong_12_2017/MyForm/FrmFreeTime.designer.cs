namespace BaoCaoLuong_12_2017.MyForm
{
    partial class FrmFreeTime
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lb_time = new DevExpress.XtraEditors.LabelControl();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 30F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Red;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(250, 48);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "You paused:";
            // 
            // lb_time
            // 
            this.lb_time.Appearance.Font = new System.Drawing.Font("Tahoma", 60F, System.Drawing.FontStyle.Bold);
            this.lb_time.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.lb_time.Appearance.Options.UseFont = true;
            this.lb_time.Appearance.Options.UseForeColor = true;
            this.lb_time.Location = new System.Drawing.Point(12, 84);
            this.lb_time.Name = "lb_time";
            this.lb_time.Size = new System.Drawing.Size(102, 97);
            this.lb_time.TabIndex = 1;
            this.lb_time.Text = "00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frm_FreeTime
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(403, 210);
            this.Controls.Add(this.lb_time);
            this.Controls.Add(this.labelControl1);
            this.KeyPreview = true;
            this.Name = "FrmFreeTime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FreeTime";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_FreeTime_FormClosing);
            this.Load += new System.EventHandler(this.frm_FreeTime_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frm_FreeTime_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lb_time;
        private System.Windows.Forms.Timer timer1;
    }
}
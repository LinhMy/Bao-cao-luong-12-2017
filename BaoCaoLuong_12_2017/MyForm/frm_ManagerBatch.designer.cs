namespace BaoCaoLuong_12_2017.MyForm
{
    partial class frm_ManagerBatch
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_ManagerBatch));
            this.btn_Xoa = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btn_xoabatch = new DevExpress.XtraEditors.SimpleButton();
            this.btn_TaoBatch = new DevExpress.XtraEditors.SimpleButton();
            this.BatchID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Xoa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.AutoHeight = false;
            editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
            this.btn_Xoa.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(editorButtonImageOptions1, DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, null)});
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.btn_Xoa.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btn_Xoa_ButtonClick);
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.btn_Xoa});
            this.gridControl1.Size = new System.Drawing.Size(947, 559);
            this.gridControl1.TabIndex = 3;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.BatchID,
            this.gridColumn2,
            this.gridColumn1,
            this.gridColumn9,
            this.gridColumn5,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn6,
            this.gridColumn8,
            this.gridColumn7});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.InvertSelection = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.CustomDrawRowIndicator += new DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventHandler(this.gridView1_CustomDrawRowIndicator);
            this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Folder";
            this.gridColumn9.FieldName = "PathPicture";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 3;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tên Batch";
            this.gridColumn2.FieldName = "BatchName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 4;
            this.gridColumn2.Width = 202;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Ngày tạo";
            this.gridColumn5.FieldName = "DateCreate";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.OptionsColumn.ReadOnly = true;
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 5;
            this.gridColumn5.Width = 141;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Số hình";
            this.gridColumn3.FieldName = "NumberImage";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 6;
            this.gridColumn3.Width = 110;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "User tạo batch";
            this.gridColumn4.FieldName = "UserCreate";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 7;
            this.gridColumn4.Width = 95;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Chia User";
            this.gridColumn6.FieldName = "ChiaUser";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 8;
            this.gridColumn6.Width = 77;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Công khai batch";
            this.gridColumn8.FieldName = "CongKhaiBatch";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 9;
            this.gridColumn8.Width = 83;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Xóa batch";
            this.gridColumn7.ColumnEdit = this.btn_Xoa;
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 10;
            this.gridColumn7.Width = 87;
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btn_xoabatch);
            this.panelControl1.Controls.Add(this.btn_TaoBatch);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 559);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(947, 38);
            this.panelControl1.TabIndex = 2;
            // 
            // btn_xoabatch
            // 
            this.btn_xoabatch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_xoabatch.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_xoabatch.Appearance.Options.UseFont = true;
            this.btn_xoabatch.Location = new System.Drawing.Point(478, 6);
            this.btn_xoabatch.Name = "btn_xoabatch";
            this.btn_xoabatch.Size = new System.Drawing.Size(120, 27);
            this.btn_xoabatch.TabIndex = 1;
            this.btn_xoabatch.Text = "Xóa batch (n)";
            this.btn_xoabatch.Click += new System.EventHandler(this.btn_xoabatch_Click);
            // 
            // btn_TaoBatch
            // 
            this.btn_TaoBatch.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btn_TaoBatch.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TaoBatch.Appearance.Options.UseFont = true;
            this.btn_TaoBatch.Location = new System.Drawing.Point(349, 6);
            this.btn_TaoBatch.Name = "btn_TaoBatch";
            this.btn_TaoBatch.Size = new System.Drawing.Size(118, 27);
            this.btn_TaoBatch.TabIndex = 0;
            this.btn_TaoBatch.Text = "Tạo Batch mới";
            this.btn_TaoBatch.Click += new System.EventHandler(this.btn_TaoBatch_Click);
            // 
            // BatchID
            // 
            this.BatchID.Caption = "Batch ID";
            this.BatchID.FieldName = "BatchID";
            this.BatchID.Name = "BatchID";
            this.BatchID.Visible = true;
            this.BatchID.VisibleIndex = 1;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "City";
            this.gridColumn1.FieldName = "City";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // frm_ManagerBatch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 597);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_ManagerBatch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Batch";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frm_ManagerBatch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Xoa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit btn_Xoa;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btn_TaoBatch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraEditors.SimpleButton btn_xoabatch;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn BatchID;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
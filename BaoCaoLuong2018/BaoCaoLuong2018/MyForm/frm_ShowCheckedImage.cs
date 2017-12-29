using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_ShowCheckedImage : XtraForm
    {
        public frm_ShowCheckedImage()
        {
            InitializeComponent();
        }

        public string BatchID = "";
        public string TypeCheck = "";

        public bool Cal(int width, GridView view)
        {
            view.IndicatorWidth = view.IndicatorWidth < width ? width : view.IndicatorWidth;
            return true;
        }

        private void LoadSttGridView(RowIndicatorCustomDrawEventArgs e, GridView dgv)
        {
            if (e.Info.IsRowIndicator && e.RowHandle >= 0)
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            SizeF size = e.Graphics.MeasureString(e.Info.DisplayText, e.Appearance.Font);
            int width = Convert.ToInt32(size.Width) + 20;
            BeginInvoke(new MethodInvoker(delegate { Cal(width, dgv); }));
        }
        public void SetNumberRowGridView(DataGridView dgv)
        {
            for (int i = 0; i < dgv.Rows.Count; i++)
            {
                dgv.Rows[i].HeaderCell.Value = (i + 1).ToString();
            }
        }
        bool FlagLoad = false;
        private void frm_ShowCheckedImage_Load(object sender, EventArgs e)
        {
            FlagLoad = true;
            gridView1.DoubleClick += gridView1_DoubleClick;
            gridView1.ShownEditor += gridView1_ShownEditor;
            gridView1.HiddenEditor += gridView1_HiddenEditor;
            comboBox1.DataSource = (from w in Global.Db.tbl_Batches where w.City==Global.StrCity select new { w.BatchID, w.BatchName }).ToList();
            comboBox1.DisplayMember = "BatchName";
            comboBox1.ValueMember = "BatchID";
            if (!string.IsNullOrEmpty(BatchID))
            {
                comboBox1.SelectedValue = BatchID;
            }
            FlagLoad = false;
            btn_Search_Click(null,null);
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            var listimage = (from w in Global.Db.GetImage_ShowImageCheck(comboBox1.SelectedValue+"",Global.StrUserName,Global.StrCity,Global.StrCheck,TypeCheck) select new {w.BatchID,w.BatchName, w.IDImage, w.DateCheckDeSo}).ToList();
            gridControl1.DataSource = listimage;
        }
        private void DoRowDoubleClick(GridView view, Point pt)
        {
            GridHitInfo info = view.CalcHitInfo(pt);
            if (info.RowHandle < 0)
                return;
            ShowImage showwImage = new ShowImage();
            showwImage.BatchID = gridView1.GetRowCellValue(info.RowHandle, "BatchID") + "";
            showwImage.BatchName = gridView1.GetRowCellValue(info.RowHandle, "BatchName") + "";
            showwImage.IdImage = gridView1.GetRowCellValue(info.RowHandle, "IDImage") + "";
            showwImage.ShowDialog();
        }
        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            GridView view = (GridView)sender;
            Point pt = view.GridControl.PointToClient(MousePosition);
            DoRowDoubleClick(view, pt);
        }

        BaseEdit _inplaceEditor;
        private void gridView1_ShownEditor(object sender, EventArgs e)
        {
            _inplaceEditor = ((GridView)sender).ActiveEditor;
            _inplaceEditor.DoubleClick += inplaceEditor_DoubleClick;
        }

        private void gridView1_HiddenEditor(object sender, EventArgs e)
        {
            if (_inplaceEditor != null)
            {
                _inplaceEditor.DoubleClick -= inplaceEditor_DoubleClick;
                _inplaceEditor = null;
            }
        }

        void inplaceEditor_DoubleClick(object sender, EventArgs e)
        {
            BaseEdit editor = (BaseEdit)sender;
            GridControl grid = (GridControl)editor.Parent;
            Point pt = grid.PointToClient(MousePosition);
            GridView view = (GridView)grid.FocusedView;
            DoRowDoubleClick(view, pt);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FlagLoad)
                return;
            btn_Search_Click(null, null);
        }

        private void gridView1_CustomDrawRowIndicator(object sender, RowIndicatorCustomDrawEventArgs e)
        {
            LoadSttGridView(e, gridView1);
        }
    }
}
using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using Series = DevExpress.XtraCharts.Series;

namespace BaoCaoLuong_12_2017.MyForm
{
    public partial class FrmTienDo : XtraForm
    {
        public FrmTienDo()
        {
            InitializeComponent();
        }

        private void frm_TienDo_Load(object sender, EventArgs e)
        {
        var fBatchName = (from w in Global.Db.tbl_Batches orderby w.BatchID select new { w.BatchID }).ToList();
        cbb_Batch.Properties.DataSource = fBatchName;
        cbb_Batch.Properties.DisplayMember = "BatchID";
        cbb_Batch.Properties.ValueMember = "BatchID";
        cbb_Batch.Text = Global.StrBatch;
    }

        private void ThongKe()
        {
            try
            {
                chartControl1.DataSource = null;
                chartControl1.Series.Clear();
                if (ck_All.Checked)
                {
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images select w.IDImage).Count() + "";
                    chartControl1.DataSource = Global.Db.ThongKeTienDoAll();
                }
                else{lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images where w.BatchID == cbb_Batch.Text select w.IDImage).Count() + "";
                    chartControl1.DataSource = Global.Db.ThongKeTienDo(cbb_Batch.Text);
                }
                Series series1 = new Series("Series1", ViewType.Pie);
                series1.ArgumentScaleType = ScaleType.Qualitative;
                series1.ArgumentDataMember = "name";
                series1.ValueScaleType = ScaleType.Numerical;
                series1.ValueDataMembers.AddRange("soluong");
                chartControl1.Series.Add(series1);
                ((PiePointOptions) series1.Label.PointOptions).PointView = PointView.ArgumentAndValues;
                chartControl1.PaletteName = "Palette 1";
            }
            catch (Exception)
            {
                // ignored
            }
        }

        private void cbb_Batch_EditValueChanged(object sender, EventArgs e)
        {
            ThongKe();
        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            //var frm = new frm_ChiTietTienDo() { lb_fBatchName = { Text = ck_All.Checked ? "All" : cbb_Batch.Text } };
            //frm.ShowDialog();
        }

        private void ck_All_CheckedChanged(object sender, EventArgs e)
        {
            cbb_Batch.Enabled = !ck_All.Checked;
            ThongKe();
        }

        private void chartControl1_CustomDrawSeriesPoint(object sender, CustomDrawSeriesPointEventArgs e)
        {
            string argument = e.SeriesPoint.Argument;
            var pointValue = e.SeriesPoint.Values[0];
            if (argument == "Hình chưa nhập")
            {
                e.LabelText = "Hình chưa nhập: " + pointValue + " hình";
            }
            else if (argument == "Hình đang nhập")
            {
                e.LabelText = "Hình đang nhập: " + pointValue + " hình";}
            else if (argument == "Hình chờ check")
            {
                e.LabelText = "Hình chờ check: " + pointValue + " hình";
            }
            else if (argument == "Hình đang check")
            {
                e.LabelText = "Hình đang check: " + pointValue + " hình";
            }
            else if (argument == "Hình hoàn thành")
            {
                e.LabelText = "Hình hoàn thành: " + pointValue + " hình";
            }
        }

        private void time_CheckHinhChuaNhap_Tick(object sender, EventArgs e)
        {
            if (cbb_Batch.Text == "No batch")
                return;
            ThongKe();
            lb_soHinhUserGood.Text = (from w in Global.Db.tbl_Images where w.FlagReadDeSo_Good == 0 & w.BatchID == cbb_Batch.Text select w).Count().ToString();
            lb_soHinhUserNotGood.Text = (from w in Global.Db.tbl_Images where w.FlagReadDeSo_NotGood == 0 & w.BatchID == cbb_Batch.Text select w).Count().ToString();

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
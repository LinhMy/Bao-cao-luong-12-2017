using DevExpress.XtraCharts;
using DevExpress.XtraEditors;
using System;
using System.Linq;
using Series = DevExpress.XtraCharts.Series;

namespace BaoCaoLuong2018.MyForm
{
    public partial class FrmTienDo : XtraForm
    {
        public FrmTienDo()
        {
            InitializeComponent();
        }

        private void frm_TienDo_Load(object sender, EventArgs e)
        {
            //var fBatchName = (from w in Global.Db.tbl_Batches orderby w.BatchID select new { w.BatchID }).ToList();
            //cbb_Batch.Properties.DataSource = fBatchName;
            //cbb_Batch.Properties.DisplayMember = "BatchID";
            //cbb_Batch.Properties.ValueMember = "BatchID";
        cbb_City.Text = Global.StrCity;
        cbb_City_SelectedIndexChanged(null, null);
        }

        private void ThongKeDeJP()
        {
            try
            {
                chartControl1.DataSource = null;
                chartControl1.Series.Clear();
                if (ck_All.Checked)
                {
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images select w.IDImage).Count() + "";
                    chartControl1.DataSource = Global.Db.ThongKeTienDoDeJPAll();
                }
                else{
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images where w.BatchID == cbb_Batch.SelectedValue.ToString() select w.IDImage).Count() + "";
                    chartControl1.DataSource = Global.Db.ThongKeTienDoDeJP(cbb_Batch.SelectedValue.ToString());

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
        private void ThongKeDeSo()
        {
            try
            {
                chartControl1.DataSource = null;
                chartControl1.Series.Clear();
                if (ck_All.Checked)
                {
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images select w.IDImage).Count() + "";
                    chartControl1.DataSource = Global.Db.ThongKeTienDoDeSoAll();
                }
                else
                {
                    lb_TongSoHinh.Text = (from w in Global.Db.tbl_Images where w.BatchID == cbb_Batch.SelectedValue.ToString() select w.IDImage).Count() + "";
                    chartControl1.DataSource = Global.Db.ThongKeTienDoDeSo(cbb_Batch.SelectedValue.ToString());

                }
                Series series1 = new Series("Series1", ViewType.Pie);
                series1.ArgumentScaleType = ScaleType.Qualitative;
                series1.ArgumentDataMember = "name";
                series1.ValueScaleType = ScaleType.Numerical;
                series1.ValueDataMembers.AddRange("soluong");
                chartControl1.Series.Add(series1);
                ((PiePointOptions)series1.Label.PointOptions).PointView = PointView.ArgumentAndValues;
                chartControl1.PaletteName = "Palette 1";
            }
            catch (Exception)
            {
                // ignored
            }
        }
        private void cbb_Batch_EditValueChanged(object sender, EventArgs e)
        {
            rb_deso1.Checked = true;
            ck_All.Checked = false;
            ThongKeDeSo();

        }

        private void btn_ChiTiet_Click(object sender, EventArgs e)
        {
            //if (cbb_Batch.Text == "" && ck_All.Checked == false)
            {
                return;
            }
            var frm = new frm_ChiTietTienDo() { lb_fBatchNameHT = { Text = ck_All.Checked ? "All" : cbb_Batch.Text } };
            frm.lb_City.Text = cbb_City.Text;
            frm.lb_fBatchName = ck_All.Checked ? "All" : cbb_Batch.SelectedValue.ToString();
            if (rb_deso1.Checked)
            {
                frm.rb_deso.Checked = true;
            }
            else if (rb_dejp.Checked)
            {
                frm.rb_dejp.Checked = true;
            }
            frm.ShowDialog();
        }

        private void ck_All_CheckedChanged(object sender, EventArgs e)
        {
            cbb_Batch.Enabled = !ck_All.Checked;
            if(rb_deso1.Checked == true)
            {
                ThongKeDeSo();
            }
            else if (rb_dejp.Checked == true) { ThongKeDeJP();
            }            
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
                e.LabelText = "Hình đang nhập: " + pointValue + " hình";
            }
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
            if (cbb_Batch.Text == "")
                return;
            ck_All_CheckedChanged(null,null);
            lb_soHinhUserGood.Text = (from w in Global.Db.tbl_Images where w.FlagReadDeSo_Good == 0 & w.BatchID == cbb_Batch.Text select w).Count().ToString();
            lb_soHinhUserNotGood.Text = (from w in Global.Db.tbl_Images where w.FlagReadDeSo_NotGood == 0 & w.BatchID == cbb_Batch.Text select w).Count().ToString();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            ThongKeDeSo();
        }

        private void rb_dejp_CheckedChanged(object sender, EventArgs e)
        {
            ThongKeDeJP();
        }

        private void cbb_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_Batch.DataSource = null;
            cbb_Batch.Text = "";
            var fBatchName = (from w in  Global.Db.GetBatch(cbb_City.Text) select new { w.BatchID, w.BatchName}).ToList();
            cbb_Batch.DataSource = fBatchName;
            cbb_Batch.DisplayMember = "BatchName";
            cbb_Batch.ValueMember = "BatchID";
        }
    }
}
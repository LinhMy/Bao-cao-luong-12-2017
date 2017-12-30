using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BaoCaoLuong2018.Properties;
using System.Collections.Generic;
using BaoCaoLuong2018.MyData;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_Checker : XtraForm
    {
        public frm_Checker()
        {
            InitializeComponent();
        }
        private string fbatchRefresh = "";
        private bool fLagRefresh = false;
        private string Folder = "";
        public string TypeCheck = "";
        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cbb_Batch_Check.Text))
                return;
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                DialogResult = DialogResult.Yes;
                return;
            }
            if (Global.StrCheck == "CHECKDESO")
            {
                var nhap = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals b.BatchID where b.City == Global.StrCity && w.BatchID == cbb_Batch_Check.SelectedValue+"" && w.ReadImageDeSo < 2 select w.IDImage).Count();
                var check = (from w in Global.Db.tbl_MissImage_DeSos join b in Global.Db.tbl_Batches on w.BatchID equals b.BatchID where b.City == Global.StrCity && w.BatchID == cbb_Batch_Check.SelectedValue + "" && w.Submit == false select w.IDImage).Count();
                if (nhap > 0)
                {
                    MessageBox.Show("Chưa nhập xong DeSo!");
                    return;
                }
                if (check > 0)
                {
                    var list_user = (from w in Global.Db.tbl_MissImage_DeSos join b in Global.Db.tbl_Batches on w.BatchID equals b.BatchID where b.City == Global.StrCity && w.BatchID == cbb_Batch_Check.SelectedValue + "" && w.Submit == false select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in list_user)
                    {
                        sss += item + "\r\n";
                    }

                    if (list_user.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng không nhập: \r\n" + sss);
                        return;
                    }
                }
            }
            else if (Global.StrCheck == "CHECKDEJP")
            {
                var nhap = (from w in Global.Db.tbl_Images join b in Global.Db.tbl_Batches on w.BatchID equals b.BatchID where b.City == Global.StrCity && w.BatchID == cbb_Batch_Check.SelectedValue + "" && w.ReadImageDeJP < 2 select w.IDImage).Count();
                var check = (from w in Global.Db.tbl_MissImage_DeJPs join b in Global.Db.tbl_Batches on w.BatchID equals b.BatchID where b.City == Global.StrCity && w.BatchID == cbb_Batch_Check.SelectedValue + "" && w.Submit == false select w.IDImage).Count();
                if (nhap > 0)
                {
                    MessageBox.Show("Chưa nhập xong DeJP!");
                    return;
                }
                if (check > 0)
                {
                    var list_user = (from w in Global.Db.tbl_MissImage_DeJPs join b in Global.Db.tbl_Batches on w.BatchID equals b.BatchID where b.City == Global.StrCity && w.BatchID == cbb_Batch_Check.SelectedValue + "" && w.Submit == false select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in list_user)
                    {
                        sss += item + "\r\n";
                    }

                    if (list_user.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng không nhập: \r\n" + sss);
                        return;
                    }
                }
            }
            string temp = GetImage();
            if (temp == "NULL")
            {
                uC_PictureBox1.imageBox1.Image = null;
                MessageBox.Show(@"Batch '" + cbb_Batch_Check.Text + "' đã hoàn thành");
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                return;
            }
            Load_DeSo(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
            //
            btn_Luu_DeSo1.Visible = true;
            btn_Luu_DeSo2.Visible = true;
            btn_SuaVaLuu_DeSo1.Visible = false;
            btn_SuaVaLuu_DeSo2.Visible = false;
            btn_Start.Visible = false;
        }

        private void ResetData()
        {
            lb_Image.Text = "";
            if (Global.StrCheck == "CHECKDESO")
            {
                uC_CityO_Loai11.ResetData();
                uC_CityO_Loai3_DeSo1.ResetData();
                uC_CityO_Loai12.ResetData();
                uC_CityO_Loai3_DeSo2.ResetData();
            }
            else if (Global.StrCheck == "CHECKDEJP")
            {
                uC_CityO_JP1.ResetData();
                uC_CityO_JP2.ResetData();
            }
            uC_PictureBox1.imageBox1.Image = null;
        }


        public void LoadBatchMoi()
        {
            if (MessageBox.Show(@"You want to do the next batch?", @"Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
            {
                Close();
            }
            else
            {
                VisibleButtonSave();
                ResetData();
                cbb_Batch_Check.Text = "";
                cbb_Batch_Check.DataSource = null;
                cbb_Batch_Check.DataSource = (from w in Global.Db.GetBatNotFinishChecker(Global.StrUserName, Global.StrCity, TypeCheck) select new { w.BatchID, w.BatchName }).ToList();
                cbb_Batch_Check.DisplayMember = "BatchName";
                cbb_Batch_Check.ValueMember = "BatchID";
                var soloi = ((from w in Global.Db.GetSoLoiCheck(cbb_Batch_Check.SelectedValue + "", Global.StrCity, TypeCheck) select w.IDImage).Count() / 2).ToString();
                lb_Loi.Text = soloi + " Lỗi";
                //Folder = "";
                //Folder = (from w in Global.Db.GetFolder(cbb_Batch_Check.Text) select w.fPathPicture).FirstOrDefault();
                btn_Start_Click(null, null);
            }
        }

        private void VisibleButtonSave()
        {
            btn_Luu_DeSo1.Visible = false;
            btn_Luu_DeSo2.Visible = false;
            btn_SuaVaLuu_DeSo1.Visible = false;
            btn_SuaVaLuu_DeSo2.Visible = false;
        }

        private void LockControl(bool kt)
        {
            if (kt)
            {
                btn_Luu_DeSo1.Visible = false;
                btn_Luu_DeSo2.Visible = false;
            }
            else
            {
                btn_Luu_DeSo1.Visible = true;
                btn_Luu_DeSo2.Visible = true;
                //if (fLagRefresh == true)
                //{
                //    if (Global.StrCity == "CityO" && Global.StrCheck == "CHECKDESO")
                //    {
                //        var temp = (from w in Global.Db.tbl_DeSo_CityOs
                //                    where w.BatchID == fbatchRefresh && w.IDImage == lb_Image.Text
                //                    select new
                //                    {
                //                        w.UserName,
                //                        w.Error,
                //                        w.True
                //                    }).ToList();
                //        if (temp[0].Error == true && temp[0].True == true)
                //        {
                //            btn_SuaVaLuu_DeSo1.Visible = true;
                //            btn_Luu_DeSo2.Visible = true;
                //        }
                //        else if (temp[1].Error == true && temp[1].True == true)
                //        {
                //            btn_SuaVaLuu_DeSo2.Visible = true;
                //            btn_Luu_DeSo1.Visible = true;
                //        }
                //        else
                //        {
                //            btn_Luu_DeSo1.Visible = true;
                //            btn_Luu_DeSo2.Visible = true;
                //        }
                //    }
                //    else if(Global.StrCity == "CityO" && Global.StrCheck == "CHECKDEJP")
                //    {
                //        var temp = (from w in Global.Db.tbl_DeJP_CityOs
                //                    where w.BatchID == fbatchRefresh && w.IDImage == lb_Image.Text
                //                    select new
                //                    {
                //                        w.UserName,
                //                        w.Error,
                //                        w.True
                //                    }).ToList();
                //        if (temp[0].Error == true && temp[0].True == true)
                //        {
                //            btn_SuaVaLuu_DeSo1.Visible = true;
                //            btn_Luu_DeSo2.Visible = true;
                //        }
                //        else if (temp[1].Error == true && temp[1].True == true)
                //        {
                //            btn_SuaVaLuu_DeSo2.Visible = true;
                //            btn_Luu_DeSo1.Visible = true;
                //        }
                //        else
                //        {
                //            btn_Luu_DeSo1.Visible = true;
                //            btn_Luu_DeSo2.Visible = true;
                //        }
                //    }
                //}
                //else
                //{
                //    btn_Luu_DeSo1.Visible = true;
                //    btn_Luu_DeSo2.Visible = true;
                //}
            }
        }
        private string imageTemp_check = "";
        private string GetImage()
        {
            LockControl(true);
            lb_Image.Text = "";
            imageTemp_check = "";
            imageTemp_check = (from w in Global.Db.GetImageCheck(cbb_Batch_Check.SelectedValue+"", Global.StrUserName,Global.StrCity,TypeCheck) select w.Column1).FirstOrDefault();
                if (string.IsNullOrEmpty(imageTemp_check))
                {
                    return "NULL";
                }
                lb_Image.Text = imageTemp_check;
                uC_PictureBox1.imageBox1.Image = null;
                if (uC_PictureBox1.LoadImage(Global.Webservice + cbb_Batch_Check.SelectedValue + "" + "/" + imageTemp_check, imageTemp_check, Settings.Default.ZoomImage) == "Error")
                {
                    uC_PictureBox1.imageBox1.Image = Resources.svn_deleted;
                    return "Error";
                }
            return "ok";
        }

        private void Load_DeSo(string fbatchname, string idimage)
        {
            //lb_User1.ForeColor = Color.Black;
            //lb_User2.ForeColor = Color.Black;
            if (Global.StrCheck == "CHECKDESO" && Global.StrCity == "CityO")
            {
                List<tbl_DeSo_CityO> data = (from w in Global.Db.tbl_DeSo_CityOs where w.BatchID == fbatchname && w.IDImage == idimage && w.Phase==1 select w).ToList();
                var result = (from w in Global.DbBpo.tbl_Users where w.Username == data[0].UserName select w.NotGoodUser).FirstOrDefault();
                if (result == false)
                {
                    lb_User1.Text = data[0].UserName;
                    lb_User2.Text = data[1].UserName;
                    //if (data[0].True.Value)
                    //    lb_User1.ForeColor = Color.Red;
                    //if (data[1].True.Value)
                    //    lb_User2.ForeColor = Color.Red;
                    if (data[0].LoaiPhieu == "Loai1")
                    {
                        tab_De1.SelectedTabPage = tab_CityO_Loai1_De1;
                        uC_CityO_Loai11.txt_Truong_018.Text = data[0].Truong_018;
                        uC_CityO_Loai11.txt_Truong_019.Text = data[0].Truong_019;
                        uC_CityO_Loai11.txt_Truong_021.Text = data[0].Truong_021;
                        uC_CityO_Loai11.txt_Truong_022.Text = data[0].Truong_022;
                        uC_CityO_Loai11.txt_Truong_023.Text = data[0].Truong_023;
                        uC_CityO_Loai11.txt_Truong_024.Text = data[0].Truong_024;
                        uC_CityO_Loai11.txt_Truong_025.Text = data[0].Truong_025;
                        uC_CityO_Loai11.txt_Truong_026.Text = data[0].Truong_026;
                        uC_CityO_Loai11.txt_Truong_027.Text = data[0].Truong_027;
                        uC_CityO_Loai11.chk_QC.Checked = data[0].CheckQC.Value;
                    }
                    else if (data[0].LoaiPhieu == "Loai2")
                        tab_De1.SelectedTabPage = tab_CityO_Loai2_De1;
                    else if (data[0].LoaiPhieu == "Loai3")
                    {
                        tab_De1.SelectedTabPage = tab_CityO_Loai3_De1;
                        uC_CityO_Loai3_DeSo1.txt_Truong_015.Text = data[0].Truong_015;
                        uC_CityO_Loai3_DeSo1.txt_Truong_017.Text = data[0].Truong_017;
                        uC_CityO_Loai3_DeSo1.txt_Truong_018.Text = data[0].Truong_018;
                        uC_CityO_Loai3_DeSo1.txt_Truong_019.Text = data[0].Truong_019;
                        uC_CityO_Loai3_DeSo1.txt_Truong_020.Text = data[0].Truong_020;
                        uC_CityO_Loai3_DeSo1.txt_Truong_021.Text = data[0].Truong_021;
                        uC_CityO_Loai3_DeSo1.txt_Truong_023.Text = data[0].Truong_023;
                        uC_CityO_Loai3_DeSo1.txt_Truong_024.Text = data[0].Truong_024;
                        uC_CityO_Loai3_DeSo1.txt_Truong_025.Text = data[0].Truong_025;
                        uC_CityO_Loai3_DeSo1.txt_Truong_026.Text = data[0].Truong_026;
                        uC_CityO_Loai3_DeSo1.txt_Truong_027.Text = data[0].Truong_027;
                        uC_CityO_Loai3_DeSo1.txt_Truong_028.Text = data[0].Truong_028;
                        uC_CityO_Loai3_DeSo1.txt_Truong_030.Text = data[0].Truong_030;
                        uC_CityO_Loai3_DeSo1.txt_Truong_031.Text = data[0].Truong_031;
                        uC_CityO_Loai3_DeSo1.txt_Truong_032.Text = data[0].Truong_032;
                        uC_CityO_Loai3_DeSo1.txt_Truong_033.Text = data[0].Truong_033;
                        uC_CityO_Loai3_DeSo1.txt_Truong_034.Text = data[0].Truong_034;
                        uC_CityO_Loai3_DeSo1.txt_Truong_035.Text = data[0].Truong_035;
                        uC_CityO_Loai3_DeSo1.txt_Truong_036.Text = data[0].Truong_036;
                        uC_CityO_Loai3_DeSo1.txt_Truong_037.Text = data[0].Truong_037;
                        uC_CityO_Loai3_DeSo1.txt_Truong_038.Text = data[0].Truong_038;
                        uC_CityO_Loai3_DeSo1.txt_Truong_039.Text = data[0].Truong_039;
                        uC_CityO_Loai3_DeSo1.txt_Truong_040.Text = data[0].Truong_040;
                        uC_CityO_Loai3_DeSo1.txt_Truong_041.Text = data[0].Truong_041;
                        uC_CityO_Loai3_DeSo1.txt_Truong_044.Text = data[0].Truong_044;
                        uC_CityO_Loai3_DeSo1.txt_Truong_045.Text = data[0].Truong_045;
                        uC_CityO_Loai3_DeSo1.txt_Truong_046.Text = data[0].Truong_046;
                        uC_CityO_Loai3_DeSo1.txt_Truong_048.Text = data[0].Truong_048;
                        uC_CityO_Loai3_DeSo1.txt_Truong_049.Text = data[0].Truong_049;
                        uC_CityO_Loai3_DeSo1.txt_Truong_050.Text = data[0].Truong_050;
                        uC_CityO_Loai3_DeSo1.txt_Truong_051.Text = data[0].Truong_051;
                        uC_CityO_Loai3_DeSo1.txt_Truong_052.Text = data[0].Truong_052;
                        uC_CityO_Loai3_DeSo1.txt_Truong_055.Text = data[0].Truong_055;
                        uC_CityO_Loai3_DeSo1.txt_Truong_056.Text = data[0].Truong_056;
                        uC_CityO_Loai3_DeSo1.txt_Truong_058.Text = data[0].Truong_058;
                        uC_CityO_Loai3_DeSo1.txt_Truong_059.Text = data[0].Truong_059;
                        uC_CityO_Loai3_DeSo1.txt_Truong_060.Text = data[0].Truong_060;
                        uC_CityO_Loai3_DeSo1.txt_Truong_062.Text = data[0].Truong_062;
                        uC_CityO_Loai3_DeSo1.txt_Truong_063.Text = data[0].Truong_063;
                        uC_CityO_Loai3_DeSo1.txt_Truong_064.Text = data[0].Truong_064;
                        uC_CityO_Loai3_DeSo1.txt_Truong_067.Text = data[0].Truong_067;
                        uC_CityO_Loai3_DeSo1.txt_Truong_069.Text = data[0].Truong_069;
                        uC_CityO_Loai3_DeSo1.txt_Truong_072.Text = data[0].Truong_072;
                        uC_CityO_Loai3_DeSo1.txt_Truong_073.Text = data[0].Truong_073;
                        uC_CityO_Loai3_DeSo1.txt_Truong_074.Text = data[0].Truong_074;
                        uC_CityO_Loai3_DeSo1.txt_Truong_075.Text = data[0].Truong_075;
                        uC_CityO_Loai3_DeSo1.txt_Truong_076.Text = data[0].Truong_076;
                        uC_CityO_Loai3_DeSo1.txt_Truong_077.Text = data[0].Truong_077;
                        uC_CityO_Loai3_DeSo1.txt_Truong_078.Text = data[0].Truong_078;
                        uC_CityO_Loai3_DeSo1.txt_Truong_079.Text = data[0].Truong_079;
                        uC_CityO_Loai3_DeSo1.txt_Truong_081.Text = data[0].Truong_081;
                        uC_CityO_Loai3_DeSo1.txt_Truong_082.Text = data[0].Truong_082;
                        uC_CityO_Loai3_DeSo1.txt_Truong_083.Text = data[0].Truong_083;
                        uC_CityO_Loai3_DeSo1.txt_Truong_084.Text = data[0].Truong_084;
                        uC_CityO_Loai3_DeSo1.txt_Truong_086.Text = data[0].Truong_086;
                        uC_CityO_Loai3_DeSo1.txt_Truong_087.Text = data[0].Truong_087;
                        uC_CityO_Loai3_DeSo1.txt_Truong_088.Text = data[0].Truong_088;
                        uC_CityO_Loai3_DeSo1.txt_Truong_089.Text = data[0].Truong_089;
                        uC_CityO_Loai3_DeSo1.txt_Truong_090.Text = data[0].Truong_090;
                        uC_CityO_Loai3_DeSo1.txt_Truong_095.Text = data[0].Truong_095;
                        uC_CityO_Loai3_DeSo1.txt_Truong_097.Text = data[0].Truong_097;
                        uC_CityO_Loai3_DeSo1.txt_Truong_099.Text = data[0].Truong_099;
                        uC_CityO_Loai3_DeSo1.txt_Truong_101.Text = data[0].Truong_101;
                        uC_CityO_Loai3_DeSo1.txt_Truong_103.Text = data[0].Truong_103;
                        uC_CityO_Loai3_DeSo1.txt_Truong_105.Text = data[0].Truong_105;
                        uC_CityO_Loai3_DeSo1.txt_Truong_107.Text = data[0].Truong_107;
                        uC_CityO_Loai3_DeSo1.txt_Truong_109.Text = data[0].Truong_109;
                        uC_CityO_Loai3_DeSo1.txt_Truong_110.Text = data[0].Truong_110;
                        uC_CityO_Loai3_DeSo1.txt_Truong_111.Text = data[0].Truong_111;
                        uC_CityO_Loai3_DeSo1.chk_QC.Checked = data[0].CheckQC.Value;
                    }

                    if (data[1].LoaiPhieu == "Loai1")
                    {
                        tab_De2.SelectedTabPage = tab_CityO_Loai1_De2;
                        uC_CityO_Loai12.txt_Truong_018.Text = data[1].Truong_018;
                        uC_CityO_Loai12.txt_Truong_019.Text = data[1].Truong_019;
                        uC_CityO_Loai12.txt_Truong_021.Text = data[1].Truong_021;
                        uC_CityO_Loai12.txt_Truong_022.Text = data[1].Truong_022;
                        uC_CityO_Loai12.txt_Truong_023.Text = data[1].Truong_023;
                        uC_CityO_Loai12.txt_Truong_024.Text = data[1].Truong_024;
                        uC_CityO_Loai12.txt_Truong_025.Text = data[1].Truong_025;
                        uC_CityO_Loai12.txt_Truong_026.Text = data[1].Truong_026;
                        uC_CityO_Loai12.txt_Truong_027.Text = data[1].Truong_027;
                        uC_CityO_Loai12.chk_QC.Checked = data[1].CheckQC.Value;
                    }
                    else if (data[1].LoaiPhieu == "Loai2")
                        tab_De2.SelectedTabPage = tab_CityO_Loai2_De2;
                    else if (data[1].LoaiPhieu == "Loai3")
                    {
                        tab_De2.SelectedTabPage = tab_CityO_Loai3_De2;
                        uC_CityO_Loai3_DeSo2.txt_Truong_015.Text = data[1].Truong_015;
                        uC_CityO_Loai3_DeSo2.txt_Truong_017.Text = data[1].Truong_017;
                        uC_CityO_Loai3_DeSo2.txt_Truong_018.Text = data[1].Truong_018;
                        uC_CityO_Loai3_DeSo2.txt_Truong_019.Text = data[1].Truong_019;
                        uC_CityO_Loai3_DeSo2.txt_Truong_020.Text = data[1].Truong_020;
                        uC_CityO_Loai3_DeSo2.txt_Truong_021.Text = data[1].Truong_021;
                        uC_CityO_Loai3_DeSo2.txt_Truong_023.Text = data[1].Truong_023;
                        uC_CityO_Loai3_DeSo2.txt_Truong_024.Text = data[1].Truong_024;
                        uC_CityO_Loai3_DeSo2.txt_Truong_025.Text = data[1].Truong_025;
                        uC_CityO_Loai3_DeSo2.txt_Truong_026.Text = data[1].Truong_026;
                        uC_CityO_Loai3_DeSo2.txt_Truong_027.Text = data[1].Truong_027;
                        uC_CityO_Loai3_DeSo2.txt_Truong_028.Text = data[1].Truong_028;
                        uC_CityO_Loai3_DeSo2.txt_Truong_030.Text = data[1].Truong_030;
                        uC_CityO_Loai3_DeSo2.txt_Truong_031.Text = data[1].Truong_031;
                        uC_CityO_Loai3_DeSo2.txt_Truong_032.Text = data[1].Truong_032;
                        uC_CityO_Loai3_DeSo2.txt_Truong_033.Text = data[1].Truong_033;
                        uC_CityO_Loai3_DeSo2.txt_Truong_034.Text = data[1].Truong_034;
                        uC_CityO_Loai3_DeSo2.txt_Truong_035.Text = data[1].Truong_035;
                        uC_CityO_Loai3_DeSo2.txt_Truong_036.Text = data[1].Truong_036;
                        uC_CityO_Loai3_DeSo2.txt_Truong_037.Text = data[1].Truong_037;
                        uC_CityO_Loai3_DeSo2.txt_Truong_038.Text = data[1].Truong_038;
                        uC_CityO_Loai3_DeSo2.txt_Truong_039.Text = data[1].Truong_039;
                        uC_CityO_Loai3_DeSo2.txt_Truong_040.Text = data[1].Truong_040;
                        uC_CityO_Loai3_DeSo2.txt_Truong_041.Text = data[1].Truong_041;
                        uC_CityO_Loai3_DeSo2.txt_Truong_044.Text = data[1].Truong_044;
                        uC_CityO_Loai3_DeSo2.txt_Truong_045.Text = data[1].Truong_045;
                        uC_CityO_Loai3_DeSo2.txt_Truong_046.Text = data[1].Truong_046;
                        uC_CityO_Loai3_DeSo2.txt_Truong_048.Text = data[1].Truong_048;
                        uC_CityO_Loai3_DeSo2.txt_Truong_049.Text = data[1].Truong_049;
                        uC_CityO_Loai3_DeSo2.txt_Truong_050.Text = data[1].Truong_050;
                        uC_CityO_Loai3_DeSo2.txt_Truong_051.Text = data[1].Truong_051;
                        uC_CityO_Loai3_DeSo2.txt_Truong_052.Text = data[1].Truong_052;
                        uC_CityO_Loai3_DeSo2.txt_Truong_055.Text = data[1].Truong_055;
                        uC_CityO_Loai3_DeSo2.txt_Truong_056.Text = data[1].Truong_056;
                        uC_CityO_Loai3_DeSo2.txt_Truong_058.Text = data[1].Truong_058;
                        uC_CityO_Loai3_DeSo2.txt_Truong_059.Text = data[1].Truong_059;
                        uC_CityO_Loai3_DeSo2.txt_Truong_060.Text = data[1].Truong_060;
                        uC_CityO_Loai3_DeSo2.txt_Truong_062.Text = data[1].Truong_062;
                        uC_CityO_Loai3_DeSo2.txt_Truong_063.Text = data[1].Truong_063;
                        uC_CityO_Loai3_DeSo2.txt_Truong_064.Text = data[1].Truong_064;
                        uC_CityO_Loai3_DeSo2.txt_Truong_067.Text = data[1].Truong_067;
                        uC_CityO_Loai3_DeSo2.txt_Truong_069.Text = data[1].Truong_069;
                        uC_CityO_Loai3_DeSo2.txt_Truong_072.Text = data[1].Truong_072;
                        uC_CityO_Loai3_DeSo2.txt_Truong_073.Text = data[1].Truong_073;
                        uC_CityO_Loai3_DeSo2.txt_Truong_074.Text = data[1].Truong_074;
                        uC_CityO_Loai3_DeSo2.txt_Truong_075.Text = data[1].Truong_075;
                        uC_CityO_Loai3_DeSo2.txt_Truong_076.Text = data[1].Truong_076;
                        uC_CityO_Loai3_DeSo2.txt_Truong_077.Text = data[1].Truong_077;
                        uC_CityO_Loai3_DeSo2.txt_Truong_078.Text = data[1].Truong_078;
                        uC_CityO_Loai3_DeSo2.txt_Truong_079.Text = data[1].Truong_079;
                        uC_CityO_Loai3_DeSo2.txt_Truong_081.Text = data[1].Truong_081;
                        uC_CityO_Loai3_DeSo2.txt_Truong_082.Text = data[1].Truong_082;
                        uC_CityO_Loai3_DeSo2.txt_Truong_083.Text = data[1].Truong_083;
                        uC_CityO_Loai3_DeSo2.txt_Truong_084.Text = data[1].Truong_084;
                        uC_CityO_Loai3_DeSo2.txt_Truong_086.Text = data[1].Truong_086;
                        uC_CityO_Loai3_DeSo2.txt_Truong_087.Text = data[1].Truong_087;
                        uC_CityO_Loai3_DeSo2.txt_Truong_088.Text = data[1].Truong_088;
                        uC_CityO_Loai3_DeSo2.txt_Truong_089.Text = data[1].Truong_089;
                        uC_CityO_Loai3_DeSo2.txt_Truong_090.Text = data[1].Truong_090;
                        uC_CityO_Loai3_DeSo2.txt_Truong_095.Text = data[1].Truong_095;
                        uC_CityO_Loai3_DeSo2.txt_Truong_097.Text = data[1].Truong_097;
                        uC_CityO_Loai3_DeSo2.txt_Truong_099.Text = data[1].Truong_099;
                        uC_CityO_Loai3_DeSo2.txt_Truong_101.Text = data[1].Truong_101;
                        uC_CityO_Loai3_DeSo2.txt_Truong_103.Text = data[1].Truong_103;
                        uC_CityO_Loai3_DeSo2.txt_Truong_105.Text = data[1].Truong_105;
                        uC_CityO_Loai3_DeSo2.txt_Truong_107.Text = data[1].Truong_107;
                        uC_CityO_Loai3_DeSo2.txt_Truong_109.Text = data[1].Truong_109;
                        uC_CityO_Loai3_DeSo2.txt_Truong_110.Text = data[1].Truong_110;
                        uC_CityO_Loai3_DeSo2.txt_Truong_111.Text = data[1].Truong_111;
                        uC_CityO_Loai3_DeSo2.chk_QC.Checked = data[1].CheckQC.Value;
                    }
                }
                else if (result == true)
                {
                    lb_User1.Text = data[1].UserName;
                    lb_User2.Text = data[0].UserName;
                    //if (data[1].True.Value)
                    //    lb_User1.ForeColor = Color.Red;
                    //if (data[0].True.Value)
                    //    lb_User2.ForeColor = Color.Red;
                    if (data[1].LoaiPhieu == "Loai1")
                    {
                        tab_De1.SelectedTabPage = tab_CityO_Loai1_De1;
                        uC_CityO_Loai11.txt_Truong_018.Text = data[1].Truong_018;
                        uC_CityO_Loai11.txt_Truong_019.Text = data[1].Truong_019;
                        uC_CityO_Loai11.txt_Truong_021.Text = data[1].Truong_021;
                        uC_CityO_Loai11.txt_Truong_022.Text = data[1].Truong_022;
                        uC_CityO_Loai11.txt_Truong_023.Text = data[1].Truong_023;
                        uC_CityO_Loai11.txt_Truong_024.Text = data[1].Truong_024;
                        uC_CityO_Loai11.txt_Truong_025.Text = data[1].Truong_025;
                        uC_CityO_Loai11.txt_Truong_026.Text = data[1].Truong_026;
                        uC_CityO_Loai11.txt_Truong_027.Text = data[1].Truong_027;
                    }
                    else if (data[1].LoaiPhieu == "Loai2")
                        tab_De1.SelectedTabPage = tab_CityO_Loai3_De2;
                    else if (data[1].LoaiPhieu == "Loai3")
                    {
                        tab_De1.SelectedTabPage = tab_CityO_Loai3_De1;
                        uC_CityO_Loai3_DeSo1.txt_Truong_015.Text = data[1].Truong_015;
                        uC_CityO_Loai3_DeSo1.txt_Truong_017.Text = data[1].Truong_017;
                        uC_CityO_Loai3_DeSo1.txt_Truong_018.Text = data[1].Truong_018;
                        uC_CityO_Loai3_DeSo1.txt_Truong_019.Text = data[1].Truong_019;
                        uC_CityO_Loai3_DeSo1.txt_Truong_020.Text = data[1].Truong_020;
                        uC_CityO_Loai3_DeSo1.txt_Truong_021.Text = data[1].Truong_021;
                        uC_CityO_Loai3_DeSo1.txt_Truong_023.Text = data[1].Truong_023;
                        uC_CityO_Loai3_DeSo1.txt_Truong_024.Text = data[1].Truong_024;
                        uC_CityO_Loai3_DeSo1.txt_Truong_025.Text = data[1].Truong_025;
                        uC_CityO_Loai3_DeSo1.txt_Truong_026.Text = data[1].Truong_026;
                        uC_CityO_Loai3_DeSo1.txt_Truong_027.Text = data[1].Truong_027;
                        uC_CityO_Loai3_DeSo1.txt_Truong_028.Text = data[1].Truong_028;
                        uC_CityO_Loai3_DeSo1.txt_Truong_030.Text = data[1].Truong_030;
                        uC_CityO_Loai3_DeSo1.txt_Truong_031.Text = data[1].Truong_031;
                        uC_CityO_Loai3_DeSo1.txt_Truong_032.Text = data[1].Truong_032;
                        uC_CityO_Loai3_DeSo1.txt_Truong_033.Text = data[1].Truong_033;
                        uC_CityO_Loai3_DeSo1.txt_Truong_034.Text = data[1].Truong_034;
                        uC_CityO_Loai3_DeSo1.txt_Truong_035.Text = data[1].Truong_035;
                        uC_CityO_Loai3_DeSo1.txt_Truong_036.Text = data[1].Truong_036;
                        uC_CityO_Loai3_DeSo1.txt_Truong_037.Text = data[1].Truong_037;
                        uC_CityO_Loai3_DeSo1.txt_Truong_038.Text = data[1].Truong_038;
                        uC_CityO_Loai3_DeSo1.txt_Truong_039.Text = data[1].Truong_039;
                        uC_CityO_Loai3_DeSo1.txt_Truong_040.Text = data[1].Truong_040;
                        uC_CityO_Loai3_DeSo1.txt_Truong_041.Text = data[1].Truong_041;
                        uC_CityO_Loai3_DeSo1.txt_Truong_044.Text = data[1].Truong_044;
                        uC_CityO_Loai3_DeSo1.txt_Truong_045.Text = data[1].Truong_045;
                        uC_CityO_Loai3_DeSo1.txt_Truong_046.Text = data[1].Truong_046;
                        uC_CityO_Loai3_DeSo1.txt_Truong_048.Text = data[1].Truong_048;
                        uC_CityO_Loai3_DeSo1.txt_Truong_049.Text = data[1].Truong_049;
                        uC_CityO_Loai3_DeSo1.txt_Truong_050.Text = data[1].Truong_050;
                        uC_CityO_Loai3_DeSo1.txt_Truong_051.Text = data[1].Truong_051;
                        uC_CityO_Loai3_DeSo1.txt_Truong_052.Text = data[1].Truong_052;
                        uC_CityO_Loai3_DeSo1.txt_Truong_055.Text = data[1].Truong_055;
                        uC_CityO_Loai3_DeSo1.txt_Truong_056.Text = data[1].Truong_056;
                        uC_CityO_Loai3_DeSo1.txt_Truong_058.Text = data[1].Truong_058;
                        uC_CityO_Loai3_DeSo1.txt_Truong_059.Text = data[1].Truong_059;
                        uC_CityO_Loai3_DeSo1.txt_Truong_060.Text = data[1].Truong_060;
                        uC_CityO_Loai3_DeSo1.txt_Truong_062.Text = data[1].Truong_062;
                        uC_CityO_Loai3_DeSo1.txt_Truong_063.Text = data[1].Truong_063;
                        uC_CityO_Loai3_DeSo1.txt_Truong_064.Text = data[1].Truong_064;
                        uC_CityO_Loai3_DeSo1.txt_Truong_067.Text = data[1].Truong_067;
                        uC_CityO_Loai3_DeSo1.txt_Truong_069.Text = data[1].Truong_069;
                        uC_CityO_Loai3_DeSo1.txt_Truong_072.Text = data[1].Truong_072;
                        uC_CityO_Loai3_DeSo1.txt_Truong_073.Text = data[1].Truong_073;
                        uC_CityO_Loai3_DeSo1.txt_Truong_074.Text = data[1].Truong_074;
                        uC_CityO_Loai3_DeSo1.txt_Truong_075.Text = data[1].Truong_075;
                        uC_CityO_Loai3_DeSo1.txt_Truong_076.Text = data[1].Truong_076;
                        uC_CityO_Loai3_DeSo1.txt_Truong_077.Text = data[1].Truong_077;
                        uC_CityO_Loai3_DeSo1.txt_Truong_078.Text = data[1].Truong_078;
                        uC_CityO_Loai3_DeSo1.txt_Truong_079.Text = data[1].Truong_079;
                        uC_CityO_Loai3_DeSo1.txt_Truong_081.Text = data[1].Truong_081;
                        uC_CityO_Loai3_DeSo1.txt_Truong_082.Text = data[1].Truong_082;
                        uC_CityO_Loai3_DeSo1.txt_Truong_083.Text = data[1].Truong_083;
                        uC_CityO_Loai3_DeSo1.txt_Truong_084.Text = data[1].Truong_084;
                        uC_CityO_Loai3_DeSo1.txt_Truong_086.Text = data[1].Truong_086;
                        uC_CityO_Loai3_DeSo1.txt_Truong_087.Text = data[1].Truong_087;
                        uC_CityO_Loai3_DeSo1.txt_Truong_088.Text = data[1].Truong_088;
                        uC_CityO_Loai3_DeSo1.txt_Truong_089.Text = data[1].Truong_089;
                        uC_CityO_Loai3_DeSo1.txt_Truong_090.Text = data[1].Truong_090;
                        uC_CityO_Loai3_DeSo1.txt_Truong_095.Text = data[1].Truong_095;
                        uC_CityO_Loai3_DeSo1.txt_Truong_097.Text = data[1].Truong_097;
                        uC_CityO_Loai3_DeSo1.txt_Truong_099.Text = data[1].Truong_099;
                        uC_CityO_Loai3_DeSo1.txt_Truong_101.Text = data[1].Truong_101;
                        uC_CityO_Loai3_DeSo1.txt_Truong_103.Text = data[1].Truong_103;
                        uC_CityO_Loai3_DeSo1.txt_Truong_105.Text = data[1].Truong_105;
                        uC_CityO_Loai3_DeSo1.txt_Truong_107.Text = data[1].Truong_107;
                        uC_CityO_Loai3_DeSo1.txt_Truong_109.Text = data[1].Truong_109;
                        uC_CityO_Loai3_DeSo1.txt_Truong_110.Text = data[1].Truong_110;
                        uC_CityO_Loai3_DeSo1.txt_Truong_111.Text = data[1].Truong_111;
                    }

                    if (data[0].LoaiPhieu == "Loai1")
                    {
                        tab_De2.SelectedTabPage = tab_CityO_Loai1_De2;
                        uC_CityO_Loai12.txt_Truong_018.Text = data[0].Truong_018;
                        uC_CityO_Loai12.txt_Truong_019.Text = data[0].Truong_019;
                        uC_CityO_Loai12.txt_Truong_021.Text = data[0].Truong_021;
                        uC_CityO_Loai12.txt_Truong_022.Text = data[0].Truong_022;
                        uC_CityO_Loai12.txt_Truong_023.Text = data[0].Truong_023;
                        uC_CityO_Loai12.txt_Truong_024.Text = data[0].Truong_024;
                        uC_CityO_Loai12.txt_Truong_025.Text = data[0].Truong_025;
                        uC_CityO_Loai12.txt_Truong_026.Text = data[0].Truong_026;
                        uC_CityO_Loai12.txt_Truong_027.Text = data[0].Truong_027;
                    }
                    else if (data[0].LoaiPhieu == "Loai2")
                        tab_De2.SelectedTabPage = tab_CityO_Loai2_De2;
                    else if (data[0].LoaiPhieu == "Loai3")
                    {
                        tab_De2.SelectedTabPage = tab_CityO_Loai3_De2;
                        uC_CityO_Loai3_DeSo2.txt_Truong_015.Text = data[0].Truong_015;
                        uC_CityO_Loai3_DeSo2.txt_Truong_017.Text = data[0].Truong_017;
                        uC_CityO_Loai3_DeSo2.txt_Truong_018.Text = data[0].Truong_018;
                        uC_CityO_Loai3_DeSo2.txt_Truong_019.Text = data[0].Truong_019;
                        uC_CityO_Loai3_DeSo2.txt_Truong_020.Text = data[0].Truong_020;
                        uC_CityO_Loai3_DeSo2.txt_Truong_021.Text = data[0].Truong_021;
                        uC_CityO_Loai3_DeSo2.txt_Truong_023.Text = data[0].Truong_023;
                        uC_CityO_Loai3_DeSo2.txt_Truong_024.Text = data[0].Truong_024;
                        uC_CityO_Loai3_DeSo2.txt_Truong_025.Text = data[0].Truong_025;
                        uC_CityO_Loai3_DeSo2.txt_Truong_026.Text = data[0].Truong_026;
                        uC_CityO_Loai3_DeSo2.txt_Truong_027.Text = data[0].Truong_027;
                        uC_CityO_Loai3_DeSo2.txt_Truong_028.Text = data[0].Truong_028;
                        uC_CityO_Loai3_DeSo2.txt_Truong_030.Text = data[0].Truong_030;
                        uC_CityO_Loai3_DeSo2.txt_Truong_031.Text = data[0].Truong_031;
                        uC_CityO_Loai3_DeSo2.txt_Truong_032.Text = data[0].Truong_032;
                        uC_CityO_Loai3_DeSo2.txt_Truong_033.Text = data[0].Truong_033;
                        uC_CityO_Loai3_DeSo2.txt_Truong_034.Text = data[0].Truong_034;
                        uC_CityO_Loai3_DeSo2.txt_Truong_035.Text = data[0].Truong_035;
                        uC_CityO_Loai3_DeSo2.txt_Truong_036.Text = data[0].Truong_036;
                        uC_CityO_Loai3_DeSo2.txt_Truong_037.Text = data[0].Truong_037;
                        uC_CityO_Loai3_DeSo2.txt_Truong_038.Text = data[0].Truong_038;
                        uC_CityO_Loai3_DeSo2.txt_Truong_039.Text = data[0].Truong_039;
                        uC_CityO_Loai3_DeSo2.txt_Truong_040.Text = data[0].Truong_040;
                        uC_CityO_Loai3_DeSo2.txt_Truong_041.Text = data[0].Truong_041;
                        uC_CityO_Loai3_DeSo2.txt_Truong_044.Text = data[0].Truong_044;
                        uC_CityO_Loai3_DeSo2.txt_Truong_045.Text = data[0].Truong_045;
                        uC_CityO_Loai3_DeSo2.txt_Truong_046.Text = data[0].Truong_046;
                        uC_CityO_Loai3_DeSo2.txt_Truong_048.Text = data[0].Truong_048;
                        uC_CityO_Loai3_DeSo2.txt_Truong_049.Text = data[0].Truong_049;
                        uC_CityO_Loai3_DeSo2.txt_Truong_050.Text = data[0].Truong_050;
                        uC_CityO_Loai3_DeSo2.txt_Truong_051.Text = data[0].Truong_051;
                        uC_CityO_Loai3_DeSo2.txt_Truong_052.Text = data[0].Truong_052;
                        uC_CityO_Loai3_DeSo2.txt_Truong_055.Text = data[0].Truong_055;
                        uC_CityO_Loai3_DeSo2.txt_Truong_056.Text = data[0].Truong_056;
                        uC_CityO_Loai3_DeSo2.txt_Truong_058.Text = data[0].Truong_058;
                        uC_CityO_Loai3_DeSo2.txt_Truong_059.Text = data[0].Truong_059;
                        uC_CityO_Loai3_DeSo2.txt_Truong_060.Text = data[0].Truong_060;
                        uC_CityO_Loai3_DeSo2.txt_Truong_062.Text = data[0].Truong_062;
                        uC_CityO_Loai3_DeSo2.txt_Truong_063.Text = data[0].Truong_063;
                        uC_CityO_Loai3_DeSo2.txt_Truong_064.Text = data[0].Truong_064;
                        uC_CityO_Loai3_DeSo2.txt_Truong_067.Text = data[0].Truong_067;
                        uC_CityO_Loai3_DeSo2.txt_Truong_069.Text = data[0].Truong_069;
                        uC_CityO_Loai3_DeSo2.txt_Truong_072.Text = data[0].Truong_072;
                        uC_CityO_Loai3_DeSo2.txt_Truong_073.Text = data[0].Truong_073;
                        uC_CityO_Loai3_DeSo2.txt_Truong_074.Text = data[0].Truong_074;
                        uC_CityO_Loai3_DeSo2.txt_Truong_075.Text = data[0].Truong_075;
                        uC_CityO_Loai3_DeSo2.txt_Truong_076.Text = data[0].Truong_076;
                        uC_CityO_Loai3_DeSo2.txt_Truong_077.Text = data[0].Truong_077;
                        uC_CityO_Loai3_DeSo2.txt_Truong_078.Text = data[0].Truong_078;
                        uC_CityO_Loai3_DeSo2.txt_Truong_079.Text = data[0].Truong_079;
                        uC_CityO_Loai3_DeSo2.txt_Truong_081.Text = data[0].Truong_081;
                        uC_CityO_Loai3_DeSo2.txt_Truong_082.Text = data[0].Truong_082;
                        uC_CityO_Loai3_DeSo2.txt_Truong_083.Text = data[0].Truong_083;
                        uC_CityO_Loai3_DeSo2.txt_Truong_084.Text = data[0].Truong_084;
                        uC_CityO_Loai3_DeSo2.txt_Truong_086.Text = data[0].Truong_086;
                        uC_CityO_Loai3_DeSo2.txt_Truong_087.Text = data[0].Truong_087;
                        uC_CityO_Loai3_DeSo2.txt_Truong_088.Text = data[0].Truong_088;
                        uC_CityO_Loai3_DeSo2.txt_Truong_089.Text = data[0].Truong_089;
                        uC_CityO_Loai3_DeSo2.txt_Truong_090.Text = data[0].Truong_090;
                        uC_CityO_Loai3_DeSo2.txt_Truong_095.Text = data[0].Truong_095;
                        uC_CityO_Loai3_DeSo2.txt_Truong_097.Text = data[0].Truong_097;
                        uC_CityO_Loai3_DeSo2.txt_Truong_099.Text = data[0].Truong_099;
                        uC_CityO_Loai3_DeSo2.txt_Truong_101.Text = data[0].Truong_101;
                        uC_CityO_Loai3_DeSo2.txt_Truong_103.Text = data[0].Truong_103;
                        uC_CityO_Loai3_DeSo2.txt_Truong_105.Text = data[0].Truong_105;
                        uC_CityO_Loai3_DeSo2.txt_Truong_107.Text = data[0].Truong_107;
                        uC_CityO_Loai3_DeSo2.txt_Truong_109.Text = data[0].Truong_109;
                        uC_CityO_Loai3_DeSo2.txt_Truong_110.Text = data[0].Truong_110;
                        uC_CityO_Loai3_DeSo2.txt_Truong_111.Text = data[0].Truong_111;
                    }
                }
                if (tab_De1.SelectedTabPage == tab_CityO_Loai1_De1 || tab_De2.SelectedTabPage == tab_CityO_Loai1_De2)
                {
                    Compare_TextBox(uC_CityO_Loai11.txt_Truong_018, uC_CityO_Loai12.txt_Truong_018);
                    Compare_TextBox(uC_CityO_Loai11.txt_Truong_019, uC_CityO_Loai12.txt_Truong_019);
                    Compare_TextBox(uC_CityO_Loai11.txt_Truong_021, uC_CityO_Loai12.txt_Truong_021);
                    Compare_TextBox(uC_CityO_Loai11.txt_Truong_022, uC_CityO_Loai12.txt_Truong_022);
                    Compare_TextBox(uC_CityO_Loai11.txt_Truong_023, uC_CityO_Loai12.txt_Truong_023);
                    Compare_TextBox(uC_CityO_Loai11.txt_Truong_024, uC_CityO_Loai12.txt_Truong_024);
                    Compare_TextBox(uC_CityO_Loai11.txt_Truong_025, uC_CityO_Loai12.txt_Truong_025);
                    Compare_TextBox(uC_CityO_Loai11.txt_Truong_026, uC_CityO_Loai12.txt_Truong_026);
                    Compare_TextBox(uC_CityO_Loai11.txt_Truong_027, uC_CityO_Loai12.txt_Truong_027);
                }
                else if (tab_De1.SelectedTabPage == tab_CityO_Loai3_De1 || tab_De2.SelectedTabPage == tab_CityO_Loai3_De2)
                {
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_015, uC_CityO_Loai3_DeSo2.txt_Truong_015);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_017, uC_CityO_Loai3_DeSo2.txt_Truong_017);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_018, uC_CityO_Loai3_DeSo2.txt_Truong_018);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_019, uC_CityO_Loai3_DeSo2.txt_Truong_019);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_020, uC_CityO_Loai3_DeSo2.txt_Truong_020);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_021, uC_CityO_Loai3_DeSo2.txt_Truong_021);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_023, uC_CityO_Loai3_DeSo2.txt_Truong_023);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_024, uC_CityO_Loai3_DeSo2.txt_Truong_024);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_025, uC_CityO_Loai3_DeSo2.txt_Truong_025);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_026, uC_CityO_Loai3_DeSo2.txt_Truong_026);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_027, uC_CityO_Loai3_DeSo2.txt_Truong_027);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_028, uC_CityO_Loai3_DeSo2.txt_Truong_028);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_030, uC_CityO_Loai3_DeSo2.txt_Truong_030);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_031, uC_CityO_Loai3_DeSo2.txt_Truong_031);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_032, uC_CityO_Loai3_DeSo2.txt_Truong_032);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_033, uC_CityO_Loai3_DeSo2.txt_Truong_033);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_034, uC_CityO_Loai3_DeSo2.txt_Truong_034);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_035, uC_CityO_Loai3_DeSo2.txt_Truong_035);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_036, uC_CityO_Loai3_DeSo2.txt_Truong_036);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_037, uC_CityO_Loai3_DeSo2.txt_Truong_037);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_038, uC_CityO_Loai3_DeSo2.txt_Truong_038);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_039, uC_CityO_Loai3_DeSo2.txt_Truong_039);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_040, uC_CityO_Loai3_DeSo2.txt_Truong_040);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_041, uC_CityO_Loai3_DeSo2.txt_Truong_041);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_044, uC_CityO_Loai3_DeSo2.txt_Truong_044);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_045, uC_CityO_Loai3_DeSo2.txt_Truong_045);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_046, uC_CityO_Loai3_DeSo2.txt_Truong_046);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_048, uC_CityO_Loai3_DeSo2.txt_Truong_048);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_049, uC_CityO_Loai3_DeSo2.txt_Truong_049);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_050, uC_CityO_Loai3_DeSo2.txt_Truong_050);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_051, uC_CityO_Loai3_DeSo2.txt_Truong_051);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_052, uC_CityO_Loai3_DeSo2.txt_Truong_052);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_055, uC_CityO_Loai3_DeSo2.txt_Truong_055);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_056, uC_CityO_Loai3_DeSo2.txt_Truong_056);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_058, uC_CityO_Loai3_DeSo2.txt_Truong_058);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_059, uC_CityO_Loai3_DeSo2.txt_Truong_059);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_060, uC_CityO_Loai3_DeSo2.txt_Truong_060);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_062, uC_CityO_Loai3_DeSo2.txt_Truong_062);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_063, uC_CityO_Loai3_DeSo2.txt_Truong_063);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_064, uC_CityO_Loai3_DeSo2.txt_Truong_064);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_067, uC_CityO_Loai3_DeSo2.txt_Truong_067);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_069, uC_CityO_Loai3_DeSo2.txt_Truong_069);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_072, uC_CityO_Loai3_DeSo2.txt_Truong_072);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_073, uC_CityO_Loai3_DeSo2.txt_Truong_073);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_074, uC_CityO_Loai3_DeSo2.txt_Truong_074);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_075, uC_CityO_Loai3_DeSo2.txt_Truong_075);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_076, uC_CityO_Loai3_DeSo2.txt_Truong_076);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_077, uC_CityO_Loai3_DeSo2.txt_Truong_077);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_078, uC_CityO_Loai3_DeSo2.txt_Truong_078);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_079, uC_CityO_Loai3_DeSo2.txt_Truong_079);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_081, uC_CityO_Loai3_DeSo2.txt_Truong_081);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_082, uC_CityO_Loai3_DeSo2.txt_Truong_082);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_083, uC_CityO_Loai3_DeSo2.txt_Truong_083);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_084, uC_CityO_Loai3_DeSo2.txt_Truong_084);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_086, uC_CityO_Loai3_DeSo2.txt_Truong_086);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_087, uC_CityO_Loai3_DeSo2.txt_Truong_087);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_088, uC_CityO_Loai3_DeSo2.txt_Truong_088);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_089, uC_CityO_Loai3_DeSo2.txt_Truong_089);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_090, uC_CityO_Loai3_DeSo2.txt_Truong_090);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_095, uC_CityO_Loai3_DeSo2.txt_Truong_095);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_097, uC_CityO_Loai3_DeSo2.txt_Truong_097);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_099, uC_CityO_Loai3_DeSo2.txt_Truong_099);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_101, uC_CityO_Loai3_DeSo2.txt_Truong_101);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_103, uC_CityO_Loai3_DeSo2.txt_Truong_103);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_105, uC_CityO_Loai3_DeSo2.txt_Truong_105);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_107, uC_CityO_Loai3_DeSo2.txt_Truong_107);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_109, uC_CityO_Loai3_DeSo2.txt_Truong_109);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_110, uC_CityO_Loai3_DeSo2.txt_Truong_110);
                    Compare_TextBox(uC_CityO_Loai3_DeSo1.txt_Truong_111, uC_CityO_Loai3_DeSo2.txt_Truong_111);
                }
            }
            else if (Global.StrCheck == "CHECKDEJP" && Global.StrCity == "CityO")
            {
                List<tbl_DeJP_CityO> data = (from w in Global.Db.tbl_DeJP_CityOs where w.BatchID == fbatchname && w.IDImage == idimage && w.Phase == 1 select w).ToList();
                var result = (from w in Global.DbBpo.tbl_Users where w.Username == data[0].UserName select w.NotGoodUser).FirstOrDefault();
                if (result == false)
                {
                    lb_User1.Text = data[0].UserName;
                    lb_User2.Text = data[1].UserName;
                    //if (data[0].True.Value)
                    //    lb_User1.ForeColor = Color.Red;
                    //if (data[1].True.Value)
                    //    lb_User2.ForeColor = Color.Red;
                    tab_De1.SelectedTabPage.Name = "tab_CityO_Loai1_De1";
                    uC_CityO_JP1.txt_Truong_016.Text = data[0].Truong_016;
                    uC_CityO_JP1.txt_Truong_094.Text = data[0].Truong_094;
                    uC_CityO_JP1.txt_Truong_096.Text = data[0].Truong_096;
                    uC_CityO_JP1.txt_Truong_098.Text = data[0].Truong_098;
                    uC_CityO_JP1.txt_Truong_100.Text = data[0].Truong_100;
                    uC_CityO_JP1.txt_Truong_102.Text = data[0].Truong_102;
                    uC_CityO_JP1.txt_Truong_104.Text = data[0].Truong_104;
                    uC_CityO_JP1.txt_Truong_106.Text = data[0].Truong_106;
                    uC_CityO_JP1.txt_Truong_108.Text = data[0].Truong_108;

                    tab_De2.SelectedTabPage.Name = "tab_CityO_Loai1_De2";
                    uC_CityO_JP2.txt_Truong_016.Text = data[1].Truong_016;
                    uC_CityO_JP2.txt_Truong_094.Text = data[1].Truong_094;
                    uC_CityO_JP2.txt_Truong_096.Text = data[1].Truong_096;
                    uC_CityO_JP2.txt_Truong_098.Text = data[1].Truong_098;
                    uC_CityO_JP2.txt_Truong_100.Text = data[1].Truong_100;
                    uC_CityO_JP2.txt_Truong_102.Text = data[1].Truong_102;
                    uC_CityO_JP2.txt_Truong_104.Text = data[1].Truong_104;
                    uC_CityO_JP2.txt_Truong_106.Text = data[1].Truong_106;
                    uC_CityO_JP2.txt_Truong_108.Text = data[1].Truong_108;

                }
                else if (result == true)
                {
                    lb_User1.Text = data[1].UserName;
                    lb_User2.Text = data[0].UserName;
                    //if (data[1].True.Value)
                    //    lb_User1.ForeColor = Color.Red;
                    //if (data[0].True.Value)
                    //    lb_User2.ForeColor = Color.Red;
                    tab_De1.SelectedTabPage.Name = "tab_CityO_Loai1_De1";
                    uC_CityO_JP1.txt_Truong_016.Text = data[1].Truong_016;
                    uC_CityO_JP1.txt_Truong_094.Text = data[1].Truong_094;
                    uC_CityO_JP1.txt_Truong_096.Text = data[1].Truong_096;
                    uC_CityO_JP1.txt_Truong_098.Text = data[1].Truong_098;
                    uC_CityO_JP1.txt_Truong_100.Text = data[1].Truong_100;
                    uC_CityO_JP1.txt_Truong_102.Text = data[1].Truong_102;
                    uC_CityO_JP1.txt_Truong_104.Text = data[1].Truong_104;
                    uC_CityO_JP1.txt_Truong_106.Text = data[1].Truong_106;
                    uC_CityO_JP1.txt_Truong_108.Text = data[1].Truong_108;

                    tab_De2.SelectedTabPage.Name = "tab_CityO_Loai1_De2";
                    uC_CityO_JP2.txt_Truong_016.Text = data[0].Truong_016;
                    uC_CityO_JP2.txt_Truong_094.Text = data[0].Truong_094;
                    uC_CityO_JP2.txt_Truong_096.Text = data[0].Truong_096;
                    uC_CityO_JP2.txt_Truong_098.Text = data[0].Truong_098;
                    uC_CityO_JP2.txt_Truong_100.Text = data[0].Truong_100;
                    uC_CityO_JP2.txt_Truong_102.Text = data[0].Truong_102;
                    uC_CityO_JP2.txt_Truong_104.Text = data[0].Truong_104;
                    uC_CityO_JP2.txt_Truong_106.Text = data[0].Truong_106;
                    uC_CityO_JP2.txt_Truong_108.Text = data[0].Truong_108;
                }
                Compare_TextBox(uC_CityO_JP1.txt_Truong_016, uC_CityO_JP2.txt_Truong_016);
                Compare_TextBox(uC_CityO_JP1.txt_Truong_094, uC_CityO_JP2.txt_Truong_094);
                Compare_TextBox(uC_CityO_JP1.txt_Truong_096, uC_CityO_JP2.txt_Truong_096);
                Compare_TextBox(uC_CityO_JP1.txt_Truong_098, uC_CityO_JP2.txt_Truong_098);
                Compare_TextBox(uC_CityO_JP1.txt_Truong_100, uC_CityO_JP2.txt_Truong_100);
                Compare_TextBox(uC_CityO_JP1.txt_Truong_102, uC_CityO_JP2.txt_Truong_102);
                Compare_TextBox(uC_CityO_JP1.txt_Truong_104, uC_CityO_JP2.txt_Truong_104);
                Compare_TextBox(uC_CityO_JP1.txt_Truong_106, uC_CityO_JP2.txt_Truong_106);
                Compare_TextBox(uC_CityO_JP1.txt_Truong_108, uC_CityO_JP2.txt_Truong_108);
            }
            var soloi = ((from w in Global.Db.GetSoLoiCheck(cbb_Batch_Check.SelectedValue + "", Global.StrCity, TypeCheck) select w.IDImage).Count() / 2).ToString();
            lb_Loi.Text = soloi + " Lỗi";
            timer1.Enabled = true;
        }
        bool FlagLoad = false;
        private void frm_Checker_Load(object sender, EventArgs e)
        {
            Global.FlagLoad = true;
            FlagLoad = true;
            this.Text = TypeCheck;
            splitCheck.SplitterPosition = Settings.Default.PositionSplitCheck;
            VisibleButtonSave();
            cbb_Batch_Check.DataSource = (from w in Global.Db.GetBatNotFinishChecker(Global.StrUserName, Global.StrCity, TypeCheck) select new { w.BatchID, w.BatchName }).ToList();
            cbb_Batch_Check.DisplayMember = "BatchName";
            cbb_Batch_Check.ValueMember = "BatchID";
            cbb_Batch_Check.SelectedValue = Global.StrBatchID;
            Folder = "";
            //Folder = (from w in Global.Db.GetFolder(cbb_Batch_Check.Text) select w.fPathPicture).FirstOrDefault();
            tab_CityO_Loai1_De1.PageVisible = false;
            tab_CityO_Loai2_De1.PageVisible = false;
            tab_CityO_Loai3_De1.PageVisible = false;
            tab_CityO_JP_De1.PageVisible = false;
            tab_CityO_Loai1_De2.PageVisible = false;
            tab_CityO_Loai2_De2.PageVisible = false;
            tab_CityO_Loai3_De2.PageVisible = false;
            tab_CityO_JP_De2.PageVisible = false;
            Global.FlagLoad = false;
            if (Global.StrCheck == "CHECKDESO" && Global.StrCity == "CityO")
            {
                uC_CityO_Loai3_DeSo1.UC_CityO_Loai3_DeSo_Load(null, null);
                uC_CityO_Loai3_DeSo2.UC_CityO_Loai3_DeSo_Load(null, null);
                uC_CityO_Loai3_DeSo1.Focus += UC_CityO_Loai3_DeSo1_Focus;
                uC_CityO_Loai3_DeSo2.Focus += UC_CityO_Loai3_DeSo1_Focus;
                tab_CityO_Loai1_De1.PageVisible = true;
                tab_CityO_Loai2_De1.PageVisible = true;
                tab_CityO_Loai3_De1.PageVisible = true;
                tab_CityO_Loai1_De2.PageVisible = true;
                tab_CityO_Loai2_De2.PageVisible = true;
                tab_CityO_Loai3_De2.PageVisible = true;
                uC_CityO_Loai11.Changed += UC_DESO1_Changed;
                uC_CityO_Loai3_DeSo1.Changed += UC_DESO1_Changed;
                uC_CityO_JP1.Changed += UC_DESO1_Changed;
                uC_CityO_Loai12.Changed += Uc_DeSo2_Changed;
                uC_CityO_Loai3_DeSo2.Changed += Uc_DeSo2_Changed;
                uC_CityO_JP2.Changed += Uc_DeSo2_Changed;
                
            }
            else if (Global.StrCheck == "CHECKDEJP" && Global.StrCity == "CityO")
            {
                tab_CityO_JP_De1.PageVisible = true;
                tab_CityO_JP_De2.PageVisible = true;
                splitCheck.SplitterPosition = 530;
                uC_CityO_JP1.Changed += UC_DESO1_Changed;
                uC_CityO_JP2.Changed += Uc_DeSo2_Changed;
            }
            var soloi = ((from w in Global.Db.GetSoLoiCheck(cbb_Batch_Check.SelectedValue + "", Global.StrCity, TypeCheck) select w.IDImage).Count() / 2).ToString();
            lb_Loi.Text = soloi + " Lỗi";
            FlagLoad = false;
        }

        private void UC_CityO_Loai3_DeSo1_Focus(string Truong, string Tag)
        {
            txt_Note.Text = Tag;
        }

        private void Uc_DeSo2_Changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lb_Image.Text))
                return;
            VisibleButtonSave();
            btn_SuaVaLuu_DeSo2.Visible = true;
        }

        private void UC_DESO1_Changed(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lb_Image.Text))
                return;
            VisibleButtonSave();
            btn_SuaVaLuu_DeSo1.Visible = true;
        }

        private void btn_Luu_DeSo1_Click(object sender, EventArgs e)
        {
            //Global.DbBpo.UpdateTimeLastRequest(Global.Token);
            if (Global.StrCheck == "CHECKDESO")
            {
                if (fLagRefresh)
                    Global.Db.Luu_DeSo(lb_User1.Text, lb_User2.Text, lb_Image.Text, fbatchRefresh, Global.StrUserName, Global.StrCity);
                else
                    Global.Db.Luu_DeSo(lb_User1.Text, lb_User2.Text, lb_Image.Text, cbb_Batch_Check.SelectedValue + "", Global.StrUserName, Global.StrCity);
            }
            else if (Global.StrCheck == "CHECKDEJP")
            {
                if (fLagRefresh)
                    Global.Db.Luu_DEJP(lb_User1.Text, lb_User2.Text, lb_Image.Text, fbatchRefresh, Global.StrUserName, Global.StrCity);
                else
                    Global.Db.Luu_DEJP(lb_User1.Text, lb_User2.Text, lb_Image.Text, cbb_Batch_Check.SelectedValue + "", Global.StrUserName, Global.StrCity);
            }
            
            fLagRefresh = false;
            fbatchRefresh = "";
            ResetData();
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                DialogResult = DialogResult.Yes;
                return;
            }
            string temp = GetImage();
            if (temp == "NULL")
            {
                uC_PictureBox1.imageBox1.Image = null;
                MessageBox.Show(@"Batch '" + cbb_Batch_Check.Text + "' đã hoàn thành");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                VisibleButtonSave();
                return;
            }
            Load_DeSo(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
            VisibleButtonSave();
        }

        private void btn_Luu_DeSo2_Click(object sender, EventArgs e)
        {
            //Global.DbBpo.UpdateTimeLastRequest(Global.Token);
            if (Global.StrCheck == "CHECKDESO")
            {
                if (fLagRefresh)
                    Global.Db.Luu_DeSo(lb_User2.Text, lb_User1.Text, lb_Image.Text, fbatchRefresh, Global.StrUserName, Global.StrCity);
                else
                    Global.Db.Luu_DeSo(lb_User2.Text, lb_User1.Text, lb_Image.Text, cbb_Batch_Check.SelectedValue + "", Global.StrUserName, Global.StrCity);
            }
            else if (Global.StrCheck == "CHECKDEJP")
            {
                if (fLagRefresh)
                    Global.Db.Luu_DEJP(lb_User2.Text, lb_User1.Text, lb_Image.Text, fbatchRefresh, Global.StrUserName, Global.StrCity);
                else
                    Global.Db.Luu_DEJP(lb_User2.Text, lb_User1.Text, lb_Image.Text, cbb_Batch_Check.SelectedValue + "", Global.StrUserName, Global.StrCity);
            }
            fLagRefresh = false;
            fbatchRefresh = "";
            ResetData();
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                DialogResult = DialogResult.Yes;
                return;
            }
            string temp = GetImage();
            if (temp == "NULL")
            {
                uC_PictureBox1.imageBox1.Image = null;
                MessageBox.Show(@"Batch '" + cbb_Batch_Check.Text + "' đã hoàn thành");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                VisibleButtonSave();
                return;
            }
            Load_DeSo(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
            VisibleButtonSave();
        }
        
        private void btn_SuaVaLuu_DeSo1_Click(object sender, EventArgs e)
        {
            //Global.DbBpo.UpdateTimeLastRequest(Global.Token);
            if (fLagRefresh)
            {
                if (tab_De1.SelectedTabPage == tab_CityO_Loai1_De1)
                    uC_CityO_Loai11.Edit_Save_CityO_Loai1(fbatchRefresh, lb_Image.Text);
                else if (tab_De1.SelectedTabPage == tab_CityO_Loai2_De1)
                    Global.Db.Sua_va_Luu_DeSo(fbatchRefresh, lb_Image.Text,Global.StrUserName, Global.StrCity, "Loai2",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", false);
                else if (tab_De1.SelectedTabPage == tab_CityO_Loai3_De1)
                    uC_CityO_Loai3_DeSo1.Edit_Save_CityO_Loai3(fbatchRefresh, lb_Image.Text);
                else if (tab_De1.SelectedTabPage == tab_CityO_JP_De1)
                    uC_CityO_JP1.Edit_Save_CityO_JP(fbatchRefresh, lb_Image.Text);

            }
            else
            {
                if (tab_De1.SelectedTabPage == tab_CityO_Loai1_De1)
                    uC_CityO_Loai11.Edit_Save_CityO_Loai1(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
                else if (tab_De1.SelectedTabPage == tab_CityO_Loai2_De1)
                    Global.Db.Sua_va_Luu_DeSo(cbb_Batch_Check.SelectedValue + "", lb_Image.Text, Global.StrUserName, Global.StrCity, "Loai2",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", false);
                else if (tab_De1.SelectedTabPage == tab_CityO_Loai3_De1)
                    uC_CityO_Loai3_DeSo1.Edit_Save_CityO_Loai3(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
                else if (tab_De1.SelectedTabPage == tab_CityO_JP_De1)
                    uC_CityO_JP1.Edit_Save_CityO_JP(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
            }
            fLagRefresh = false;
            fbatchRefresh = "";
            ResetData();
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                DialogResult = DialogResult.Yes;
                return;
            }
            string temp = GetImage();
            if (temp == "NULL")
            {
                uC_PictureBox1.imageBox1.Image = null;
                MessageBox.Show(@"Batch '" + cbb_Batch_Check.Text + "' đã hoàn thành");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                VisibleButtonSave();
                return;
            }
            Load_DeSo(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
            VisibleButtonSave();
        }

        private void btn_SuaVaLuu_DeSo2_Click(object sender, EventArgs e)
        {
            //Global.DbBpo.UpdateTimeLastRequest(Global.Token);
            if (fLagRefresh)
            {
                if (tab_De2.SelectedTabPage.Name == "tab_CityO_Loai1_De2")
                    uC_CityO_Loai12.Edit_Save_CityO_Loai1(fbatchRefresh, lb_Image.Text);
                else if (tab_De2.SelectedTabPage.Name == "tab_CityO_Loai2_De2")
                    Global.Db.Sua_va_Luu_DeSo(fbatchRefresh, lb_Image.Text, Global.StrUserName, Global.StrCity, "Loai2",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", false);
                else if (tab_De2.SelectedTabPage.Name == "tab_CityO_Loai3_De2")
                    uC_CityO_Loai3_DeSo2.Edit_Save_CityO_Loai3(fbatchRefresh, lb_Image.Text);
                else if (tab_De2.SelectedTabPage.Name == "tab_CityO_JP_De2")
                    uC_CityO_JP2.Edit_Save_CityO_JP(fbatchRefresh, lb_Image.Text);

            }
            else
            {
                if (tab_De2.SelectedTabPage == tab_CityO_Loai1_De2)
                    uC_CityO_Loai12.Edit_Save_CityO_Loai1(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
                else if (tab_De2.SelectedTabPage == tab_CityO_Loai2_De2)
                    Global.Db.Sua_va_Luu_DeSo(cbb_Batch_Check.SelectedValue + "", lb_Image.Text, Global.StrUserName, Global.StrCity, "Loai2",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", "", "", "", "", "",
                                                     "", "", "", "", "", false);
                else if (tab_De2.SelectedTabPage == tab_CityO_Loai3_De2)
                    uC_CityO_Loai3_DeSo2.Edit_Save_CityO_Loai3(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
                else if (tab_De2.SelectedTabPage == tab_CityO_JP_De2)
                    uC_CityO_JP2.Edit_Save_CityO_JP(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
            }
            fLagRefresh = false;
            fbatchRefresh = "";
            ResetData();
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                DialogResult = DialogResult.Yes;
                return;
            }
            string temp = GetImage();
            if (temp == "NULL")
            {
                uC_PictureBox1.imageBox1.Image = null;
                MessageBox.Show(@"Batch '" + cbb_Batch_Check.Text + "' đã hoàn thành");
                LoadBatchMoi();
                return;
            }
            if (temp == "Error")
            {
                MessageBox.Show("Lỗi load hình");
                VisibleButtonSave();
                return;
            }
            Load_DeSo(cbb_Batch_Check.SelectedValue + "", lb_Image.Text);
            VisibleButtonSave();
        }

        private void Compare_TextBox(TextEdit t1, TextEdit t2)
        {
            if (t1.Text != t2.Text)
            {
                t1.BackColor = Color.PaleVioletRed;
                t2.BackColor = Color.PaleVioletRed;
            }
            else
            {
                t1.BackColor = Color.White;
                t2.BackColor = Color.White;
            }
        }
        public void CompareRichTextBox(RichTextBox t1, RichTextBox t2)
        {
            int n = 0;
            string s = t1.Text;
            string s1 = t2.Text;
            if (s.Length > s1.Length)
            {
                n = s1.Length;
                t1.SelectionStart = n;
                t1.SelectionLength = s.Length - s1.Length;
                t1.SelectionColor = Color.Red;
            }
            else
            {
                n = s.Length;
                t2.SelectionStart = n;
                t2.SelectionLength = s1.Length - s.Length;
                t2.SelectionColor = Color.Red;
            }

            for (int i = 0; i < n; i++)
            {
                if (s[i] != s1[i])
                {
                    t1.SelectionStart = i;
                    t1.SelectionLength = 1;
                    t1.SelectionColor = Color.Red;

                    t2.SelectionStart = i;
                    t2.SelectionLength = 1;
                    t2.SelectionColor = Color.Red;
                }
            }
        }

        private void lb_fBatchName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(cbb_Batch_Check.Text);
            XtraMessageBox.Show("Copy batch name Success!");
        }

        private void lb_Image_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_Image.Text);
            XtraMessageBox.Show("Copy image name Success!");
        }
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            LockControl(false);
        }

        private void cbb_Batch_Check_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FlagLoad)
                return;
            VisibleButtonSave();
            lb_Image.Text = "";
            //Global.StrBatchID = cbb_Batch_Check.SelectedValue+"";
            var soloi = ((from w in Global.Db.GetSoLoiCheck(cbb_Batch_Check.SelectedValue + "", Global.StrCity, TypeCheck) select w.IDImage).Count() / 2).ToString();
            lb_Loi.Text = soloi + " Lỗi";
            ResetData();
            btn_Start.Visible = true;
        }

        private void btn_ShowImageCheck_Click(object sender, EventArgs e)
        {
            frm_ShowCheckedImage a = new frm_ShowCheckedImage();
            a.BatchID = cbb_Batch_Check.SelectedValue + "";
            a.TypeCheck = TypeCheck;
            a.ShowDialog();
        }

        private void splitContainerControl1_SplitterPositionChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(splitCheck.SplitterPosition+"");
            Settings.Default.PositionSplitCheck = splitCheck.SplitterPosition;
            Settings.Default.Save();
        }

        private void btn_CheckLai_Click(object sender, EventArgs e)
        {
            var temp = (from w in Global.Db.GetImage_RefreshCheck(Global.StrUserName,Global.StrCity,TypeCheck) select new { w.BatchID, w.IDImage}).FirstOrDefault();
            if (temp == null)
            {
                MessageBox.Show("Bạn chưa check, vui lòng check hình trước khi check lại");
                return;
            }
            lb_Image.Text = "";
            fbatchRefresh = "";
            var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (version != Global.Version)
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                Application.Exit();
            }
            ResetData();
            lb_Image.Text = temp.IDImage;
            fbatchRefresh = temp.BatchID;
            uC_PictureBox1.LoadImage(Global.Webservice + fbatchRefresh + "/" + lb_Image.Text, lb_Image.Text, Settings.Default.ZoomImage);
            //uC_PictureBox1.LoadImage(Global.Webservice + temp.fPathPicture + @"\" + fbatchRefresh + "/" + lb_Image.Text, lb_Image.Text, Settings.Default.ZoomImage);
            Load_DeSo(fbatchRefresh, lb_Image.Text);
            VisibleButtonSave();
            fLagRefresh = true;
            btn_Start.Visible = false;
        }

        private void cbb_Batch_Check_TextChanged(object sender, EventArgs e)
        {
            //Folder = "";
            //Folder = (from w in Global.Db.GetFolder(cbb_Batch_Check.Text) select w.fPathPicture).FirstOrDefault();
        }

        private void uC_CityO_Loai11_Scroll(object sender, ScrollEventArgs e)
        {
            if (tab_De1.SelectedTabPage.Name == "tab_CityO_Loai1_De1" && tab_De2.SelectedTabPage.Name == "tab_CityO_Loai1_De2")
            {
                if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                    uC_CityO_Loai12.HorizontalScroll.Value = e.NewValue;
                else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                    uC_CityO_Loai12.VerticalScroll.Value = e.NewValue;
            }
        }

        private void uC_CityO_Loai12_Scroll(object sender, ScrollEventArgs e)
        {
            if (tab_De1.SelectedTabPage.Name == "tab_CityO_Loai1_De1" && tab_De2.SelectedTabPage.Name == "tab_CityO_Loai1_De2")
            {
                if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                    uC_CityO_Loai11.HorizontalScroll.Value = e.NewValue;
                else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                    uC_CityO_Loai11.VerticalScroll.Value = e.NewValue;
            }
        }

        private void uC_CityO_Loai3_DeSo1_Scroll(object sender, ScrollEventArgs e)
        {
            if (tab_De1.SelectedTabPage.Name == "tab_CityO_Loai3_De1" && tab_De2.SelectedTabPage.Name == "tab_CityO_Loai3_De2")
            {
                if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                    uC_CityO_Loai3_DeSo2.HorizontalScroll.Value = e.NewValue;
                else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                    uC_CityO_Loai3_DeSo2.VerticalScroll.Value = e.NewValue;
            }
        }

        private void uC_CityO_Loai3_DeSo2_Scroll(object sender, ScrollEventArgs e)
        {
            if (tab_De1.SelectedTabPage.Name == "tab_CityO_Loai3_De1" && tab_De2.SelectedTabPage.Name == "tab_CityO_Loai3_De2")
            {
                if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                    uC_CityO_Loai3_DeSo1.HorizontalScroll.Value = e.NewValue;
                else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                    uC_CityO_Loai3_DeSo1.VerticalScroll.Value = e.NewValue;
            }
        }

        private void uC_CityO_JP1_Scroll(object sender, ScrollEventArgs e)
        {
            if (tab_De1.SelectedTabPage.Name == "tab_CityO_JP_De1" && tab_De2.SelectedTabPage.Name == "tab_CityO_JP_De2")
            {
                if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                    uC_CityO_JP2.HorizontalScroll.Value = e.NewValue;
                else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                    uC_CityO_JP2.VerticalScroll.Value = e.NewValue;
            }
        }

        private void uC_CityO_JP2_Scroll(object sender, ScrollEventArgs e)
        {
            if (tab_De1.SelectedTabPage.Name == "tab_CityO_JP_De1" && tab_De2.SelectedTabPage.Name == "tab_CityO_JP_De2")
            {
                if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.HorizontalScroll)
                    uC_CityO_JP1.HorizontalScroll.Value = e.NewValue;
                else if (e.ScrollOrientation == System.Windows.Forms.ScrollOrientation.VerticalScroll)
                    uC_CityO_JP1.VerticalScroll.Value = e.NewValue;
            }
        }

        private void tab_De1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (tab_De1.SelectedTabPage == tab_CityO_Loai3_De1 || tab_De2.SelectedTabPage == tab_CityO_Loai3_De2)
            {
                uC_CityO_Loai3_DeSo1.txt_Truong_015.Focus();
                splitCheck.SplitterPosition = 695;
            }
            else if (tab_De1.SelectedTabPage == tab_CityO_Loai1_De1|| tab_De2.SelectedTabPage == tab_CityO_Loai1_De2)
            {
                splitCheck.SplitterPosition = 305;
            }
        }

        private void cbb_Batch_Check_KeyPress(object sender, KeyPressEventArgs e)
        {
            if((int)e.KeyChar!=3)
            {
                e.Handled = true;
            }
        }

        private void cbb_Batch_Check_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete || e.KeyCode == Keys.Back)
                cbb_Batch_Check.Text = "";
        }
    }
}
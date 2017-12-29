using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BaoCaoLuong2018.MyClass;
using BaoCaoLuong2018.Properties;

namespace BaoCaoLuong2018.MyForm
{
    public partial class ShowImage : DevExpress.XtraEditors.XtraForm
    {
        public ShowImage()
        {
            InitializeComponent();
        }
        public string BatchName = "";
        public string BatchID = "";
        public string IdImage = "";
        private void SoSanhDoiMau(TextEdit txt1, TextEdit txt2, TextEdit txt3)
        {
            if ((txt1.Text != txt2.Text))
            {
                txt2.ForeColor = Color.White;
                txt2.BackColor = Color.Red;
                txt1.ForeColor = Color.White;
                txt1.BackColor = Color.Green;
                if (txt3.Text == txt1.Text)
                {
                    txt3.ForeColor = Color.White;
                    txt3.BackColor = Color.Green;
                }
            }
            if ((txt1.Text != txt3.Text))
            {
                txt3.ForeColor = Color.White;
                txt3.BackColor = Color.Red;
                txt1.ForeColor = Color.White;
                txt1.BackColor = Color.Green;
                if (txt1.Text == txt2.Text)
                {
                    txt2.ForeColor = Color.White;
                    txt2.BackColor = Color.Green;
                }
            }
        }

        private string Folder = "";
        private void ShowImage_Load(object sender, EventArgs e)
        {
            uC_ShowImage_CityO1.tab_CityO_JP_Check.PageVisible = false;
            uC_ShowImage_CityO1.tab_CityO_JP_User1.PageVisible = false;
            uC_ShowImage_CityO1.tab_CityO_JP_User2.PageVisible = false;

            uC_ShowImage_CityO1.tab_CityO_Loai1_Check.PageVisible = false;
            uC_ShowImage_CityO1.tab_CityO_Loai1_User1.PageVisible = false;
            uC_ShowImage_CityO1.tab_CityO_Loai1_User2.PageVisible = false;

            uC_ShowImage_CityO1.tab_CityO_Loai2_Check.PageVisible = false;
            uC_ShowImage_CityO1.tab_CityO_Loai2_User1.PageVisible = false;
            uC_ShowImage_CityO1.tab_CityO_Loai2_User2.PageVisible = false;

            uC_ShowImage_CityO1.tab_CityO_Loai3_Check.PageVisible = false;
            uC_ShowImage_CityO1.tab_CityO_Loai3_User1.PageVisible = false;
            uC_ShowImage_CityO1.tab_CityO_Loai3_User2.PageVisible = false;

            lb_Batch.Text = BatchName;
            lb_Image.Text = IdImage;
            //Folder = "";
            //Folder = (from w in Global.Db.GetFolder(FBatchName) select w.fPathPicture).FirstOrDefault();
            uc_PictureBox1.LoadImage(Global.Webservice + BatchID + "/" + IdImage, IdImage, Settings.Default.ZoomImage);
            if (Global.StrCheck == "CHECKDESO" && Global.StrCity=="CityO")
            {
                uC_ShowImage_CityO1.tab_CityO_Loai1_Check.PageVisible = true;
                uC_ShowImage_CityO1.tab_CityO_Loai1_User1.PageVisible = true;
                uC_ShowImage_CityO1.tab_CityO_Loai1_User2.PageVisible = true;

                uC_ShowImage_CityO1.tab_CityO_Loai2_Check.PageVisible = true;
                uC_ShowImage_CityO1.tab_CityO_Loai2_User1.PageVisible = true;
                uC_ShowImage_CityO1.tab_CityO_Loai2_User2.PageVisible = true;

                uC_ShowImage_CityO1.tab_CityO_Loai3_Check.PageVisible = true;
                uC_ShowImage_CityO1.tab_CityO_Loai3_User1.PageVisible = true;
                uC_ShowImage_CityO1.tab_CityO_Loai3_User2.PageVisible = true;
                var data = (from w in Global.Db.tbl_DeSo_CityOs where w.BatchID==BatchID && w.IDImage==IdImage orderby w.Phase descending,w.True descending select w).ToList();
                if (data.Count == 3)
                {
                    uC_ShowImage_CityO1.lb_UserCheck.Text = "Check: " + data[0].UserName;
                    uC_ShowImage_CityO1.lb_User1.Text = "User1: " + data[1].UserName;
                    uC_ShowImage_CityO1.lb_User2.Text = "User2: " + data[2].UserName;
                    if (data[0].LoaiPhieu == "Loai1")
                    {
                        uC_ShowImage_CityO1.xtraTabControl1.SelectedTabPage.Name = "tab_CityO_Loai1_Check";
                        uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_018.Text = data[0].Truong_018;
                        uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_019.Text = data[0].Truong_019;
                        uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_021.Text = data[0].Truong_021;
                        uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_022.Text = data[0].Truong_022;
                        uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_023.Text = data[0].Truong_023;
                        uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_024.Text = data[0].Truong_024;
                        uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_025.Text = data[0].Truong_025;
                        uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_026.Text = data[0].Truong_026;
                        uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_027.Text = data[0].Truong_027;
                        uC_ShowImage_CityO1.uC_CityO_Loai11.chk_QC.Checked = data[0].CheckQC.Value;
                    }
                    else if (data[0].LoaiPhieu == "Loai2")
                    {
                        uC_ShowImage_CityO1.xtraTabControl1.SelectedTabPage.Name = "tab_CityO_Loai2_Check";
                    }
                    else if (data[0].LoaiPhieu == "Loai3")
                    {
                        uC_ShowImage_CityO1.xtraTabControl1.SelectedTabPage.Name = "tab_CityO_Loai3_Check";
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_015.Text = data[0].Truong_015;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_017.Text = data[0].Truong_017;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_018.Text = data[0].Truong_018;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_019.Text = data[0].Truong_019;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_020.Text = data[0].Truong_020;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_021.Text = data[0].Truong_021;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_023.Text = data[0].Truong_023;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_024.Text = data[0].Truong_024;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_025.Text = data[0].Truong_025;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_026.Text = data[0].Truong_026;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_027.Text = data[0].Truong_027;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_028.Text = data[0].Truong_028;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_030.Text = data[0].Truong_030;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_031.Text = data[0].Truong_031;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_032.Text = data[0].Truong_032;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_033.Text = data[0].Truong_033;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_034.Text = data[0].Truong_034;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_035.Text = data[0].Truong_035;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_036.Text = data[0].Truong_036;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_037.Text = data[0].Truong_037;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_038.Text = data[0].Truong_038;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_039.Text = data[0].Truong_039;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_040.Text = data[0].Truong_040;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_041.Text = data[0].Truong_041;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_044.Text = data[0].Truong_044;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_045.Text = data[0].Truong_045;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_046.Text = data[0].Truong_046;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_048.Text = data[0].Truong_048;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_049.Text = data[0].Truong_049;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_050.Text = data[0].Truong_050;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_051.Text = data[0].Truong_051;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_052.Text = data[0].Truong_052;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_055.Text = data[0].Truong_055;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_056.Text = data[0].Truong_056;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_058.Text = data[0].Truong_058;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_059.Text = data[0].Truong_059;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_060.Text = data[0].Truong_060;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_062.Text = data[0].Truong_062;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_063.Text = data[0].Truong_063;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_064.Text = data[0].Truong_064;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_067.Text = data[0].Truong_067;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_069.Text = data[0].Truong_069;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_072.Text = data[0].Truong_072;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_073.Text = data[0].Truong_073;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_074.Text = data[0].Truong_074;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_075.Text = data[0].Truong_075;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_076.Text = data[0].Truong_076;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_077.Text = data[0].Truong_077;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_078.Text = data[0].Truong_078;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_079.Text = data[0].Truong_079;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_081.Text = data[0].Truong_081;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_082.Text = data[0].Truong_082;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_083.Text = data[0].Truong_083;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_084.Text = data[0].Truong_084;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_086.Text = data[0].Truong_086;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_087.Text = data[0].Truong_087;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_088.Text = data[0].Truong_088;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_089.Text = data[0].Truong_089;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_090.Text = data[0].Truong_090;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_095.Text = data[0].Truong_095;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_097.Text = data[0].Truong_097;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_099.Text = data[0].Truong_099;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_101.Text = data[0].Truong_101;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_103.Text = data[0].Truong_103;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_105.Text = data[0].Truong_105;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_107.Text = data[0].Truong_107;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_109.Text = data[0].Truong_109;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_110.Text = data[0].Truong_110;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_111.Text = data[0].Truong_111;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.chk_QC.Checked = data[0].CheckQC.Value;
                    }
                    if (data[1].LoaiPhieu == "Loai1")
                    {
                        uC_ShowImage_CityO1.xtraTabControl2.SelectedTabPage.Name = "tab_CityO_Loai1_Check";
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_018.Text = data[1].Truong_018;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_019.Text = data[1].Truong_019;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_021.Text = data[1].Truong_021;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_022.Text = data[1].Truong_022;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_023.Text = data[1].Truong_023;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_024.Text = data[1].Truong_024;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_025.Text = data[1].Truong_025;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_026.Text = data[1].Truong_026;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_027.Text = data[1].Truong_027;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.chk_QC.Checked = data[1].CheckQC.Value;
                    }
                    else if (data[1].LoaiPhieu == "Loai2")
                    {
                        uC_ShowImage_CityO1.xtraTabControl2.SelectedTabPage.Name = "tab_CityO_Loai2_Check";
                    }
                    else if (data[1].LoaiPhieu == "Loai3")
                    {
                        uC_ShowImage_CityO1.xtraTabControl2.SelectedTabPage.Name = "tab_CityO_Loai3_Check";
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_015.Text = data[1].Truong_015;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_017.Text = data[1].Truong_017;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_018.Text = data[1].Truong_018;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_019.Text = data[1].Truong_019;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_020.Text = data[1].Truong_020;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_021.Text = data[1].Truong_021;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_023.Text = data[1].Truong_023;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_024.Text = data[1].Truong_024;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_025.Text = data[1].Truong_025;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_026.Text = data[1].Truong_026;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_027.Text = data[1].Truong_027;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_028.Text = data[1].Truong_028;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_030.Text = data[1].Truong_030;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_031.Text = data[1].Truong_031;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_032.Text = data[1].Truong_032;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_033.Text = data[1].Truong_033;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_034.Text = data[1].Truong_034;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_035.Text = data[1].Truong_035;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_036.Text = data[1].Truong_036;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_037.Text = data[1].Truong_037;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_038.Text = data[1].Truong_038;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_039.Text = data[1].Truong_039;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_040.Text = data[1].Truong_040;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_041.Text = data[1].Truong_041;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_044.Text = data[1].Truong_044;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_045.Text = data[1].Truong_045;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_046.Text = data[1].Truong_046;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_048.Text = data[1].Truong_048;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_049.Text = data[1].Truong_049;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_050.Text = data[1].Truong_050;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_051.Text = data[1].Truong_051;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_052.Text = data[1].Truong_052;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_055.Text = data[1].Truong_055;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_056.Text = data[1].Truong_056;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_058.Text = data[1].Truong_058;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_059.Text = data[1].Truong_059;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_060.Text = data[1].Truong_060;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_062.Text = data[1].Truong_062;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_063.Text = data[1].Truong_063;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_064.Text = data[1].Truong_064;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_067.Text = data[1].Truong_067;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_069.Text = data[1].Truong_069;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_072.Text = data[1].Truong_072;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_073.Text = data[1].Truong_073;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_074.Text = data[1].Truong_074;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_075.Text = data[1].Truong_075;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_076.Text = data[1].Truong_076;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_077.Text = data[1].Truong_077;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_078.Text = data[1].Truong_078;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_079.Text = data[1].Truong_079;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_081.Text = data[1].Truong_081;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_082.Text = data[1].Truong_082;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_083.Text = data[1].Truong_083;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_084.Text = data[1].Truong_084;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_086.Text = data[1].Truong_086;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_087.Text = data[1].Truong_087;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_088.Text = data[1].Truong_088;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_089.Text = data[1].Truong_089;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_090.Text = data[1].Truong_090;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_095.Text = data[1].Truong_095;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_097.Text = data[1].Truong_097;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_099.Text = data[1].Truong_099;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_101.Text = data[1].Truong_101;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_103.Text = data[1].Truong_103;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_105.Text = data[1].Truong_105;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_107.Text = data[1].Truong_107;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_109.Text = data[1].Truong_109;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_110.Text = data[1].Truong_110;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_111.Text = data[1].Truong_111;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.chk_QC.Checked = data[1].CheckQC.Value;
                    }
                    if (data[2].LoaiPhieu == "Loai1")
                    {
                        uC_ShowImage_CityO1.xtraTabControl3.SelectedTabPage.Name = "tab_CityO_Loai1_Check";
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_018.Text = data[2].Truong_018;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_019.Text = data[2].Truong_019;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_021.Text = data[2].Truong_021;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_022.Text = data[2].Truong_022;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_023.Text = data[2].Truong_023;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_024.Text = data[2].Truong_024;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_025.Text = data[2].Truong_025;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_026.Text = data[2].Truong_026;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_027.Text = data[2].Truong_027;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.chk_QC.Checked = data[2].CheckQC.Value;
                        SetColorLoai1();
                    }
                    else if (data[2].LoaiPhieu == "Loai2")
                    {
                        uC_ShowImage_CityO1.xtraTabControl3.SelectedTabPage.Name = "tab_CityO_Loai2_Check";
                    }
                    else if (data[2].LoaiPhieu == "Loai3")
                    {
                        uC_ShowImage_CityO1.xtraTabControl3.SelectedTabPage.Name = "tab_CityO_Loai3_Check";
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_015.Text = data[2].Truong_015;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_017.Text = data[2].Truong_017;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_018.Text = data[2].Truong_018;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_019.Text = data[2].Truong_019;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_020.Text = data[2].Truong_020;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_021.Text = data[2].Truong_021;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_023.Text = data[2].Truong_023;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_024.Text = data[2].Truong_024;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_025.Text = data[2].Truong_025;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_026.Text = data[2].Truong_026;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_027.Text = data[2].Truong_027;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_028.Text = data[2].Truong_028;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_030.Text = data[2].Truong_030;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_031.Text = data[2].Truong_031;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_032.Text = data[2].Truong_032;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_033.Text = data[2].Truong_033;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_034.Text = data[2].Truong_034;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_035.Text = data[2].Truong_035;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_036.Text = data[2].Truong_036;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_037.Text = data[2].Truong_037;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_038.Text = data[2].Truong_038;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_039.Text = data[2].Truong_039;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_040.Text = data[2].Truong_040;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_041.Text = data[2].Truong_041;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_044.Text = data[2].Truong_044;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_045.Text = data[2].Truong_045;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_046.Text = data[2].Truong_046;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_048.Text = data[2].Truong_048;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_049.Text = data[2].Truong_049;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_050.Text = data[2].Truong_050;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_051.Text = data[2].Truong_051;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_052.Text = data[2].Truong_052;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_055.Text = data[2].Truong_055;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_056.Text = data[2].Truong_056;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_058.Text = data[2].Truong_058;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_059.Text = data[2].Truong_059;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_060.Text = data[2].Truong_060;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_062.Text = data[2].Truong_062;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_063.Text = data[2].Truong_063;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_064.Text = data[2].Truong_064;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_067.Text = data[2].Truong_067;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_069.Text = data[2].Truong_069;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_072.Text = data[2].Truong_072;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_073.Text = data[2].Truong_073;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_074.Text = data[2].Truong_074;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_075.Text = data[2].Truong_075;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_076.Text = data[2].Truong_076;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_077.Text = data[2].Truong_077;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_078.Text = data[2].Truong_078;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_079.Text = data[2].Truong_079;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_081.Text = data[2].Truong_081;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_082.Text = data[2].Truong_082;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_083.Text = data[2].Truong_083;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_084.Text = data[2].Truong_084;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_086.Text = data[2].Truong_086;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_087.Text = data[2].Truong_087;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_088.Text = data[2].Truong_088;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_089.Text = data[2].Truong_089;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_090.Text = data[2].Truong_090;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_095.Text = data[2].Truong_095;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_097.Text = data[2].Truong_097;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_099.Text = data[2].Truong_099;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_101.Text = data[2].Truong_101;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_103.Text = data[2].Truong_103;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_105.Text = data[2].Truong_105;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_107.Text = data[2].Truong_107;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_109.Text = data[2].Truong_109;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_110.Text = data[2].Truong_110;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_111.Text = data[2].Truong_111;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.chk_QC.Checked = data[2].CheckQC.Value;
                        SetColorLoai3();
                    }
                }
                if (data.Count == 2)
                {
                    var Usercheck = (from w in Global.Db.tbl_MissCheck_DeSos where w.BatchID == BatchID & w.IDImage == IdImage select w.UserName).FirstOrDefault();
                    uC_ShowImage_CityO1.lb_UserCheck.Text = "Check: " + Usercheck;
                    uC_ShowImage_CityO1.lb_User1.Text = "User1: " + data[0].UserName;
                    uC_ShowImage_CityO1.lb_User2.Text = "User2: " + data[1].UserName;
                    if (data[0].LoaiPhieu == "Loai1")
                    {
                        uC_ShowImage_CityO1.xtraTabControl1.SelectedTabPage.Name = "tab_CityO_Loai1_Check";
                        uC_ShowImage_CityO1.xtraTabControl2.SelectedTabPage.Name = "tab_CityO_Loai1_Check";
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_018.Text = uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_018.Text = data[0].Truong_018;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_019.Text = uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_019.Text = data[0].Truong_019;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_021.Text = uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_021.Text = data[0].Truong_021;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_022.Text = uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_022.Text = data[0].Truong_022;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_023.Text = uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_023.Text = data[0].Truong_023;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_024.Text = uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_024.Text = data[0].Truong_024;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_025.Text = uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_025.Text = data[0].Truong_025;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_026.Text = uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_026.Text = data[0].Truong_026;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_027.Text = uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_027.Text = data[0].Truong_027;
                        uC_ShowImage_CityO1.uC_CityO_Loai12.chk_QC.Checked = uC_ShowImage_CityO1.uC_CityO_Loai11.chk_QC.Checked = data[0].CheckQC.Value;
                    }
                    else if (data[0].LoaiPhieu == "Loai2")
                    {
                        uC_ShowImage_CityO1.xtraTabControl1.SelectedTabPage.Name = "tab_CityO_Loai2_Check";
                        uC_ShowImage_CityO1.xtraTabControl2.SelectedTabPage.Name = "tab_CityO_Loai2_Check";
                    }
                    else if (data[0].LoaiPhieu == "Loai3")
                    {
                        uC_ShowImage_CityO1.xtraTabControl1.SelectedTabPage.Name = "tab_CityO_Loai3_Check";
                        uC_ShowImage_CityO1.xtraTabControl2.SelectedTabPage.Name = "tab_CityO_Loai3_Check";
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_015.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_015.Text = data[0].Truong_015;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_017.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_017.Text = data[0].Truong_017;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_018.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_018.Text = data[0].Truong_018;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_019.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_019.Text = data[0].Truong_019;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_020.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_020.Text = data[0].Truong_020;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_021.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_021.Text = data[0].Truong_021;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_023.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_023.Text = data[0].Truong_023;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_024.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_024.Text = data[0].Truong_024;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_025.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_025.Text = data[0].Truong_025;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_026.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_026.Text = data[0].Truong_026;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_027.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_027.Text = data[0].Truong_027;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_028.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_028.Text = data[0].Truong_028;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_030.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_030.Text = data[0].Truong_030;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_031.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_031.Text = data[0].Truong_031;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_032.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_032.Text = data[0].Truong_032;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_033.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_033.Text = data[0].Truong_033;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_034.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_034.Text = data[0].Truong_034;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_035.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_035.Text = data[0].Truong_035;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_036.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_036.Text = data[0].Truong_036;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_037.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_037.Text = data[0].Truong_037;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_038.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_038.Text = data[0].Truong_038;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_039.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_039.Text = data[0].Truong_039;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_040.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_040.Text = data[0].Truong_040;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_041.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_041.Text = data[0].Truong_041;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_044.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_044.Text = data[0].Truong_044;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_045.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_045.Text = data[0].Truong_045;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_046.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_046.Text = data[0].Truong_046;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_048.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_048.Text = data[0].Truong_048;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_049.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_049.Text = data[0].Truong_049;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_050.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_050.Text = data[0].Truong_050;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_051.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_051.Text = data[0].Truong_051;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_052.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_052.Text = data[0].Truong_052;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_055.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_055.Text = data[0].Truong_055;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_056.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_056.Text = data[0].Truong_056;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_058.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_058.Text = data[0].Truong_058;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_059.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_059.Text = data[0].Truong_059;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_060.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_060.Text = data[0].Truong_060;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_062.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_062.Text = data[0].Truong_062;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_063.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_063.Text = data[0].Truong_063;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_064.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_064.Text = data[0].Truong_064;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_067.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_067.Text = data[0].Truong_067;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_069.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_069.Text = data[0].Truong_069;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_072.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_072.Text = data[0].Truong_072;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_073.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_073.Text = data[0].Truong_073;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_074.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_074.Text = data[0].Truong_074;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_075.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_075.Text = data[0].Truong_075;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_076.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_076.Text = data[0].Truong_076;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_077.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_077.Text = data[0].Truong_077;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_078.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_078.Text = data[0].Truong_078;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_079.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_079.Text = data[0].Truong_079;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_081.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_081.Text = data[0].Truong_081;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_082.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_082.Text = data[0].Truong_082;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_083.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_083.Text = data[0].Truong_083;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_084.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_084.Text = data[0].Truong_084;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_086.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_086.Text = data[0].Truong_086;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_087.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_087.Text = data[0].Truong_087;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_088.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_088.Text = data[0].Truong_088;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_089.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_089.Text = data[0].Truong_089;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_090.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_090.Text = data[0].Truong_090;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_095.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_095.Text = data[0].Truong_095;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_097.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_097.Text = data[0].Truong_097;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_099.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_099.Text = data[0].Truong_099;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_101.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_101.Text = data[0].Truong_101;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_103.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_103.Text = data[0].Truong_103;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_105.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_105.Text = data[0].Truong_105;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_107.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_107.Text = data[0].Truong_107;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_109.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_109.Text = data[0].Truong_109;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_110.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_110.Text = data[0].Truong_110;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_111.Text = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_111.Text = data[0].Truong_111;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.chk_QC.Checked = uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.chk_QC.Checked = data[0].CheckQC.Value;
                    }
                    if (data[1].LoaiPhieu == "Loai1")
                    {
                        uC_ShowImage_CityO1.xtraTabControl3.SelectedTabPage.Name = "tab_CityO_Loai1_Check";
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_018.Text = data[1].Truong_018;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_019.Text = data[1].Truong_019;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_021.Text = data[1].Truong_021;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_022.Text = data[1].Truong_022;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_023.Text = data[1].Truong_023;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_024.Text = data[1].Truong_024;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_025.Text = data[1].Truong_025;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_026.Text = data[1].Truong_026;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_027.Text = data[1].Truong_027;
                        uC_ShowImage_CityO1.uC_CityO_Loai13.chk_QC.Checked = data[1].CheckQC.Value;
                        SetColorLoai1();
                    }
                    else if (data[1].LoaiPhieu == "Loai2")
                    {
                        uC_ShowImage_CityO1.xtraTabControl3.SelectedTabPage.Name = "tab_CityO_Loai2_Check";
                    }
                    else if (data[1].LoaiPhieu == "Loai3")
                    {
                        uC_ShowImage_CityO1.xtraTabControl3.SelectedTabPage.Name = "tab_CityO_Loai3_Check";
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_015.Text = data[1].Truong_015;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_017.Text = data[1].Truong_017;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_018.Text = data[1].Truong_018;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_019.Text = data[1].Truong_019;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_020.Text = data[1].Truong_020;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_021.Text = data[1].Truong_021;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_023.Text = data[1].Truong_023;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_024.Text = data[1].Truong_024;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_025.Text = data[1].Truong_025;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_026.Text = data[1].Truong_026;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_027.Text = data[1].Truong_027;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_028.Text = data[1].Truong_028;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_030.Text = data[1].Truong_030;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_031.Text = data[1].Truong_031;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_032.Text = data[1].Truong_032;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_033.Text = data[1].Truong_033;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_034.Text = data[1].Truong_034;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_035.Text = data[1].Truong_035;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_036.Text = data[1].Truong_036;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_037.Text = data[1].Truong_037;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_038.Text = data[1].Truong_038;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_039.Text = data[1].Truong_039;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_040.Text = data[1].Truong_040;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_041.Text = data[1].Truong_041;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_044.Text = data[1].Truong_044;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_045.Text = data[1].Truong_045;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_046.Text = data[1].Truong_046;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_048.Text = data[1].Truong_048;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_049.Text = data[1].Truong_049;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_050.Text = data[1].Truong_050;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_051.Text = data[1].Truong_051;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_052.Text = data[1].Truong_052;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_055.Text = data[1].Truong_055;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_056.Text = data[1].Truong_056;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_058.Text = data[1].Truong_058;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_059.Text = data[1].Truong_059;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_060.Text = data[1].Truong_060;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_062.Text = data[1].Truong_062;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_063.Text = data[1].Truong_063;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_064.Text = data[1].Truong_064;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_067.Text = data[1].Truong_067;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_069.Text = data[1].Truong_069;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_072.Text = data[1].Truong_072;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_073.Text = data[1].Truong_073;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_074.Text = data[1].Truong_074;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_075.Text = data[1].Truong_075;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_076.Text = data[1].Truong_076;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_077.Text = data[1].Truong_077;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_078.Text = data[1].Truong_078;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_079.Text = data[1].Truong_079;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_081.Text = data[1].Truong_081;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_082.Text = data[1].Truong_082;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_083.Text = data[1].Truong_083;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_084.Text = data[1].Truong_084;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_086.Text = data[1].Truong_086;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_087.Text = data[1].Truong_087;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_088.Text = data[1].Truong_088;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_089.Text = data[1].Truong_089;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_090.Text = data[1].Truong_090;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_095.Text = data[1].Truong_095;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_097.Text = data[1].Truong_097;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_099.Text = data[1].Truong_099;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_101.Text = data[1].Truong_101;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_103.Text = data[1].Truong_103;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_105.Text = data[1].Truong_105;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_107.Text = data[1].Truong_107;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_109.Text = data[1].Truong_109;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_110.Text = data[1].Truong_110;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_111.Text = data[1].Truong_111;
                        uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.chk_QC.Checked = data[1].CheckQC.Value;
                        SetColorLoai3();
                    }
                }
            }
            if (Global.StrCheck == "CHECKDEJP" && Global.StrCity == "CityO")
            {
                uC_ShowImage_CityO1.tab_CityO_JP_Check.PageVisible = true;
                uC_ShowImage_CityO1.tab_CityO_JP_User1.PageVisible = true;
                uC_ShowImage_CityO1.tab_CityO_JP_User2.PageVisible = true;
                var data = (from w in Global.Db.tbl_DeJP_CityOs where w.BatchID == BatchID && w.IDImage == IdImage orderby w.Phase descending, w.True descending select w).ToList();
                if (data.Count == 3)
                {
                    uC_ShowImage_CityO1.lb_UserCheck.Text = "Check: " + data[0].UserName;
                    uC_ShowImage_CityO1.lb_User1.Text = "User1: " + data[1].UserName;
                    uC_ShowImage_CityO1.lb_User2.Text = "User2: " + data[2].UserName;
                    uC_ShowImage_CityO1.xtraTabControl1.SelectedTabPage.Name = "tab_CityO_JP_Check";
                    uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_016.Text = data[0].Truong_016;
                    uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_094.Text = data[0].Truong_094;
                    uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_096.Text = data[0].Truong_096;
                    uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_098.Text = data[0].Truong_098;
                    uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_100.Text = data[0].Truong_100;
                    uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_102.Text = data[0].Truong_102;
                    uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_104.Text = data[0].Truong_104;
                    uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_106.Text = data[0].Truong_106;
                    uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_108.Text = data[0].Truong_108;

                    uC_ShowImage_CityO1.xtraTabControl2.SelectedTabPage.Name = "tab_CityO_JP_Check";
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_016.Text = data[1].Truong_016;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_094.Text = data[1].Truong_094;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_096.Text = data[1].Truong_096;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_098.Text = data[1].Truong_098;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_100.Text = data[1].Truong_100;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_102.Text = data[1].Truong_102;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_104.Text = data[1].Truong_104;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_106.Text = data[1].Truong_106;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_108.Text = data[1].Truong_108;

                    uC_ShowImage_CityO1.xtraTabControl3.SelectedTabPage.Name = "tab_CityO_JP_Check";
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_016.Text = data[2].Truong_016;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_094.Text = data[2].Truong_094;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_096.Text = data[2].Truong_096;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_098.Text = data[2].Truong_098;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_100.Text = data[2].Truong_100;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_102.Text = data[2].Truong_102;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_104.Text = data[2].Truong_104;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_106.Text = data[2].Truong_106;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_108.Text = data[2].Truong_108;
                }
                if (data.Count == 2)
                {
                    var Usercheck = (from w in Global.Db.tbl_MissCheck_DeJPs where w.BatchID == BatchID & w.IDImage == IdImage select w.UserName).FirstOrDefault();

                    uC_ShowImage_CityO1.lb_UserCheck.Text = "Check: " + Usercheck;
                    uC_ShowImage_CityO1.lb_User1.Text = "User1: " + data[1].UserName;
                    uC_ShowImage_CityO1.lb_User2.Text = "User2: " + data[2].UserName;

                    uC_ShowImage_CityO1.xtraTabControl1.SelectedTabPage.Name = "tab_CityO_JP_Check";
                    uC_ShowImage_CityO1.xtraTabControl2.SelectedTabPage.Name = "tab_CityO_JP_Check";
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_016.Text = uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_016.Text = data[0].Truong_016;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_094.Text = uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_094.Text = data[0].Truong_094;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_096.Text = uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_096.Text = data[0].Truong_096;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_098.Text = uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_098.Text = data[0].Truong_098;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_100.Text = uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_100.Text = data[0].Truong_100;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_102.Text = uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_102.Text = data[0].Truong_102;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_104.Text = uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_104.Text = data[0].Truong_104;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_106.Text = uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_106.Text = data[0].Truong_106;
                    uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_108.Text = uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_108.Text = data[0].Truong_108;

                    uC_ShowImage_CityO1.xtraTabControl3.SelectedTabPage.Name = "tab_CityO_JP_Check";
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_016.Text = data[1].Truong_016;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_094.Text = data[1].Truong_094;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_096.Text = data[1].Truong_096;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_098.Text = data[1].Truong_098;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_100.Text = data[1].Truong_100;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_102.Text = data[1].Truong_102;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_104.Text = data[1].Truong_104;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_106.Text = data[1].Truong_106;
                    uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_108.Text = data[1].Truong_108;
                }
                SetColorLoaiJP();
            }
        }
        public void SetColorLoai1()
        {
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_018, uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_018, uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_018);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_019, uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_019, uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_019);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_021, uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_021, uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_021);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_022, uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_022, uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_022);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_023, uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_023, uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_023);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_024, uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_024, uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_024);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_025, uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_025, uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_025);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_026, uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_026, uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_026);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai11.txt_Truong_027, uC_ShowImage_CityO1.uC_CityO_Loai12.txt_Truong_027, uC_ShowImage_CityO1.uC_CityO_Loai13.txt_Truong_027);
        }
        public void SetColorLoai3()
        {
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_015, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_015, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_015);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_017, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_017, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_017);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_018, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_018, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_018);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_019, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_019, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_019);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_020, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_020, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_020);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_021, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_021, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_021);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_023, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_023, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_023);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_024, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_024, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_024);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_025, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_025, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_025);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_026, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_026, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_026);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_027, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_027, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_027);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_028, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_028, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_028);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_030, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_030, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_030);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_031, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_031, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_031);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_032, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_032, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_032);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_033, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_033, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_033);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_034, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_034, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_034);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_035, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_035, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_035);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_036, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_036, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_036);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_037, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_037, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_037);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_038, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_038, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_038);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_039, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_039, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_039);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_040, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_040, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_040);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_041, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_041, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_041);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_044, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_044, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_044);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_045, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_045, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_045);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_046, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_046, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_046);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_048, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_048, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_048);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_049, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_049, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_049);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_050, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_050, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_050);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_051, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_051, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_051);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_052, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_052, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_052);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_055, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_055, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_055);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_056, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_056, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_056);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_058, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_058, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_058);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_059, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_059, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_059);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_060, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_060, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_060);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_062, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_062, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_062);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_063, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_063, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_063);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_064, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_064, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_064);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_067, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_067, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_067);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_069, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_069, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_069);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_072, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_072, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_072);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_073, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_073, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_073);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_074, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_074, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_074);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_075, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_075, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_075);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_076, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_076, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_076);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_077, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_077, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_077);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_078, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_078, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_078);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_079, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_079, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_079);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_081, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_081, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_081);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_082, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_082, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_082);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_083, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_083, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_083);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_084, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_084, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_084);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_086, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_086, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_086);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_087, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_087, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_087);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_088, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_088, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_088);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_089, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_089, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_089);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_090, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_090, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_090);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_095, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_095, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_095);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_097, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_097, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_097);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_099, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_099, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_099);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_101, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_101, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_101);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_103, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_103, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_103);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_105, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_105, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_105);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_107, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_107, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_107);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_109, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_109, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_109);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_110, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_110, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_110);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo1.txt_Truong_111, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo2.txt_Truong_111, uC_ShowImage_CityO1.uC_CityO_Loai3_DeSo3.txt_Truong_111);
        }
        public void SetColorLoaiJP()
        {
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_016, uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_016, uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_016);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_094, uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_094, uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_094);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_096, uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_096, uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_096);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_098, uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_098, uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_098);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_100, uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_100, uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_100);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_102, uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_102, uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_102);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_104, uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_104, uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_104);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_106, uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_106, uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_106);
            SoSanhDoiMau(uC_ShowImage_CityO1.uC_CityO_JP1.txt_Truong_108, uC_ShowImage_CityO1.uC_CityO_JP2.txt_Truong_108, uC_ShowImage_CityO1.uC_CityO_JP3.txt_Truong_108);
        }
        private void lb_Batch_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_Batch.Text);
            XtraMessageBox.Show("Copy batch name Success!");
        }

        private void lb_Image_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_Image.Text);
            XtraMessageBox.Show("Copy batch name Success!");
        }

        private void splitContainerControl1_SplitterPositionChanged(object sender, EventArgs e)
        {
            MessageBox.Show(splitContainerControl1.SplitterPosition + "");
        }
    }
}
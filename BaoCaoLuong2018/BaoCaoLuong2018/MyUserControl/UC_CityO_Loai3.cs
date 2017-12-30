using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using BaoCaoLuong2018.Properties;
using System.Text.RegularExpressions;

namespace BaoCaoLuong2018.MyUserControl
{
    public partial class UC_CityO_Loai3_DeSo : UserControl
    {
        public event Focus_Text Focus;
        public event AllTextChange Changed;
        public UC_CityO_Loai3_DeSo()
        {
            InitializeComponent();
        }

        private List<Category> category = new List<Category>();
        public class Category
        {
            public string Value_JP { get; set; }
            public string Value_SO { get; set; }
        }
        private void SetDataLookUpEdit()
        {
            category.Clear();
            category.Add(new Category() { Value_JP = "", Value_SO = "" });
            category.Add(new Category() { Value_JP = "住", Value_SO = "01" });
            category.Add(new Category() { Value_JP = "認", Value_SO = "02" });
            category.Add(new Category() { Value_JP = "増", Value_SO = "03" });
            category.Add(new Category() { Value_JP = "震", Value_SO = "04" });
            category.Add(new Category() { Value_JP = "特", Value_SO = "11" });
            category.Add(new Category() { Value_JP = "住（特）", Value_SO = "11" });
            category.Add(new Category() { Value_JP = "認（特）", Value_SO = "12" });
            category.Add(new Category() { Value_JP = "増（特）", Value_SO = "13" });
            category.Add(new Category() { Value_JP = "?", Value_SO = "?" });
        }
        string FormatCurency(string curency)// định dạng 1,234
        {
            string str = curency.ToString();
            string pattern = @"(?<a>\d*)(?<b>\d{3})*";
            Match m = Regex.Match(str, pattern, RegexOptions.RightToLeft);
            StringBuilder sb = new StringBuilder();
            foreach (Capture i in m.Groups["b"].Captures)
            {
                sb.Insert(0, "," + i.Value);
            }
            sb.Insert(0, m.Groups["a"].Value);
            return sb.ToString().Trim(',');
        }
        public void UC_CityO_Loai3_DeSo_Load(object sender, EventArgs e)
        {
            SetDataLookUpEdit();
            txt_Truong_079.Properties.DataSource = category;
            txt_Truong_079.Properties.DisplayMember = "Value_JP";
            txt_Truong_079.Properties.ValueMember = "Value_SO";

            txt_Truong_084.Properties.DataSource = category;
            txt_Truong_084.Properties.DisplayMember = "Value_JP";
            txt_Truong_084.Properties.ValueMember = "Value_SO";
            if (Global.FlagLoad)
                return;
            textEdit1.Tag = "";
            textEdit2.Tag = "";
            textEdit3.Tag = "";
            textEdit4.Tag = "";
            textEdit5.Tag = "";
            txt_Truong_015.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "15" select w.Note).FirstOrDefault();
            txt_Truong_017.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "17" select w.Note).FirstOrDefault();
            txt_Truong_018.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "18" select w.Note).FirstOrDefault();
            txt_Truong_019.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "19" select w.Note).FirstOrDefault();
            txt_Truong_020.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "20" select w.Note).FirstOrDefault();
            txt_Truong_021.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "21" select w.Note).FirstOrDefault();
            txt_Truong_023.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "23" select w.Note).FirstOrDefault();
            txt_Truong_024.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "24" select w.Note).FirstOrDefault();
            txt_Truong_025.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "25" select w.Note).FirstOrDefault();
            txt_Truong_026.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "26" select w.Note).FirstOrDefault();
            txt_Truong_027.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "27" select w.Note).FirstOrDefault();
            txt_Truong_028.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "28" select w.Note).FirstOrDefault();
            txt_Truong_030.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "30" select w.Note).FirstOrDefault();
            txt_Truong_031.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "31" select w.Note).FirstOrDefault();
            txt_Truong_032.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "32" select w.Note).FirstOrDefault();
            txt_Truong_033.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "33" select w.Note).FirstOrDefault();
            txt_Truong_034.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "34" select w.Note).FirstOrDefault();
            txt_Truong_035.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "35" select w.Note).FirstOrDefault();
            txt_Truong_036.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "36" select w.Note).FirstOrDefault();
            txt_Truong_037.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "37" select w.Note).FirstOrDefault();
            txt_Truong_038.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "38" select w.Note).FirstOrDefault();
            txt_Truong_039.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "39" select w.Note).FirstOrDefault();
            txt_Truong_040.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "40" select w.Note).FirstOrDefault();
            txt_Truong_041.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "41" select w.Note).FirstOrDefault();
            txt_Truong_044.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "44" select w.Note).FirstOrDefault();
            txt_Truong_045.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "45" select w.Note).FirstOrDefault();
            txt_Truong_046.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "46" select w.Note).FirstOrDefault();
            txt_Truong_048.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "48" select w.Note).FirstOrDefault();
            txt_Truong_049.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "49" select w.Note).FirstOrDefault();
            txt_Truong_050.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "50" select w.Note).FirstOrDefault();
            txt_Truong_051.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "51" select w.Note).FirstOrDefault();
            txt_Truong_052.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "52" select w.Note).FirstOrDefault();
            txt_Truong_055.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "55" select w.Note).FirstOrDefault();
            txt_Truong_056.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "56" select w.Note).FirstOrDefault();
            txt_Truong_058.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "58" select w.Note).FirstOrDefault();
            txt_Truong_059.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "59" select w.Note).FirstOrDefault();
            txt_Truong_060.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "60" select w.Note).FirstOrDefault();
            txt_Truong_062.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "62" select w.Note).FirstOrDefault();
            txt_Truong_063.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "63" select w.Note).FirstOrDefault();
            txt_Truong_064.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "64" select w.Note).FirstOrDefault();
            txt_Truong_067.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "67" select w.Note).FirstOrDefault();
            txt_Truong_069.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "69" select w.Note).FirstOrDefault();
            txt_Truong_072.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "72" select w.Note).FirstOrDefault();
            txt_Truong_073.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "73" select w.Note).FirstOrDefault();
            txt_Truong_074.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "74" select w.Note).FirstOrDefault();
            txt_Truong_075.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "75" select w.Note).FirstOrDefault();
            txt_Truong_076.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "76" select w.Note).FirstOrDefault();
            txt_Truong_077.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "77" select w.Note).FirstOrDefault();
            txt_Truong_078.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "78" select w.Note).FirstOrDefault();
            txt_Truong_079.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "79" select w.Note).FirstOrDefault();
            txt_Truong_081.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "81" select w.Note).FirstOrDefault();
            txt_Truong_082.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "82" select w.Note).FirstOrDefault();
            txt_Truong_083.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "83" select w.Note).FirstOrDefault();
            txt_Truong_084.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "84" select w.Note).FirstOrDefault();
            txt_Truong_086.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "86" select w.Note).FirstOrDefault();
            txt_Truong_087.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "87" select w.Note).FirstOrDefault();
            txt_Truong_088.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "88" select w.Note).FirstOrDefault();
            txt_Truong_089.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "89" select w.Note).FirstOrDefault();
            txt_Truong_090.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "90" select w.Note).FirstOrDefault();
            txt_Truong_095.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "95" select w.Note).FirstOrDefault();
            txt_Truong_097.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "97" select w.Note).FirstOrDefault();
            txt_Truong_099.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "99" select w.Note).FirstOrDefault();
            txt_Truong_101.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "101" select w.Note).FirstOrDefault();
            txt_Truong_103.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "103" select w.Note).FirstOrDefault();
            txt_Truong_105.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "105" select w.Note).FirstOrDefault();
            txt_Truong_107.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "107" select w.Note).FirstOrDefault();
            txt_Truong_109.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "109" select w.Note).FirstOrDefault();
            txt_Truong_110.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "110" select w.Note).FirstOrDefault();
            txt_Truong_111.Tag = (from w in Global.DataNote where w.City == "CityO" & w.LoaiPhieu == "Loai3" & w.Truong == "111" select w.Note).FirstOrDefault();

            txt_Truong_015.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_017.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_018.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_019.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_020.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_021.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_023.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_024.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_025.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_026.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_027.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_028.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_030.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_031.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_032.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_033.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_034.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_035.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_036.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_037.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_038.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_039.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_040.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_041.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_044.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_045.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_046.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_048.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_049.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_050.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_051.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_052.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_055.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_056.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_058.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_059.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_060.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_062.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_063.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_064.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_067.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_069.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_072.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_073.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_074.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_075.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_076.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_077.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_078.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_079.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_081.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_082.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_083.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_084.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_086.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_087.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_088.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_089.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_090.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_095.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_097.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_099.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_101.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_103.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_105.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_107.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_109.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_110.GotFocus += Txt_Truong_015_GotFocus;
            txt_Truong_111.GotFocus += Txt_Truong_015_GotFocus;
        }

        private void Txt_Truong_015_GotFocus(object sender, EventArgs e)
        {
            Focus(((TextEdit)sender)?.Name, ((TextEdit)sender)?.Tag + "");
            ((TextEdit)sender).SelectAll();
        }
        
        private void txt_Truong_015_TextChanged(object sender, EventArgs e)
        {
            if (((TextEdit)sender).Text.IndexOf('●') >= 0)
                ((TextEdit)sender).Text = "●";
            if (((TextEdit)sender).Text.IndexOf('?') >= 0)
                ((TextEdit)sender).Text = "?";
        }
        public void ResetData()
        {
            txt_Truong_015.Text = "";
            txt_Truong_017.Text = "";
            txt_Truong_018.Text = "";
            txt_Truong_019.Text = "";
            txt_Truong_020.Text = "";
            txt_Truong_021.Text = "";
            txt_Truong_023.Text = "";
            txt_Truong_024.Text = "";
            txt_Truong_025.Text = "";
            txt_Truong_026.Text = "";
            txt_Truong_027.Text = "";
            txt_Truong_028.Text = "";
            txt_Truong_030.Text = "";
            txt_Truong_031.Text = "";
            txt_Truong_032.Text = "";
            txt_Truong_033.Text = "";
            txt_Truong_034.Text = "";
            txt_Truong_035.Text = "";
            txt_Truong_036.Text = "";
            txt_Truong_037.Text = "";
            txt_Truong_038.Text = "";
            txt_Truong_039.Text = "";
            txt_Truong_040.Text = "";
            txt_Truong_041.Text = "";
            txt_Truong_044.Text = "";
            txt_Truong_045.Text = "";
            txt_Truong_046.Text = "";
            txt_Truong_048.Text = "";
            txt_Truong_049.Text = "";
            txt_Truong_050.Text = "";
            txt_Truong_051.Text = "";
            txt_Truong_052.Text = "";
            txt_Truong_055.Text = "";
            txt_Truong_056.Text = "";
            txt_Truong_058.Text = "";
            txt_Truong_059.Text = "";
            txt_Truong_060.Text = "";
            txt_Truong_061_1.Text = "";
            txt_Truong_061_2.Text = "";
            txt_Truong_061_3.Text = "";
            txt_Truong_061_4.Text = "";
            txt_Truong_062.Text = "";
            txt_Truong_063.Text = "";
            txt_Truong_064.Text = "";
            txt_Truong_067.Text = "";
            txt_Truong_069.Text = "";
            txt_Truong_072.Text = "";
            txt_Truong_073.Text = "";
            txt_Truong_074.Text = "";
            txt_Truong_075.Text = "";
            txt_Truong_076.Text = "";
            txt_Truong_077.Text = "";
            txt_Truong_078.Text = "";
            txt_Truong_079.ItemIndex = 0;
            txt_Truong_081.Text = "";
            txt_Truong_082.Text = "";
            txt_Truong_083.Text = "";
            txt_Truong_084.ItemIndex = 0;
            txt_Truong_086.Text = "";
            txt_Truong_087.Text = "";
            txt_Truong_088.Text = "";
            txt_Truong_089.Text = "";
            txt_Truong_090.Text = "";
            txt_Truong_095.Text = "";
            txt_Truong_097.Text = "";
            txt_Truong_099.Text = "";
            txt_Truong_101.Text = "";
            txt_Truong_103.Text = "";
            txt_Truong_105.Text = "";
            txt_Truong_107.Text = "";
            txt_Truong_109.Text = "";
            txt_Truong_110.Text = "";
            txt_Truong_111.Text = "";
            chk_QC.Checked = false;

            txt_Truong_015.ForeColor = Color.Black;
            txt_Truong_017.ForeColor = Color.Black;
            txt_Truong_018.ForeColor = Color.Black;
            txt_Truong_019.ForeColor = Color.Black;
            txt_Truong_020.ForeColor = Color.Black;
            txt_Truong_021.ForeColor = Color.Black;
            txt_Truong_023.ForeColor = Color.Black;
            txt_Truong_024.ForeColor = Color.Black;
            txt_Truong_025.ForeColor = Color.Black;
            txt_Truong_026.ForeColor = Color.Black;
            txt_Truong_027.ForeColor = Color.Black;
            txt_Truong_028.ForeColor = Color.Black;
            txt_Truong_030.ForeColor = Color.Black;
            txt_Truong_031.ForeColor = Color.Black;
            txt_Truong_032.ForeColor = Color.Black;
            txt_Truong_033.ForeColor = Color.Black;
            txt_Truong_034.ForeColor = Color.Black;
            txt_Truong_035.ForeColor = Color.Black;
            txt_Truong_036.ForeColor = Color.Black;
            txt_Truong_037.ForeColor = Color.Black;
            txt_Truong_038.ForeColor = Color.Black;
            txt_Truong_039.ForeColor = Color.Black;
            txt_Truong_040.ForeColor = Color.Black;
            txt_Truong_041.ForeColor = Color.Black;
            txt_Truong_044.ForeColor = Color.Black;
            txt_Truong_045.ForeColor = Color.Black;
            txt_Truong_046.ForeColor = Color.Black;
            txt_Truong_048.ForeColor = Color.Black;
            txt_Truong_049.ForeColor = Color.Black;
            txt_Truong_050.ForeColor = Color.Black;
            txt_Truong_051.ForeColor = Color.Black;
            txt_Truong_052.ForeColor = Color.Black;
            txt_Truong_055.ForeColor = Color.Black;
            txt_Truong_056.ForeColor = Color.Black;
            txt_Truong_058.ForeColor = Color.Black;
            txt_Truong_059.ForeColor = Color.Black;
            txt_Truong_060.ForeColor = Color.Black;
            txt_Truong_061_1.ForeColor = Color.Black;
            txt_Truong_061_2.ForeColor = Color.Black;
            txt_Truong_061_3.ForeColor = Color.Black;
            txt_Truong_061_4.ForeColor = Color.Black;
            txt_Truong_062.ForeColor = Color.Black;
            txt_Truong_063.ForeColor = Color.Black;
            txt_Truong_064.ForeColor = Color.Black;
            txt_Truong_067.ForeColor = Color.Black;
            txt_Truong_069.ForeColor = Color.Black;
            txt_Truong_072.ForeColor = Color.Black;
            txt_Truong_073.ForeColor = Color.Black;
            txt_Truong_074.ForeColor = Color.Black;
            txt_Truong_075.ForeColor = Color.Black;
            txt_Truong_076.ForeColor = Color.Black;
            txt_Truong_077.ForeColor = Color.Black;
            txt_Truong_078.ForeColor = Color.Black;
            txt_Truong_079.ForeColor = Color.Black;
            txt_Truong_081.ForeColor = Color.Black;
            txt_Truong_082.ForeColor = Color.Black;
            txt_Truong_083.ForeColor = Color.Black;
            txt_Truong_084.ForeColor = Color.Black;
            txt_Truong_086.ForeColor = Color.Black;
            txt_Truong_087.ForeColor = Color.Black;
            txt_Truong_088.ForeColor = Color.Black;
            txt_Truong_089.ForeColor = Color.Black;
            txt_Truong_090.ForeColor = Color.Black;
            txt_Truong_095.ForeColor = Color.Black;
            txt_Truong_097.ForeColor = Color.Black;
            txt_Truong_099.ForeColor = Color.Black;
            txt_Truong_101.ForeColor = Color.Black;
            txt_Truong_103.ForeColor = Color.Black;
            txt_Truong_105.ForeColor = Color.Black;
            txt_Truong_107.ForeColor = Color.Black;
            txt_Truong_109.ForeColor = Color.Black;
            txt_Truong_110.ForeColor = Color.Black;
            txt_Truong_111.ForeColor = Color.Black;

            txt_Truong_015.BackColor = Color.White;
            txt_Truong_017.BackColor = Color.White;
            txt_Truong_018.BackColor = Color.White;
            txt_Truong_019.BackColor = Color.White;
            txt_Truong_020.BackColor = Color.White;
            txt_Truong_021.BackColor = Color.White;
            txt_Truong_023.BackColor = Color.White;
            txt_Truong_024.BackColor = Color.White;
            txt_Truong_025.BackColor = Color.White;
            txt_Truong_026.BackColor = Color.White;
            txt_Truong_027.BackColor = Color.White;
            txt_Truong_028.BackColor = Color.White;
            txt_Truong_030.BackColor = Color.White;
            txt_Truong_031.BackColor = Color.White;
            txt_Truong_032.BackColor = Color.White;
            txt_Truong_033.BackColor = Color.White;
            txt_Truong_034.BackColor = Color.White;
            txt_Truong_035.BackColor = Color.White;
            txt_Truong_036.BackColor = Color.White;
            txt_Truong_037.BackColor = Color.White;
            txt_Truong_038.BackColor = Color.White;
            txt_Truong_039.BackColor = Color.White;
            txt_Truong_040.BackColor = Color.White;
            txt_Truong_041.BackColor = Color.White;
            txt_Truong_044.BackColor = Color.White;
            txt_Truong_045.BackColor = Color.White;
            txt_Truong_046.BackColor = Color.White;
            txt_Truong_048.BackColor = Color.White;
            txt_Truong_049.BackColor = Color.White;
            txt_Truong_050.BackColor = Color.White;
            txt_Truong_051.BackColor = Color.White;
            txt_Truong_052.BackColor = Color.White;
            txt_Truong_055.BackColor = Color.White;
            txt_Truong_056.BackColor = Color.White;
            txt_Truong_058.BackColor = Color.White;
            txt_Truong_059.BackColor = Color.White;
            txt_Truong_060.BackColor = Color.White;
            txt_Truong_061_1.BackColor = Color.White;
            txt_Truong_061_2.BackColor = Color.White;
            txt_Truong_061_3.BackColor = Color.White;
            txt_Truong_061_4.BackColor = Color.White;
            txt_Truong_062.BackColor = Color.White;
            txt_Truong_063.BackColor = Color.White;
            txt_Truong_064.BackColor = Color.White;
            txt_Truong_067.BackColor = Color.White;
            txt_Truong_069.BackColor = Color.White;
            txt_Truong_072.BackColor = Color.White;
            txt_Truong_073.BackColor = Color.White;
            txt_Truong_074.BackColor = Color.White;
            txt_Truong_075.BackColor = Color.White;
            txt_Truong_076.BackColor = Color.White;
            txt_Truong_077.BackColor = Color.White;
            txt_Truong_078.BackColor = Color.White;
            txt_Truong_079.BackColor = Color.White;
            txt_Truong_081.BackColor = Color.White;
            txt_Truong_082.BackColor = Color.White;
            txt_Truong_083.BackColor = Color.White;
            txt_Truong_084.BackColor = Color.White;
            txt_Truong_086.BackColor = Color.White;
            txt_Truong_087.BackColor = Color.White;
            txt_Truong_088.BackColor = Color.White;
            txt_Truong_089.BackColor = Color.White;
            txt_Truong_090.BackColor = Color.White;
            txt_Truong_095.BackColor = Color.White;
            txt_Truong_097.BackColor = Color.White;
            txt_Truong_099.BackColor = Color.White;
            txt_Truong_101.BackColor = Color.White;
            txt_Truong_103.BackColor = Color.White;
            txt_Truong_105.BackColor = Color.White;
            txt_Truong_107.BackColor = Color.White;
            txt_Truong_109.BackColor = Color.White;
            txt_Truong_110.BackColor = Color.White;
            txt_Truong_111.BackColor = Color.White;
            //txt_Truong_015.Focus();
        }
        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_015.Text) &&
                string.IsNullOrEmpty(txt_Truong_017.Text) &&
                string.IsNullOrEmpty(txt_Truong_018.Text) &&
                string.IsNullOrEmpty(txt_Truong_019.Text) &&
                string.IsNullOrEmpty(txt_Truong_020.Text) &&
                string.IsNullOrEmpty(txt_Truong_021.Text) &&
                string.IsNullOrEmpty(txt_Truong_023.Text) &&
                string.IsNullOrEmpty(txt_Truong_024.Text) &&
                string.IsNullOrEmpty(txt_Truong_025.Text) &&
                string.IsNullOrEmpty(txt_Truong_026.Text) &&
                string.IsNullOrEmpty(txt_Truong_027.Text) &&
                string.IsNullOrEmpty(txt_Truong_028.Text) &&
                string.IsNullOrEmpty(txt_Truong_030.Text) &&
                string.IsNullOrEmpty(txt_Truong_031.Text) &&
                string.IsNullOrEmpty(txt_Truong_032.Text) &&
                string.IsNullOrEmpty(txt_Truong_033.Text) &&
                string.IsNullOrEmpty(txt_Truong_034.Text) &&
                string.IsNullOrEmpty(txt_Truong_035.Text) &&
                string.IsNullOrEmpty(txt_Truong_036.Text) &&
                string.IsNullOrEmpty(txt_Truong_037.Text) &&
                string.IsNullOrEmpty(txt_Truong_038.Text) &&
                string.IsNullOrEmpty(txt_Truong_039.Text) &&
                string.IsNullOrEmpty(txt_Truong_040.Text) &&
                string.IsNullOrEmpty(txt_Truong_041.Text) &&
                string.IsNullOrEmpty(txt_Truong_044.Text) &&
                string.IsNullOrEmpty(txt_Truong_045.Text) &&
                string.IsNullOrEmpty(txt_Truong_046.Text) &&
                string.IsNullOrEmpty(txt_Truong_048.Text) &&
                string.IsNullOrEmpty(txt_Truong_049.Text) &&
                string.IsNullOrEmpty(txt_Truong_050.Text) &&
                string.IsNullOrEmpty(txt_Truong_051.Text) &&
                string.IsNullOrEmpty(txt_Truong_052.Text) &&
                string.IsNullOrEmpty(txt_Truong_055.Text) &&
                string.IsNullOrEmpty(txt_Truong_056.Text) &&
                string.IsNullOrEmpty(txt_Truong_058.Text) &&
                string.IsNullOrEmpty(txt_Truong_059.Text) &&
                string.IsNullOrEmpty(txt_Truong_060.Text) &&
                string.IsNullOrEmpty(txt_Truong_061_1.Text) &&
                string.IsNullOrEmpty(txt_Truong_061_2.Text) &&
                string.IsNullOrEmpty(txt_Truong_061_3.Text) &&
                string.IsNullOrEmpty(txt_Truong_061_4.Text) &&
                string.IsNullOrEmpty(txt_Truong_062.Text) &&
                string.IsNullOrEmpty(txt_Truong_063.Text) &&
                string.IsNullOrEmpty(txt_Truong_064.Text) &&
                string.IsNullOrEmpty(txt_Truong_067.Text) &&
                string.IsNullOrEmpty(txt_Truong_069.Text) &&
                string.IsNullOrEmpty(txt_Truong_072.Text) &&
                string.IsNullOrEmpty(txt_Truong_073.Text) &&
                string.IsNullOrEmpty(txt_Truong_074.Text) &&
                string.IsNullOrEmpty(txt_Truong_075.Text) &&
                string.IsNullOrEmpty(txt_Truong_076.Text) &&
                string.IsNullOrEmpty(txt_Truong_077.Text) &&
                string.IsNullOrEmpty(txt_Truong_078.Text) &&
                string.IsNullOrEmpty(txt_Truong_079.Text) &&
                string.IsNullOrEmpty(txt_Truong_081.Text) &&
                string.IsNullOrEmpty(txt_Truong_082.Text) &&
                string.IsNullOrEmpty(txt_Truong_083.Text) &&
                string.IsNullOrEmpty(txt_Truong_084.Text) &&
                string.IsNullOrEmpty(txt_Truong_086.Text) &&
                string.IsNullOrEmpty(txt_Truong_087.Text) &&
                string.IsNullOrEmpty(txt_Truong_088.Text) &&
                string.IsNullOrEmpty(txt_Truong_089.Text) &&
                string.IsNullOrEmpty(txt_Truong_090.Text) &&
                string.IsNullOrEmpty(txt_Truong_095.Text) &&
                string.IsNullOrEmpty(txt_Truong_097.Text) &&
                string.IsNullOrEmpty(txt_Truong_099.Text) &&
                string.IsNullOrEmpty(txt_Truong_101.Text) &&
                string.IsNullOrEmpty(txt_Truong_103.Text) &&
                string.IsNullOrEmpty(txt_Truong_105.Text) &&
                string.IsNullOrEmpty(txt_Truong_107.Text) &&
                string.IsNullOrEmpty(txt_Truong_109.Text) &&
                string.IsNullOrEmpty(txt_Truong_110.Text) &&
                string.IsNullOrEmpty(txt_Truong_111.Text) &&
                !chk_QC.Checked)
                return true;
            return false;
        }
        public bool CheckQC()
        {
            if (txt_Truong_015.Text.IndexOf('?') >= 0 || txt_Truong_015.Text.IndexOf('●') >= 0 ||
                txt_Truong_017.Text.IndexOf('?') >= 0 || txt_Truong_017.Text.IndexOf('●') >= 0 ||
                txt_Truong_018.Text.IndexOf('?') >= 0 || txt_Truong_018.Text.IndexOf('●') >= 0 ||
                txt_Truong_019.Text.IndexOf('?') >= 0 || txt_Truong_019.Text.IndexOf('●') >= 0 ||
                txt_Truong_020.Text.IndexOf('?') >= 0 || txt_Truong_020.Text.IndexOf('●') >= 0 ||
                txt_Truong_021.Text.IndexOf('?') >= 0 || txt_Truong_021.Text.IndexOf('●') >= 0 ||
                txt_Truong_023.Text.IndexOf('?') >= 0 || txt_Truong_023.Text.IndexOf('●') >= 0 ||
                txt_Truong_024.Text.IndexOf('?') >= 0 || txt_Truong_024.Text.IndexOf('●') >= 0 ||
                txt_Truong_025.Text.IndexOf('?') >= 0 || txt_Truong_025.Text.IndexOf('●') >= 0 ||
                txt_Truong_026.Text.IndexOf('?') >= 0 || txt_Truong_026.Text.IndexOf('●') >= 0 ||
                txt_Truong_027.Text.IndexOf('?') >= 0 || txt_Truong_027.Text.IndexOf('●') >= 0 ||
                txt_Truong_028.Text.IndexOf('?') >= 0 || txt_Truong_028.Text.IndexOf('●') >= 0 ||
                txt_Truong_030.Text.IndexOf('?') >= 0 || txt_Truong_030.Text.IndexOf('●') >= 0 ||
                txt_Truong_031.Text.IndexOf('?') >= 0 || txt_Truong_031.Text.IndexOf('●') >= 0 ||
                txt_Truong_032.Text.IndexOf('?') >= 0 || txt_Truong_032.Text.IndexOf('●') >= 0 ||
                txt_Truong_033.Text.IndexOf('?') >= 0 || txt_Truong_033.Text.IndexOf('●') >= 0 ||
                txt_Truong_034.Text.IndexOf('?') >= 0 || txt_Truong_034.Text.IndexOf('●') >= 0 ||
                txt_Truong_035.Text.IndexOf('?') >= 0 || txt_Truong_035.Text.IndexOf('●') >= 0 ||
                txt_Truong_036.Text.IndexOf('?') >= 0 || txt_Truong_036.Text.IndexOf('●') >= 0 ||
                txt_Truong_037.Text.IndexOf('?') >= 0 || txt_Truong_037.Text.IndexOf('●') >= 0 ||
                txt_Truong_038.Text.IndexOf('?') >= 0 || txt_Truong_038.Text.IndexOf('●') >= 0 ||
                txt_Truong_039.Text.IndexOf('?') >= 0 || txt_Truong_039.Text.IndexOf('●') >= 0 ||
                txt_Truong_040.Text.IndexOf('?') >= 0 || txt_Truong_040.Text.IndexOf('●') >= 0 ||
                txt_Truong_041.Text.IndexOf('?') >= 0 || txt_Truong_041.Text.IndexOf('●') >= 0 ||
                txt_Truong_044.Text.IndexOf('?') >= 0 || txt_Truong_044.Text.IndexOf('●') >= 0 ||
                txt_Truong_045.Text.IndexOf('?') >= 0 || txt_Truong_045.Text.IndexOf('●') >= 0 ||
                txt_Truong_046.Text.IndexOf('?') >= 0 || txt_Truong_046.Text.IndexOf('●') >= 0 ||
                txt_Truong_048.Text.IndexOf('?') >= 0 || txt_Truong_048.Text.IndexOf('●') >= 0 ||
                txt_Truong_049.Text.IndexOf('?') >= 0 || txt_Truong_049.Text.IndexOf('●') >= 0 ||
                txt_Truong_050.Text.IndexOf('?') >= 0 || txt_Truong_050.Text.IndexOf('●') >= 0 ||
                txt_Truong_051.Text.IndexOf('?') >= 0 || txt_Truong_051.Text.IndexOf('●') >= 0 ||
                txt_Truong_052.Text.IndexOf('?') >= 0 || txt_Truong_052.Text.IndexOf('●') >= 0 ||
                txt_Truong_055.Text.IndexOf('?') >= 0 || txt_Truong_055.Text.IndexOf('●') >= 0 ||
                txt_Truong_056.Text.IndexOf('?') >= 0 || txt_Truong_056.Text.IndexOf('●') >= 0 ||
                txt_Truong_058.Text.IndexOf('?') >= 0 || txt_Truong_058.Text.IndexOf('●') >= 0 ||
                txt_Truong_059.Text.IndexOf('?') >= 0 || txt_Truong_059.Text.IndexOf('●') >= 0 ||
                txt_Truong_060.Text.IndexOf('?') >= 0 || txt_Truong_060.Text.IndexOf('●') >= 0 ||
                txt_Truong_061_1.Text.IndexOf('?') >= 0 || txt_Truong_061_1.Text.IndexOf('●') >= 0 ||
                txt_Truong_061_2.Text.IndexOf('?') >= 0 || txt_Truong_061_2.Text.IndexOf('●') >= 0 ||
                txt_Truong_061_3.Text.IndexOf('?') >= 0 || txt_Truong_061_3.Text.IndexOf('●') >= 0 ||
                txt_Truong_061_4.Text.IndexOf('?') >= 0 || txt_Truong_061_4.Text.IndexOf('●') >= 0 ||
                txt_Truong_062.Text.IndexOf('?') >= 0 || txt_Truong_062.Text.IndexOf('●') >= 0 ||
                txt_Truong_063.Text.IndexOf('?') >= 0 || txt_Truong_063.Text.IndexOf('●') >= 0 ||
                txt_Truong_064.Text.IndexOf('?') >= 0 || txt_Truong_064.Text.IndexOf('●') >= 0 ||
                txt_Truong_067.Text.IndexOf('?') >= 0 || txt_Truong_067.Text.IndexOf('●') >= 0 ||
                txt_Truong_069.Text.IndexOf('?') >= 0 || txt_Truong_069.Text.IndexOf('●') >= 0 ||
                txt_Truong_072.Text.IndexOf('?') >= 0 || txt_Truong_072.Text.IndexOf('●') >= 0 ||
                txt_Truong_073.Text.IndexOf('?') >= 0 || txt_Truong_073.Text.IndexOf('●') >= 0 ||
                txt_Truong_074.Text.IndexOf('?') >= 0 || txt_Truong_074.Text.IndexOf('●') >= 0 ||
                txt_Truong_075.Text.IndexOf('?') >= 0 || txt_Truong_075.Text.IndexOf('●') >= 0 ||
                txt_Truong_076.Text.IndexOf('?') >= 0 || txt_Truong_076.Text.IndexOf('●') >= 0 ||
                txt_Truong_077.Text.IndexOf('?') >= 0 || txt_Truong_077.Text.IndexOf('●') >= 0 ||
                txt_Truong_078.Text.IndexOf('?') >= 0 || txt_Truong_078.Text.IndexOf('●') >= 0 ||
                txt_Truong_079.Text.IndexOf('?') >= 0 || txt_Truong_079.Text.IndexOf('●') >= 0 ||
                txt_Truong_081.Text.IndexOf('?') >= 0 || txt_Truong_081.Text.IndexOf('●') >= 0 ||
                txt_Truong_082.Text.IndexOf('?') >= 0 || txt_Truong_082.Text.IndexOf('●') >= 0 ||
                txt_Truong_083.Text.IndexOf('?') >= 0 || txt_Truong_083.Text.IndexOf('●') >= 0 ||
                txt_Truong_084.Text.IndexOf('?') >= 0 || txt_Truong_084.Text.IndexOf('●') >= 0 ||
                txt_Truong_086.Text.IndexOf('?') >= 0 || txt_Truong_086.Text.IndexOf('●') >= 0 ||
                txt_Truong_087.Text.IndexOf('?') >= 0 || txt_Truong_087.Text.IndexOf('●') >= 0 ||
                txt_Truong_088.Text.IndexOf('?') >= 0 || txt_Truong_088.Text.IndexOf('●') >= 0 ||
                txt_Truong_089.Text.IndexOf('?') >= 0 || txt_Truong_089.Text.IndexOf('●') >= 0 ||
                txt_Truong_090.Text.IndexOf('?') >= 0 || txt_Truong_090.Text.IndexOf('●') >= 0 ||
                txt_Truong_095.Text.IndexOf('?') >= 0 || txt_Truong_095.Text.IndexOf('●') >= 0 ||
                txt_Truong_097.Text.IndexOf('?') >= 0 || txt_Truong_097.Text.IndexOf('●') >= 0 ||
                txt_Truong_099.Text.IndexOf('?') >= 0 || txt_Truong_099.Text.IndexOf('●') >= 0 ||
                txt_Truong_101.Text.IndexOf('?') >= 0 || txt_Truong_101.Text.IndexOf('●') >= 0 ||
                txt_Truong_103.Text.IndexOf('?') >= 0 || txt_Truong_103.Text.IndexOf('●') >= 0 ||
                txt_Truong_105.Text.IndexOf('?') >= 0 || txt_Truong_105.Text.IndexOf('●') >= 0 ||
                txt_Truong_107.Text.IndexOf('?') >= 0 || txt_Truong_107.Text.IndexOf('●') >= 0 ||
                txt_Truong_109.Text.IndexOf('?') >= 0 || txt_Truong_109.Text.IndexOf('●') >= 0 ||
                txt_Truong_110.Text.IndexOf('?') >= 0 || txt_Truong_110.Text.IndexOf('●') >= 0 ||
                txt_Truong_111.Text.IndexOf('?') >= 0 || txt_Truong_111.Text.IndexOf('●') >= 0 ||
                chk_QC.Checked)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CheckSubmit()
        {
            if (!string.IsNullOrEmpty(txt_Truong_033.Text) & string.IsNullOrEmpty(txt_Truong_034.Text))
                return false;
            else if(!string.IsNullOrEmpty(txt_Truong_033.Text) &
                    !string.IsNullOrEmpty(txt_Truong_034.Text) &
                    txt_Truong_033.Text.IndexOf("?") < 0 &
                    txt_Truong_033.Text.IndexOf("●") < 0 &
                    txt_Truong_034.Text.IndexOf("?") < 0 &
                    txt_Truong_034.Text.IndexOf("●") < 0)
            {
                if (Double.Parse(txt_Truong_033.Text) >= Double.Parse(txt_Truong_034.Text))
                    return false;
                else
                    return true;
            }
            else
                return true;
        }
        public void Save_CityO_Loai3(string Batch, string image)
        {
            Global.Db.Insert_DESo_CityO(Batch, image, Global.StrUserName, CheckQC(), "Loai3",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "",
                                        txt_Truong_015.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_015.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_015.Text.IndexOf('*') >= 0 ? txt_Truong_015.Text.Replace("*","") : txt_Truong_015.Text,
                                        "",
                                        txt_Truong_017.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_017.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_017.Text.Replace(",",""),
                                        txt_Truong_018.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_018.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_018.Text.Replace(",", ""),
                                        txt_Truong_019.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_019.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_019.Text.Replace(",", ""),
                                        txt_Truong_020.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_020.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_020.Text.Replace(",", ""),
                                        txt_Truong_021.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_021.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_021.Text,
                                        "",
                                        txt_Truong_023.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_023.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_023.Text,
                                        txt_Truong_024.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_024.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_024.Text.Replace(",", ""),
                                        txt_Truong_025.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_025.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_025.Text,
                                        txt_Truong_026.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_026.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_026.Text,
                                        txt_Truong_027.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_027.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_027.Text,
                                        txt_Truong_028.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_028.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_028.Text,
                                        "",
                                        txt_Truong_030.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_030.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_030.Text,
                                        txt_Truong_031.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_031.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_031.Text,
                                        txt_Truong_032.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_032.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_032.Text,
                                        txt_Truong_033.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_033.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_033.Text.Replace(",", ""),
                                        txt_Truong_034.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_034.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_034.Text.Replace(",", ""),
                                        txt_Truong_035.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_035.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_035.Text.Replace(",", ""),
                                        txt_Truong_036.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_036.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_036.Text.Replace(",", ""),
                                        txt_Truong_037.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_037.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_037.Text.Replace(",", ""),
                                        txt_Truong_038.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_038.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_038.Text.Replace(",", ""),
                                        txt_Truong_039.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_039.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_039.Text.Replace(",", ""),
                                        txt_Truong_040.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_040.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_040.Text.Replace(",", ""),
                                        txt_Truong_041.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_041.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_041.Text,
                                        "",
                                        "",
                                        txt_Truong_044.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_044.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_044.Text,
                                        txt_Truong_045.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_045.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_045.Text,
                                        txt_Truong_046.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_046.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_046.Text,
                                        "",
                                        txt_Truong_048.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_048.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_048.Text,
                                        txt_Truong_049.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_049.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_049.Text,
                                        txt_Truong_050.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_050.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_050.Text,
                                        txt_Truong_051.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_051.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_051.Text,
                                        txt_Truong_052.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_052.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_052.Text,
                                        "",
                                        "",
                                        txt_Truong_055.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_055.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_055.Text,
                                        txt_Truong_056.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_056.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_056.Text,
                                        "",
                                        txt_Truong_058.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_058.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_058.Text,
                                        txt_Truong_059.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_059.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_059.Text,
                                        txt_Truong_060.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_060.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_060.Text,
                                        txt_Truong_061_1.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_061_1.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_061_1.Text,
                                        txt_Truong_061_2.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_061_2.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_061_2.Text,
                                        txt_Truong_061_3.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_061_3.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_061_3.Text,
                                        txt_Truong_061_4.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_061_4.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_061_4.Text,
                                        txt_Truong_062.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_062.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_062.Text,
                                        txt_Truong_063.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_063.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_063.Text,
                                        txt_Truong_064.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_064.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_064.Text,
                                        "",
                                        "",
                                        txt_Truong_067.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_067.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_067.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_069.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_069.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_069.Text,
                                        "",
                                        "",
                                        txt_Truong_072.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_072.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_072.Text,
                                        txt_Truong_073.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_073.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_073.Text,
                                        txt_Truong_074.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_074.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_074.Text,
                                        txt_Truong_075.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_075.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_075.Text,
                                        txt_Truong_076.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_076.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_076.Text,
                                        txt_Truong_077.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_077.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_077.Text,
                                        txt_Truong_078.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_078.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_078.Text.Replace(",", ""),
                                        txt_Truong_079.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_079.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_079.Text,
                                        "",
                                        txt_Truong_081.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_081.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_081.Text,
                                        txt_Truong_082.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_082.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_082.Text,
                                        txt_Truong_083.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_083.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_083.Text,
                                        txt_Truong_084.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_084.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_084.Text,
                                        "",
                                        txt_Truong_086.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_086.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_086.Text.Replace(",", ""),
                                        txt_Truong_087.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_087.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_087.Text.Replace(",", ""),
                                        txt_Truong_088.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_088.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_088.Text.Replace(",", ""),
                                        txt_Truong_089.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_089.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_089.Text.Replace(",", ""),
                                        txt_Truong_090.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_090.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_090.Text,
                                        "",
                                        "",
                                        "",
                                        "",
                                        txt_Truong_095.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_095.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_095.Text,
                                        "",
                                        txt_Truong_097.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_097.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_097.Text,
                                        "",
                                        txt_Truong_099.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_099.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_099.Text,
                                        "",
                                        txt_Truong_101.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_101.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_101.Text,
                                        "",
                                        txt_Truong_103.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_103.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_103.Text,
                                        "",
                                        txt_Truong_105.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_105.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_105.Text,
                                        "",
                                        txt_Truong_107.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_107.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_107.Text,
                                        "",
                                        txt_Truong_109.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_109.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_109.Text,
                                        txt_Truong_110.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_110.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_110.Text,
                                        txt_Truong_111.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_111.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_111.Text,
                                        "");
        }
        public void Edit_Save_CityO_Loai3(string Batch, string image)
        {
            Global.Db.Sua_va_Luu_DeSo(Batch, image, Global.StrUserName, Global.StrCity, "Loai3",
                                        "", "", "", "", "", "", "", "", "", "",
                                        "", "", "", "",
                                        txt_Truong_015.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_015.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_015.Text.IndexOf('*') >= 0 ? txt_Truong_015.Text.Replace("*", "") : txt_Truong_015.Text,
                                        "",
                                        txt_Truong_017.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_017.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_017.Text.Replace(",", ""),
                                        txt_Truong_018.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_018.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_018.Text.Replace(",", ""),
                                        txt_Truong_019.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_019.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_019.Text.Replace(",", ""),
                                        txt_Truong_020.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_020.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_020.Text.Replace(",", ""),
                                        txt_Truong_021.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_021.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_021.Text,
                                        "",
                                        txt_Truong_023.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_023.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_023.Text,
                                        txt_Truong_024.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_024.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_024.Text.Replace(",", ""),
                                        txt_Truong_025.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_025.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_025.Text,
                                        txt_Truong_026.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_026.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_026.Text,
                                        txt_Truong_027.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_027.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_027.Text,
                                        txt_Truong_028.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_028.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_028.Text,
                                        "",
                                        txt_Truong_030.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_030.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_030.Text,
                                        txt_Truong_031.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_031.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_031.Text,
                                        txt_Truong_032.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_032.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_032.Text,
                                        txt_Truong_033.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_033.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_033.Text.Replace(",", ""),
                                        txt_Truong_034.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_034.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_034.Text.Replace(",", ""),
                                        txt_Truong_035.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_035.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_035.Text.Replace(",", ""),
                                        txt_Truong_036.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_036.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_036.Text.Replace(",", ""),
                                        txt_Truong_037.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_037.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_037.Text.Replace(",", ""),
                                        txt_Truong_038.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_038.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_038.Text.Replace(",", ""),
                                        txt_Truong_039.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_039.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_039.Text.Replace(",", ""),
                                        txt_Truong_040.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_040.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_040.Text.Replace(",", ""),
                                        txt_Truong_041.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_041.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_041.Text,
                                        "",
                                        "",
                                        txt_Truong_044.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_044.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_044.Text,
                                        txt_Truong_045.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_045.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_045.Text,
                                        txt_Truong_046.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_046.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_046.Text,
                                        "",
                                        txt_Truong_048.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_048.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_048.Text,
                                        txt_Truong_049.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_049.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_049.Text,
                                        txt_Truong_050.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_050.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_050.Text,
                                        txt_Truong_051.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_051.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_051.Text,
                                        txt_Truong_052.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_052.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_052.Text,
                                        "",
                                        "",
                                        txt_Truong_055.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_055.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_055.Text,
                                        txt_Truong_056.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_056.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_056.Text,
                                        "",
                                        txt_Truong_058.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_058.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_058.Text,
                                        txt_Truong_059.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_059.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_059.Text,
                                        txt_Truong_060.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_060.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_060.Text,
                                        txt_Truong_061_1.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_061_1.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_061_1.Text,
                                        txt_Truong_061_2.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_061_2.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_061_2.Text,
                                        txt_Truong_061_3.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_061_3.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_061_3.Text,
                                        txt_Truong_061_4.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_061_4.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_061_4.Text,
                                        txt_Truong_062.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_062.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_062.Text,
                                        txt_Truong_063.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_063.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_063.Text,
                                        txt_Truong_064.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_064.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_064.Text,
                                        "",
                                        "",
                                        txt_Truong_067.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_067.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_067.Text.Replace(",", ""),
                                        "",
                                        txt_Truong_069.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_069.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_069.Text,
                                        "",
                                        "",
                                        txt_Truong_072.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_072.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_072.Text,
                                        txt_Truong_073.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_073.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_073.Text,
                                        txt_Truong_074.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_074.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_074.Text,
                                        txt_Truong_075.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_075.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_075.Text,
                                        txt_Truong_076.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_076.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_076.Text,
                                        txt_Truong_077.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_077.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_077.Text,
                                        txt_Truong_078.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_078.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_078.Text.Replace(",", ""),
                                        txt_Truong_079.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_079.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_079.Text,
                                        "",
                                        txt_Truong_081.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_081.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_081.Text,
                                        txt_Truong_082.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_082.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_082.Text,
                                        txt_Truong_083.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_083.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_083.Text,
                                        txt_Truong_084.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_084.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_084.Text,
                                        "",
                                        txt_Truong_086.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_086.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_086.Text.Replace(",", ""),
                                        txt_Truong_087.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_087.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_087.Text.Replace(",", ""),
                                        txt_Truong_088.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_088.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_088.Text.Replace(",", ""),
                                        txt_Truong_089.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_089.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_089.Text.Replace(",", ""),
                                        txt_Truong_090.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_090.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_090.Text,
                                        "",
                                        "",
                                        "",
                                        "",
                                        txt_Truong_095.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_095.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_095.Text,
                                        "",
                                        txt_Truong_097.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_097.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_097.Text,
                                        "",
                                        txt_Truong_099.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_099.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_099.Text,
                                        "",
                                        txt_Truong_101.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_101.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_101.Text,
                                        "",
                                        txt_Truong_103.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_103.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_103.Text,
                                        "",
                                        txt_Truong_105.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_105.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_105.Text,
                                        "",
                                        txt_Truong_107.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_107.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_107.Text,
                                        "",
                                        txt_Truong_109.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_109.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_109.Text,
                                        txt_Truong_110.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_110.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_110.Text,
                                        txt_Truong_111.Text.IndexOf('●') >= 0 ? "●" : txt_Truong_111.Text.IndexOf('?') >= 0 ? "?" : txt_Truong_111.Text,
                                        "",
                                        CheckQC());
        }
        private void DoiMau(int soByteBe, int soBytelon, TextEdit textBox)
        {
            if (textBox.Text.IndexOf('?') < 0 && textBox.Text.IndexOf('●') < 0 && !string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Text.Length >= soByteBe && textBox.Text.Length <= soBytelon)
                {
                    textBox.BackColor = Color.White;
                    textBox.ForeColor = Color.Black;
                }
                else
                {
                    textBox.BackColor = Color.Red;
                    textBox.ForeColor = Color.White;
                }
            }
            else
            {
                textBox.BackColor = Color.White;
                textBox.ForeColor = Color.Black;
            }
        }
        private void DoiMauTruongTien(int soByteBe, int soBytelon, TextEdit textBox)
        {
            if (textBox.Text.IndexOf('?') < 0 && textBox.Text.IndexOf('●') < 0 && !string.IsNullOrEmpty(textBox.Text))
            {
                if (textBox.Text.Substring(0, 1) == "-")
                {
                    if (textBox.Text.Length >= soByteBe && textBox.Text.Length <= soBytelon + 1)
                    {
                        textBox.ForeColor = Color.Black;
                        textBox.BackColor = Color.White;
                    }
                    else
                    {
                        textBox.ForeColor = Color.White;
                        textBox.BackColor = Color.Red;
                    }
                }
                else
                {
                    if (textBox.Text.Length >= soByteBe && textBox.Text.Length <= soBytelon)
                    {
                        textBox.BackColor = Color.White;
                        textBox.ForeColor = Color.Black;
                    }
                    else
                    {
                        textBox.BackColor = Color.Red;
                        textBox.ForeColor = Color.White;
                    }
                }
            }
            else
            {
                textBox.BackColor = Color.White;
                textBox.ForeColor = Color.Black;
            }
        }

        private void txt_Truong_015_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong15 = ((TextEdit)sender).Text;
            Settings.Default.LoaiPhieu = "Loai3";
            Settings.Default.Save();
        }

        private void txt_Truong_015_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 30, (TextEdit)sender);
        }

        private void txt_Truong_090_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 12, (TextEdit)sender);
        }

        private void txt_Truong_073_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 15, (TextEdit)sender);
        }

        private void txt_Truong_017_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMauTruongTien(0, 15, (TextEdit)sender);
        }

        private void txt_Truong_021_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 1, (TextEdit)sender);
        }

        private void txt_Truong_025_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 2, (TextEdit)sender);
        }

        private void txt_Truong_110_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 200, (TextEdit)sender);
        }

        private void chk_QC_CheckedChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
        }

        private void txt_Truong_090_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong90 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_073_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong73 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_017_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong17 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_018_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong18 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_019_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong19 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_020_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong20 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_021_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong21 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_023_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong23 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_024_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong24 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_025_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong25 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_026_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong26 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_027_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong27 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_028_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong28 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_041_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong41 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_030_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong30 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_031_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong31 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_032_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong32 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_033_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong33 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_034_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong34 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_035_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong35 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_036_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong36 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_037_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong37 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_067_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong67 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_086_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong86 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_087_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong87 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_088_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong88 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_089_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong89 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_039_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong39 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_077_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong77 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_078_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong78 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_074_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong74 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_075_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong75 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_076_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong76 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_081_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong81 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_082_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong82 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_083_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong83 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_079_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong79 = ((LookUpEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_084_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong84 = ((LookUpEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_038_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong38 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_040_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong40 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_095_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong95 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_097_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong97 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_099_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong99 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_101_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong101 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_103_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong103 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_105_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong105 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_107_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong107 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_109_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong109 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_110_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong110 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_111_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong111 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_069_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong69 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_052_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong52 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_072_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong72 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_044_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong44 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_045_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong45 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_046_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong46 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_048_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong48 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_049_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong49 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_050_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong50 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_051_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong51 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_055_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong55 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_056_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong56 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_058_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong58 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_059_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong59 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_060_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong60 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_061_1_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong61_1 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_061_2_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong61_2 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_061_3_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong61_3 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_061_4_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong61_4 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_062_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong62 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_063_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong63 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_064_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong64 = ((TextEdit)sender).Text;
            Settings.Default.Save();
        }

        private void txt_Truong_017_KeyUp(object sender, KeyEventArgs e)
        {
            TextEdit te = (TextEdit)sender;
            if (te.Text.IndexOf('●') >= 0 || te.Text.IndexOf('?') >= 0)
            {
                te.Text = te.Text.Replace(",", "");
            }
            else if(!string.IsNullOrEmpty(te.Text))
            {
                if(te.Text[0]+""=="-")
                {
                    string str = te.Text.Replace("-","").Replace(",","");
                    int start = te.Text.Length - te.SelectionStart;
                    te.Text = "-"+FormatCurency(str);
                    te.SelectionStart = -start + te.Text.Length;
                }
                else
                {
                    string str = te.Text.Replace(",", "");
                    int start = te.Text.Length - te.SelectionStart;
                    te.Text = FormatCurency(str);
                    te.SelectionStart = -start + te.Text.Length;
                }
            }
        }

        private void txt_Truong_017_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Add)
            {
                ((TextEdit)sender).Text = ((TextEdit)sender).Text + "000";
                ((TextEdit)sender).SelectionStart = ((TextEdit)sender).Text.Length;
            }
        }
    }
}

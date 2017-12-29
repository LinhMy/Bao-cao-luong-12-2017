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

namespace BaoCaoLuong2018.MyUserControl
{
    public partial class UC_CityO_JP : UserControl
    {
        public event AllTextChange Changed;
        public UC_CityO_JP()
        {
            InitializeComponent();
        }
        public bool bSubmit = false;

        private List<string> lChar = new List<string>
                                        {   "ｱ",
                                            "ｲ",
                                            "ｳ",
                                            "ｴ",
                                            "ｵ",
                                            "ｶ",
                                            "ｷ",
                                            "ｸ",
                                            "ｹ",
                                            "ｺ",
                                            "ｻ",
                                            "ｼ",
                                            "ｽ",
                                            "ｾ",
                                            "ｿ",
                                            "ﾀ",
                                            "ﾁ",
                                            "ﾂ",
                                            "ﾃ",
                                            "ﾄ",
                                            "ﾅ",
                                            "ﾆ",
                                            "ﾇ",
                                            "ﾈ",
                                            "ﾉ",
                                            "ﾊ",
                                            "ﾋ",
                                            "ﾌ",
                                            "ﾍ",
                                            "ﾎ",
                                            "ﾏ",
                                            "ﾐ",
                                            "ﾑ",
                                            "ﾒ",
                                            "ﾓ",
                                            "ﾔ",
                                            "ﾕ",
                                            "ﾖ",
                                            "ﾗ",
                                            "ﾘ",
                                            "ﾙ",
                                            "ﾚ",
                                            "ﾛ",
                                            "ﾜ",
                                            "ｦ",
                                            "ﾝ",
                                            "ｶﾞ",
                                            "ｷﾞ",
                                            "ｸﾞ",
                                            "ｹﾞ",
                                            "ｺﾞ",
                                            "ｻﾞ",
                                            "ｼﾞ",
                                            "ｽﾞ",
                                            "ｾﾞ",
                                            "ｿﾞ",
                                            "ﾀﾞ",
                                            "ﾁﾞ",
                                            "ﾂﾞ",
                                            "ﾃﾞ",
                                            "ﾄﾞ",
                                            "ﾊﾞ",
                                            "ﾊﾟ",
                                            "ﾋﾞ",
                                            "ﾋﾟ",
                                            "ﾌﾞ",
                                            "ﾌﾟ",
                                            "ﾍﾞ",
                                            "ﾍﾟ",
                                            "ﾎﾞ",
                                            "ﾎﾟ",
                                            "ｳﾞ",
                                            "A",
                                            "B",
                                            "C",
                                            "D",
                                            "E",
                                            "F",
                                            "G",
                                            "H",
                                            "I",
                                            "J",
                                            "K",
                                            "L",
                                            "M",
                                            "N",
                                            "O",
                                            "P",
                                            "Q",
                                            "R",
                                            "S",
                                            "T",
                                            "U",
                                            "V",
                                            "W",
                                            "X",
                                            "Y",
                                            "Z",
                                            " ",
                                            "‐"};

        private void UC_CityO_JP_Load(object sender, EventArgs e)
        {
            txt_Truong_016.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_094.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_096.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_098.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_100.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_102.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_104.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_106.GotFocus += Txt_Truong_094_GotFocus;
            txt_Truong_108.GotFocus += Txt_Truong_094_GotFocus;
        }

        private void Txt_Truong_094_GotFocus(object sender, EventArgs e)
        {
            ((TextEdit)sender).SelectAll();
        }

        private void txt_Truong_094_TextChanged(object sender, EventArgs e)
        {
            if (((TextEdit)sender).Text.IndexOf('●') >= 0)
                ((TextEdit)sender).Text = "●";
            if (((TextEdit)sender).Text.IndexOf('?') >= 0)
                ((TextEdit)sender).Text = "?";
        }
        public void ResetData()
        {
            txt_Truong_016.Text = "";
            txt_Truong_094.Text = "";
            txt_Truong_096.Text = "";
            txt_Truong_098.Text = "";
            txt_Truong_100.Text = "";
            txt_Truong_102.Text = "";
            txt_Truong_104.Text = "";
            txt_Truong_106.Text = "";
            txt_Truong_108.Text = "";

            txt_Truong_016.ForeColor = Color.Black;
            txt_Truong_094.ForeColor = Color.Black;
            txt_Truong_096.ForeColor = Color.Black;
            txt_Truong_098.ForeColor = Color.Black;
            txt_Truong_100.ForeColor = Color.Black;
            txt_Truong_102.ForeColor = Color.Black;
            txt_Truong_104.ForeColor = Color.Black;
            txt_Truong_106.ForeColor = Color.Black;
            txt_Truong_108.ForeColor = Color.Black;

            txt_Truong_016.BackColor = Color.White;
            txt_Truong_094.BackColor = Color.White;
            txt_Truong_096.BackColor = Color.White;
            txt_Truong_098.BackColor = Color.White;
            txt_Truong_100.BackColor = Color.White;
            txt_Truong_102.BackColor = Color.White;
            txt_Truong_104.BackColor = Color.White;
            txt_Truong_106.BackColor = Color.White;
            txt_Truong_108.BackColor = Color.White;
        }
        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_016.Text) &&
                string.IsNullOrEmpty(txt_Truong_094.Text) &&
                string.IsNullOrEmpty(txt_Truong_096.Text) &&
                string.IsNullOrEmpty(txt_Truong_098.Text) &&
                string.IsNullOrEmpty(txt_Truong_100.Text) &&
                string.IsNullOrEmpty(txt_Truong_102.Text) &&
                string.IsNullOrEmpty(txt_Truong_104.Text) &&
                string.IsNullOrEmpty(txt_Truong_106.Text) &&
                string.IsNullOrEmpty(txt_Truong_108.Text))
                return true;
            return false;
        }
        public bool CheckQC()
        {
            if (txt_Truong_016.Text.IndexOf('?') >= 0 || txt_Truong_016.Text.IndexOf('●') >= 0 ||
                txt_Truong_094.Text.IndexOf('?') >= 0 || txt_Truong_094.Text.IndexOf('●') >= 0 ||
                txt_Truong_096.Text.IndexOf('?') >= 0 || txt_Truong_096.Text.IndexOf('●') >= 0 ||
                txt_Truong_098.Text.IndexOf('?') >= 0 || txt_Truong_098.Text.IndexOf('●') >= 0 ||
                txt_Truong_100.Text.IndexOf('?') >= 0 || txt_Truong_100.Text.IndexOf('●') >= 0 ||
                txt_Truong_102.Text.IndexOf('?') >= 0 || txt_Truong_102.Text.IndexOf('●') >= 0 ||
                txt_Truong_104.Text.IndexOf('?') >= 0 || txt_Truong_104.Text.IndexOf('●') >= 0 ||
                txt_Truong_106.Text.IndexOf('?') >= 0 || txt_Truong_106.Text.IndexOf('●') >= 0 ||
                txt_Truong_108.Text.IndexOf('?') >= 0 || txt_Truong_108.Text.IndexOf('●') >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void doimautrongkhoang(TextEdit txt, int so_nho, int so_lon)
        {
            if (!string.IsNullOrEmpty(txt.Text))
            {
                if (txt.Text.Length >= 2)
                {
                    if (txt.Text.Substring(txt.Text.Length - 2, 2) == "  ")
                    {
                        txt.BackColor = Color.Red;
                        txt.ForeColor = Color.White;
                        bSubmit = true;
                        txt.Properties.MaxLength = txt.Text.Length;
                    }
                    else
                    {
                        string result = lChar.Find(s => s == txt.Text[txt.Text.Length - 1].ToString());
                        if (string.IsNullOrEmpty(result))
                        {
                            txt.BackColor = Color.Red;
                            txt.ForeColor = Color.White;
                            bSubmit = true;
                            txt.Properties.MaxLength = txt.Text.Length;
                        }
                        else
                        {
                            txt.BackColor = Color.White;
                            txt.ForeColor = Color.Black;
                            bSubmit = false;
                            txt.Properties.MaxLength = 0;
                        }
                    }
                }
                else
                {
                    string result = lChar.Find(s => s == txt.Text[txt.Text.Length - 1].ToString());
                    if (string.IsNullOrEmpty(result))
                    {
                        txt.BackColor = Color.Red;
                        txt.ForeColor = Color.White;
                        bSubmit = true;
                        txt.Properties.MaxLength = txt.Text.Length;
                    }
                    else
                    {
                        txt.BackColor = Color.White;
                        txt.ForeColor = Color.Black;
                        bSubmit = false;
                        txt.Properties.MaxLength = 0;
                    }
                }
            }
            else
            {
                txt.BackColor = Color.White;
                txt.ForeColor = Color.Black;
                bSubmit = false;
                txt.Properties.MaxLength = 0;
            }
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

        public void Save_CityO_JP(string Batch, string image)
        {
            Global.Db.Insert_DEJP_CityO(Batch, image, Global.StrUserName, Global.Token, Global.Version,
                     txt_Truong_016.Text,
                     txt_Truong_094.Text,
                     txt_Truong_096.Text,
                     txt_Truong_098.Text,
                     txt_Truong_100.Text,
                     txt_Truong_102.Text,
                     txt_Truong_104.Text,
                     txt_Truong_106.Text,
                     txt_Truong_108.Text);
        }

        public void Edit_Save_CityO_JP(string Batch, string image)
        {
            Global.Db.Sua_Va_Luu_DeJP(Batch, image, Global.StrUserName, Global.StrCity,
                     txt_Truong_016.Text,
                     txt_Truong_094.Text,
                     txt_Truong_096.Text,
                     txt_Truong_098.Text,
                     txt_Truong_100.Text,
                     txt_Truong_102.Text,
                     txt_Truong_104.Text,
                     txt_Truong_106.Text,
                     txt_Truong_108.Text);
        }
        private void txt_Truong_016_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            doimautrongkhoang((TextEdit)sender, 0, 50);
        }

        private void txt_Truong_094_EditValueChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            DoiMau(0, 60, (TextEdit)sender);
        }

        private void txt_Truong_016_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong16 = txt_Truong_016.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_094_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong94 = txt_Truong_094.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_096_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong96 = txt_Truong_096.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_098_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong98 = txt_Truong_098.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_100_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong100 = txt_Truong_100.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_102_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong102 = txt_Truong_102.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_104_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong104 = txt_Truong_104.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_106_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong106 = txt_Truong_106.Text;
            Settings.Default.Save();
        }

        private void txt_Truong_108_Leave(object sender, EventArgs e)
        {
            if (Global.FlagChangeSave == false)
                return;
            Settings.Default.Truong108 = txt_Truong_108.Text;
            Settings.Default.Save();
        }
        
    }
}
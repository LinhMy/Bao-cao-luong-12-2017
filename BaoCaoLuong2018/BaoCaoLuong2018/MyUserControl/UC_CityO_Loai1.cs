using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BaoCaoLuong2018.MyUserControl
{
    public delegate void AllTextChange(object sender, EventArgs e);
    public partial class UC_CityO_Loai1 : UserControl
    {
        public event AllTextChange Changed;
        public UC_CityO_Loai1()
        {
            InitializeComponent();
        }

        private void txt_Truong_018_TextChanged(object sender, EventArgs e)
        {
            Changed?.Invoke(sender, e);
            if (((TextEdit)sender).Text.IndexOf('●') >= 0)
                ((TextEdit)sender).Text = "●";
            if (((TextEdit)sender).Text.IndexOf('?') >= 0)
                ((TextEdit)sender).Text = "?";
        }
        public void ResetData()
        {
            txt_Truong_018.Text = "";
            txt_Truong_019.Text = "";
            txt_Truong_021.Text = "";
            txt_Truong_022.Text = "";
            txt_Truong_023.Text = "";
            txt_Truong_024.Text = "";
            txt_Truong_025.Text = "";
            txt_Truong_026.Text = "";
            txt_Truong_027.Text = "";
            chk_QC.Checked = false;

            txt_Truong_018.ForeColor = Color.Black;
            txt_Truong_019.ForeColor = Color.Black;
            txt_Truong_021.ForeColor = Color.Black;
            txt_Truong_022.ForeColor = Color.Black;
            txt_Truong_023.ForeColor = Color.Black;
            txt_Truong_024.ForeColor = Color.Black;
            txt_Truong_025.ForeColor = Color.Black;
            txt_Truong_026.ForeColor = Color.Black;
            txt_Truong_027.ForeColor = Color.Black;

            txt_Truong_018.BackColor = Color.White;
            txt_Truong_019.BackColor = Color.White;
            txt_Truong_021.BackColor = Color.White;
            txt_Truong_022.BackColor = Color.White;
            txt_Truong_023.BackColor = Color.White;
            txt_Truong_024.BackColor = Color.White;
            txt_Truong_025.BackColor = Color.White;
            txt_Truong_026.BackColor = Color.White;
            txt_Truong_027.BackColor = Color.White;
            txt_Truong_018.Focus();
        }
        public bool IsEmpty()
        {
            if (string.IsNullOrEmpty(txt_Truong_018.Text) &&
                string.IsNullOrEmpty(txt_Truong_019.Text) &&
                string.IsNullOrEmpty(txt_Truong_021.Text) &&
                string.IsNullOrEmpty(txt_Truong_022.Text) &&
                string.IsNullOrEmpty(txt_Truong_023.Text) &&
                string.IsNullOrEmpty(txt_Truong_024.Text) &&
                string.IsNullOrEmpty(txt_Truong_025.Text) &&
                string.IsNullOrEmpty(txt_Truong_026.Text) &&
                string.IsNullOrEmpty(txt_Truong_027.Text))
                return true;
            return false;
        }
        public bool CheckQC()
        {
            if (txt_Truong_018.Text.IndexOf('?') >= 0 || txt_Truong_018.Text.IndexOf('●') >= 0 ||
                txt_Truong_019.Text.IndexOf('?') >= 0 || txt_Truong_019.Text.IndexOf('●') >= 0 ||
                txt_Truong_021.Text.IndexOf('?') >= 0 || txt_Truong_021.Text.IndexOf('●') >= 0 ||
                txt_Truong_022.Text.IndexOf('?') >= 0 || txt_Truong_022.Text.IndexOf('●') >= 0 ||
                txt_Truong_023.Text.IndexOf('?') >= 0 || txt_Truong_023.Text.IndexOf('●') >= 0 ||
                txt_Truong_024.Text.IndexOf('?') >= 0 || txt_Truong_024.Text.IndexOf('●') >= 0 ||
                txt_Truong_025.Text.IndexOf('?') >= 0 || txt_Truong_025.Text.IndexOf('●') >= 0 ||
                txt_Truong_026.Text.IndexOf('?') >= 0 || txt_Truong_026.Text.IndexOf('●') >= 0 ||
                txt_Truong_027.Text.IndexOf('?') >= 0 || txt_Truong_027.Text.IndexOf('●') >= 0 ||
                chk_QC.Checked)
            {
                return true;
            }
            else
            {
                return false;
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
        private void txt_Truong_018_EditValueChanged(object sender, EventArgs e)
        {
            DoiMau(0, 12, (TextEdit)sender);
        }

        private void txt_Truong_019_EditValueChanged(object sender, EventArgs e)
        {
            DoiMau(0, 8, (TextEdit)sender);
        }

        private void txt_Truong_021_EditValueChanged(object sender, EventArgs e)
        {
            DoiMau(0, 8, (TextEdit)sender);
        }

        private void txt_Truong_022_EditValueChanged(object sender, EventArgs e)
        {
            DoiMau(0, 8, (TextEdit)sender);
        }

        private void txt_Truong_023_EditValueChanged(object sender, EventArgs e)
        {
            DoiMau(0, 8, (TextEdit)sender);
        }

        private void txt_Truong_024_EditValueChanged(object sender, EventArgs e)
        {
            DoiMau(0, 8, (TextEdit)sender);
        }

        private void txt_Truong_025_EditValueChanged(object sender, EventArgs e)
        {
            DoiMau(0, 13, (TextEdit)sender);
        }

        private void txt_Truong_026_EditValueChanged(object sender, EventArgs e)
        {
            DoiMau(0, 8, (TextEdit)sender);
        }

        private void txt_Truong_027_EditValueChanged(object sender, EventArgs e)
        {
            DoiMau(0, 8, (TextEdit)sender);
        }
    }
}

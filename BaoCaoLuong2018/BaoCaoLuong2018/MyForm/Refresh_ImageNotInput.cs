using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BaoCaoLuong2018.MyForm
{
    public partial class Refresh_ImageNotInput : DevExpress.XtraEditors.XtraForm
    {
        int minute = 0;
        public Refresh_ImageNotInput()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //int minute = 0;
            if (string.IsNullOrEmpty(txt_MinuteSo.Text))
                minute = 10;
            else
                minute = int.Parse(txt_MinuteSo.Text);
            gridControl1.DataSource = Global.Db.GetImageNotSubmitDeSo(minute);
            gridControl2.DataSource = Global.Db.GetImageNotSubmitDeJP(int.Parse(txt_MinuteJP.Text));
        }

        private void Refresh_ImageNotInput_Load(object sender, EventArgs e)
        {
            txt_MinuteSo.Text = "10";
            txt_MinuteJP.Text = "10";
            gridControl1.DataSource = Global.Db.GetImageNotSubmitDeSo(int.Parse(txt_MinuteSo.Text));
            gridControl2.DataSource = Global.Db.GetImageNotSubmitDeJP(int.Parse(txt_MinuteJP.Text));
        }    

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        //private void txt_Minute_TextChanged(object sender, EventArgs e)
        //{
        //   // int minute = 0;
        //    if (string.IsNullOrEmpty(txt_MinuteSo.Text))
        //        minute = 10;
        //    else
        //        minute = int.Parse(txt_MinuteSo.Text);
        //    gridControl1.DataSource = Global.Db.GetImageNotSubmitDeSo(minute);
        //    gridControl2.DataSource = Global.Db.GetImageNotSubmitDeJP(int.Parse(txt_MinuteJP.Text));
        //}

        private void Refresh_ImageNotInput_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
        }

        private void btn_Refresh_Click_1(object sender, EventArgs e)
        {
            foreach (var rowHandle in gridView1.GetSelectedRows())
            {
                string BatchID = gridView1.GetRowCellValue(rowHandle, "BatchID").ToString();
                string ImageName = gridView1.GetRowCellValue(rowHandle, "IdImage").ToString();
                string UserName = gridView1.GetRowCellValue(rowHandle, "UserName").ToString();
                Global.Db.RefreshImageNotInputDeSo(BatchID, ImageName, UserName);
            }
           // int minute = 0;
            if (string.IsNullOrEmpty(txt_MinuteSo.Text))
                minute = 10;
            else
                minute = int.Parse(txt_MinuteSo.Text);
            gridControl1.DataSource = Global.Db.GetImageNotSubmitDeSo(minute);

        }

        private void btn_Refresh_All_Click_1(object sender, EventArgs e)
        {
            foreach (var rowHandle in gridView1.GetSelectedRows())
            {
                string BatchID = gridView1.GetRowCellValue(rowHandle, "BatchID").ToString();
                string ImageName = gridView1.GetRowCellValue(rowHandle, "IdImage").ToString();
                string UserName = gridView1.GetRowCellValue(rowHandle, "UserName").ToString();
                Global.Db.RefreshImageNotInputDeSo(BatchID, ImageName, UserName);
            }
            //int minute = 0;
            if (string.IsNullOrEmpty(txt_MinuteSo.Text))
                minute = 10;
            else
                minute = int.Parse(txt_MinuteSo.Text);
            gridControl1.DataSource = Global.Db.GetImageNotSubmitDeSo(minute);

        }

        private void bt_CapNhat_Click(object sender, EventArgs e)
        {
            foreach (var rowHandle in gridView2.GetSelectedRows())
            {
                string BatchID = gridView2.GetRowCellValue(rowHandle, "BatchID").ToString();
                string ImageName = gridView2.GetRowCellValue(rowHandle, "IdImage").ToString();
                string UserName = gridView2.GetRowCellValue(rowHandle, "UserName").ToString();
                Global.Db.RefreshImageNotInputDeJP(BatchID, ImageName, UserName);
            }
           // int minute = 0;
            if (string.IsNullOrEmpty(txt_MinuteJP.Text))
                minute = 10;
            else
                minute = int.Parse(txt_MinuteJP.Text);
            gridControl2.DataSource = Global.Db.GetImageNotSubmitDeJP(minute);
        }

        private void bt_AllCapNhat_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < gridView2.RowCount; i++)
            {
                string BatchID = gridView2.GetRowCellValue(i, "BatchID").ToString();
                string ImageName = gridView2.GetRowCellValue(i, "IdImage").ToString();
                string UserName = gridView2.GetRowCellValue(i, "UserName").ToString();
                Global.Db.RefreshImageNotInputDeJP(BatchID, ImageName, UserName);
            }
            
            if (string.IsNullOrEmpty(txt_MinuteJP.Text))
                minute = 10;
            else
                minute = int.Parse(txt_MinuteJP.Text);
            gridControl2.DataSource = Global.Db.GetImageNotSubmitDeJP(minute);
        }

        private void txt_MinuteJP_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MinuteJP.Text))
                minute = 10;
            else
                minute = int.Parse(txt_MinuteJP.Text);
            gridControl2.DataSource = Global.Db.GetImageNotSubmitDeJP(minute);
        }

        private void txt_MinuteSo_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_MinuteSo.Text))
                minute = 10;
            else
                minute = int.Parse(txt_MinuteSo.Text);
            gridControl1.DataSource = Global.Db.GetImageNotSubmitDeSo(minute);
        }
    }
}
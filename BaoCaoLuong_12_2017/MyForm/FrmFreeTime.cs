using System;
using System.Windows.Forms;

namespace BaoCaoLuong_12_2017.MyForm
{
    public partial class FrmFreeTime : DevExpress.XtraEditors.XtraForm
    {
        private int _gio, _phut, _giay;

        public FrmFreeTime()
        {
            InitializeComponent();
        }

        private void frm_FreeTime_Load(object sender, EventArgs e)
        {
            _giay = Global.FreeTime;
            _gio = _giay / 3600;
            _phut = (_giay - (_gio * 3600)) / 60;
            _giay = _giay - (_gio * 3600 + _phut * 60);

            lb_time.Text = _gio.ToString("D2") + @":" + _phut.ToString("D2") + @":" + _giay.ToString("D2");

            timer1.Start();
        }

        private void frm_FreeTime_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }

        private void frm_FreeTime_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Global.FreeTime++;
            _giay = Global.FreeTime;
            _gio = _giay / 3600;
            _phut = (_giay - (_gio * 3600)) / 60;
            _giay = _giay - (_gio * 3600 + _phut * 60);

            lb_time.Text = _gio.ToString("D2") + @":" + _phut.ToString("D2") + @":" + _giay.ToString("D2");
        }
    }
}
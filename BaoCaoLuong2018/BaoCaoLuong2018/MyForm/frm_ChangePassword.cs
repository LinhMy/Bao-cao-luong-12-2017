using System;
using System.Data;
using System.Linq;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_ChangePassword : DevExpress.XtraEditors.XtraForm
    {
        public frm_ChangePassword()
        {
            InitializeComponent();
        }
        
        private void btn_ChangePass_Click(object sender, EventArgs e)
        {
            var passcu = (from w in Global.DbBpo.tbl_Users where w.Username == Global.StrUserName select w.Password).FirstOrDefault();
            if (string.IsNullOrEmpty(txt_PassCu.Text))
            {
                lb_ThongBao.Text = "Bạn vui lòng nhập password cũ";
            }
            else
            {
                if (txt_PassCu.Text != passcu)
                {
                    lb_ThongBao.Text = "Bạn nhập sai password cũ!";
                }
                else
                {
                    if (string.IsNullOrEmpty(txt_PassMoi.Text))
                    {
                        lb_ThongBao.Text = "Bạn không được để trống password mới!";
                    }
                    else
                    {
                        if (txt_PassMoi.Text != txt_PassNhapLai.Text)
                        {
                            lb_ThongBao.Text = "Bạn nhập 2 lần password mới không giống nhau!";
                        }
                        else
                        {
                            if (Global.DbBpo.UpdatePassword(Global.StrUserName, txt_PassCu.Text, txt_PassMoi.Text) == 0)
                            {
                                lb_ThongBao.Text = "Bạn đã đổi password thành công!";
                            }
                            txt_PassCu.Text = "";
                            txt_PassMoi.Text = "";
                            txt_PassNhapLai.Text = "";
                        }
                    }
                }
            }
        }

        private void frm_ChangePassword_Load(object sender, EventArgs e)
        {
            lb_ThongBao.Text = "";
        }
    }
}
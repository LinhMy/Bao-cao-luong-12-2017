using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using BaoCaoLuong_12_2017.MyClass;
using BaoCaoLuong_12_2017.Properties;

namespace BaoCaoLuong_12_2017.MyForm
{
    public partial class frmLogin : XtraForm
    {
        ClsLogin DAL = new ClsLogin();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lb_version.Text = Global.Version;
            UserLookAndFeel.Default.SkinName = Settings.Default.ApplicationSkinName;
            txt_password.Properties.UseSystemPasswordChar = true;
            txt_machine.ReadOnly = true;
            txt_userwindow.ReadOnly = true;
            txt_ipaddress.ReadOnly = true;
            txt_role.ReadOnly = true;
            txt_machine.Text = Environment.MachineName;
            txt_userwindow.Text = Environment.UserDomainName + @"\" + Environment.UserName;
            try
            {
                txt_ipaddress.Text = Global.GetServerIpAddress().ToString();
            }
            catch (Exception)
            {

                txt_ipaddress.Text = "127.0.0.1";
            }
            lb_ngay.Text = DateTime.Now.ToShortDateString();
            lb_gio.Text = DateTime.Now.ToShortTimeString();
            cbb_City.SelectedIndex = 0;
            if (Settings.Default.Check)
            {
                txt_username.Text = Settings.Default.username;
                txt_password.Text = Settings.Default.password;
                chb_luu.Checked = true;
            }
            try
            {
                GetInfo();
              //  txt_username_TextChanged(sender, e);
            }
            catch (Exception i) { MessageBox.Show(i.Message + ""); }
        }

        bool GetInfo()
        {
            try
            {
                if (Global.DbBpo.KiemTraLogin(txt_username.Text, txt_password.Text) == 1)
                {
                    string role = "";
                    role = (from w in (Global.DbBpo.GetRoLeCheckLogin(txt_username.Text, ref role)) select w.Column1).FirstOrDefault();
                    txt_role.Text = role;
                }
                else
                {
                    txt_role.Text = "User & Password không đúng!";
                    return false;
                }
            }
            catch (Exception)
            {
                txt_role.Text = "User không tồn tại trong hệ thống!";
                return false;
            }
            return true;
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            var query = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            if (lb_version.Text == query)
            {
                if (GetInfo())
                {
                    if (Global.CheckOutSource(txt_role.Text) == true)
                    {
                        MessageBox.Show("Hiện tại dự án chưa có nhu cầu về nguồn nhân lực bên ngoài");
                        return;
                    }
                    if (string.IsNullOrEmpty(cbb_batchname.Text))
                    {
                        if (MessageBox.Show("Không có batch nào được chọn. Bạn vẫn muốn đăng nhập?", "Thông báo!", MessageBoxButtons.YesNo) == DialogResult.No)
                        {
                            return;
                        }
                    }
                    if (chb_luu.Checked)
                    {
                        Settings.Default.username = txt_username.Text;
                        Settings.Default.password = txt_password.Text;
                        Settings.Default.Check = true;
                        Settings.Default.Save();
                    }
                    else
                    {
                        Settings.Default.username = "";
                        Settings.Default.password = "";
                        Settings.Default.Check = false;
                        Settings.Default.Save();
                    }
                    Global.Token = Global.GetToken(txt_username.Text);
                    Global.StrBatch = cbb_batchname.Text;
                    Global.StrCity = cbb_City.Text;
                    Global.StrUserName = txt_username.Text;
                    Global.StrPcName = txt_machine.Text;
                    Global.StrDomainName = txt_userwindow.Text;
                    Global.StrRole = txt_role.Text;
                    Global.Version = lb_version.Text;
                    bool has = Global.DbBpo.tbl_TokenLogins.Any(w => w.UserName == txt_username.Text && w.IDProject == Global.StrIdProject);
                    if (has)
                    {
                        var token = (from w in Global.DbBpo.tbl_TokenLogins where w.UserName == txt_username.Text && w.IDProject == Global.StrIdProject select w.Token).FirstOrDefault();
                        if (token == "")
                        {
                            Global.DbBpo.updateToken(txt_username.Text, Global.StrIdProject, Global.Token);
                            Global.DbBpo.InsertLoginTime_new(txt_username.Text, DateTime.Now, txt_userwindow.Text, txt_machine.Text, txt_ipaddress.Text, Global.Token, Global.StrIdProject);
                        }
                        else
                        {
                            if (MessageBox.Show(@"User đang đăng nhập vào máy khác. Bạn có muốn tiếp tục đăng nhập?", @"Notification", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                            {
                                Global.DbBpo.updateToken(txt_username.Text, Global.StrIdProject, Global.Token);
                                Global.DbBpo.InsertLoginTime_new(txt_username.Text, DateTime.Now, txt_userwindow.Text, txt_machine.Text, txt_ipaddress.Text, Global.Token, Global.StrIdProject);
                            }
                            else
                            {
                                return;
                            }
                        }
                    }
                    else
                    {
                        var token = new tbl_TokenLogin();
                        token.UserName = txt_username.Text;
                        token.IDProject = Global.StrIdProject;
                        token.Token = "";
                        token.DateLogin = DateTime.Now; Global.DbBpo.tbl_TokenLogins.InsertOnSubmit(token);
                        Global.DbBpo.SubmitChanges();
                        Global.DbBpo.updateToken(txt_username.Text, Global.StrIdProject, Global.Token);
                        Global.DbBpo.InsertLoginTime_new(txt_username.Text, DateTime.Now, txt_userwindow.Text, txt_machine.Text, txt_ipaddress.Text, Global.Token, Global.StrIdProject);
                    }
                    DialogResult = DialogResult.OK;
                }
            }
            else
            {
                MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Global.RunUpdateVersion();
                Application.Exit();
            }
        } 

        private void btn_thoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        
        private void txt_username_TextChanged(object sender, EventArgs e)
        {
            cbb_batchname.DataSource = null;
            GetInfo();
            cbb_City_SelectedIndexChanged(null,null);

            //var ktUser = (from w in Global.DbBpo.tbl_Users where w.Username == txt_username.Text select w.NotGoodUser).FirstOrDefault();
            //if (txt_role.Text == "DESO")
            //{
            //    if (ktUser == false)
            //    {
            //        cbb_batchname.DataSource = Global.Db.GetBatNotFinishDeSo_Good(txt_username.Text);
            //        cbb_batchname.DisplayMember = "fbatchname";
            //        cbb_batchname.ValueMember = "fbatchname";
            //    }
            //    else if (ktUser == true)
            //    {
            //        cbb_batchname.DataSource = Global.Db.GetBatNotFinishDeSo_NotGood(txt_username.Text);
            //        cbb_batchname.DisplayMember = "fbatchname";
            //        cbb_batchname.ValueMember = "fbatchname";
            //    }
            //}
            //else if (txt_role.Text == "CHECKERDESO")
            //{
            //    cbb_batchname.DataSource = (from w in Global.Db.GetBatNotFinishCheckerDeSo(txt_username.Text) select w.fBatchName).ToList();
            //    cbb_batchname.DisplayMember = "fBatchName";
            //    cbb_batchname.ValueMember = "fBatchName";
            //}
            //else if (txt_role.Text == "ADMIN")
            //{
            //    cbb_batchname.DataSource = Global.Db.GetBatch();
            //    cbb_batchname.DisplayMember = "fBatchName";
            //    cbb_batchname.ValueMember = "fBatchName";
            //}
        }

        private void txt_password_EditValueChanged(object sender, EventArgs e)
        {
            cbb_batchname.DataSource = null;
            GetInfo();
            cbb_City_SelectedIndexChanged(null, null);
            //cbb_batchname.DataSource = null;
            //GetInfo();
            //var ktUser = (from w in Global.DbBpo.tbl_Users where w.Username == txt_username.Text select w.NotGoodUser).FirstOrDefault();

            //if (txt_role.Text == "DESO")
            //{
            //    //DAL.Combobox_NotFinish_MissImageDESO(cbb_batchname, txt_username.Text);
            //    //if (cbb_batchname.Items.Count < 1)
            //    //{
            //    //    DAL.Combobox_NotFinishDESO(cbb_batchname, txt_username.Text);
            //    //}
            //    if (ktUser == false)
            //    {
            //        cbb_batchname.DataSource = Global.Db.GetBatNotFinishDeSo_Good(txt_username.Text);
            //        cbb_batchname.DisplayMember = "fbatchname";
            //        cbb_batchname.ValueMember = "fbatchname";
            //    }
            //    else if (ktUser == true)
            //    {
            //        cbb_batchname.DataSource = Global.Db.GetBatNotFinishDeSo_NotGood(txt_username.Text);
            //        cbb_batchname.DisplayMember = "fbatchname";
            //        cbb_batchname.ValueMember = "fbatchname";
            //    }
            //}
            //else if (txt_role.Text == "CHECKERDESO")
            //{
            //    cbb_batchname.DataSource =  Global.Db.GetBatNotFinishCheckerDeSo(txt_username.Text)/* select w.fbatchname).ToList()*/;
            //    cbb_batchname.DisplayMember = "fbatchname";
            //    cbb_batchname.ValueMember = "fbatchname";
            //}
            //else if (txt_role.Text == "ADMIN")
            //{
            //    cbb_batchname.DataSource = Global.Db.GetBatch();
            //    cbb_batchname.DisplayMember = "fBatchName";
            //    cbb_batchname.ValueMember = "fBatchName";
            //}
        }

        private void cbb_batchname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 3)
            {
                e.Handled = true;
            }
        }

        private void cbb_City_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbb_batchname.DataSource = null;
            GetInfo();
            var ktUser = (from w in Global.DbBpo.tbl_Users where w.Username == txt_username.Text select w.NotGoodUser).FirstOrDefault();

            if (txt_role.Text == "DESO")
            {
                if (ktUser == false)
                {
                    cbb_batchname.DataSource = Global.Db.GetBatNotFinishDeSo_Good(txt_username.Text, cbb_City.Text);
                    cbb_batchname.DisplayMember = "fbatchname";
                    cbb_batchname.ValueMember = "fbatchname";
                }
                else if (ktUser == true)
                {
                    cbb_batchname.DataSource = Global.Db.GetBatNotFinishDeSo_NotGood(txt_username.Text,cbb_City.Text);
                    cbb_batchname.DisplayMember = "BatchID";
                    cbb_batchname.ValueMember = "BatchID";
                }
            }
            else if (txt_role.Text=="DEJP")
            {
                if (ktUser == false)
                {
                    cbb_batchname.DataSource = Global.Db.GetBatNotFinishDeJP_Good(txt_username.Text, cbb_City.Text);
                    cbb_batchname.DisplayMember = "BatchID";
                    cbb_batchname.ValueMember = "BatchID";
                }
                else if (ktUser == true)
                {
                    cbb_batchname.DataSource = Global.Db.GetBatNotFinishDeJP_NotGood(txt_username.Text,cbb_City.Text);
                    cbb_batchname.DisplayMember = "BatchID";
                    cbb_batchname.ValueMember = "BatchID";
                }
            }
            else if (txt_role.Text == "CHECKERDESO")
            {
                cbb_batchname.DataSource = (from w in Global.Db.GetBatNotFinishCheckerDeSo(txt_username.Text, cbb_City.Text) select w.BatchID).ToList();
                cbb_batchname.DisplayMember = "BatchID";
                cbb_batchname.ValueMember = "BatchID";
            }
            else if (txt_role.Text == "CHECKERDEJP")
            {
                cbb_batchname.DataSource = (from w in Global.Db.GetBatNotFinishCheckerDeJP(txt_username.Text, cbb_City.Text) select w.BatchID).ToList();
                cbb_batchname.DisplayMember = "BatchID";
                cbb_batchname.ValueMember = "BatchID";
            }
            else if (txt_role.Text == "ADMIN")
            {
                cbb_batchname.DataSource = Global.Db.GetBatch(cbb_City.Text);
                cbb_batchname.DisplayMember = "BatchID";
                cbb_batchname.ValueMember = "BatchID";
            }
        }
    }
}
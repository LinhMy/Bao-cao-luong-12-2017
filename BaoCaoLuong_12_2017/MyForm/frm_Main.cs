using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using System.Diagnostics;
using BaoCaoLuong_12_2017.Properties;

namespace BaoCaoLuong_12_2017.MyForm
{
    public partial class frm_Main : DevExpress.XtraEditors.XtraForm
    {
        public frm_Main()
        {
            InitializeComponent();
        }

        int ChiaUser = -1;
        int LevelUser = -1;
        private string Folder = "";
        private void btn_Logout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void btn_Exit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void btn_QuanLyBatch_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           new frm_ManagerBatch().ShowDialog();
        }

        private void frm_Main_Load(object sender, EventArgs e)
        {
            try
            {
                ChiaUser = -1;
                LevelUser = -1;
                Global.FlagChangeSave = false;
                UserLookAndFeel.Default.SkinName = Settings.Default.ApplicationSkinName;
                xtraTabControl1.TabPages.Remove(tp_DeSo);
                //splitMain.SplitterPosition = Settings.Default.PositionSplitMain;
                lb_IdImage.Text = "";

                menu_QuanLy.Enabled = false;
                btn_Check.Enabled = false;
                btn_Submit.Enabled = false;
                btn_Submit_Logout.Enabled = false;
                Folder = "";

                lb_fBatchName.Text = Global.StrBatch;
                lb_UserName.Text = Global.StrUserName;
                var checkDisableUser = (from w in Global.DbBpo.tbl_Users where w.Username == Global.StrUserName select w.IsDelete).FirstOrDefault();
               // Global.listdata13.Clear();
             //   Global.listdata13 = (from w in Global.Db.tbl_Database_Truong13s select w.id3).ToList();
               // Folder = (from w in Global.Db.GetFolder(lb_fBatchName.Text) select w.fPathPicture).FirstOrDefault();
                //if (checkDisableUser)
                //{
                //    MessageBox.Show("Tài khoản này đã vô hiệu hóa. Vui lòng liên hệ với Admin");
                //    DialogResult = DialogResult.Yes;
                //}
                //if (Global.StrRole == "DESO")
                //{
                //    Global.FlagChangeSave = true;
                //  //  var ktBatch = (from w in Global.Db.CheckBatchChiaUser(Global.StrBatch) select w.ChiaUser).FirstOrDefault();
                //  ////  if (ktBatch == true)
                //  //  {
                //  //      ChiaUser = 1;
                //  //  }
                //    else
                //    {
                //        ChiaUser = 0;
                //    }
                //    var ktUser = (from w in Global.DbBpo.CheckLevelUser(Global.StrUserName) select w.NotGoodUser).FirstOrDefault();
                //    if (ktUser == true)
                //        LevelUser = 0;
                //    else if (ktUser == false)
                //        LevelUser = 1;
                //    //lb_TongPhieu.Text = (from w in Global.Db.tbl_Batches where w.fBatchName == Global.StrBatch select w.SoLuongHinh).FirstOrDefault();

                //    setValue();
                //    xtraTabControl1.TabPages.Add(tp_DeSo);
                //    menu_QuanLy.Enabled = false;
                //    btn_Check.Enabled = false;
                //    btn_Submit.Enabled = true;
                //}
                //else if (Global.StrRole == "ADMIN")
                //{
                //    menu_QuanLy.Enabled = true;
                //    btn_Check.Enabled = true;
                //    btn_Submit.Enabled = false;
                //    btn_Submit_Logout.Enabled = false;
                //    FlagLoad = true;
                //    bool? OutSource = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.OutSource).FirstOrDefault();
                //    if (OutSource == true)
                //        ckOutSource.EditValue = true;
                //    else
                //        ckOutSource.EditValue = false;
                //    FlagLoad = false;
                //}
                //else if (Global.StrRole == "CHECKERDESO")
                //{
                //    menu_QuanLy.Enabled = false;
                //    btn_Check.Enabled = true;
                //    btn_Submit.Enabled = false;
                //    btn_Submit_Logout.Enabled = false;
                //}
            }
            catch
            {
                MessageBox.Show("Kết nối internet của bạn bị gián đoạn, Vui lòng kiểm tra lại!");
                DialogResult = DialogResult.Yes;
            }
        }

        private void setValue()
        {
            //if (Global.StrRole == "DESO")
            //{
            //    lb_SoPhieuCon.Text = (from w in Global.Db.tbl_Images where w.ReadImageDeSoNhap < 2 && w.fBatchName == Global.StrBatch && (w.UserNameDeSoNhap != Global.StrUserName || w.UserNameDeSoNhap == null || w.UserNameDeSoNhap == "") select w.IdImage).Count().ToString();
            //    lb_SoPhieuNhap.Text = (from w in Global.Db.tbl_MissImage_DeSos where w.UserName == Global.StrUserName && w.fBatchName == Global.StrBatch select w.IdImage).Count().ToString();
            //}
        }

        private string[] strTrans = null;
        private string getFilename = "";

        private string GetImage()
        {
            //lb_IdImage.Text = "";
            //strTrans = null;
            //getFilename = "";
            //if (Global.StrRole=="DESO")
            //{
            //    if (ChiaUser==1)  //Batch có chia User nhập
            //    {
            //        if (LevelUser==1) //User Level Good
            //        {
            //           // getFilename = (from w in Global.Db.tbl_MissImage_DeSos where w.fBatchName == lb_fBatchName.Text && w.UserName == lb_UserName.Text && w.Submit == 0 select w.IdImage).FirstOrDefault();
            //            if (string.IsNullOrEmpty(getFilename))
            //            {
            //                try
            //                {
            //                  ///  getFilename = (from w in Global.Db.GetImage_Group_Good(lb_fBatchName.Text, lb_UserName.Text) select w.Column1).FirstOrDefault();
            //                    if (string.IsNullOrEmpty(getFilename))
            //                    {
            //                        return "NULL";
            //                    }
            //                    lb_IdImage.Text = getFilename;
            //                    strTrans = getFilename.Split('.');
            //                    uC_DESO1.txt_TruongSo01.Text = strTrans[0];
            //                    uc_PictureBox1.imageBox1.Image = null;
            //                    if (uc_PictureBox1.LoadImage(Global.Webservice + Folder + @"\" + lb_fBatchName.Text + "/" + getFilename, getFilename, Settings.Default.ZoomImage) == "Error")
            //                    {
            //                        uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
            //                        return "Error";
            //                    }
            //                    //Settings.Default.Truong3 = "";
            //                    //Settings.Default.Truong4 = "";
            //                    //Settings.Default.Truong5 = "";
            //                    //Settings.Default.Truong6 = "";
            //                    //Settings.Default.Truong7 = "";
            //                    //Settings.Default.Truong8_1 = "";
            //                    //Settings.Default.Truong8_2 = "";
            //                    //Settings.Default.Truong9 = "";
            //                    //Settings.Default.Truong10 = "";
            //                    //Settings.Default.Truong11 = "";
            //                    //Settings.Default.Truong12 = "";
            //                    //Settings.Default.Truong13 = "";
            //                    //Settings.Default.Truong14 = "";
            //                    ////Settings.Default.FlagError = "";
            //                    //Settings.Default.fBatchName = Global.StrBatch;
            //                    //Settings.Default.IdImage = lb_IdImage.Text;
            //                    //Settings.Default.UserInput = Global.StrUserName;
            //                    Settings.Default.Save();
            //                }
            //                catch (Exception)
            //                {
            //                    return "NULL";
            //                }
            //            }
            //            else
            //            {
            //                lb_IdImage.Text = getFilename;
            //                strTrans = getFilename.Split('.');
            //                uC_DESO1.txt_TruongSo01.Text = strTrans[0];
            //                uc_PictureBox1.imageBox1.Image = null;
            //                if (uc_PictureBox1.LoadImage(Global.Webservice + Folder + @"\" + lb_fBatchName.Text + "/" + getFilename, getFilename, Settings.Default.ZoomImage) == "Error")
            //                {
            //                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
            //                    return "Error";
            //                }
            //                //if (Settings.Default.fBatchName == Global.StrBatch & Settings.Default.IdImage == lb_IdImage.Text & Settings.Default.UserInput.ToUpper() == Global.StrUserName.ToUpper())
            //                //{
            //                //    uC_DESO1.txt_TruongSo03.Text = Settings.Default.Truong3;
            //                //    uC_DESO1.txt_TruongSo04.Text = Settings.Default.Truong4;
            //                //    uC_DESO1.txt_TruongSo05.Text = Settings.Default.Truong5;
            //                //    uC_DESO1.txt_TruongSo06.Text = Settings.Default.Truong6;
            //                //    uC_DESO1.txt_TruongSo07.Text = Settings.Default.Truong7;
            //                //    uC_DESO1.txt_TruongSo08_1.Text = Settings.Default.Truong8_1;
            //                //    uC_DESO1.txt_TruongSo08_2.Text = Settings.Default.Truong8_2;
            //                //    uC_DESO1.txt_TruongSo09.Text = Settings.Default.Truong9;
            //                //    uC_DESO1.txt_TruongSo10.Text = Settings.Default.Truong10;
            //                //    uC_DESO1.txt_TruongSo11.Text = Settings.Default.Truong11;
            //                //    uC_DESO1.txt_TruongSo12.Text = Settings.Default.Truong12;
            //                //    uC_DESO1.txt_TruongSo13.Text = Settings.Default.Truong13;
            //                //    uC_DESO1.txt_TruongSo14.Text = Settings.Default.Truong14;
            //                //    uC_DESO1.txt_TruongSo13_Leave(null, null);
            //                //    //uC_DESO1.txt_FlagError.Text = Settings.Default.FlagError;
            //                //}
            //                //else
            //                //{
            //                //    Settings.Default.fBatchName = Global.StrBatch;
            //                //    Settings.Default.IdImage = lb_IdImage.Text;
            //                //    Settings.Default.UserInput = Global.StrUserName;
            //                //    Settings.Default.Truong3 = "";
            //                //    Settings.Default.Truong4 = "";
            //                //    Settings.Default.Truong5 = "";
            //                //    Settings.Default.Truong6 = "";
            //                //    Settings.Default.Truong7 = "";
            //                //    Settings.Default.Truong8_1 = "";
            //                //    Settings.Default.Truong8_2 = "";
            //                //    Settings.Default.Truong9 = "";
            //                //    Settings.Default.Truong10 = "";
            //                //    Settings.Default.Truong11 = "";
            //                //    Settings.Default.Truong12 = "";
            //                //    Settings.Default.Truong13 = "";
            //                //    Settings.Default.Truong14 = "";
            //                //   // Settings.Default.FlagError = "";
            //                //    Settings.Default.Save();
            //                //}
            //            }
            //        }
            //        else if (LevelUser == 0) //User Level Not Good
            //        {
            //            //getFilename = (from w in Global.Db.tbl_MissImage_DeSos where w.fBatchName == lb_fBatchName.Text && w.UserName == lb_UserName.Text && w.Submit == 0 select w.IdImage).FirstOrDefault();
            //            //if (string.IsNullOrEmpty(getFilename))
            //            //{
            //            //    try
            //            //    {
            //            //        var getFilename = (from w in Global.Db.GetImage_Group_Notgood(lb_fBatchName.Text, lb_UserName.Text) select w.Column1).FirstOrDefault();
            //            //        if (string.IsNullOrEmpty(getFilename))
            //            //        {
            //            //            return "NULL";
            //            //        }
            //            //        lb_IdImage.Text = getFilename;
            //            //        strTrans = getFilename.Split('.');
            //            //        uC_DESO1.txt_TruongSo01.Text = strTrans[0];
            //            //        uc_PictureBox1.imageBox1.Image = null;
            //            //        if (uc_PictureBox1.LoadImage(Global.Webservice + Folder + @"\" + lb_fBatchName.Text + "/" + getFilename, getFilename, Settings.Default.ZoomImage) == "Error")
            //            //        {
            //            //            uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
            //            //            return "Error";
            //            //        }
            //            //        Settings.Default.Truong3 = "";
            //            //        Settings.Default.Truong4 = "";
            //            //        Settings.Default.Truong5 = "";
            //            //        Settings.Default.Truong6 = "";
            //            //        Settings.Default.Truong7 = "";
            //            //        Settings.Default.Truong8_1 = "";
            //            //        Settings.Default.Truong8_2 = "";
            //            //        Settings.Default.Truong9 = "";
            //            //        Settings.Default.Truong10 = "";
            //            //        Settings.Default.Truong11 = "";
            //            //        Settings.Default.Truong12 = "";
            //            //        Settings.Default.Truong13 = "";
            //            //        Settings.Default.Truong14 = "";
            //            //       // Settings.Default.FlagError = "";
            //            //        Settings.Default.fBatchName = Global.StrBatch;
            //            //        Settings.Default.IdImage = lb_IdImage.Text;
            //            //        Settings.Default.UserInput = Global.StrUserName;
            //                    Settings.Default.Save();
            //                }
            //                catch (Exception)
            //                {
            //                    return "NULL";
            //                }
            //            }
            //            else
            //            {
            //                //lb_IdImage.Text = getFilename;
            //                //strTrans = getFilename.Split('.');
            //                uC_DESO1.txt_TruongSo01.Text = strTrans[0];
            //                uc_PictureBox1.imageBox1.Image = null;
            //                if (uc_PictureBox1.LoadImage(Global.Webservice + Folder + @"\" + lb_fBatchName.Text + "/" + getFilename, getFilename, Settings.Default.ZoomImage) == "Error")
            //                {
            //                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
            //                    return "Error";
            //                }
            //                //if (Settings.Default.fBatchName == Global.StrBatch & Settings.Default.IdImage == lb_IdImage.Text & Settings.Default.UserInput.ToUpper() == Global.StrUserName.ToUpper())
            //                //{
            //                //    uC_DESO1.txt_TruongSo03.Text = Settings.Default.Truong3;
            //                //    uC_DESO1.txt_TruongSo04.Text = Settings.Default.Truong4;
            //                //    uC_DESO1.txt_TruongSo05.Text = Settings.Default.Truong5;
            //                //    uC_DESO1.txt_TruongSo06.Text = Settings.Default.Truong6;
            //                //    uC_DESO1.txt_TruongSo07.Text = Settings.Default.Truong7;
            //                //    uC_DESO1.txt_TruongSo08_1.Text = Settings.Default.Truong8_1;
            //                //    uC_DESO1.txt_TruongSo08_2.Text = Settings.Default.Truong8_2;
            //                //    uC_DESO1.txt_TruongSo09.Text = Settings.Default.Truong9;
            //                //    uC_DESO1.txt_TruongSo10.Text = Settings.Default.Truong10;
            //                //    uC_DESO1.txt_TruongSo11.Text = Settings.Default.Truong11;
            //                //    uC_DESO1.txt_TruongSo12.Text = Settings.Default.Truong12;
            //                //    uC_DESO1.txt_TruongSo13.Text = Settings.Default.Truong13;
            //                //    uC_DESO1.txt_TruongSo14.Text = Settings.Default.Truong14;
            //                //    uC_DESO1.txt_TruongSo13_Leave(null, null);
            //                //    // uC_DESO1.txt_FlagError.Text = Settings.Default.FlagError;
            //                //}
            //                //else
            //                //{
            //                //    Settings.Default.fBatchName = Global.StrBatch;
            //                //    Settings.Default.IdImage = lb_IdImage.Text;
            //                //    Settings.Default.UserInput = Global.StrUserName;
            //                //    Settings.Default.Truong3 = "";
            //                //    Settings.Default.Truong4 = "";
            //                //    Settings.Default.Truong5 = "";
            //                //    Settings.Default.Truong6 = "";
            //                //    Settings.Default.Truong7 = "";
            //                //    Settings.Default.Truong8_1 = "";
            //                //    Settings.Default.Truong8_2 = "";
            //                //    Settings.Default.Truong9 = "";
            //                //    Settings.Default.Truong10 = "";
            //                //    Settings.Default.Truong11 = "";
            //                //    Settings.Default.Truong12 = "";
            //                //    Settings.Default.Truong13 = "";
            //                //    Settings.Default.Truong14 = "";
            //                //    //Settings.Default.FlagError = "";
            //                //    Settings.Default.Save();
            //                //}
            //            }
            //        }
            //    }
            //    else if (ChiaUser == 0)  //Batch không chia user
            //    {
            //       getFilename = (from w in Global.Db.tbl_MissImage_DeSos where w.fBatchName == lb_fBatchName.Text && w.UserName == lb_UserName.Text && w.Submit == 0 select w.IdImage).FirstOrDefault();
            //        if (string.IsNullOrEmpty(getFilename))
            //        {
            //            try
            //            {
            //                var getFilename = (from w in Global.Db.LayHinhMoi_DeSo(lb_fBatchName.Text, lb_UserName.Text) select w.Column1).FirstOrDefault();
            //                if (string.IsNullOrEmpty(getFilename))
            //                {
            //                    return "NULL";
            //                }
            //                lb_IdImage.Text = getFilename;
            //                strTrans = getFilename.Split('.');
            //                uC_DESO1.txt_TruongSo01.Text = strTrans[0];
            //                uc_PictureBox1.imageBox1.Image = null;
            //                if (uc_PictureBox1.LoadImage(Global.Webservice + Folder + @"\" + lb_fBatchName.Text + "/" + getFilename, getFilename, Settings.Default.ZoomImage) == "Error")
            //                {
            //                    uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
            //                    return "Error";
            //                }
            //                Settings.Default.Truong3 = "";
            //                Settings.Default.Truong4 = "";
            //                Settings.Default.Truong5 = "";
            //                Settings.Default.Truong6 = "";
            //                Settings.Default.Truong7 = "";
            //                Settings.Default.Truong8_1 = "";
            //                Settings.Default.Truong8_2 = "";
            //                Settings.Default.Truong9 = "";
            //                Settings.Default.Truong10 = "";
            //                Settings.Default.Truong11 = "";
            //                Settings.Default.Truong12 = "";
            //                Settings.Default.Truong13 = "";
            //                Settings.Default.Truong14 = "";
            //               // Settings.Default.FlagError = "";
            //                Settings.Default.fBatchName = Global.StrBatch;
            //                Settings.Default.IdImage = lb_IdImage.Text;
            //                Settings.Default.UserInput = Global.StrUserName;
            //                Settings.Default.Save();
            //            }
            //            catch (Exception)
            //            {
            //                return "NULL";
            //            }
            //        }
            //        else
            //        {
            //            lb_IdImage.Text = getFilename;
            //            strTrans = getFilename.Split('.');
            //            uC_DESO1.txt_TruongSo01.Text = strTrans[0];
            //            uc_PictureBox1.imageBox1.Image = null;
            //            if (uc_PictureBox1.LoadImage(Global.Webservice + Folder + @"\" + lb_fBatchName.Text + "/" + getFilename, getFilename, Settings.Default.ZoomImage) == "Error")
            //            {
            //                uc_PictureBox1.imageBox1.Image = Resources.svn_deleted;
            //                return "Error";
            //            }
            //            if (Settings.Default.fBatchName == Global.StrBatch & Settings.Default.IdImage == lb_IdImage.Text & Settings.Default.UserInput.ToUpper() == Global.StrUserName.ToUpper())
            //            {
            //                uC_DESO1.txt_TruongSo03.Text = Settings.Default.Truong3;
            //                uC_DESO1.txt_TruongSo04.Text = Settings.Default.Truong4;
            //                uC_DESO1.txt_TruongSo05.Text = Settings.Default.Truong5;
            //                uC_DESO1.txt_TruongSo06.Text = Settings.Default.Truong6;
            //                uC_DESO1.txt_TruongSo07.Text = Settings.Default.Truong7;
            //                uC_DESO1.txt_TruongSo08_1.Text = Settings.Default.Truong8_1;
            //                uC_DESO1.txt_TruongSo08_2.Text = Settings.Default.Truong8_2;
            //                uC_DESO1.txt_TruongSo09.Text = Settings.Default.Truong9;
            //                uC_DESO1.txt_TruongSo10.Text = Settings.Default.Truong10;
            //                uC_DESO1.txt_TruongSo11.Text = Settings.Default.Truong11;
            //                uC_DESO1.txt_TruongSo12.Text = Settings.Default.Truong12;
            //                uC_DESO1.txt_TruongSo13.Text = Settings.Default.Truong13;
            //                uC_DESO1.txt_TruongSo14.Text = Settings.Default.Truong14;
            //                uC_DESO1.txt_TruongSo13_Leave(null, null);
            //                // uC_DESO1.txt_FlagError.Text = Settings.Default.FlagError;
            //            }
            //            else
            //            {
            //                Settings.Default.fBatchName = Global.StrBatch;
            //                Settings.Default.IdImage = lb_IdImage.Text;
            //                Settings.Default.UserInput = Global.StrUserName;
            //                Settings.Default.Truong3 = "";
            //                Settings.Default.Truong4 = "";
            //                Settings.Default.Truong5 = "";
            //                Settings.Default.Truong6 = "";
            //                Settings.Default.Truong7 = "";
            //                Settings.Default.Truong8_1 = "";
            //                Settings.Default.Truong8_2 = "";
            //                Settings.Default.Truong9 = "";
            //                Settings.Default.Truong10 = "";
            //                Settings.Default.Truong11 = "";
            //                Settings.Default.Truong12 = "";
            //                Settings.Default.Truong13 = "";
            //                Settings.Default.Truong14 = "";
            //               // Settings.Default.FlagError = "";
            //                Settings.Default.Save();
            //            }
            //        }
            //    }
            //    uC_DESO1.txt_TruongSo03.Focus();
            //}
            return "ok";
        }

        private string token = "", version = "", Image_temp="";
        string flagTruong13 = "", flagTruong09 = "", truong11 = "";
        private void btn_Submit_Click(object sender, EventArgs e)
        {
            //token = "";
            //version = "";
            //Image_temp = "";
            //truong11 = "";
            //Global.DbBpo.UpdateTimeLastRequest(Global.Token);
            ////Kiểm tra token
            //token = (from w in Global.DbBpo.tbl_TokenLogins where w.UserName == Global.StrUserName && w.IDProject == Global.StrIdProject select w.Token).FirstOrDefault();
            //if (token != Global.Token)
            //{
            //    MessageBox.Show(@"User logged on to another PC, please login again!");
            //    DialogResult = DialogResult.Yes;
            //}
            //version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            //if (version != Global.Version)
            //{
            //    MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Global.RunUpdateVersion();
            //    Application.Exit();
            //}
            //if (btn_Submit.Text == "Start")
            //{
            //    if (string.IsNullOrEmpty(Global.StrBatch))
            //    {
            //        MessageBox.Show("Vui lòng đăng nhập lại và chọn Batch!");
            //        return;
            //    }
            //    Image_temp = GetImage();

            //    if (Image_temp == "NULL")
            //    {
            //        MessageBox.Show(@"Hoàn thành batch '" + lb_fBatchName.Text + "'");
            //        Global.StrBatch = "";
            //        Folder = "";
            //        if (LevelUser==0)
            //        {
            //           var listResult = Global.Db.GetBatNotFinishDeSo_NotGood(Global.StrUserName).ToList();
            //            if (listResult.Count > 0)
            //            {
            //                if (MessageBox.Show(@"Batch tiếp theo: " + listResult[0].fbatchname + "\nBạn muốn làm tiếp ??", "Thông báo!", MessageBoxButtons.YesNo,MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //                {
            //                    if (Global.CheckOutSource(Global.StrRole) == true)
            //                    {
            //                        MessageBox.Show("Hiện tại dự án chưa có nhu cầu về nguồn nhân lực bên ngoài");
            //                        btn_Logout_ItemClick(null, null);
            //                    }
            //                    Global.StrBatch = listResult[0].fbatchname;
            //                    Folder = (from w in Global.Db.GetFolder(listResult[0].fbatchname) select w.fPathPicture).FirstOrDefault();

            //                    var ktBatch = (from w in Global.Db.CheckBatchChiaUser(listResult[0].fbatchname) select w.ChiaUser).FirstOrDefault();
            //                    if (ktBatch == true)
            //                    {
            //                        ChiaUser = 1;
            //                    }
            //                    else
            //                    {
            //                        ChiaUser = 0;
            //                    }
            //                    lb_fBatchName.Text = Global.StrBatch;
            //                    lb_IdImage.Text = "";
            //                    lb_TongPhieu.Text = (from w in Global.Db.tbl_Images where w.fBatchName == Global.StrBatch select w.IdImage).Count().ToString();
            //                    setValue();
            //                    btn_Submit.Text = @"Start";
            //                    btn_Submit_Click(null, null);
            //                }
            //                else
            //                {
            //                    btn_Logout_ItemClick(null, null);
            //                }
            //            }
            //            else
            //            {
            //                btn_Logout_ItemClick(null, null);
            //            }
            //        }
            //        else
            //        {
            //            var listResult = Global.Db.GetBatNotFinishDeSo_Good(Global.StrUserName).ToList();
            //            if (listResult.Count > 0)
            //            {
            //                if (MessageBox.Show(@"Batch tiếp theo: " + listResult[0].fbatchname + "\nBạn muốn làm tiếp ??", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //                {
            //                    if (Global.CheckOutSource(Global.StrRole) == true)
            //                    {
            //                        MessageBox.Show("Hiện tại dự án chưa có nhu cầu về nguồn nhân lực bên ngoài");
            //                        btn_Logout_ItemClick(null, null);
            //                    }
            //                    Global.StrBatch = listResult[0].fbatchname;
            //                    Folder = (from w in Global.Db.GetFolder(listResult[0].fbatchname) select w.fPathPicture).FirstOrDefault();
            //                    var ktBatch = (from w in Global.Db.CheckBatchChiaUser(listResult[0].fbatchname) select w.ChiaUser).FirstOrDefault();
            //                    if (ktBatch == true)
            //                    {
            //                        ChiaUser = 1;
            //                    }
            //                    else
            //                    {
            //                        ChiaUser = 0;
            //                    }
            //                    lb_fBatchName.Text = Global.StrBatch;
            //                    lb_TongPhieu.Text = (from w in Global.Db.tbl_Images where w.fBatchName == Global.StrBatch select w.IdImage).Count().ToString();
            //                    setValue();
            //                    btn_Submit.Text = @"Start";
            //                    btn_Submit_Click(null, null);
            //                }
            //                else
            //                {
            //                    btn_Logout_ItemClick(null, null);
            //                }
            //            }
            //            else
            //            {
            //                btn_Logout_ItemClick(null, null);
            //            }
            //        }
            //    }
            //    else if (Image_temp == "Error")
            //    {
            //        MessageBox.Show("Không thể load hình!");
            //        btn_Logout_ItemClick(null, null);
            //    }
            //    btn_Submit.Text = "Submit";
            //    btn_Submit_Logout.Enabled = true;
            //}
            //else
            //{
            //    if (Global.StrRole == "DESO")
            //    {
            //        if (uC_DESO1.IsEmpty())
            //        {
            //            if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.No)
            //                return;
            //        }
            //        uC_DESO1.txt_TruongSo13_Leave(null, null);
            //        if (uC_DESO1.txt_TruongSo13.BackColor == System.Drawing.Color.SkyBlue)
            //        {
            //            flagTruong13 = "1";
            //        }
            //        else { flagTruong13 = "0"; }
            //        if(uC_DESO1.checkTruong09(uC_DESO1.txt_TruongSo09.Text)==true) { flagTruong09 = "1"; }
            //        else if(uC_DESO1.checkTruong09(uC_DESO1.txt_TruongSo09.Text) == false) { flagTruong09 = "0"; }
            //        //---
            //        if (uC_DESO1.txt_TruongSo11.Text.IndexOf('●') >= 0)
            //            truong11 = "●";
            //        else if (uC_DESO1.txt_TruongSo11.Text.IndexOf('?') >= 0)
            //            truong11 = "?";
            //        else
            //            truong11 = uC_DESO1.txt_TruongSo11.Text;
            //        //---
            //        Global.Db.Insert_DeSo_0911(lb_IdImage.Text, lb_fBatchName.Text, Global.StrUserName,
            //           uC_DESO1.txt_TruongSo01.Text,
            //           uC_DESO1.txt_TruongSo03.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo03.Text,
            //           uC_DESO1.txt_TruongSo04.Text.Replace(",",""),
            //           uC_DESO1.txt_TruongSo05.Text,
            //           uC_DESO1.txt_TruongSo06.Text,
            //           uC_DESO1.txt_TruongSo07.Text,
            //           uC_DESO1.txt_TruongSo08_1.Text,
            //           uC_DESO1.txt_TruongSo08_2.Text,
            //           uC_DESO1.txt_TruongSo09.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo09.Text,
            //           uC_DESO1.txt_TruongSo10.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo10.Text,
            //           truong11,
            //           uC_DESO1.txt_TruongSo12.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo12.Text,
            //           uC_DESO1.txt_TruongSo13.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo13.Text,
            //           flagTruong13,
            //           uC_DESO1.txt_TruongSo14.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo14.Text,
            //           flagTruong09                       
            //          // uC_DESO1.txt_FlagError.Text
            //          );
            //        uC_DESO1.ResetData();
            //        setValue();
            //    }
            //    Image_temp = GetImage();
            //    if (Image_temp == "NULL")
            //    {
            //        MessageBox.Show(@"Hoàn thành batch '" + lb_fBatchName.Text + "'");
            //        Global.StrBatch = "";
            //        Folder = "";
            //        if (LevelUser == 0)
            //        {
            //            var listResult = Global.Db.GetBatNotFinishDeSo_NotGood(Global.StrUserName).ToList();
            //            if (listResult.Count > 0)
            //            {
            //                if (MessageBox.Show(@"Batch tiếp theo: " + listResult[0].fbatchname + "\nBạn muốn làm tiếp ??", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //                {
            //                    if (Global.CheckOutSource(Global.StrRole) == true)
            //                    {
            //                        MessageBox.Show("Hiện tại dự án chưa có nhu cầu về nguồn nhân lực bên ngoài");
            //                        btn_Logout_ItemClick(null, null);
            //                    }
            //                    Global.StrBatch = listResult[0].fbatchname;
            //                    Folder = (from w in Global.Db.GetFolder(listResult[0].fbatchname) select w.fPathPicture).FirstOrDefault();
            //                    var ktBatch = (from w in Global.Db.CheckBatchChiaUser(listResult[0].fbatchname) select w.ChiaUser).FirstOrDefault();
            //                    if (ktBatch == true)
            //                    {
            //                        ChiaUser = 1;
            //                    }
            //                    else
            //                    {
            //                        ChiaUser = 0;
            //                    }
            //                    lb_fBatchName.Text = Global.StrBatch;
            //                    lb_IdImage.Text = "";
            //                    lb_TongPhieu.Text =(from w in Global.Db.tbl_Images where w.fBatchName == Global.StrBatch select w.IdImage).Count().ToString();
            //                    setValue();
            //                    btn_Submit.Text = @"Start";
            //                    btn_Submit_Click(null, null);
            //                }
            //                else
            //                {
            //                    btn_Logout_ItemClick(null, null);
            //                }
            //            }
            //            else
            //            {
            //                btn_Logout_ItemClick(null, null);
            //            }
            //        }
            //        else
            //        {
            //            var listResult = Global.Db.GetBatNotFinishDeSo_Good(Global.StrUserName).ToList();
            //            if (listResult.Count > 0)
            //            {
            //                if (MessageBox.Show(@"Batch tiếp theo: " + listResult[0].fbatchname + "\nBạn muốn làm tiếp ??", "Thông báo!", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            //                {
            //                    if (Global.CheckOutSource(Global.StrRole) == true)
            //                    {
            //                        MessageBox.Show("Hiện tại dự án chưa có nhu cầu về nguồn nhân lực bên ngoài");
            //                        btn_Logout_ItemClick(null, null);
            //                    }
            //                    Global.StrBatch = listResult[0].fbatchname;
            //                    Folder = (from w in Global.Db.GetFolder(listResult[0].fbatchname) select w.fPathPicture).FirstOrDefault();
            //                    var ktBatch = (from w in Global.Db.CheckBatchChiaUser(listResult[0].fbatchname) select w.ChiaUser).FirstOrDefault();
            //                    if (ktBatch == true)
            //                    {
            //                        ChiaUser = 1;
            //                    }
            //                    else
            //                    {
            //                        ChiaUser = 0;
            //                    }
            //                    lb_fBatchName.Text = Global.StrBatch;
            //                    lb_TongPhieu.Text = (from w in Global.Db.tbl_Images where w.fBatchName == Global.StrBatch select w.IdImage).Count().ToString();
            //                    setValue();
            //                    btn_Submit.Text = @"Start";
            //                    btn_Submit_Click(null, null);
            //                }
            //                else
            //                {
            //                    btn_Logout_ItemClick(null, null);
            //                }
            //            }
            //            else
            //            {
            //                btn_Logout_ItemClick(null, null);
            //            }
            //        }
            //    }
            //    else if (Image_temp == "Error")
            //    {
            //        MessageBox.Show("Không thể load hình!");
            //        btn_Logout_ItemClick(null, null);
            //    }
            //}
        }

        private void btn_Submit_Logout_Click(object sender, EventArgs e)
        {
            //truong11 = "";
            //Global.DbBpo.UpdateTimeLastRequest(Global.Token);
            //var token = (from w in Global.DbBpo.tbl_TokenLogins where w.UserName == Global.StrUserName && w.IDProject == Global.StrIdProject select w.Token).FirstOrDefault();

            //if (token != Global.Token)
            //{
            //    MessageBox.Show(@"User logged on to another PC, please login again!");
            //    DialogResult = DialogResult.Yes;
            //}
            //var version = (from w in Global.DbBpo.tbl_Versions where w.IDProject == Global.StrIdProject select w.IDVersion).FirstOrDefault();
            //if (version != Global.Version)
            //{
            //    MessageBox.Show("Version bạn dùng đã cũ, vui lòng cập nhật phiên bản mới!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    Global.RunUpdateVersion();
            //    Application.Exit();
            //}
            //if (Global.StrRole == "DESO")
            //{
            //    if (uC_DESO1.IsEmpty())
            //    {
            //        if (MessageBox.Show("Bạn đang để trống 1 hoặc nhiều trường. Bạn có muốn submit không? \r\nYes = Submit và chuyển qua hình khác<Nhấn Enter>\r\nNo = nhập lại trường trống cho hình này.<nhấn phím N>", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.No)
            //            return;
            //    }
            //    uC_DESO1.txt_TruongSo13_Leave(null, null);
            //    if (uC_DESO1.txt_TruongSo13.BackColor == System.Drawing.Color.SkyBlue)
            //    {
            //        flagTruong13 = "1";
            //    }
            //    else { flagTruong13 = "0"; }

            //    if (uC_DESO1.checkTruong09(uC_DESO1.txt_TruongSo09.Text) == true) { flagTruong09 = "1"; }
            //    else if(uC_DESO1.checkTruong09(uC_DESO1.txt_TruongSo09.Text) == false) { flagTruong09 = "0"; }
            //    //---
            //    if (uC_DESO1.txt_TruongSo11.Text.IndexOf('●') >= 0)
            //        truong11 = "●";
            //    else if (uC_DESO1.txt_TruongSo11.Text.IndexOf('?') >= 0)
            //        truong11 = "?";
            //    else
            //        truong11 = uC_DESO1.txt_TruongSo11.Text;
            //    //---
            //    Global.Db.Insert_DeSo_0911(lb_IdImage.Text, lb_fBatchName.Text, Global.StrUserName,
            //           uC_DESO1.txt_TruongSo01.Text,
            //           uC_DESO1.txt_TruongSo03.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo03.Text,
            //           uC_DESO1.txt_TruongSo04.Text.Replace(",", ""),
            //           uC_DESO1.txt_TruongSo05.Text,
            //           uC_DESO1.txt_TruongSo06.Text,
            //           uC_DESO1.txt_TruongSo07.Text,
            //           uC_DESO1.txt_TruongSo08_1.Text,
            //           uC_DESO1.txt_TruongSo08_2.Text,
            //           uC_DESO1.txt_TruongSo09.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo09.Text,
            //           uC_DESO1.txt_TruongSo10.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo10.Text,
            //           truong11,
            //           uC_DESO1.txt_TruongSo12.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo12.Text,
            //           uC_DESO1.txt_TruongSo13.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo13.Text,
            //           flagTruong13,
            //           uC_DESO1.txt_TruongSo14.Text.IndexOf('?') >= 0 ? "?" : uC_DESO1.txt_TruongSo14.Text,
            //           flagTruong09
            //           //uC_DESO1.txt_FlagError.Text
            //           );
            //}
            //DialogResult=DialogResult.Yes;
        }

        private void frm_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Enter)
            {
                btn_Submit_Click(null, null);
            }
            if (e.KeyCode == Keys.Escape)
            {
                //new FrmFreeTime().ShowDialog();
                //Global.DbBpo.UpdateTimeFree(Global.Token, Global.FreeTime);
            }
        }
        
        private void btn_ExportExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // new frm_ExportExcel().ShowDialog();
        }

        private void btn_TienDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // new FrmTienDo().ShowDialog();
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new FrmFeedback().ShowDialog();
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //new frm_NangSuat().ShowDialog();
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frm_User().ShowDialog();
        }

        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           // new frm_ChangePassword().ShowDialog();
        }

        private void frm_Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Global.DbBpo.UpdateTimeLastRequest(Global.Token);
                Global.DbBpo.UpdateTimeLogout(Global.Token);
                Global.DbBpo.ResetToken(Global.StrUserName, Global.StrIdProject, Global.Token);
            }
            catch { /**/}
            Settings.Default.ApplicationSkinName = UserLookAndFeel.Default.SkinName;
            Settings.Default.Save();
        }

        private void splitMain_SplitterPositionChanged(object sender, EventArgs e)
        {
          //  Settings.Default.PositionSplitMain = splitMain.SplitterPosition;
          //  Settings.Default.Save();
        }

        private void btn_Pause_Click(object sender, EventArgs e)
        {
          //  new FrmFreeTime().ShowDialog();
            //Global.DbBpo.UpdateTimeFree(Global.Token, Global.FreeTime);
        }

        private void lb_IdImage_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_IdImage.Text);
            XtraMessageBox.Show("Copy image name Success!");
        }

        private void lb_fBatchName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(lb_fBatchName.Text);
            XtraMessageBox.Show("Copy batch name Success!");
        }

        private void btn_Check_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Global.FlagChangeSave = false;
            Global.StrCheck = "CHECKDESO";
         //   new frm_Checker().ShowDialog();
        }

        private void btn_RefreshImageNotInput_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
         //   new Refresh_ImageNotInput().ShowDialog();
        }

        bool FlagLoad = false;
        private void ckOutSource_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                if (FlagLoad == true)
                    return;
                int a = Global.DbBpo.UpdateOutSourceProject(Global.StrIdProject, Convert.ToBoolean(ckOutSource.EditValue+""));
                if (a == 0)
                {
                    MessageBox.Show("Thay đổi thành công");
                }
                else if (a == -1)
                {
                    MessageBox.Show("Thay đổi không thành công");
                }
            }
            catch (Exception i)
            {
                MessageBox.Show("Lỗi: " + i.Message); ;
            }
        }
    }
}
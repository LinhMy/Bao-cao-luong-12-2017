using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using BaoCaoLuong2018.MyData;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_CreateBatch : DevExpress.XtraEditors.XtraForm
    {
        private string _csvpath = "";
        private string[] _lFileNames;
        private bool _multi;
        private int soluonghinh;

        public frm_CreateBatch()
        {
            InitializeComponent();
        }

        private void btn_Browser_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                txt_PathFolder.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_BrowserImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_BatchName.Text))
            {
                MessageBox.Show("Vui lòng điền tên batch", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
           
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Types Image|*.bmp;*.jpg;*.jpeg;*.png;*.tif;*.tiff";

            dlg.Multiselect = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _lFileNames = dlg.FileNames;
                txt_ImagePath.Text = Path.GetDirectoryName(dlg.FileName);
            }soluonghinh = 0;
            soluonghinh = dlg.FileNames.Length;
            lb_SoLuongHinh.Text = dlg.FileNames.Length + " files ";
        }

        private void btn_CreateBatch_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Quá trình tạo batch đang diễn ra, Bạn hãy chờ quá trình tạo batch kết thúc mới tiếp tục tạo batch mới !");
                return;
            }
            lb_SobatchHoanThanh.Text = "";
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
            backgroundWorker1.RunWorkerAsync();
        }

        private void txt_BatchName_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_BatchName.Text))
            {
                _multi = false;
                
                txt_PathFolder.Enabled = false;
                btn_Browser.Enabled = false;
            }
            else
            {
                txt_PathFolder.Enabled = true;
                btn_Browser.Enabled = true;
            }
        }

        private void txt_PathFolder_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txt_PathFolder.Text))
            {
                _multi = true;
                
                txt_BatchName.Enabled = false;
                txt_ImagePath.Enabled = false;
                btn_BrowserImage.Enabled = false;
            }
            else
            {
                txt_BatchName.Enabled = true;
                txt_ImagePath.Enabled = true;
                btn_BrowserImage.Enabled = true;
            }
        }
        public string City = "";
        private bool flag_load = false;
        private void frm_CreateBatch_Load(object sender, EventArgs e)
        {
            chk_ChiaUser.Checked = true;
            txt_UserCreate.Text = Global.StrUserName;
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();

            txt_LoaiPhieu.Items.Add(new { Text = "", Value = "" });
            txt_LoaiPhieu.Items.Add(new { Text = "CityN", Value = "CityS" });
            txt_LoaiPhieu.Items.Add(new { Text = "CityO", Value = "CityO" });
            txt_LoaiPhieu.Items.Add(new { Text = "CityS", Value = "CityS" });
            txt_LoaiPhieu.DisplayMember = "Text";
            txt_LoaiPhieu.ValueMember = "Value";
            txt_LoaiPhieu.Text = City;
            flag_load = true;
            txt_BatchName.Focus();
        }

        public static string[] GetFilesFrom(string searchFolder, string[] filters, bool isRecursive)
        {
            List<string> filesFound = new List<string>();
            var searchOption = isRecursive ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
            foreach (var filter in filters)
            {
                filesFound.AddRange(Directory.GetFiles(searchFolder, $"*.{filter}", searchOption));
            }
            return filesFound.ToArray();
        }

        string[] separators = { @"\", "/" };
        private void UpLoadSingle()
        {
            progressBar1.Step = 1;
            progressBar1.Value = 1;
            progressBar1.Maximum = _lFileNames.Length;
            progressBar1.Minimum = 0;
            ModifyProgressBarColor.SetState(progressBar1, 1);

            string sBatchID = (txt_BatchName.Text + txt_LoaiPhieu.Text + txt_DateCreate.Text).Replace("/", "").Replace(@"\", "").Replace(@":", "").Replace(@"-", "");
            var batch = (from w in Global.Db.tbl_Batches.Where(w => w.BatchID == sBatchID) select w.BatchID).FirstOrDefault();
            if (!string.IsNullOrEmpty(txt_ImagePath.Text))
            {

                if (string.IsNullOrEmpty(batch))
                {
                    var fBatch = new tbl_Batch
                    {
                        BatchID = sBatchID,
                        City = txt_LoaiPhieu.Text,
                        BatchName = txt_BatchName.Text,
                        UserCreate = txt_UserCreate.Text,
                        DateCreate = DateTime.Now,
                        PathPicture = txt_Location.Text,
                        Location = txt_ImagePath.Text,
                        NumberImage = soluonghinh.ToString(),
                        ChiaUser = chk_ChiaUser.Checked ? true : false,
                        CongKhaiBatch = false
                    };
                    Global.Db.tbl_Batches.InsertOnSubmit(fBatch);
                    Global.Db.SubmitChanges();
                }
                else
                {
                    MessageBox.Show("Batch đã tồn tại vui lòng điền tên batch khác!");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Bạn chưa chọn hình ảnh!");
                return;
            }

            string temp = Global.StrPath + "\\" + sBatchID;
            if (!Directory.Exists(temp))
            {
                Directory.CreateDirectory(temp);
            }
            else
            {
                MessageBox.Show("Bị trùng tên batch!");
                return;
            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new[] { new DataColumn("ImageID", typeof(string)) });
            for (int i = 0; i < _lFileNames.Count(); i++)
            {
                FileInfo fi = new FileInfo(_lFileNames[i]);
                dt.Rows.Add(fi.Name);
            }
            string ConnectionString = Global.Db.Connection.ConnectionString;
            SqlConnection con = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand("Insert_Image", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@BatchID", sBatchID);
            cmd.Parameters.AddWithValue("@ListIdImage", dt);
            cmd.Parameters.AddWithValue("@ChiaUser", chk_ChiaUser.Checked ? 1 : 0);
            con.Open();
            cmd.ExecuteNonQuery();

            for (int i = 0; i < _lFileNames.Count(); i++)
            {
                File.Copy(_lFileNames[i], temp + @"\" + new FileInfo(_lFileNames[i]).Name);
                progressBar1.PerformStep();
                lb_SoImageDaHoanThanh.Text = (i + 1) + @"\" + _lFileNames.Count();
            }
            txt_DateCreate.Text = DateTime.Now.ToShortDateString() + "-" + DateTime.Now.ToShortTimeString();
            MessageBox.Show("Tạo batch mới thành công!");
            txt_BatchName.Text = "";
            txt_ImagePath.Text = "";
            lb_SoLuongHinh.Text = "";

        }

        private void UpLoadMulti()
        {
            //btn_Browser.Enabled = false;
            //txt_PathFolder.Enabled = false;
            //txt_Location.Enabled = false;
            //List<string> lStrBath = new List<string>();
            //lStrBath.AddRange(Directory.GetDirectories(txt_PathFolder.Text));
            //int countBatchExists = 0;
            //string listBatchExxists = "";
            //for (int i = 0; i < lStrBath.Count; i++)
            //{
            //    var batchExists = (from w in Global.db.tbl_Batches where w.fBatchName == new DirectoryInfo(lStrBath[i]).Name select w.fBatchName).ToList();
            //    if (batchExists.Count > 0)
            //    {
            //        countBatchExists += 1;
            //        listBatchExxists += batchExists[0] + "\r\n";
            //    }
            //}
            //if (countBatchExists>0)
            //{
            //    MessageBox.Show("Batch đã tồn tại :\r\n" + listBatchExxists);
            //    btn_Browser.Enabled = true;
            //    txt_PathFolder.Enabled = true;
            //    txt_Location.Enabled = true;
            //    return;
            //}
            //int n = 0;
            //foreach (string itemBatch in lStrBath)
            //{
            //    string batchName = "", loaiPhieu = "", pathPicture = "";
            //    int m = 0;
            //    batchName = new DirectoryInfo(itemBatch).Name;
            //    if (batchName.IndexOf("AEON", StringComparison.Ordinal) >= 0 || batchName.IndexOf("aeon", StringComparison.Ordinal) >= 0)
            //    {
            //        loaiPhieu = "AEON";
            //    }
            //    else if (batchName.IndexOf("ASAHI", StringComparison.Ordinal) >= 0 || batchName.IndexOf("asahi", StringComparison.Ordinal) >= 0)
            //    {
            //        loaiPhieu = "ASAHI";
            //    }
            //    else if (batchName.IndexOf("EIZEN", StringComparison.Ordinal) >= 0 || batchName.IndexOf("eizen", StringComparison.Ordinal) >= 0)
            //    {
            //        loaiPhieu = "EIZEN";
            //    }
            //    else if (batchName.IndexOf("YAMAMOTO", StringComparison.Ordinal) >= 0 || batchName.IndexOf("yamamoto", StringComparison.Ordinal) >= 0)
            //    {
            //        loaiPhieu = "YAMAMOTO";
            //    }
            //    else if (batchName.IndexOf("YASUDA", StringComparison.Ordinal) >= 0 || batchName.IndexOf("yasuda", StringComparison.Ordinal) >= 0)
            //    {
            //        loaiPhieu = "YASUDA";
            //    }
            //    else if (batchName.IndexOf("TAIYO", StringComparison.Ordinal) >= 0 || batchName.IndexOf("taiyo", StringComparison.Ordinal) >= 0)
            //    {
            //        loaiPhieu = "TAIYO";
            //    }
            //    else
            //    {
            //        continue;
            //    }

            //    n += 1;
            //    lb_SobatchHoanThanh.Text = n + @" :";

            //    pathPicture = itemBatch + @"\入力画像";
            //    var fBatch = new tbl_Batch
            //    {
            //        fBatchName = batchName,
            //        fUserCreate = txt_UserCreate.Text,
            //        fDateCreated = DateTime.Now,
            //        fPathPicture = pathPicture,
            //        fLocation = txt_Location.Text,
            //        fSoLuongAnh = Directory.GetFiles(pathPicture).Length.ToString(),
            //        fLoaiPhieu = loaiPhieu
            //    };
            //    Global.db.tbl_Batches.InsertOnSubmit(fBatch);
            //    Global.db.SubmitChanges();
                
            //    var filters = new String[] { "jpg", "jpeg", "png", "gif", "tif", "bmp" };
            //    string[] pathImageLocation = GetFilesFrom(pathPicture, filters, false);
            //    string pathImageServer = Global.StrPath + "\\" + new DirectoryInfo(itemBatch).Name;
            //    Directory.CreateDirectory(pathImageServer);
            //    string imageJPG = "";

            //    progressBar1.Step = 1;
            //    progressBar1.Value = 1;
            //    progressBar1.Maximum = pathImageLocation.Length;
            //    progressBar1.Minimum = 0;
            //    ModifyProgressBarColor.SetState(progressBar1, 1);

            //    foreach (string i in pathImageLocation)
            //    {
            //        FileInfo fi = new FileInfo(i);
            //        tbl_Image tempImage = new tbl_Image
            //        {
            //            fbatchname = batchName,
            //            idimage = Path.GetFileName(fi.ToString()),
            //            ReadImageDESo = 0,
            //            CheckedDESo = 0,
            //            Checked_QC = 0,
            //            TienDoDESO = "Hình chưa nhập",
            //            CheckQC = false
            //        };
                    
            //        Global.db.tbl_Images.InsertOnSubmit(tempImage);
            //        Global.db.SubmitChanges();
            //        //tbl_TienDo tempTblTienDo = new tbl_TienDo
            //        //{
            //        //    IDProject = "JEMS",
            //        //    fBatchName = txt_BatchName.Text,
            //        //    Idimage = Path.GetFileName(fi.ToString()),
            //        //    TienDoDeSo = "Hình chưa nhập",
            //        //    UserCheckDeSo = "",
            //        //    DateCreate = DateTime.Now
            //        //};
            //        //Global.db_BPO.tbl_TienDos.InsertOnSubmit(tempTblTienDo);
            //        //Global.db_BPO.SubmitChanges();

            //        string des = pathImageServer + @"\" + Path.GetFileName(fi.ToString());
            //        fi.CopyTo(des);
            //        m += 1;
            //        lb_SoImageDaHoanThanh.Text = m + @"/" + pathImageLocation.Length;
            //        progressBar1.PerformStep();
            //    }
            //}
            //MessageBox.Show(@"Tạo batch mới thành công!");
            //txt_BatchName.Text = "";
            //txt_ImagePath.Text = "";
            //lb_SoLuongHinh.Text = "";
            //txt_PathFolder.Text = "";
            //txt_LoaiPhieu.SelectedIndex = 0;

            ////btn_CreateBatch.Enabled = true;
            //btn_Browser.Enabled = true;
            //txt_PathFolder.Enabled = true;
            //txt_Location.Enabled = true;
        }


        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (string.IsNullOrEmpty(txt_LoaiPhieu.Text) && _multi==false)
            {
                MessageBox.Show("Vui lòng chọn loại phiếu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_multi)
            {
                lb_SobatchHoanThanh.Text = "";
                lb_SoImageDaHoanThanh.Text = "";
                //label1.Visible = true;
                //lb_SobatchHoanThanh.Visible = true;
                //lb_SoImageDaHoanThanh.Visible = true;
                UpLoadMulti();
            }
            else
            {
                lb_SobatchHoanThanh.Text = "1";
                lb_SoImageDaHoanThanh.Text = "";
                //label1.Visible = false;
                //lb_SobatchHoanThanh.Visible = false;
                //lb_SoImageDaHoanThanh.Visible = false;
                UpLoadSingle();
            }
        }
        
        private bool closePending;

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            if (backgroundWorker1.IsBusy)
            {
                MessageBox.Show("Quá trình tạo batch đang diễn ra, Bạn hãy chờ quá trình tạo batch kết thúc!");
                e.Cancel = true;
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (closePending) Close();
            closePending = false;
        }
        private bool flag = false;
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
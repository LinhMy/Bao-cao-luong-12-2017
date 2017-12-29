using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Threading;
using System.Data.SqlClient;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_ExportExcel : DevExpress.XtraEditors.XtraForm
    {
        public frm_ExportExcel()
        {
            InitializeComponent();
        }
        Microsoft.Office.Interop.Excel.Application App = null;
        Microsoft.Office.Interop.Excel.Workbook book = null;
        Microsoft.Office.Interop.Excel.Worksheet wrksheet = null;
        FileStream stream = null;
        int h = 0;
        string namefileExcel = "";

        public struct MyEntry
        {
            public string BatchID { get; set; }
            public string BatchName { get; set; }
        }
        bool FlagLoad = false;
        private void frm_ExportExcel_Load(object sender, EventArgs e)
        {
            FlagLoad = true;
            cbb_City.Items.Add(new { Text = "", Value = "" });
            cbb_City.Items.Add(new { Text = "CityN", Value = "CityS" });
            cbb_City.Items.Add(new { Text = "CityO", Value = "CityO" });
            cbb_City.Items.Add(new { Text = "CityS", Value = "CityS" });
            cbb_City.DisplayMember = "Text";
            cbb_City.ValueMember = "Value";
            cbb_City.Text = Global.StrCity;
            chk_Multiple.Checked = false;
            dgv.PageVisible = true;
            Batch.PageVisible = false;
            list_Batch.DataSource= (from w in Global.Db.GetBatch(cbb_City.Text) select new MyEntry { BatchID=w.BatchID, BatchName = w.BatchName }).ToList();
            list_Batch.DisplayMember = "BatchName";
            list_Batch.ValueMember = "BatchID";
            cbb_Batch.DataSource = (from w in Global.Db.GetBatch(cbb_City.Text) select new { w.BatchID,w.BatchName }).ToList();
            cbb_Batch.DisplayMember = "BatchName";
            cbb_Batch.ValueMember = "BatchID";
            cbb_Batch.SelectedValue = Global.StrBatchID;
            FlagLoad = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            var CountImageNotComplete = (from w in Global.Db.CheckInputComplete(cbb_Batch.SelectedValue+"","DESO") select w.IdImage).ToList();
            var check = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.IDImage).Count();
            if (CountImageNotComplete.Count > 0)
            {
                MessageBox.Show("Chưa nhập xong DeSo!");
                return;
            }
            if (check > 0)
            {
                var list_user = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.UserName).ToList();
                string sss = "";
                foreach (var item in list_user)
                {
                    sss += item + "\r\n";
                }
                if (list_user.Count > 0)
                {
                    MessageBox.Show("Những user lấy hình về nhưng chưa nhập deso: \r\n" + sss);
                    return;
                }
            }
            var soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(cbb_Batch.SelectedValue+"", "DESO") select w.IDImage).Count();
            var ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
            if (soloi > 0)
            {
                MessageBox.Show("Chưa check xong DeSo!");
                return;
            }
            if (ListCheckNotComplete.Count > 0)
            {
                string sss = "";
                foreach (var item in ListCheckNotComplete)
                {
                    sss += item.UserName + "\r\n";
                }
                MessageBox.Show("Những user lấy hình về nhưng chưa check deso: \r\n" + sss);
                return;
            }
            CountImageNotComplete = (from w in Global.Db.CheckInputComplete(cbb_Batch.SelectedValue + "", "DEJP") select w.IdImage).ToList();
            check = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.IDImage).Count();
            if (CountImageNotComplete.Count > 0)
            {
                MessageBox.Show("Chưa nhập xong DEJP!");
                return;
            }
            if (check > 0)
            {
                var list_user = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.UserName).ToList();
                string sss = "";
                foreach (var item in list_user)
                {
                    sss += item + "\r\n";
                }
                if (list_user.Count > 0)
                {
                    MessageBox.Show("Những user lấy hình về nhưng chưa nhập dejp: \r\n" + sss);
                    return;
                }
            }
            soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(cbb_Batch.SelectedValue + "", "DEJP") select w.IDImage).Count();
            ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
            if (soloi > 0)
            {
                MessageBox.Show("Chưa check xong DEJP!");
                return;
            }
            if (ListCheckNotComplete.Count > 0)
            {
                string sss = "";
                foreach (var item in ListCheckNotComplete)
                {
                    sss += item.UserName + "\r\n";
                }
                MessageBox.Show("Những user lấy hình về nhưng chưa check dejp: \r\n" + sss);
                return;
            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx");
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
            }
            else
            {
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
            }
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = (from w in Global.Db.ExportExcel(cbb_Batch.SelectedValue + "") select w).ToList();
            namefileExcel = cbb_Batch.Text + "";
            App = new Microsoft.Office.Interop.Excel.Application();
            book = App.Workbooks.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx", 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
            backgroundWorker1.RunWorkerAsync();
        }
        
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            progressBar1.Step = 1;
            progressBar1.Value = 0;
            progressBar1.Maximum = dataGridView1.RowCount;
            progressBar1.Minimum = 0;
            ModifyProgressBarColor.SetState(progressBar1, 1);
            h = 2;
            string Truong66 = "";
            bool IsLoai2 = false;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                Truong66 = "";
                if (i > 0 & IsLoai2 & dataGridView1[1, i].Value + "" == "Loai3")
                    Truong66 = "1";
                if (dataGridView1[1, i].Value + "" == "Loai2")
                    IsLoai2 = true;
                else if (dataGridView1[1, i].Value + "" == "Loai1")
                    IsLoai2 = false;

                wrksheet.Cells[h, 1] = dataGridView1[0, i].Value + "";  //Trường 01/ Tên hình
                wrksheet.Cells[h, 2] = dataGridView1[1, i].Value + "";  //LoaiPhieu
                wrksheet.Cells[h, 3] = dataGridView1[2, i].Value + "";  //Truong001
                wrksheet.Cells[h, 4] = dataGridView1[3, i].Value + "";
                wrksheet.Cells[h, 5] = dataGridView1[4, i].Value + "";
                wrksheet.Cells[h, 6] = dataGridView1[5, i].Value + "";
                wrksheet.Cells[h, 7] = dataGridView1[6, i].Value + "";
                wrksheet.Cells[h, 8] = dataGridView1[7, i].Value + "";
                wrksheet.Cells[h, 9] = dataGridView1[8, i].Value + "";
                wrksheet.Cells[h, 10] = dataGridView1[9, i].Value + "";
                wrksheet.Cells[h, 11] = dataGridView1[10, i].Value + "";
                wrksheet.Cells[h, 12] = dataGridView1[11, i].Value + "";
                wrksheet.Cells[h, 13] = dataGridView1[12, i].Value + "";
                wrksheet.Cells[h, 14] = dataGridView1[13, i].Value + "";
                wrksheet.Cells[h, 15] = dataGridView1[14, i].Value + "";
                wrksheet.Cells[h, 16] = dataGridView1[15, i].Value + "";
                wrksheet.Cells[h, 17] = dataGridView1[16, i].Value + "";    //Truong015
                wrksheet.Cells[h, 18] = dataGridView1[17, i].Value + "";    //Truong016
                wrksheet.Cells[h, 19] = dataGridView1[18, i].Value + "";    //Truong017
                wrksheet.Cells[h, 20] = dataGridView1[19, i].Value + "";    //Truong018
                wrksheet.Cells[h, 21] = dataGridView1[20, i].Value + "";    //Truong019
                wrksheet.Cells[h, 22] = dataGridView1[21, i].Value + "";    //Truong020
                wrksheet.Cells[h, 23] = dataGridView1[22, i].Value + "";    //Truong021
                wrksheet.Cells[h, 24] = dataGridView1[23, i].Value + "";    //Truong022
                wrksheet.Cells[h, 25] = dataGridView1[24, i].Value + "";    //Truong023
                wrksheet.Cells[h, 26] = dataGridView1[25, i].Value + "";    //Truong024
                wrksheet.Cells[h, 27] = dataGridView1[26, i].Value + "";    //Truong025
                wrksheet.Cells[h, 28] = dataGridView1[27, i].Value + "";    //Truong026
                wrksheet.Cells[h, 29] = dataGridView1[28, i].Value + "";    //Truong027
                wrksheet.Cells[h, 30] = dataGridView1[29, i].Value + "";    //Truong028
                wrksheet.Cells[h, 31] = dataGridView1[30, i].Value + "";    //Truong029
                wrksheet.Cells[h, 32] = dataGridView1[31, i].Value + "";    //Truong030
                wrksheet.Cells[h, 33] = dataGridView1[32, i].Value + "";    //Truong031
                wrksheet.Cells[h, 34] = dataGridView1[33, i].Value + "";    //Truong032
                wrksheet.Cells[h, 35] = dataGridView1[34, i].Value + "";    //Truong033
                wrksheet.Cells[h, 36] = dataGridView1[35, i].Value + "";    //Truong034
                wrksheet.Cells[h, 37] = dataGridView1[36, i].Value + "";    //Truong035
                wrksheet.Cells[h, 38] = dataGridView1[37, i].Value + "";    //Truong036
                wrksheet.Cells[h, 39] = dataGridView1[38, i].Value + "";    //Truong037
                wrksheet.Cells[h, 40] = dataGridView1[39, i].Value + "";    //Truong038
                wrksheet.Cells[h, 41] = dataGridView1[40, i].Value + "";    //Truong039
                wrksheet.Cells[h, 42] = dataGridView1[41, i].Value + "";    //Truong040
                wrksheet.Cells[h, 43] = dataGridView1[42, i].Value + "";    //Truong041
                wrksheet.Cells[h, 44] = dataGridView1[43, i].Value + "";    //Truong042
                wrksheet.Cells[h, 45] = dataGridView1[44, i].Value + "";    //Truong043
                wrksheet.Cells[h, 46] = dataGridView1[45, i].Value + "";    //Truong044
                wrksheet.Cells[h, 47] = dataGridView1[46, i].Value + "";    //Truong045
                wrksheet.Cells[h, 48] = dataGridView1[47, i].Value + "";    //Truong046
                wrksheet.Cells[h, 49] = dataGridView1[48, i].Value + "";    //Truong047
                wrksheet.Cells[h, 50] = dataGridView1[49, i].Value + "";    //Truong048
                wrksheet.Cells[h, 51] = dataGridView1[50, i].Value + "";    //Truong049
                wrksheet.Cells[h, 52] = dataGridView1[51, i].Value + "";    //Truong050
                wrksheet.Cells[h, 53] = dataGridView1[52, i].Value + "";    //Truong051
                wrksheet.Cells[h, 54] = dataGridView1[53, i].Value + "";    //Truong052
                wrksheet.Cells[h, 55] = dataGridView1[54, i].Value + "";    //Truong053
                wrksheet.Cells[h, 56] = dataGridView1[55, i].Value + "";    //Truong054
                wrksheet.Cells[h, 57] = dataGridView1[56, i].Value + "";    //Truong055
                wrksheet.Cells[h, 58] = dataGridView1[57, i].Value + "";    //Truong056
                wrksheet.Cells[h, 59] = dataGridView1[58, i].Value + "";    //Truong057
                wrksheet.Cells[h, 60] = dataGridView1[59, i].Value + "";    //Truong058
                wrksheet.Cells[h, 61] = dataGridView1[60, i].Value + "";    //Truong059
                wrksheet.Cells[h, 62] = dataGridView1[61, i].Value + "";    //Truong060
                wrksheet.Cells[h, 63] = dataGridView1[62, i].Value + "";    //Truong061
                wrksheet.Cells[h, 64] = dataGridView1[63, i].Value + "";    //Truong062
                wrksheet.Cells[h, 65] = dataGridView1[64, i].Value + "";    //Truong063
                wrksheet.Cells[h, 66] = dataGridView1[65, i].Value + "";    //Truong064
                wrksheet.Cells[h, 67] = dataGridView1[66, i].Value + "";    //Truong065
                wrksheet.Cells[h, 68] = Truong66;                           //Truong066
                wrksheet.Cells[h, 69] = dataGridView1[68, i].Value + "";    //Truong067
                wrksheet.Cells[h, 70] = dataGridView1[69, i].Value + "";    //Truong068
                wrksheet.Cells[h, 71] = dataGridView1[70, i].Value + "";    //Truong069
                wrksheet.Cells[h, 72] = dataGridView1[71, i].Value + "";    //Truong070
                wrksheet.Cells[h, 73] = dataGridView1[72, i].Value + "";    //Truong071
                wrksheet.Cells[h, 74] = dataGridView1[73, i].Value + "";    //Truong072
                wrksheet.Cells[h, 75] = dataGridView1[74, i].Value + "";    //Truong073
                wrksheet.Cells[h, 76] = dataGridView1[75, i].Value + "";    //Truong074
                wrksheet.Cells[h, 77] = dataGridView1[76, i].Value + "";    //Truong075
                wrksheet.Cells[h, 78] = dataGridView1[77, i].Value + "";    //Truong076
                wrksheet.Cells[h, 79] = dataGridView1[78, i].Value + "";    //Truong077
                wrksheet.Cells[h, 80] = dataGridView1[79, i].Value + "";    //Truong078
                wrksheet.Cells[h, 81] = dataGridView1[80, i].Value + "";    //Truong079
                wrksheet.Cells[h, 82] = dataGridView1[81, i].Value + "";    //Truong080
                wrksheet.Cells[h, 83] = dataGridView1[82, i].Value + "";    //Truong081
                wrksheet.Cells[h, 84] = dataGridView1[83, i].Value + "";    //Truong082
                wrksheet.Cells[h, 85] = dataGridView1[84, i].Value + "";    //Truong083
                wrksheet.Cells[h, 86] = dataGridView1[85, i].Value + "";    //Truong084
                wrksheet.Cells[h, 87] = dataGridView1[86, i].Value + "";    //Truong085
                wrksheet.Cells[h, 88] = dataGridView1[87, i].Value + "";    //Truong086
                wrksheet.Cells[h, 89] = dataGridView1[88, i].Value + "";    //Truong087
                wrksheet.Cells[h, 90] = dataGridView1[89, i].Value + "";    //Truong088
                wrksheet.Cells[h, 91] = dataGridView1[90, i].Value + "";    //Truong089
                wrksheet.Cells[h, 92] = dataGridView1[91, i].Value + "";    //Truong090
                wrksheet.Cells[h, 93] = dataGridView1[92, i].Value + "";    //Truong091
                wrksheet.Cells[h, 94] = dataGridView1[93, i].Value + "";    //Truong092
                wrksheet.Cells[h, 95] = dataGridView1[94, i].Value + "";    //Truong093
                wrksheet.Cells[h, 96] = dataGridView1[95, i].Value + "";    //Truong094
                wrksheet.Cells[h, 97] = dataGridView1[96, i].Value + "";    //Truong095
                wrksheet.Cells[h, 98] = dataGridView1[97, i].Value + "";    //Truong096
                wrksheet.Cells[h, 99] = dataGridView1[98, i].Value + "";    //Truong097
                wrksheet.Cells[h, 100] = dataGridView1[99, i].Value + "";    //Truong098
                wrksheet.Cells[h, 101] = dataGridView1[100, i].Value + "";    //Truong099
                wrksheet.Cells[h, 102] = dataGridView1[101, i].Value + "";    //Truong100
                wrksheet.Cells[h, 103] = dataGridView1[102, i].Value + "";    //Truong101
                wrksheet.Cells[h, 104] = dataGridView1[103, i].Value + "";    //Truong102
                wrksheet.Cells[h, 105] = dataGridView1[104, i].Value + "";    //Truong103
                wrksheet.Cells[h, 106] = dataGridView1[105, i].Value + "";    //Truong104
                wrksheet.Cells[h, 107] = dataGridView1[106, i].Value + "";    //Truong105
                wrksheet.Cells[h, 108] = dataGridView1[107, i].Value + "";    //Truong106
                wrksheet.Cells[h, 109] = dataGridView1[108, i].Value + "";    //Truong107
                wrksheet.Cells[h, 110] = dataGridView1[109, i].Value + "";    //Truong108
                wrksheet.Cells[h, 111] = dataGridView1[110, i].Value + "";    //Truong109
                wrksheet.Cells[h, 112] = dataGridView1[111, i].Value + "";    //Truong110
                wrksheet.Cells[h, 113] = dataGridView1[112, i].Value + "";    //Truong111
                wrksheet.Cells[h, 114] = "";   //Truong112

                lb_Complete.Text = (i + 1) + "/" + dataGridView1.RowCount;
                progressBar1.PerformStep();
                h++;
            }
            Microsoft.Office.Interop.Excel.Range rowHead = wrksheet.get_Range("A1", "DJ" + (h - 1));
            rowHead.Borders.LineStyle = Microsoft.Office.Interop.Excel.Constants.xlSolid;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                string savePath = "";
                saveFileDialog1.Title = "Save Excel Files";
                saveFileDialog1.Filter = "Excel files (*.xlsx)|*.xlsx";
                saveFileDialog1.FileName = namefileExcel;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    book.SaveCopyAs(saveFileDialog1.FileName);
                    book.Saved = true;
                    savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                }
                else
                {
                    MessageBox.Show(@"Error exporting excel!");
                    return;
                }
                Process.Start(savePath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (book != null)
                    book.Close();
                if (App != null)
                    App.Quit();
                if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx"))
                {
                    File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx");
                }
            }
        }

        private void cbb_Batch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 3)
                e.Handled = true;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (!chk_Multiple.Checked)
            {
                var CountImageNotComplete = (from w in Global.Db.CheckInputComplete(cbb_Batch.SelectedValue + "", "DESO") select w.IdImage).ToList();
                var check = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.IDImage).Count();
                if (CountImageNotComplete.Count > 0)
                {
                    MessageBox.Show("Chưa nhập xong DeSo!");
                    return;
                }
                if (check > 0)
                {
                    var list_user = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in list_user)
                    {
                        sss += item + "\r\n";
                    }
                    if (list_user.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng chưa nhập deso: \r\n" + sss);
                        return;
                    }
                }
                var soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(cbb_Batch.SelectedValue + "", "DESO") select w.IDImage).Count();
                var ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                if (ListCheckNotComplete.Count > 0 || soloi > 0)
                {
                    MessageBox.Show("Chưa check xong DeSo!");
                    string sss = "";
                    foreach (var item in ListCheckNotComplete)
                    {
                        sss += item.UserName + "\r\n";
                    }
                    MessageBox.Show("Những user lấy hình về nhưng chưa check deso: \r\n" + sss);
                    return;
                }

                CountImageNotComplete = (from w in Global.Db.CheckInputComplete(cbb_Batch.SelectedValue + "", "DEJP") select w.IdImage).ToList();
                check = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.IDImage).Count();
                if (CountImageNotComplete.Count > 0)
                {
                    MessageBox.Show("Chưa nhập xong DEJP!");
                    return;
                }
                if (check > 0)
                {
                    var list_user = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select w.UserName).ToList();
                    string sss = "";
                    foreach (var item in list_user)
                    {
                        sss += item + "\r\n";
                    }
                    if (list_user.Count > 0)
                    {
                        MessageBox.Show("Những user lấy hình về nhưng chưa nhập dejp: \r\n" + sss);
                        return;
                    }
                }
                soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(cbb_Batch.SelectedValue + "", "DEJP") select w.IDImage).Count();
                ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == cbb_Batch.SelectedValue + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                if (ListCheckNotComplete.Count > 0 || soloi > 0)
                {
                    MessageBox.Show("Chưa check xong DEJP!");
                    string sss = "";
                    foreach (var item in ListCheckNotComplete)
                    {
                        sss += item.UserName + "\r\n";
                    }
                    MessageBox.Show("Những user lấy hình về nhưng chưa check dejp: \r\n" + sss);
                    return;
                }

                dataGridView1.DataSource = null;
                dataGridView1.DataSource = (from w in Global.Db.ExportExcel_Error(cbb_Batch.SelectedValue+"") select w).ToList();
                namefileExcel = cbb_Batch.Text + "_Error";
            }
            else if (chk_Multiple.Checked)
            {
                if (list_Batch.SelectedItems.Count <= 0 & list_Batch.Items.Count > 0)
                {
                    MessageBox.Show("Vui lòng chọn batch.");
                    return;
                }
                if (list_Batch.Items.Count <= 0)
                {
                    MessageBox.Show("Không có Batch.");
                    return;
                }

                DataTable dt = new DataTable();
                dt.Columns.AddRange(new[] { new DataColumn("BatchName", typeof(string)) });

                foreach (var item in list_Batch.SelectedItems)
                {
                    var CountImageNotComplete = (from w in Global.Db.CheckInputComplete(((MyEntry)item).BatchID + "", "DESO") select w.IdImage).ToList();
                    var check = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.IDImage).Count();
                    if (CountImageNotComplete.Count > 0)
                    {
                        MessageBox.Show("Chưa nhập xong DeSo!");
                        return;
                    }
                    if (check > 0)
                    {
                        var list_user = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.UserName).ToList();
                        string sss = "";
                        foreach (var item_temp in list_user)
                        {
                            sss += item_temp + "\r\n";
                        }
                        if (list_user.Count > 0)
                        {
                            MessageBox.Show("Những user lấy hình về nhưng chưa nhập deso: \r\n" + sss);
                            return;
                        }
                    }
                    var soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(((MyEntry)item).BatchID + "", "DESO") select w.IDImage).Count();
                    var ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeSos where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                    if (ListCheckNotComplete.Count > 0 || soloi > 0)
                    {
                        MessageBox.Show("Chưa check xong DeSo!");
                        string sss = "";
                        foreach (var item_temp in ListCheckNotComplete)
                        {
                            sss += item_temp.UserName + "\r\n";
                        }
                        MessageBox.Show("Những user lấy hình về nhưng chưa check deso: \r\n" + sss);
                        return;
                    }

                    CountImageNotComplete = (from w in Global.Db.CheckInputComplete(((MyEntry)item).BatchID + "", "DEJP") select w.IdImage).ToList();
                    check = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.IDImage).Count();
                    if (CountImageNotComplete.Count > 0)
                    {
                        MessageBox.Show("Chưa nhập xong DEJP!");
                        return;
                    }
                    if (check > 0)
                    {
                        var list_user = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select w.UserName).ToList();
                        string sss = "";
                        foreach (var item_temp in list_user)
                        {
                            sss += item_temp + "\r\n";
                        }
                        if (list_user.Count > 0)
                        {
                            MessageBox.Show("Những user lấy hình về nhưng chưa nhập dejp: \r\n" + sss);
                            return;
                        }
                    }
                    soloi = (from w in Global.Db.GetNumberErrorUnfinish_Excel(((MyEntry)item).BatchID + "", "DEJP") select w.IDImage).Count();
                    ListCheckNotComplete = (from w in Global.Db.tbl_MissImage_DeJPs where w.BatchID == ((MyEntry)item).BatchID + "" && w.Submit == false select new { w.IDImage, w.UserName }).ToList();
                    if (ListCheckNotComplete.Count > 0 || soloi > 0)
                    {
                        MessageBox.Show("Chưa check xong DEJP!");
                        string sss = "";
                        foreach (var item_temp in ListCheckNotComplete)
                        {
                            sss += item_temp.UserName + "\r\n";
                        }
                        MessageBox.Show("Những user lấy hình về nhưng chưa check dejp: \r\n" + sss);
                        return;
                    }
                    dt.Rows.Add(((MyEntry)item).BatchID + "");
                }
                string ConnectionString = Global.Db.Connection.ConnectionString;
                SqlConnection con = new SqlConnection(ConnectionString);
                DataTable data = new DataTable();
                SqlCommand cmd = new SqlCommand("ExportExcel_Error_Multiple", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@BatchID", dt);
                cmd.Parameters.AddWithValue("@City", cbb_City.Text);
                con.Open();
                data.Load(cmd.ExecuteReader());
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = data;
                namefileExcel = "Multiple_Error";

            }
            if (File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx");
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
            }
            else
            {
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/ExportExcel.xlsx"), Properties.Resources.ExportExcel);
            }
            App = new Microsoft.Office.Interop.Excel.Application();
            book = App.Workbooks.Open(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\ExportExcel.xlsx", 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.ActiveSheet;
            backgroundWorker1.RunWorkerAsync();
        }

        private void chk_Multiple_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_Multiple.Checked)
            {
                dgv.PageVisible = false;
                Batch.PageVisible = true;
                cbb_Batch.Enabled = false;
            }
            else
            {
                dgv.PageVisible = true;
                Batch.PageVisible = false;
                cbb_Batch.Enabled = true;
            }
        }

        private void txt_LoaiPhieu_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FlagLoad)
                return;
            list_Batch.DataSource = (from w in Global.Db.GetBatch(cbb_City.Text) select new MyEntry { BatchID = w.BatchID, BatchName = w.BatchName }).ToList();
            list_Batch.DisplayMember = "BatchName";
            list_Batch.ValueMember = "BatchID";
            cbb_Batch.DataSource = (from w in Global.Db.GetBatch(cbb_City.Text) select new { w.BatchID, w.BatchName }).ToList();
            cbb_Batch.DisplayMember = "BatchName";
            cbb_Batch.ValueMember = "BatchID";
        }
    }
}
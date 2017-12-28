using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;

namespace BaoCaoLuong2018.MyForm
{
    public partial class frm_NangSuat : DevExpress.XtraEditors.XtraForm
    {
        private DateTime firstDateTime;
        private DateTime lastDateTime;
        public frm_NangSuat()
        {
            InitializeComponent();
        }

        private void frm_NangSuat_Load(object sender, EventArgs e)
        {
            timeFisrt.EditValue = "00:00";
            timeEnd.EditValue = "23:59";
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd ") + timeFisrt.Text + ":00";//" 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd ") + timeEnd.Text + ":59";// " 23:59:59";

            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            LoadDataGrid(firstDateTime, lastDateTime);
        }
        private void LoadDataGrid(DateTime TuNgay, DateTime DenNgay)
        {
            gridControl1.DataSource = dataGridView1.DataSource = Global.Db.NangSuatDeSo(TuNgay, DenNgay);           
            gridControl2.DataSource = dataGridView2.DataSource = Global.Db.NangSuatDeJP(TuNgay, DenNgay);
            // gridControl1.DataSource = dataGridView1.DataSource = Global.Db.NangSuatDeSo(TuNgay, DenNgay);
            //gridView1.RowCellStyle += GridView1_RowCellStyle;
            //gridView2.RowCellStyle += GridView1_RowCellStyle;
        }
        private void GridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView View = sender as GridView;
            //doi mau row chan
            if (e.RowHandle >= 0)
            {
                if (e.RowHandle % 2 == 0) e.Appearance.BackColor = Color.LavenderBlush;
                else
                {
                    e.Appearance.BackColor = Color.BlanchedAlmond;
                }
            }
        }
        private void dtp_FirstDay_ValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd ") + timeFisrt.Text + ":00"; //" 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd ") + timeEnd.Text + ":59"; //" 23:59:59";
            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            gridControl1.DataSource = null;
            dataGridView1.DataSource = null;
            // gridControl2.DataSource = null;
            if (firstDateTime >= lastDateTime)
            {
                MessageBox.Show("Ngày bắt đầu phải nhỏ hơn hoặc bằng ngày kết thúc");
            }
            else
            {
                LoadDataGrid(firstDateTime, lastDateTime);
            }
        }

        private void dtp_EndDay_ValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd ") + timeFisrt.Text + ":00";// " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd ") + timeEnd.Text + ":59";// " 23:59:59";
            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            gridControl1.DataSource = null;
            dataGridView1.DataSource = null;
            if (firstDateTime > lastDateTime)
            {
                MessageBox.Show("Ngày kết thúc phải lớn hơn hoặc bằng ngày bắt đầu");
            }
            else
            {
                LoadDataGrid(firstDateTime, lastDateTime);
            }
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity.xlsx"))
            {
                File.Delete(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity.xlsx");
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Productivity.xlsx"), Properties.Resources.Productivity);
            }
            else
            {
                File.WriteAllBytes((Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/Productivity.xlsx"), Properties.Resources.Productivity);
            }
           TableToExcel(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "\\Productivity.xlsx");
          
        }
        public bool TableToExcel(string strfilename)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook book = app.Workbooks.Open(strfilename, 0, true, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
                Microsoft.Office.Interop.Excel.Worksheet wrksheet = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets["DeSo"];
                int h = 1;
                wrksheet.Cells[2, 10] = "* Thời gian:" + timeFisrt.Text + "/" + dtp_FirstDay.Value.Day + "/" + dtp_FirstDay.Value.Month + "/" + dtp_FirstDay.Value.Year + " đến " + timeEnd.Text + "/" + dtp_EndDay.Value.Day + "/" + dtp_EndDay.Value.Month + "/" + dtp_EndDay.Value.Year;
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    wrksheet.Cells[h + 2, 1] = h;
                    wrksheet.Cells[h + 2, 2] = dataGridView1.Rows[i].Cells[0].Value + "";//username
                    wrksheet.Cells[h + 2, 3] = dataGridView1.Rows[i].Cells[1].Value + "";//fullname
                    wrksheet.Cells[h + 2, 4] = dataGridView1.Rows[i].Cells[2].Value + "";//tong
                    wrksheet.Cells[h + 2, 5] = dataGridView1.Rows[i].Cells[3].Value + "";//phieudung
                    wrksheet.Cells[h + 2, 6] = dataGridView1.Rows[i].Cells[4].Value + "";//phieusai
                    wrksheet.Cells[h + 2, 7] = dataGridView1.Rows[i].Cells[5].Value + "";//thoigian
                    wrksheet.Cells[h + 2, 8] = dataGridView1.Rows[i].Cells[6].Value + "";//hieusuat
                    h++;
                }
                Microsoft.Office.Interop.Excel.Worksheet wrksheetjp = (Microsoft.Office.Interop.Excel.Worksheet)book.Sheets["DeJP"];
                int jp = 1;
                wrksheetjp.Cells[2, 10] = "* Thời gian:" + timeFisrt.Text + "/" + dtp_FirstDay.Value.Day + "/" + dtp_FirstDay.Value.Month + "/" + dtp_FirstDay.Value.Year + " đến " + timeEnd.Text + "/" + dtp_EndDay.Value.Day + "/" + dtp_EndDay.Value.Month + "/" + dtp_EndDay.Value.Year;
                for (int i = 0; i < dataGridView2.RowCount; i++)
                {
                    wrksheetjp.Cells[jp + 2, 1] = jp;
                    wrksheetjp.Cells[jp + 2, 2] = dataGridView2.Rows[i].Cells[0].Value + "";//username
                    wrksheetjp.Cells[jp + 2, 3] = dataGridView2.Rows[i].Cells[1].Value + "";//fullname
                    wrksheetjp.Cells[jp + 2, 4] = dataGridView2.Rows[i].Cells[2].Value + "";//tong
                    wrksheetjp.Cells[jp + 2, 5] = dataGridView2.Rows[i].Cells[3].Value + "";//phieudung
                    wrksheetjp.Cells[jp + 2, 6] = dataGridView2.Rows[i].Cells[4].Value + "";//phieusai
                    wrksheetjp.Cells[jp + 2, 7] = dataGridView2.Rows[i].Cells[5].Value + "";//thoigian
                    wrksheetjp.Cells[jp + 2, 8] = dataGridView2.Rows[i].Cells[6].Value + "";//hieusuat
                    jp++;
                }
                //copyAlltoClipboard();
                //Microsoft.Office.Interop.Excel.Range CR = (Microsoft.Office.Interop.Excel.Range)wrksheet.Cells[3, 1];
                //CR.Select();
                //wrksheet.PasteSpecial(CR, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, true);
                string savePath;
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Title = @"Save Excel Files";
                saveFileDialog1.Filter = @"Excel files (*.xlsx)|*.xlsx";
                saveFileDialog1.FileName = "NangSuat_BaoCaoLuong2018_" + dtp_FirstDay.Value.Day + "-" + dtp_EndDay.Value.Day;
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    book.SaveCopyAs(saveFileDialog1.FileName);
                    book.Saved = true;
                    savePath = Path.GetDirectoryName(saveFileDialog1.FileName);
                    app.Quit();
                }
                else
                {
                    MessageBox.Show(@"Error exporting excel!");
                    return false;
                }
                if (savePath != null) Process.Start(savePath); return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        private void copyAlltoClipboard()
        {
            dataGridView1.SelectAll();
            DataObject dataObj = dataGridView1.GetClipboardContent();
            if (dataObj != null) Clipboard.SetDataObject(dataObj);
        }
     
        private void timeFisrt_EditValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd ") + timeFisrt.Text + ":00"; //" 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd ") + timeEnd.Text + ":59"; //" 23:59:59";
            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            gridControl1.DataSource = null;
            dataGridView1.DataSource = null;
            // gridControl2.DataSource = null;
            if (firstDateTime >= lastDateTime)
            {
                MessageBox.Show("Giờ bắt đầu phải nhỏ hơn hoặc bằng giờ kết thúc");
            }
            else
            {
                LoadDataGrid(firstDateTime, lastDateTime);
            }
        }

        private void timeEnd_EditValueChanged(object sender, EventArgs e)
        {
            string firstdate = dtp_FirstDay.Value.ToString("yyyy-MM-dd ") + timeFisrt.Text + ":00";// " 00:00:00";
            string lastdate = dtp_EndDay.Value.ToString("yyyy-MM-dd ") + timeEnd.Text + ":59";// " 23:59:59";
            firstDateTime = DateTime.Parse(firstdate);
            lastDateTime = DateTime.Parse(lastdate);
            gridControl1.DataSource = null;
            dataGridView1.DataSource = null;
            if (firstDateTime > lastDateTime)
            {
                MessageBox.Show("Giờ kết thúc phải lớn hơn hoặc bằng giờ bắt đầu");
            }
            else
            {
                LoadDataGrid(firstDateTime, lastDateTime);
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BaoCaoLuong2018.MyClass
{
    internal class ClsLogin
    {
        public void Combobox_Batch(ComboBox cbb)
        {
          //  cbb.DataSource = Global.Db.GetBatch();
            cbb.DisplayMember = "fBatchName";
            cbb.ValueMember = "fBatchName";
        }

        public void Combobox_NotFinishDESO(ComboBox cbb, string tb)
        {
         //   cbb.DataSource =Global.Db.GetBatNotFinishDeSo_Good(tb);
            cbb.DisplayMember = "fBatchName";
            cbb.ValueMember = "fBatchName";
        }

        public void Combobox_NotFinishDEJP(ComboBox cbb)
        {
            //cbb.DataSource = Global.DbKiemDinhXe.GetBatNotFinishDeJP();
            //cbb.DisplayMember = "fBatchName";
            //cbb.ValueMember = "fBatchName";
            cbb.DataSource = null;
        }

        public void Combobox_NotFinish_MissImageDESO(ComboBox cbb, string tb)
        {
           // cbb.DataSource = Global.Db.GetBatNotFinish_MissImageDESO(tb);
            cbb.DisplayMember = "fBatchName";
            cbb.ValueMember = "fBatchName";
        }

        public void Combobox_NotFinish_MissImageDEJP(ComboBox cbb, string tb)
        {
            //cbb.DataSource = Global.DbKiemDinhXe.GetBatNotFinish_MissImageDEJP(tb);
            //cbb.DisplayMember = "fBatchName";
            //cbb.ValueMember = "fBatchName";
            cbb.DataSource = null;
        }
        public void Combobox_NotFinishCheckDeSo(ComboBox cbb, string tb)
        {
          //  cbb.DataSource = (from w in Global.Db.GetBatNotFinishCheckerDeSo(tb) select w.fBatchName).ToList();
            cbb.DisplayMember = "fBatchName";
            cbb.ValueMember = "fBatchName";
        }
    }
}
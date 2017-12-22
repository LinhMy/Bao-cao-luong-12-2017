using System;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.UserSkins;
using BaoCaoLuong_12_2017.MyForm;

namespace BaoCaoLuong_12_2017
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BonusSkins.Register();
            //Application.Run(new frmFeedback());
            if (new frm_ChangeServer().ShowDialog() != DialogResult.OK)
                return;
            bool temp = false;
            do
            {
                temp = false;
                frmLogin frLogin = new frmLogin();

                if (frLogin.ShowDialog() == DialogResult.OK)
                {
                    frm_Main frMain = new frm_Main();

                    if (frMain.ShowDialog() == DialogResult.Yes)
                    {
                        frMain.Close();
                        temp = true;
                    }
                }
            }
            while (temp);
        }
    }
}

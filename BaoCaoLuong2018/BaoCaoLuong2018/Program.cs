using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using BaoCaoLuong2018.MyForm;

namespace BaoCaoLuong2018
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
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            //Application.Run(new FrmTienDo());
            bool temp = false;
            do
            {
                temp = false;
                frm_ChangeServer changeserver = new frm_ChangeServer();
                if (changeserver.ShowDialog() == DialogResult.OK)
                {
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
            }
            while (temp);
        }
    }
}

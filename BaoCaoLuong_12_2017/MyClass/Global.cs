using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;
using System.Collections.Generic;
using BaoCaoLuong_12_2017.Properties;

namespace BaoCaoLuong_12_2017
{
    internal class Global
    {
        public static string StrUserName = "";
        public static string StrPcName = "";
        public static string StrDomainName = "";
        public static string StrBatch = "";
        public static string StrRole = "";
        public static string Token = "";
        public static string StrIdProject = "BaoCaoLuong2018";
        public static string StrCheck = "";
        public static int FreeTime = 0;
        public static string Version = "1.0.0";
        public static string StrCity;
        public static bool FlagChangeSave = true;
        public static string StrPath /*= @"\\10.10.10.248\PhieuKiemDinh$"*/;
        public static string Webservice;
        // public static List<string> listdata13 = new List<string>();
        //public static string Webservice = "http://10.10.10.248:8888/phieukiemdinh/";
        public static DataBaoCaoLuong2018DataContext Db;
        public static DataEntryBPODataContext DbBpo;
        
        public static string GetToken(string strUserName)
        {
            Random rnd = new Random();
            return MyClass.HashMD5.GetMd5Hash(DateTime.Now + strUserName + rnd.Next(1111, 9999));
        }

        public static IPAddress GetServerIpAddress()
        {
            if (!System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable())
            {
                return null;
            }
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            try
            {
                return host.AddressList.FirstOrDefault(ip => ip.AddressFamily == AddressFamily.InterNetwork);
            }
            catch (Exception)
            {
                return null;
            }
        }
        public static bool CheckOutSource(string Role)
        {
            bool? OutSource = (from w in DbBpo.tbl_Versions where w.IDProject == StrIdProject select w.OutSource).FirstOrDefault();
            if (OutSource == false && Settings.Default.Server == "Khác" && Role == "DESO")
                return true;
            return false;
        }
        public static void RunUpdateVersion()
        {
            if (Settings.Default.Server == "Đà Nẵng")
                Process.Start(@"\\10.10.10.254\DE_Viet\2017\");
            else
                Process.Start(/*https://drive.google.com/drive/folders/0BwO0VkvgrRHaeW5meEE4blBHdnc?usp=sharing*/"");
        }
    }
}

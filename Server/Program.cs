using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server
{
    static class Program
    {

        /*
         *                         _                  _                 
         *                        | |                | |                
         *  __ ___      ____ _  __| | __ _ _ __   ___| |__  _   _ _ __  
         * / _` \ \ /\ / / _` |/ _` |/ _` | '_ \ / __| '_ \| | | | '_ \ 
         *| (_| |\ V  V / (_| | (_| | (_| | | | | (__| | | | |_| | | | |
         * \__, | \_/\_/ \__, |\__,_|\__,_|_| |_|\___|_| |_|\__,_|_| |_|
         *    | |           | |                                         
         *    |_|           |_|                                         
         * 
         */
        [STAThread]
        static void Main()
        {
            //Computer\HKEY_CURRENT_USER\SOFTWARE\20D31F82EC0ECE81D22B
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form1 = new Form1() { Name="MainForm"};
            Application.Run(form1);
        }
        public static Form1 form1;
    }
}

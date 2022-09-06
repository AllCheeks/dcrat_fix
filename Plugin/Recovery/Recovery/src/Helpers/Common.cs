
namespace Stealer
{
    public struct Password
    {
        public string sUrl { get; set; }
        public string sUsername { get; set; }
        public string sPassword { get; set; }
    }

    internal struct Cookie
    {
        public string expirationDate { get; set; }
        public string domain { get; set; }
        public string name { get; set; }
        public string value { get; set; }
        public string sPath { get; set; }
        public string sKey { get; set; }
        public string secure { get; set; }
    }

    internal struct CreditCard
    {
        public string sNumber { get; set; }
        public string sExpYear { get; set; }
        public string sExpMonth { get; set; }
        public string sName { get; set; }
    }

    internal struct AutoFill
    {
        public string sName;
        public string sValue;
    }

    internal struct Site
    {
        public string sUrl { get; set; }
        public string sTitle { get; set; }
        public int iCount { get; set; }
    }

    internal struct Bookmark
    {
        public string sUrl { get; set; }
        public string sTitle { get; set; }
    }
        
}

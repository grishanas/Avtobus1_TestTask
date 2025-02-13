using System.Text.RegularExpressions;

namespace Domain
{

    internal static class Ensure
    {
        public static void NotNull(string? value)
        {
            if(value == null)
                throw new ArgumentNullException("value");

        }

        public static void LengthInCurrect(string value)
        {
            if((value.Length == 0)||(value.Length>=100))
                throw new ArgumentOutOfRangeException("value");
        }

        public static void IsContainHttp(string value)
        {
            var reg = new Regex("^http(s?)://");
            if(!reg.IsMatch(value))
                throw new ArgumentOutOfRangeException("value");

        }
    }
    public class UrlInfo
    {
        public string Url { get; private set; }
        public string shortUrl { get; set; }
        public DateTime DateCreation { get; private set; }
        public uint ClicksNumber { get; private set; }

        public void incClick()
        {
            this.ClicksNumber++;
        }

        public UrlInfo(string url) 
        {
            Ensure.NotNull(url);
            Ensure.LengthInCurrect(url);
            Ensure.IsContainHttp(url);
            Url = url;
            DateCreation = DateTime.Now;
            ClicksNumber = 0;
        }
    }
}

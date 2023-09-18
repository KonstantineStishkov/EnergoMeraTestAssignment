using System.Security.AccessControl;

namespace RestCountries.Stoarge.Models
{
    public struct CounrtyName
    {
        public string Common;
        public string Official;
    }

    public class CountryModel
    {
        public CounrtyName Name;
        public string[] Capital;
        public string Region;
        public Dictionary<string, string> Languages;
    }
}

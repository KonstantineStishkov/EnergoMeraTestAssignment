using RestCountries.Stoarge.Models;

namespace RestCountries.Models
{
    public class Country
    {
        public string Name;
        public string Capital;
        public string Region;
        public string[] Languages;
        
        public Country(CountryModel model)
        {
            Name = model.Name.Common;
            Capital = model.Capital.FirstOrDefault() ?? string.Empty;
            Region = model.Region;
            Languages = model.Languages.Select(l => l.Value).ToArray();
        }
    }
}

using RestCountries.Models;
using RestCountries.Stoarge.Models;
using System.Text.Json;

namespace RestCountries.Stoarge
{
    public class CountriesStorage
    {
        private const string _getAll = @"https://restcountries.com/v3.1/all";
        private IEnumerable<Country>? _countries;
        private HttpClient _client = new HttpClient();

        public async Task<IEnumerable<Country>> GetCountries(int offset, int limit)
        {
            return _countries ?? (await GetCountriesFromApi())
                                                    .Skip(offset)
                                                    .Take(limit)
                                                    .Select(c => new Country(c));
        }

        private async Task<IEnumerable<CountryModel>> GetCountriesFromApi()
        {
            List<CountryModel> countries = new();
            using (HttpResponseMessage response = await _client.GetAsync(_getAll))
            {
                if (response.IsSuccessStatusCode)
                {
                    string responseString = await response.Content.ReadAsStringAsync();
                    countries = JsonSerializer.Deserialize<List<CountryModel>>(responseString) ?? new();
                }
            }

            return countries;
        }
    }
}

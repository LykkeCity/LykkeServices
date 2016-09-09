using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Lykke.Core.Domain.Country.Models;
using LykkeServices.WebApi.Proxy.DictionaryService;

namespace LykkeServices.WebApi.Controllers
{
    public class CountryController : ApiController
    {
        private static readonly Dictionary<string, IEnumerable<CountryItem>> _countries =
            new Dictionary<string, IEnumerable<CountryItem>>();

        private readonly IDictionaryServiceProxy _dictionaryServiceProxy;

        public CountryController(IDictionaryServiceProxy dictionaryServiceProxy)
        {
            _dictionaryServiceProxy = dictionaryServiceProxy;
        }

        public async Task<IEnumerable<CountryItem>> Get(string language)
        {
            if (string.IsNullOrEmpty(language))
                return await _dictionaryServiceProxy.GetCountriesAsync(language);

            if (!_countries.ContainsKey(language))
            {
                var countryItems = await _dictionaryServiceProxy.GetCountriesAsync(language);
                _countries.Add(language, countryItems);
            }

            return _countries[language];
        }
    }
}
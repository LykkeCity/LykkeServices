using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Lykke.Core.Domain.Country.Models;
using LykkeServices.WebApi.Proxy.DictionaryService;

namespace LykkeServices.WebApi.Controllers
{
    public class CountryController : ApiController
    {
        private readonly IDictionaryServiceProxy _dictionaryServiceProxy;

        public CountryController(IDictionaryServiceProxy dictionaryServiceProxy)
        {
            _dictionaryServiceProxy = dictionaryServiceProxy;
        }

        public async Task<IEnumerable<CountryItem>> Get(string language)
        {
            return await _dictionaryServiceProxy.GetCountriesAsync(language);
        }
    }
}
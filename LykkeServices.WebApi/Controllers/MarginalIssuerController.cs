using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Lykke.Core.Domain.Assets.Models;
using LykkeServices.WebApi.Proxy.DictionaryService;

namespace LykkeServices.WebApi.Controllers
{
    public class MarginalIssuerController : ApiController
    {
        private static IEnumerable<Issuer> _issuers = new List<Issuer>();

        private readonly IDictionaryServiceProxy _dictionaryServiceProxy;

        public MarginalIssuerController(IDictionaryServiceProxy dictionaryServiceProxy)
        {
            _dictionaryServiceProxy = dictionaryServiceProxy;
        }

        public async Task<IEnumerable<Issuer>> Get()
        {
            return _issuers.Any()
                ? _issuers
                : (_issuers = await _dictionaryServiceProxy.GetMarginalIssuersAsync());
        }
    }
}
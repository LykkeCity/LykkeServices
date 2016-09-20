using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Lykke.Core.Domain.Assets.Models;
using LykkeServices.WebApi.Proxy.DictionaryService;

namespace LykkeServices.WebApi.Controllers
{
    public class MarginalAssetController : ApiController
    {
        private static IEnumerable<Asset> _assets = new List<Asset>();

        private readonly IDictionaryServiceProxy _dictionaryServiceProxy;

        public MarginalAssetController(IDictionaryServiceProxy dictionaryServiceProxy)
        {
            _dictionaryServiceProxy = dictionaryServiceProxy;
        }

        public async Task<IEnumerable<Asset>> Get()
        {
            return _assets.Any()
                ? _assets
                : (_assets = await _dictionaryServiceProxy.GetMarginalAssetsAsync());
        }
    }
}
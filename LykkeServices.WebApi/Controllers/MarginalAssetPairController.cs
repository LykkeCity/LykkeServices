using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using Lykke.Core.Domain.Assets.Models;
using LykkeServices.WebApi.Proxy.DictionaryService;

namespace LykkeServices.WebApi.Controllers
{
    public class MarginalAssetPairController : ApiController
    {
        private static IEnumerable<AssetPair> _assetPairs = new List<AssetPair>();

        private readonly IDictionaryServiceProxy _dictionaryServiceProxy;

        public MarginalAssetPairController(IDictionaryServiceProxy dictionaryServiceProxy)
        {
            _dictionaryServiceProxy = dictionaryServiceProxy;
        }

        public async Task<IEnumerable<AssetPair>> Get()
        {
            return _assetPairs.Any()
                ? _assetPairs
                : (_assetPairs = await _dictionaryServiceProxy.GetMarginalAssetPairsAsync());
        }
    }
}
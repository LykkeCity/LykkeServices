using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Core.Domain.Assets.Models;
using Lykke.Core.Domain.Country.Models;

namespace LykkeServices.WebApi.Proxy.DictionaryService
{
    public interface IDictionaryServiceProxy: IProxy
    {
        Task<IEnumerable<CountryItem>> GetCountriesAsync(string language);

        Task<IEnumerable<AssetPair>> GetMarginalAssetPairsAsync();

        Task<IEnumerable<Asset>> GetMarginalAssetsAsync();

        Task<IEnumerable<Issuer>> GetMarginalIssuersAsync();
    }
}
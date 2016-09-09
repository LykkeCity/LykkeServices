using System.Threading.Tasks;
using System.Web.Http;
using Lykke.Core.Domain.Country.Models;
using LykkeServices.WebApi.Proxy.IpGeoLocation;

namespace LykkeServices.WebApi.Controllers
{
    public class IpGeoLocationController : ApiController
    {
        private readonly IIpGeoLocationProxy _ipGeoLocationProxy;

        public IpGeoLocationController(IIpGeoLocationProxy ipGeoLocationProxy)
        {
            _ipGeoLocationProxy = ipGeoLocationProxy;
        }

        public async Task<IpGeoLocationData> Get(string ip, string language)
        {
            return await _ipGeoLocationProxy.GetCountryByIpAsync(ip, language);
        }
    }
}
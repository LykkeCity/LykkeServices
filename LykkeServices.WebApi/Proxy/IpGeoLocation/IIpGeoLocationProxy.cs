using System.Threading.Tasks;
using Lykke.Core.Domain.Country.Models;

namespace LykkeServices.WebApi.Proxy.IpGeoLocation
{
    public interface IIpGeoLocationProxy : IProxy
    {
        Task<IpGeoLocationData> GetCountryByIpAsync(string ip, string language);
    }
}
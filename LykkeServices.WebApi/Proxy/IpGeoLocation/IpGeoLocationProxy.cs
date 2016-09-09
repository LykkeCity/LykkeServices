using System;
using System.Threading.Tasks;
using Lykke.Core.Domain.Country.Models;
using Lykke.Core.Domain.Dictionary;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace LykkeServices.WebApi.Proxy.IpGeoLocation
{
    public class IpGeoLocationProxy : IIpGeoLocationProxy
    {
        private static IIpGeoLocation _actorProxy;

        public IpGeoLocationProxy()
        {
            var matchingEngineServiceUri = new Uri("fabric:/IpGeoLocation/IpGeoLocationActorService");
            var actorId = ActorId.CreateRandom();
            _actorProxy = ActorProxy.Create<IIpGeoLocation>(actorId, matchingEngineServiceUri);
        }

        public async Task<IpGeoLocationData> GetCountryByIpAsync(string ip, string language)
        {
            var ipGeoLocationData = await _actorProxy.GetCountryByIp(ip, language);
            return ipGeoLocationData;
        }
    }
}
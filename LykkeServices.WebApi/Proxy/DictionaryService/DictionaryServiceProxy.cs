using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lykke.Core.Domain.Country.Models;
using Lykke.Core.Domain.Dictionary;
using Microsoft.ServiceFabric.Actors;
using Microsoft.ServiceFabric.Actors.Client;

namespace LykkeServices.WebApi.Proxy.DictionaryService
{
    public class DictionaryServiceProxy : IDictionaryServiceProxy
    {
        private static IDictionaryService _actorProxy;

        public DictionaryServiceProxy()
        {
            var matchingEngineServiceUri = new Uri("fabric:/DictionaryApp/DictionaryServiceActorService");
            var actorId = ActorId.CreateRandom();
            _actorProxy = ActorProxy.Create<IDictionaryService>(actorId, matchingEngineServiceUri);
        }

        public async Task<IEnumerable<CountryItem>> GetCountriesAsync(string language)
        {
            return await _actorProxy.GetCountriesAsync(language);
        }
    }
}
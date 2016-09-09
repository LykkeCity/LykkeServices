using System.Reflection;
using Autofac;
using Autofac.Integration.WebApi;
using LykkeServices.WebApi.Proxy.DictionaryService;
using LykkeServices.WebApi.Proxy.IpGeoLocation;

namespace LykkeServices.WebApi
{
    public class WepApiConfig
    {
        public static IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DictionaryServiceProxy>().As<IDictionaryServiceProxy>().SingleInstance();
            builder.RegisterType<IpGeoLocationProxy>().As<IIpGeoLocationProxy>().SingleInstance();

            var container = builder.Build();
            return container;
        }
    }
}
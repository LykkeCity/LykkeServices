using System.Web.Http;
using Autofac.Integration.WebApi;
using Owin;

namespace LykkeServices.WebApi
{
    public static class Startup
    {
        public static void ConfigureApp(IAppBuilder appBuilder)
        {
            var config = new HttpConfiguration();

            SwaggerConfig.Register(config);

            var container = WepApiConfig.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            config.Routes.MapHttpRoute(
                "DefaultApi",
                "api/{controller}/{id}",
                new {id = RouteParameter.Optional}
            );

            appBuilder.UseWebApi(config);
        }
    }
}
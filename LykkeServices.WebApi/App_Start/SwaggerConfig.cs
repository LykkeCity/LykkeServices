using System.Web.Http;
using LykkeServices.WebApi;
using Swashbuckle.Application;
using WebActivatorEx;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace LykkeServices.WebApi
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.EnableSwagger(c => { c.SingleApiVersion("v1", "LykkeServices"); })
                .EnableSwaggerUi(c => { });
        }
    }
}
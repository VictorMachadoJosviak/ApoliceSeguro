using Swashbuckle.Application;
using Swashbuckle.Swagger;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Description;

namespace Apolice.API
{
    public class SwaggerConfig
    {
        public static void Register(HttpConfiguration config)
        {
            System.Reflection.Assembly thisAssembly = typeof(SwaggerConfig).Assembly;

            config.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Apólice");
            })
            .EnableSwaggerUi(c =>
            {
            });
        }
    }
}
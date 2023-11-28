using GestaoSuperHeroi.API.App_Start;

using Swashbuckle.Application;

using System.Web;
using System.Web.Http;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace GestaoSuperHeroi.API.App_Start
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration.EnableSwagger(c =>
            {
                c.SingleApiVersion("v1", "Your API Name");
                c.IncludeXmlComments(GetXmlCommentsPath());
            })
            .EnableSwaggerUi();
        }

        private static string GetXmlCommentsPath()
        {
            return System.String.Format(@"{0}\bin\YourApiName.XML", System.AppDomain.CurrentDomain.BaseDirectory);
        }
    }
}
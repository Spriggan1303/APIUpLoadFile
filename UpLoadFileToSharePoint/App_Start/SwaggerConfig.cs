using System.Web.Http;
using WebActivatorEx;
using UpLoadFileToSharePoint;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace UpLoadFileToSharePoint
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
                .EnableSwagger(c => c.SingleApiVersion("v1", "UpLoadFile"))
                    .EnableSwaggerUi();
            //GlobalConfiguration.Configuration
            //    .EnableSwagger(c =>
            //        {

            //            c.SingleApiVersion("v1", "UpLoadFileToSharepoint");

            //        })
            //    .EnableSwaggerUi(c =>
            //        {

            //        });
        }
    }
}

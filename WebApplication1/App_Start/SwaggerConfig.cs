using System.Web.Http;
using WebActivatorEx;
using API;
using Swashbuckle.Application;
using System.Linq;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace API {
    public class SwaggerConfig {
        public static void Register() {
            var thisAssembly = typeof(SwaggerConfig).Assembly;
            GlobalConfiguration.Configuration
            .EnableSwagger(c => {
                c.SingleApiVersion("v1", "Somiod Middleware");
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());  
            })
            .EnableSwaggerUi();
        }
    }
}

using Demo.Models;
using Microsoft.OData.Edm;
using System.Web.Http;
using System.Web.OData.Batch;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
namespace Demo
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapODataServiceRoute("odata", null, GetEdmModel(), new DefaultODataBatchHandler(GlobalConfiguration.DefaultServer));
            config.EnsureInitialized();
        }
        private static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.Namespace = "Demos";
            builder.ContainerName = "DefaultContainer";

            builder.EntitySet<Person>("People");

            builder.EntitySet<Trip>("Trips");

            builder.Function("GetNewPerson")
                .Returns<Person>()
                .Parameter<string>("Key");

            var action = builder.EntityType<Person>()
                .Action("AddPerson");
            action.Parameter<string>("Description");
            action.Parameter<string>("Name");
            action.Parameter<string>("TripName");

            var edmModel = builder.GetEdmModel();
            return edmModel;
        }
    }
}
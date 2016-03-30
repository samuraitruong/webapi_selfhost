using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Mvc;

namespace WindowsService1
{
    public class Startup
    {
        //  Hack from http://stackoverflow.com/a/17227764/19020 to load controllers in 
        //  another assembly.  Another way to do this is to create a custom assembly resolver
        Type valuesControllerType = typeof(WindowsService1.API.TestController);

        // This code configures Web API. The Startup class is specified as a type
        // parameter in the WebApp.Start method.
        public void Configuration(IAppBuilder appBuilder)
        {
            // Configure Web API for self-host. 
            HttpConfiguration = new HttpConfiguration();

            //  Enable attribute based routing
            //  http://www.asp.net/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
            HttpConfiguration.MapHttpAttributeRoutes();

            HttpConfiguration.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //AreaRegistration.RegisterAllAreas();
            appBuilder.UseWebApi(HttpConfiguration);
        }

        public static HttpConfiguration HttpConfiguration { get; private set; }

        //public void Configuration(IAppBuilder app)
        //{
        //    HttpConfiguration = new HttpConfiguration();

        //    AreaRegistration.RegisterAllAreas();

        //    WebApiConfig.Register(HttpConfiguration);

        //    app.UseWebApi(HttpConfiguration);
        //}

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Reflection;
using System.Net.Http.Headers;
using CrudWebAPI.Repository;
using CrudWebAPI.Models;
//using Microsoft.Practices.Unity;
using Autofac;
using Autofac.Integration.WebApi;

namespace CrudWebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/v1/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Used for Dependency Injection
            var builder = new ContainerBuilder();

            builder.RegisterInstance<IRepository<Employee>>(new FileSystemRepository(new MainFileHelper()));
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html"));
            config.EnableSystemDiagnosticsTracing();
        }
    }
}

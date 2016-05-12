using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using Servicio;
using Insfrastructura;
using WebApi.Controllers;

namespace WebApi.App_Start
{
    public static class AutofacConfig
    {
        public static void RegisterAutoFacWebApi()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterWebApiFilterProvider(config);


            builder.RegisterType<ClientController>().As<ApiController>();
            builder.RegisterType<Operacion>().As<IOperacion>();
            builder.RegisterType<AppContext>().As<IRepository>();
           
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        } 
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Servicio;
using Insfrastructura;
using System.Web.Mvc;
using Autofac.Integration.Mvc;
using System.Reflection;
using CapaControladorVista.Controllers;

namespace CapaControladorVista
{
    public static class AutofacConfig
    {
        /*El delegado action tiene la misma firma que el método:
        Action<IDependencyResolver> setResolver
        void SetResolver(IDependencyResolver resolver);
        void Action<in T>(T obj);
         */
        public static void RegisterAutofac (Action<IDependencyResolver> setResolver)
	{
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterModelBinders(Assembly.GetExecutingAssembly());
            builder.RegisterModelBinders();
            builder.RegisterAssemblyModules(typeof(MvcApplication).Assembly);

            builder.RegisterType<MantenimentoClientesController>().As<Controller>().InstancePerHttpRequest();
            builder.RegisterType<Operacion>().As<IOperacion>().InstancePerHttpRequest();
            builder.RegisterType<AppContext>().As<IRepository>().InstancePerHttpRequest();

            var container = builder.Build();
            //DependencyResolver.SetResolver(new Autofac
            setResolver(new AutofacDependencyResolver(container));
            
            
	}
        
        
    }
}
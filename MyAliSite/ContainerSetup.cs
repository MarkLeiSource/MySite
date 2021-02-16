using Castle.Windsor;
using Castle.Windsor.Installer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace MyAliSite
{
    public class ContainerSetup
    {
        public static IWindsorContainer Setup()
        {
            var container = new WindsorContainer()
                .Install(
                    //Configuration.FromAppConfig(),
                    FromAssembly.This()
                );
            //var controllerFactory = new WindsorControllerFactory(container.Kernel, GlobalConfiguration.Configuration);
            //ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            var dependencyResolver = new WindsorDependencyResolver(container);
            //DependencyResolver.SetResolver(dependencyResolver);
            GlobalConfiguration.Configuration.DependencyResolver = dependencyResolver;
            AppDomain.CurrentDomain.SetData("Container", container);
            return container;
        }
    }
}